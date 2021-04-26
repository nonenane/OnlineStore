using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Nwuram.Framework.Settings.Connection;
using Nwuram.Framework.Logging;


namespace OnlineShopOrders
{

  
    public partial class frmAddOrder : Form
    {

        readSQL proc = new readSQL(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

        

        List<int> numbersOrder = new List<int>();
        System.Data.DataTable dtTOrder;

        /// <summary>
        /// Конструктор формы добавления записей в базу из экселя
        /// </summary>
        public frmAddOrder()
        {
            InitializeComponent();
            lblMessage.Text = "Произвести загрузку заказов\r\n                  с сайта?";
            //Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EXCEL-файлы(*.xls)|*.xls; *.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                Microsoft.Office.Interop.Excel.Range rng;
                Microsoft.Office.Interop.Excel.Workbook wb;
                Microsoft.Office.Interop.Excel.Worksheet ws;

                Microsoft.Office.Interop.Excel.Application xls = new Microsoft.Office.Interop.Excel.Application();
                wb = xls.Workbooks.Open(fileName);
                ws = wb.Worksheets["Orders"];

                int rows = ws.UsedRange.Rows.Count;
                int columns = ws.UsedRange.Columns.Count;
                rng = (Microsoft.Office.Interop.Excel.Range)ws.UsedRange;
                
                var dataArr = (object[,])rng.Value;

                System.Data.DataTable dtOrders = new System.Data.DataTable();
                DataRow dr;
                for (int i = 1; i<=dataArr.GetUpperBound(1); i++)
                {
                    dtOrders.Columns.Add((string)dataArr[1, i]);
                }
                for (int i = 2; i<=dataArr.GetUpperBound(0); i++)
                {
                    dr = dtOrders.NewRow();
                    for (int n = 1; n <= dataArr.GetUpperBound(1); n++)
                    {
                        dr[n - 1] = dataArr[i, n];
                    }
                    dtOrders.Rows.Add(dr);
                }
                foreach (DataRow dRow in dtOrders.Rows)
                {
                    if (!numbersOrder.Contains(int.Parse(dRow["OrderNumber"].ToString())))
                    {
                        numbersOrder.Add(int.Parse(dRow["OrderNumber"].ToString()));
                    }
                }
               
          


                //добавление документов
                foreach (int numbers in numbersOrder)
                {
                    EnumerableRowCollection<DataRow> rowOrder = dtOrders.AsEnumerable().Where(x => int.Parse(x.Field<object>("OrderNumber").ToString()) == numbers);
                    // заголовок заказа
                    DataRow row = rowOrder.First();
                    dtTOrder = proc.Set_tOrder(int.Parse(row["OrderNumber"].ToString()),
                                    Convert.ToDateTime(row["OrderDate"].ToString()),
                                    row["LastName"].ToString(),
                                    row["FirstName"].ToString(),
                                    row["Email"].ToString(),
                                    row["Phone"].ToString(),
                                    row["Address"].ToString(),
                                    decimal.Parse(row["OrderShippingAmount"].ToString()),
                                    row["CustomerNote"].ToString() +"; "+ row["CustomerNote2"].ToString(),
                                    row["PaymentMethodTitle"].ToString(),
                                    row["DeliveryType"].ToString());
                    //тело заказа - если мы таки добавили заказ
                    if (dtTOrder.Rows[0][0].ToString()!="")
                    {
                      
                        int id_tOrder = int.Parse(dtTOrder.Rows[0][0].ToString());
                        #region LOG
                        Logging.StartFirstLevel(1529);
                        Logging.Comment("Добавление заказа id = " + id_tOrder.ToString());
                        Logging.Comment("Покупатель: " + row["LastName"].ToString() +" " + row["FirstName"].ToString() + 
                            ". Email: " +row["Email"].ToString() +
                            ". Телефон: " + row["Phone"].ToString() + 
                            ". Адрес: " +row["Address"].ToString() + 
                            ". Стоимость доставки: " + row["OrderShippingAmount"].ToString() + 
                            ". Описание доставки: " + row["CustomerNote"].ToString() +
                            ". Способ оплаты: " + row["PaymentMethodTitle"] );
                        Logging.Comment("Завершение добавления заказа");
                        Logging.StopFirstLevel();
                        #endregion
                        foreach (DataRow row1 in rowOrder)
                        {
                            string category = row1["Category"].ToString().Split(',')[0];
                            try
                            {
                                proc.Set_Order(id_tOrder,
                                                int.Parse(row1["SKU"].ToString()),
                                                category,
                                                int.Parse(row1["Item"].ToString()),
                                                decimal.Parse(row1["Quantity"].ToString()),
                                                decimal.Parse(row1["ItemCost"].ToString()));
                            }
                            catch
                            {
                                proc.delOrder(id_tOrder);
                                break;
                            }
                        }
                    }
                }

                MessageBox.Show("Файл загружен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xls.Quit();
                btnExit_Click(null, null);
            }
        }
    }
}
