using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;


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
            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("isInsert")==0);
            if (rowCollect.Count() > 0)
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, true);         
            
            rowCollect = dtData.AsEnumerable().Where(r => r.Field<int>("isInsert") == 1);
            if (rowCollect.Count() > 0)
                newTovar(rowCollect.CopyToDataTable().Copy(), folderName, false);            
        }

        private void newTovar(DataTable dtData, string folderName, bool isNew)
        {
            long chunkSize = 40 * 1024 * 1024;
            StringBuilder csv = null;
            long readBytesCount = 0;
            int countFile = 0;
            string header = "Артикул,Имя,\"Короткое описание\",Описание,Запасы,\"Цена распродажи\",\"Базовая цена\",Категории";
            string dirSave = "";
            string fileName = isNew ? "newTovar" : "oldTovar";

            //if (!Directory.Exists("csv"))
            //    Directory.CreateDirectory("csv");

            foreach (DataRow row in dtData.Rows)
            {
                string line = $"{row["id_Tovar"]},\"{row["ShortName"].ToString()}\",\"{row["ShortName"].ToString().PadLeft(50)}\",\"{row["FullName"]}\",{row["ostNow"]},{row["rcenaPromo"].ToString().Replace(',', '.')},{row["rcenaOnline"].ToString().Replace(',', '.')},\"{row["nameCategoryToCsv"]}\"";

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
