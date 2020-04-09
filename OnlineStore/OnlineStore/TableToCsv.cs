using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;


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
        public void insertData_notUserd(DataTable dtData)
        {
            //TextWriter writer = null;
            //CsvWriter csvWriter = null;
            //long readBytesCount = 0;
            //long chunkSize = 30 * 1024; //divide CSV file into each CSV file with byte size up to 30KB

            //string fileName = $"BlobHourMetrics_{Guid.NewGuid()}.csv";
            //writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName), true);
            //csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);


            //return;
            var records = new List<goods>();
            foreach (DataRow row in dtData.Rows)
            {
                goods g = new goods();
                g.CustomerName = "test";
                g.Title = "test";
                g.Deadline = DateTime.Now;
                records.Add(g);
            }


            foreach (var cur in records)
            {                                
                //var curRecordByteCount = curRecord.Sum(r => Encoding.UTF8.GetByteCount(r));// + headers.Count() + 1;
            }


            string fileName = $"csv\\BlobHourMetrics_{Guid.NewGuid()}.csv";
            //using (var mem = new MemoryStream())
            using (var writer = new StreamWriter(fileName))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Configuration.Delimiter = ",";
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap<goods>();                


                csvWriter.WriteHeader<goods>();
                csvWriter.NextRecord();
                csvWriter.WriteRecords(records);

                writer.Flush();
                writer.Close();
                //var result = Encoding.UTF8.GetString(mem.ToArray());
                //Console.WriteLine(result);
            }
        }

        public void insertData(DataTable dtData)
        {
            long chunkSize = 40 * 1024 * 1024;
            StringBuilder csv = null;
            long readBytesCount = 0;
            int countFile = 0;
            string header = "Артикул,Имя,\"Короткое описание\",Описание,Запасы,\"Цена распродажи\",\"Базовая цена\",Категории";
            string dirSave = "";

            if (!Directory.Exists("csv"))
                Directory.CreateDirectory("csv");

            foreach (DataRow row in dtData.Rows)
            {
                string line = $"{row["id_Tovar"]},\"{row["ShortName"]}\",\"{row["ShortName"]}\",\"{row["FullName"]}\",{row["ostNow"]},{row["rcenaPromo"]},{row["rcenaOnline"]},\"{row["nameCategoryToCsv"]}\"";
                
                readBytesCount += Encoding.UTF8.GetByteCount(line) + 1;

                if (csv == null || readBytesCount > chunkSize)
                {
                    if (csv != null)
                    {
                        File.WriteAllText(dirSave, csv.ToString());
                    }

                    countFile++;
                    dirSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + $@"csv\test_{countFile}.csv");
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
