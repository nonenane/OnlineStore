using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineStoreViewOrders.statisticOrder
{
    public partial class frmListPeriod : Form
    {
        public DataTable dtData  { set;get;}

        public frmListPeriod()
        {
            InitializeComponent();

            dgvDataTovar.AutoGenerateColumns = false;
            dtData = new DataTable();
            dtData.Columns.Add("id", typeof(int));
            dtData.Columns.Add("isSelect",typeof(bool));
            dtData.Columns.Add("cName", typeof(string));
            dtData.Columns.Add("dateStart", typeof(DateTime));
            dtData.Columns.Add("dateEnd", typeof(DateTime));
            dtData.Columns.Add("r", typeof(int));
            dtData.Columns.Add("g", typeof(int));
            dtData.Columns.Add("b", typeof(int));

            for (int i = 1; i <= 10; i++)
            {
                DataRow newRow = dtData.NewRow();

                newRow["isSelect"] = false;
                newRow["cName"] = $"П - {i}";
                newRow["dateStart"] = Config.connect.getDate().AddDays(-1).Date;
                newRow["dateEnd"] = Config.connect.getDate().Date;
                newRow["r"] = 255;
                newRow["g"] = 255;
                newRow["b"] = 255;
                newRow["id"] = i;

                dtData.Rows.Add(newRow);
            }

            dgvDataTovar.DataSource = dtData;
        }

        private void btHide_Click(object sender, EventArgs e)
        {
            EnumerableRowCollection<DataRow> rowCollect = dtData.AsEnumerable().Where(r =>
            (int)r["r"] == 255 && (int)r["g"] == 255 && (int)r["b"] == 255 && r.Field<bool>("isSelect"));
            if (rowCollect.Count() > 0)
            {
                MessageBox.Show("Необходимо сменить легенду с белой","Информирование",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            Close();
            ((frmStatistic)this.Owner).updatePeriod();
            
        }

        private void frmListPeriod_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            WindowState = FormWindowState.Minimized;
            e.Cancel = true;
        }

        public class CalendarColumn : DataGridViewColumn
        {
            public CalendarColumn()
                : base(new CalendarCell())
            {
            }

            public override DataGridViewCell CellTemplate
            {
                get
                {
                    return base.CellTemplate;
                }
                set
                {
                    // Ensure that the cell used for the template is a CalendarCell.
                    if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                    {
                        throw new InvalidCastException("Must be a CalendarCell");
                    }
                    base.CellTemplate = value;
                }
            }
        }

        public class CalendarCell : DataGridViewTextBoxCell
        {

            public CalendarCell()
                : base()
            {
                // Use the short date format.
                this.Style.Format = "d";
            }

            public override void InitializeEditingControl(int rowIndex, object
                initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
            {
                // Set the value of the editing control to the current cell value.
                base.InitializeEditingControl(rowIndex, initialFormattedValue,
                    dataGridViewCellStyle);
                CalendarEditingControl ctl =
                    DataGridView.EditingControl as CalendarEditingControl;
                // Use the default row value when Value property is null.
                if (this.Value == null)
                {
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                }
                else
                {
                    ctl.Value = (DateTime)this.Value;
                }
            }

            public override Type EditType
            {
                get
                {
                    // Return the type of the editing control that CalendarCell uses.
                    return typeof(CalendarEditingControl);
                }
            }

            public override Type ValueType
            {
                get
                {
                    // Return the type of the value that CalendarCell contains.

                    return typeof(DateTime);
                }
            }

            public override object DefaultNewRowValue
            {
                get
                {
                    // Use the current date and time as the default value.
                    return DateTime.Now;
                }
            }
        }

        class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
        {
            DataGridView dataGridView;
            private bool valueChanged = false;
            int rowIndex;

            public CalendarEditingControl()
            {
                this.Format = DateTimePickerFormat.Short;
            }

            // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
            // property.
            public object EditingControlFormattedValue
            {
                get
                {
                    return this.Value.ToShortDateString();
                }
                set
                {
                    if (value is String)
                    {
                        try
                        {
                            // This will throw an exception of the string is 
                            // null, empty, or not in the format of a date.
                            this.Value = DateTime.Parse((String)value);
                        }
                        catch
                        {
                            // In the case of an exception, just use the 
                            // default value so we're not left with a null
                            // value.
                            this.Value = DateTime.Now;
                        }
                    }
                }
            }

            // Implements the 
            // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
            public object GetEditingControlFormattedValue(
                DataGridViewDataErrorContexts context)
            {
                return EditingControlFormattedValue;
            }

            // Implements the 
            // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
            public void ApplyCellStyleToEditingControl(
                DataGridViewCellStyle dataGridViewCellStyle)
            {
                this.Font = dataGridViewCellStyle.Font;
                this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
                this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
            }

            // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
            // property.
            public int EditingControlRowIndex
            {
                get
                {
                    return rowIndex;
                }
                set
                {
                    rowIndex = value;
                }
            }

            // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
            // method.
            public bool EditingControlWantsInputKey(
                Keys key, bool dataGridViewWantsInputKey)
            {
                // Let the DateTimePicker handle the keys listed.
                switch (key & Keys.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Down:
                    case Keys.Right:
                    case Keys.Home:
                    case Keys.End:
                    case Keys.PageDown:
                    case Keys.PageUp:
                        return true;
                    default:
                        return !dataGridViewWantsInputKey;
                }
            }

            // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
            // method.
            public void PrepareEditingControlForEdit(bool selectAll)
            {
                // No preparation needs to be done.
            }

            // Implements the IDataGridViewEditingControl
            // .RepositionEditingControlOnValueChange property.
            public bool RepositionEditingControlOnValueChange
            {
                get
                {
                    return false;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlDataGridView property.
            public DataGridView EditingControlDataGridView
            {
                get
                {
                    return dataGridView;
                }
                set
                {
                    dataGridView = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingControlValueChanged property.
            public bool EditingControlValueChanged
            {
                get
                {
                    return valueChanged;
                }
                set
                {
                    valueChanged = value;
                }
            }

            // Implements the IDataGridViewEditingControl
            // .EditingPanelCursor property.
            public Cursor EditingPanelCursor
            {
                get
                {
                    return base.Cursor;
                }
            }

            protected override void OnValueChanged(EventArgs eventargs)
            {
                // Notify the DataGridView that the contents of the cell
                // have changed.
                valueChanged = true;
                this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
                base.OnValueChanged(eventargs);
            }
        }

        private void dgvDataTovar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {
                Color rColor = Color.White;
                DataRowView row = dtData.DefaultView[e.RowIndex];

                dgvDataTovar.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvDataTovar.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;
                dgvDataTovar.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;

                if ((int)row["r"] != -1 && (int)row["g"] != -1 && (int)row["b"] != -1)
                    dgvDataTovar.Rows[e.RowIndex].Cells[cColor.Index].Style.BackColor =
                    dgvDataTovar.Rows[e.RowIndex].Cells[cColor.Index].Style.SelectionBackColor = Color.FromArgb((int)row["r"], (int)row["g"], (int)row["b"]);
            }
        }

        private void dgvDataTovar_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void dgvDataTovar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == cColor.Index)
            {
                colorDialog1.AllowFullOpen = true;

                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    DataRowView row = dtData.DefaultView[dgvDataTovar.CurrentRow.Index];

                    row["r"] = colorDialog1.Color.R;
                    row["g"] = colorDialog1.Color.G;
                    row["b"] = colorDialog1.Color.B;

                    dtData.AcceptChanges();
                }
            }
        }
    }
}
