using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace OnlineStoreServiceLogic
{
    public class Logic : IDisposable
    {        
        static int port = 8888; // порт для приема входящих запросов
        private Procedures hCntMain;
        private Procedures hCntMainKassRealiz;
        private DataTable dtSpravTerminal;
        private List<string> ListUserTovar = new List<string>();
        private List<string> LIST_SPECT_VALUES = new List<string>();
        private List<string> LIST_SPECT_REMAINS = new List<string>();
        private string IP, Folder;
        private readonly string Login = "kass";
        private readonly string Password = "kass";
        private NetworkDrive dr = new NetworkDrive();
        //private readonly string PathProject = @"C:\winServiceOnline";
        private readonly string PathProject = @"C:\winServiceOnline";// Directory.GetCurrentDirectory();

        object obj = new object();
        private Settings settings = new Settings();

        public Logic()
        {
            RecordEntry("Запуск", "");
            initSettings();
            try
            {
                hCntMain = new Procedures(settings.ServerK21, settings.DataBaseK21, settings.Login, settings.Password, "");
                hCntMainKassRealiz = new Procedures(settings.ServerKassRealiz, settings.DataBaseKassRealiz, settings.Login, settings.Password, "");
            }
            catch (Exception ex)
            {
                RecordEntry(ex.Message, "");
            }

            CreateSocket();
           
        }

        ~Logic()
        {
            Dispose();
        }
       
        public void Dispose()
        {
            RecordEntry("Уничтожение", "");
            //if (file != null)
            //{
            //    file.Close();
            //}
        }

        public async void GetOrderNow()
        {
            //try
            //{
            //    var host = Dns.GetHostEntry(Dns.GetHostName());
            //    foreach (var ip in host.AddressList)
            //    {
            //        if (ip.AddressFamily == AddressFamily.InterNetwork)
            //        {
            //            RecordEntry(ip.ToString(), "");
            //        }
            //    }
            //}
            //catch
            //{ 
            
            //}


            dtSpravTerminal = hCntMain.GetSpravTerminal();
            EnumerableRowCollection<DataRow> rowCollect = dtSpravTerminal.AsEnumerable().Where(r => r.Field<int>("id_TerminalType") == 7);

            Task<DataTable> task = hCntMain.GetOrderNow();
            task.Wait();
            if (task == null || task.Result.Rows.Count == 0)
            {
                RecordEntry("Нет данных", "");
                return;
            }
            DataTable GoodsDbase1 = task.Result;
            //DataTable GooodUpdates = hCntMainKassRealiz.getListGoodsKassRealiz();
            


            DataTable dtGoodsToFile = new DataTable();
            dtGoodsToFile.Columns.Add("ean", typeof(string));
            dtGoodsToFile.Columns.Add("r_time", typeof(DateTime));
            dtGoodsToFile.Columns.Add("name", typeof(string));
            dtGoodsToFile.Columns.Add("price", typeof(decimal));
            dtGoodsToFile.Columns.Add("grp", typeof(int));
            dtGoodsToFile.Columns.Add("tax", typeof(int));
            dtGoodsToFile.Columns.Add("id_tovar", typeof(string));
            dtGoodsToFile.Columns.Add("kodVVO", typeof(string));
            dtGoodsToFile.Columns.Add("firm", typeof(string));
            dtGoodsToFile.Columns.Add("id_post", typeof(int));
            dtGoodsToFile.Columns.Add("id_departments", typeof(int));
            dtGoodsToFile.Columns.Add("id_goodsUpdate", typeof(int));
            dtGoodsToFile.Columns.Add("BasicPrice", typeof(decimal));
            dtGoodsToFile.Columns.Add("OrderNumber", typeof(int));
            
            dtGoodsToFile.AcceptChanges();

            DataTable dtTmp = dtGoodsToFile.Clone();


            var query = from g in GoodsDbase1.AsEnumerable()
                            //join k in GooodUpdates.AsEnumerable() on new { Q = g.Field<int>("id"), Z = g.Field<int>("id_otdel") } equals new { Q = k.Field<int>("id_tovar"), Z = k.Field<int>("id_department") }
                        //join k in GooodUpdates.AsEnumerable() on new { Q = g.Field<string>("ean").Trim() } equals new { Q = k.Field<string>("ean").Trim() }// into tempJoin
                        //from kJoin in tempJoin.DefaultIfEmpty()
                        select dtTmp.LoadDataRow(new object[]
                                                       {

                                                               g.Field<string>("ean"),
                                                               DateTime.Now,// k.Field<DateTime>("r_time"),
                                                               g.Field<string>("name"),
                                                               g.Field<object>("price")==null? null : g.Field<decimal?>("price"),
                                                               g.Field<int>("grp"),
                                                               g.Field<int>("tax"),
                                                               g.Field<string>("id_tovar"),
                                                               g.Field<string>("kodVVO"),
                                                               g.Field<string>("firm"),
                                                               g.Field<int>("id_post"),
                                                               g.Field<int>("id_departments"),
                                                               0,//k.Field<int>("id"),
                                                               g.Field<decimal>("BasicPrice"),
                                                               g.Field<object>("OrderNumber") ==null?null :g.Field<int?>("OrderNumber")
                                                       }, false);

            dtGoodsToFile = query.CopyToDataTable();
            bool isVVO = false;
            EnumerableRowCollection<DataRow> rowToFile = dtGoodsToFile.AsEnumerable();
            //Создание файла            
            ListUserTovar.Clear();
            LIST_SPECT_VALUES.Clear();
            LIST_SPECT_REMAINS.Clear();
            createSpravWithVVO(rowToFile, isVVO);

            if (rowToFile.Count() == 0) return;

            foreach (DataRow row in rowCollect)
            {
                string sLog = $"Касса:{row["Number"]}; Кол-во товаров:{rowToFile.Count()}";
                RecordEntry(sLog, "");

                //Отправка на кассу
                IP = (string)row["IP"];
                Folder = (string)row["Path"];
                string _pathToSend = "\\\\" + (string)row["IP"] + (string)row["Path"];
                try
                {
                    bool exists = true;
                    try
                    {
                        bool completedIN = false;
                        Thread t = new Thread(new ThreadStart(delegate ()
                        {
                            Directory.Exists(_pathToSend);
                        }));
                        t.Start();
                        completedIN = t.Join(3000); //half a sec of timeout
                        if (!completedIN) { exists = false; t.Abort(); }
                        t = null;
                    }
                    catch { exists = false; }


                    //Console.WriteLine(@_pathToSend + "\AIn");

                    connect();

                    if (Directory.Exists(_pathToSend))
                    {
                        File.Copy(PathProject + @"\sprav\AInT", _pathToSend + "AIn", true);
                        File.Copy(PathProject + @"\sprav\sprav.txt", _pathToSend + "sprav.txt", true);
                    }
                    else
                    {
                        RecordEntry($"{_pathToSend}- Нет папки", "");
                    }
                    disconnect();
                }
                catch (Exception ex)
                {                
                    RecordEntry(ex.Message, "");
                }
            }

        }

        private IPEndPoint ipPoint;
        private Socket listenSocket;

        private async void CreateSocket()
        {
            Task task = new Task(() =>
            {
                //ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                ipPoint = new IPEndPoint(IPAddress.Any, port);
                listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket handler = null;
                Task NewTask = null;
                // связываем сокет с локальной точкой, по которой будем принимать данные
                listenSocket.Bind(ipPoint);

                // начинаем прослушивание
                listenSocket.Listen(10);

                RecordEntry("Сервер запущен. Ожидание подключений...", "");

                while (true)
                {
                    try
                    {
                        handler = listenSocket.Accept();
                        // получаем сообщение
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0; // количество полученных байтов
                        byte[] data = new byte[256]; // буфер для получаемых данных


                        do
                        {
                            bytes = handler.Receive(data);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (handler.Available > 0);

                        RecordEntry(handler.RemoteEndPoint + ": " + DateTime.Now.ToShortTimeString() + ": " + builder.ToString(), "");

                        string message = "";

                        if (builder.ToString().Equals("GetData"))
                        {
                            if (NewTask==null || NewTask.IsCompleted)
                            {
                                NewTask = new Task(() => GetOrderNow());
                                NewTask.Start();
                                message = "Запуск формирования файла";
                            }
                            else
                            {
                                message = "Файл ещё фомируется";
                            }
                        }

                        // отправляем ответ
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                                             
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        string message = ex.Message;
                        byte[] data = new byte[256];
                        data = Encoding.Unicode.GetBytes(message);
                        if (handler != null)
                            handler.Send(data);

                        RecordEntry(ex.Message, "");
                    }
                    finally
                    {
                        if (handler != null)
                        {
                            // закрываем сокет
                            handler.Shutdown(SocketShutdown.Both);
                            handler.Close();
                        }
                    }
                }

            });
            task.Start();
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(PathProject + @"\templog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush();
                }
            }
        }

        public void createSpravWithVVO(EnumerableRowCollection<DataRow> rowGoods, bool isVVO)
        {
            StreamWriter file = null;
            if (!Directory.Exists(PathProject+@"\sprav")) Directory.CreateDirectory(PathProject + @"\sprav");

            string filePath = PathProject + @"\sprav\AInT";
            if (File.Exists(filePath))
                File.Delete(PathProject + @"\sprav\AInT");


            if (rowGoods.Count() == 0) return;
            LIST_SPECT_VALUES.Add($"{("3".PadLeft(12, '0'))};1;1;Текущая цена;;");

            DataTable dtDeps = hCntMain.getListDeps();
            if (isVVO && dtDeps != null && dtDeps.Rows.Count > 0)
            {
                dtDeps.Rows.Clear();
                DataRow newRow = dtDeps.NewRow();
                newRow["id"] = 6;
                newRow["name"] = "ВВО";
                dtDeps.Rows.Add(newRow);
            }

            DataTable dtTovar = rowGoods.CopyToDataTable();

            DataTable dtGrp = hCntMain.getListGrp();
            try
            {
                file = new System.IO.StreamWriter(PathProject + @"\sprav\AInT");

                var grop = from row in dtTovar.AsEnumerable()
                           group row by row.Field<int>("grp") into grp
                           select new
                           {
                               grpID = grp.Key,
                           };

                file.WriteLine("##@@&&");
                file.WriteLine("#");
                file.WriteLine("$$$ADDQUANTITY");

                foreach (DataRow rDep in dtDeps.Rows)
                {
                    file.WriteLine(inserGRP(rDep["id"].ToString(), rDep["name"].ToString(), ""));
                }

                foreach (var r in grop)
                {
                    DataRow[] row = dtGrp.Select("id = " + r.grpID.ToString());
                    if (row.Count() > 0)
                    {
                        DataRow[] rDeps = dtDeps.Select("id = " + row[0]["id_otdel"].ToString());
                        file.WriteLine(inserGRP(row[0]["id"].ToString(), row[0]["cname"].ToString(), rDeps[0]["id"].ToString()));
                    }
                }

                dtTovar.DefaultView.Sort = "grp ASC, name ASC";

                foreach (DataRowView row in dtTovar.DefaultView)
                {
                    string toFileString = inserTovar(row);
                    if (toFileString.Length > 0)
                        file.WriteLine(toFileString);
                }

                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("$$$DELETEALLASPECTREMAINS");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("$$$DELETEALLASPECTVALUES");



                if (LIST_SPECT_VALUES.Count > 0)
                {
                    file.WriteLine("");
                    file.WriteLine("$$$ADDASPECTVALUES");
                    foreach (string str in LIST_SPECT_VALUES)
                    {
                        file.WriteLine($"{str}");
                    }
                }

                if (LIST_SPECT_REMAINS.Count > 0)
                {
                    file.WriteLine("");
                    file.WriteLine("$$$ADDASPECTREMAINS");
                    foreach (string str in LIST_SPECT_REMAINS)
                    {
                        file.WriteLine($"{str}");
                    }
                }
            }
            catch (Exception ex)
            {
                RecordEntry(ex.Message, "");
            }
            finally
            {
                if (file != null)
                    file.Close();
            }

        }

        private string inserGRP(string id, string name, string idParent)
        {
            string str = id + ";;" + name + ";" + name + ";;;;;;;;;;;;" + idParent + ";0;" + id;
            return str;
        }

        private string inserTovar(DataRowView row)
        {
            string id_tovar = row["id_tovar"].ToString();
            string ean = row["ean"].ToString().Trim();
            string name = row["name"].ToString().Replace(";", " ");
            //string price = row["price"].ToString();
            string price = row["BasicPrice"].ToString();
            string grp = row["grp"].ToString();
            string kodVVO = row["kodVVO"].ToString();
            string firm = row["firm"].ToString();
            string id_post = row["id_post"].ToString();
            string weight = row["ean"].ToString().Trim().Length == 4 ? "1" : "0";

            if (ListUserTovar.Contains(id_tovar)) return "";

            string tax = string.Empty;
            switch (row["tax"].ToString())
            {
                case "18": tax = "1"; break;
                case "20": tax = "1"; break;
                case "10": tax = "2"; break;
                default:
                    {
                        if (!File.Exists(DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt"))
                            using (FileStream fs = File.Create(DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt"))
                            {
                                fs.Close();
                            }

                        using (StreamWriter sw = new StreamWriter(DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".txt", true))
                        {
                            sw.WriteLine("------------------error");
                            sw.WriteLine("id_tovar = " + id_tovar + ";ean = " + ean + ";name = " + name + ";price = " + price + ";tax = " + row["tax"].ToString());
                            sw.WriteLine("------------------");
                            sw.Close();

                        }
                        tax = "3"; break;
                    }
            }
            string _vvo = "0"; //55
            string _vvo56 = "1";                 
            string value_11 = "0";
            string value_12 = "0";

            EnumerableRowCollection<DataRow> rowCollect = row.DataView.Table.AsEnumerable()
                .Where(r=>r.Field<object>("OrderNumber")!=null)
                .Where(r => r.Field<string>("id_tovar").Equals(id_tovar) && r.Field<decimal>("BasicPrice") != r.Field<decimal>("price"));
            if (rowCollect.Count() > 0)
            {
                value_11 = "3".PadLeft(12, '0');
                value_12 = "1";


                var groupTovarPrice = row.DataView.Table.AsEnumerable()
                        .Where(r => r.Field<string>("id_tovar").Equals(id_tovar))
                        .GroupBy(r => new { BasicPrice = r.Field<decimal>("BasicPrice"), price = r.Field<decimal>("price") })
                        .Select(s => new
                        {
                            id_tovar,
                            s.Key.BasicPrice,
                            s.Key.price
                        });


                LIST_SPECT_REMAINS.Add($"{id_tovar};;1;{ row["BasicPrice"]};;;");

                foreach (var gr in groupTovarPrice)
                {
                    rowCollect = row.DataView.Table.AsEnumerable()
                            .Where(r => r.Field<string>("id_tovar").Equals(id_tovar) && r.Field<decimal>("BasicPrice") == gr.BasicPrice && r.Field<decimal>("price") == gr.price);

                    string lNumOrderNumber = "";
                    foreach (DataRow r in rowCollect)
                    {
                        string tmpStr = r["OrderNumber"].ToString();
                        tmpStr = tmpStr.Substring(tmpStr.Length - 3);
                        lNumOrderNumber += (lNumOrderNumber.Length == 0 ? "" : " ") + tmpStr;

                        if (lNumOrderNumber.Length >= 100)
                        {
                            lNumOrderNumber = lNumOrderNumber.Substring(0, lNumOrderNumber.LastIndexOf(" "));
                            break;
                        }
                    }

                    string _tmp = $"{value_11};1;{LIST_SPECT_VALUES.Count + 1};{lNumOrderNumber};;";
                    LIST_SPECT_VALUES.Add(_tmp);

                    LIST_SPECT_REMAINS.Add($"{id_tovar};;{LIST_SPECT_VALUES.Count};{gr.price};;;");
                }
            }

            // должно быть 57 полей
            string str = id_tovar + ";" + ean + ";" + name + ";" + name + ";" + price + ";1000;0;" + weight +
            ";0;0;" + value_11 + ";" + value_12 + ";1;1;0;" + grp + ";1;0;;" + firm + ";;" +
            ";" + tax + ";;;" + id_post + ";;;;;;;;;;;;;;;;;;;;;;;;;;;" + kodVVO.Trim() + ";;" + _vvo + ";" + _vvo56 + ";40.0";
            ListUserTovar.Add(id_tovar);
            return str;
        }

        private void initSettings()
        {
            try
            {
                settings = new Settings();
                string jsonString = File.ReadAllText(PathProject + @"\settings.json");
                settings = JsonConvert.DeserializeObject<Settings>(jsonString);
                RecordEntry("Настройки получены", "");
            }
            catch (Exception ex)
            {
                RecordEntry(ex.Message, "");
            }
        }

        private int connect()
        {
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(IP);
            if (reply.Status != IPStatus.Success)
            {
                Console.WriteLine(-100);
                RecordEntry("Нет пинга", "");
                return -100;
            }

          

            int result;
            result = dr.MapNetworkDrive(@"\\" + IP + @Folder, Login, Password);
            //Console.WriteLine(result);
            //try
            //{
            //    foreach (string str in Directory.GetFiles(@"\\" + IP + @Folder))
            //    {
            //        RecordEntry($"Папка:{str}", "");
            //    }
            //}
            //catch(Exception ex )
            //{
            //    RecordEntry(ex.Message, "");
            //}

            //RecordEntry($"Результат доступка к папке{@"\\" + IP + @Folder}:{result}", "");

            //String host = System.Net.Dns.GetHostName();
            // Получение ip-адреса.
            //System.Net.IPAddress ip = System.Net.Dns.GetHostEntry(host).AddressList[0];
            // Показ адреса в label'е.
            //Console.WriteLine(ip.ToString());

            if (Directory.Exists(@"\\" + IP + @Folder))
            {
                //RecordEntry($"Результат доступка к папке{@"\\" + IP + @Folder}:ДА", "");
                return 0;
            }
            //RecordEntry($"Результат доступка к папке{@"\\" + IP + @Folder}:Нет", "");
            return -1;
            /*
            int result;
            result = dr.MapNetworkDrive(@"\\" + Config.IP + @"\" + Config.Folder, @Config.Login, Config.Password);            
            Console.WriteLine(result);

            return result;
             */
        }

        private void disconnect()
        {
            int result;
            result = dr.DeleteNetworkDrive();
        }
    }

    public class Settings
    {
        public string IdProg { set; get; }
        public string Login { set; get; }

        public string Password { set; get; }

        public string ServerK21 { set; get; }

        public string DataBaseK21 { set; get; }

        public string ServerKassRealiz { set; get; }

        public string DataBaseKassRealiz { set; get; }
    }
}
