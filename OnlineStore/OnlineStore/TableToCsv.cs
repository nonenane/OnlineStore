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
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, true);
                foreach (DataRow row in rowCollect)
                {
                    Task<DataTable> task = Config.hCntMain.setInsertGoods((int)row["id"]);
                    task.Wait();
                }
            }
            
            rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("isInsert") == 1 && r.Field<bool>("isActive"));
            if (rowCollect.Count() > 0)
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, false);            
        }

        private void newTovar(DataTable dtData, string folderName, bool isNew)
        {
            long chunkSize = 40 * 1024 * 1024;
            StringBuilder csv = null;
            long readBytesCount = 0;
            int countFile = 0;
            string header = "Артикул,Имя,\"Короткое описание\",Описание,Запасы,\"Цена распродажи\",\"Базовая цена\",Категории," +
                "\"Мета: _advanced - qty - input - picker\"," +
                "\"Мета: _advanced-qty-quantity-suffix\"," +
                "\"Мета: _advanced-qty-price-suffix\"," +
                "\"Мета: _advanced-qty-value\"," +
                "\"Мета: _advanced-qty-max\"," +
                "\"Мета: _advanced-qty-step\"," +
                "\"Мета: _advanced-qty-min\" ";
            string dirSave = "";
            string fileName = isNew ? "newTovar" : "oldTovar";

            //if (!Directory.Exists("csv"))
            //    Directory.CreateDirectory("csv");

            foreach (DataRow row in dtData.Rows)
            {
                string line = $"{row["id_Tovar"]}," +
                    $"\"{row["ShortName"].ToString()}\"," +
                    $"\"{row["ShortName"].ToString().PadRight(50)}\"," +
                    $"\"{row["FullName"]}\"," +
                    $"{row["ostNow"].ToString().Replace(',', '.')}," +
                    $"{row["rcenaPromo_str"].ToString().Replace(',', '.')}," +
                    $"{row["rcenaOnline"].ToString().Replace(',', '.')}," +
                    $"\"{row["nameCategoryToCsv"]}\"," +
                    $"\"slider-input\"," +
                    (row["QuantitySuffix"].ToString().Length == 0 ? "" : $"\"{row["QuantitySuffix"]}\",") +
                    (row["PriceSuffix"].ToString().Length == 0 ? "" : $"\"{row["PriceSuffix"]}\",") +
                    $"{row["DefaultNetto_str"].ToString().Replace(',', '.')}," +
                    $"{row["MaxOrder_str"].ToString().Replace(',', '.')}," +
                    $"{row["Step_str"].ToString().Replace(',', '.')}," +
                    $"{row["MinOrder_str"].ToString().Replace(',', '.')}" +
                    $"";

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
