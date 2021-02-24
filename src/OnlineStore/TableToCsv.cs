using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore
{
    public class goods
    {
        public string CustomerName { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
    }

    class TableToCsv
    {
        public void insertData(DataTable dtData,string folderName)
        {

             
            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("isInsert")==0 && r.Field<bool>("isActive"));
            if (rowCollect.Count() > 0)
            {
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, true, false);
                foreach (DataRow row in rowCollect)
                {
                    Task<DataTable> task = Config.hCntMain.setInsertGoods((int)row["id"]);
                    task.Wait();
                }
            }
            
            rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("isInsert") == 1 && r.Field<bool>("isActive"));
            if (rowCollect.Count() > 0)
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, false, false);            
        }

        public void insertData(DataTable dtData, string folderName, bool allTovar)
        {


            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("isInsert") == 0);
            if (rowCollect.Count() > 0)
            {
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, true, true);
                foreach (DataRow row in rowCollect)
                {
                    Task<DataTable> task = Config.hCntMain.setInsertGoods((int)row["id"]);
                    task.Wait();
                }
            }

            rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("isInsert") == 1);
            if (rowCollect.Count() > 0)
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, false, true);
        }



        private void newTovar(DataTable dtData, string folderName, bool isNew, bool isAll)
        {
            
            long chunkSize = Config.sizeCSV * 1024 * 1024;
            StringBuilder csv = null;
            long readBytesCount = 0;
            int countFile = 0;
            string header;
            if (Config.ImageTovar)
            {
                header = "Артикул,Изображения";
            }
            else
            {
                header = $"Артикул,Имя,\"Короткое описание\",Описание,Запасы,\"Цена распродажи\",\"Базовая цена\",\"Вес\",Категории," +
                    (Config.ImageTovar ? "Изображения," : "") +
                    "\"Мета: _advanced - qty - input - picker\"," +
                    "\"Мета: _advanced-qty-quantity-suffix\"," +
                    "\"Мета: _advanced-qty-price-suffix\"," +
                    "\"Мета: _advanced-qty-value\"," +
                    "\"Мета: _advanced-qty-max\"," +
                    "\"Мета: _advanced-qty-step\"," +
                    "\"Мета: _advanced-qty-min\" ";
            }
            string dirSave = "";
            string fileName = isNew ? "newTovar" : "oldTovar";
            Console.WriteLine(header);
            //if (!Directory.Exists("csv"))
            //    Directory.CreateDirectory("csv");

            foreach (DataRow row in dtData.Rows)
            {
                string line;
                if (Config.ImageTovar)
                {
                   line = $"{row["id_Tovar"]}," +
                         "https://narodniy.spb.ru/wp-content/uploads/products/" + row["ean"].ToString() + ".png";
                }
                else
                {
                   line = $"{row["id_Tovar"]}," +
                       $"\"{row["ShortName"].ToString().Replace("\"", "").Replace(",", @"\,")}\"," +
                       $"\"{row["ShortDescription"].ToString().Replace("\"", "").Replace(",", @"\,").PadRight(50)}\"," +
                       $"\"{row["FullName"].ToString().Replace("\"", "").Replace(",", @"\,")}\"," +
                       (isAll && ((decimal) row["ostNow"] == 0 || !(bool) row["isActive"]) ? "0.000," : $"{row["ostNow"].ToString().Replace(',', '.')}," )+
                      //цена распродажи - если stockPrice not null (ну тип там в виде строки из запроса приходит "" если нулл)
                      (row["rcenaPromo_str"].ToString().Length == 0 ? $"{row["rcenaPromo_str"].ToString().Replace(',', '.')}," : $"{row["rcenaOnline"].ToString().Replace(',', '.')},") +
                       //базовая цена
                       (row["rcenaPromo_str"].ToString().Length == 0 ? $"{row["rcenaOnline"].ToString().Replace(',', '.')}," : $"{row["rcenaPromo_str"].ToString().Replace(',', '.')},") +
                       //вес товара 
                       $"{row["ves"].ToString().Replace(',', '.')}," +
                       $"\"{row["nameCategoryToCsv"].ToString().Replace("\"", "").Replace(",", @"\,")}\"," +
                       (Config.ImageTovar ? "https://narodniy.spb.ru/wp-content/uploads/products/" + row["ean"].ToString() + ".png," : "") +
                       $"\"slider-input\"," +
                       (row["QuantitySuffix"].ToString().Length == 0 ? "" : $"\"{row["QuantitySuffix"].ToString().Replace("\"", "").Replace(",", @"\,")}\",") +
                       (row["PriceSuffix"].ToString().Length == 0 ? "" : $"\"{row["PriceSuffix"].ToString().Replace("\"", "").Replace(",", @"\,")}\",") +
                       $"{row["DefaultNetto_str"].ToString().Replace(',', '.')}," +
                       $"{row["MaxOrder_str"].ToString().Replace(',', '.')}," +
                       $"{row["Step_str"].ToString().Replace(',', '.')}," +
                       $"{row["MinOrder_str"].ToString().Replace(',', '.')}" +
                       $"";
                }
                readBytesCount += Encoding.UTF8.GetByteCount(line) + 1;

                if (csv == null || readBytesCount > chunkSize)
                {
                    if (csv != null)
                    {
                        File.WriteAllText(dirSave, csv.ToString());
                    }

                    countFile++;
                    //dirSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + $@"csv\test_{countFile}.csv");
                    dirSave = Path.Combine(folderName + $@"\{fileName}_{countFile}.csv");
                    csv = new StringBuilder();
                    csv.AppendLine(header);
                    readBytesCount = Encoding.UTF8.GetByteCount(header) + 1;
                }
                csv.AppendLine(line);
            }
            if (csv.Length > 0)
            {
                File.WriteAllText(dirSave, csv.ToString());
            }
        }
    }
}
