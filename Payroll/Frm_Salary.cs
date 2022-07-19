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
using app = Microsoft.Office.Interop.Excel.Application;
using System.IO;
using Microsoft.VisualBasic;

namespace Payroll
{
    public partial class Frm_Salary : Form
    {
        public Frm_Salary()
        {
            InitializeComponent();
        }
        private void Frm_Salary_Load(object sender, EventArgs e)
        {
            string[] ds_loadcmb = File.ReadAllLines(System.Windows.Forms.Application.StartupPath + "/.../.../Debug/Staff.txt");
            string[] rows;
            for (int k = 0; k < ds_loadcmb.Length; k++)
            {
                rows = ds_loadcmb[k].Split('|');
                ListViewItem item = new ListViewItem(rows);
                cmbhoten.Items.Add(rows[0] + " - " + rows[1]);
            }
            dateTimePicker.Value = DateTime.Today;
            label9.Text = DateTime.Now.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker.Value;
            if (cmbhoten.Text == "" || txtluong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập đầy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtgiovao.Text != "" && txtgiora.Text != "")
                {
                    int gv = int.Parse(txtgiovao.Text);
                    int gr = int.Parse(txtgiora.Text);
                    if (gv > gr)
                    {
                        MessageBox.Show("Giờ vào không thể lớn hơn giờ ra.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (gr > 2359)
                        {
                            MessageBox.Show("Giờ ra không thể lớn hơn 23h59.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtgiora.Text = "";
                            txtgiora.Focus();
                        }
                        else
                        {
                            string time_in = txtgiovao.Text;
                            string time_out = txtgiora.Text;
                            string salary = txtluong.Text;
                            int num_salary = Convert.ToInt16(salary);
                            string into_money = "";


                            string timeinh = time_in.Substring(0, 2);
                            string timeinm = time_in.Substring(time_in.Length - 2, 2);
                            string timeouth = time_out.Substring(0, 2);
                            string timeoutm = time_out.Substring(time_out.Length - 2, 2);

                            int num_timeinh, num_timeinm, num_timeouth, num_timeoutm;
                            num_timeinh = Convert.ToInt16(timeinh);
                            num_timeinm = Convert.ToInt16(timeinm);
                            num_timeouth = Convert.ToInt16(timeouth);
                            num_timeoutm = Convert.ToInt16(timeoutm);



                            float totaltimeh, totaltimem;
                            string totaltime = "";
                            if (num_timeouth > num_timeinh && num_timeoutm > num_timeinm)
                            {
                                totaltimeh = num_timeouth - num_timeinh;
                                totaltimem = num_timeoutm - num_timeinm;
                                if (num_timeoutm - num_timeinm > 9)
                                    totaltime = totaltimeh.ToString() + "h" + totaltimem.ToString();
                                else
                                    totaltime = totaltimeh.ToString() + "h0" + totaltimem.ToString();
                            }
                            else if (num_timeouth > num_timeinh && num_timeoutm < num_timeinm)
                            {
                                totaltimeh = num_timeouth - num_timeinh - 1;
                                totaltimem = 60 - num_timeinm + num_timeoutm;
                                totaltime = totaltimeh.ToString() + "h" + totaltimem.ToString();
                            }
                            else if (num_timeouth == num_timeinh && num_timeoutm > num_timeinm)
                            {
                                totaltimeh = num_timeouth - num_timeinh;
                                totaltimem = num_timeoutm - num_timeinm;
                                totaltime = totaltimeh.ToString() + "h" + totaltimem.ToString();
                            }
                            else
                            {
                                totaltimeh = num_timeouth - num_timeinh;
                                totaltimem = 0;
                                totaltime = totaltimeh.ToString() + "h00";
                            }

                            float num_intomoney = totaltimeh * num_salary + totaltimem / 60 * num_salary;
                            string num_intomoney_temp = String.Format("{0:0,0}", num_intomoney);
                            into_money = num_intomoney_temp.ToString();

                            float tongtien = float.Parse(txttongtien.Text);
                            tongtien = tongtien + num_intomoney;
                            string tongtien_temp = String.Format("{0:0,0}", tongtien);
                            txttongtien.Text = tongtien_temp;


                            string[] row = { dateTimePicker.Text, timeinh + "h" + timeinm, timeouth + "h" + timeoutm, totaltime, salary, into_money };
                            dataGridView.Rows.Add(row);
                            DateTime date2 = date.AddDays(+1);
                            dateTimePicker.Value = date2;
                            txtgiovao.Text = "";
                            txtgiovao.Focus();
                        }
                    }
                }
                else
                {
                    string salary = txtluong.Text;
                    string[] row = { dateTimePicker.Text, "", "", "", salary, "" };
                    dataGridView.Rows.Add(row);
                    DateTime date2 = date.AddDays(+1);
                    dateTimePicker.Value = date2;
                    txtgiovao.Text = "";
                    txtgiovao.Focus();
                }

            }
        }
        private void exportExcel(DataGridView g, string duongDan, string tenTap)
        {

            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 12;
            obj.Range["A1:F1"].Merge();
            obj.Cells[1, 1] = cmbhoten.Text;
            obj.Range["A1:A1"].Font.Bold = true;
            obj.Range["A1:A1"].Font.Size = 14;
            obj.Columns.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[2, i] = g.Columns[i - 1].HeaderText;
                obj.Cells[2, i].Font.Bold = true;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    { obj.Cells[i + 3, j + 1] = g.Rows[i].Cells[j].Value.ToString(); }
                }
            }
            obj.Cells[g.Rows.Count + 2, 5] = "Tổng tiền";
            obj.Cells[g.Rows.Count + 2, 5].Font.Bold = true;
            obj.Cells[g.Rows.Count + 2, 6] = txttongtien.Text;
            obj.Cells[g.Rows.Count + 2, 6].Font.Bold = true;
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btnxuatexcel_Click(object sender, EventArgs e)
        {
            //string filePath = "";
            //// tạo SaveFileDialog để lưu file excel
            //SaveFileDialog dialog = new SaveFileDialog();

            //// chỉ lọc ra các file có định dạng Excel
            //dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            //// Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    filePath = dialog.FileName;
            //}
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads\\");
            exportExcel(dataGridView, pathDownload, "Lương_" + cmbhoten.Text);
            MessageBox.Show("Lưu excel thành công.\nFile được lưu ở thư mục Downloads.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            //cmbhoten.Text = "";
            dataGridView.Rows.Clear();
            txttongtien.Text = "0";
        }

        protected void btntangngay_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode.ToString() == "Tab"))
            {
                MessageBox.Show("Tab");
            }
        }

        private void txtgiovao_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                if (txtgiovao.Text != "")
                {
                    int gv = int.Parse(txtgiovao.Text);
                    if (gv < 0100)
                    {
                        MessageBox.Show("Giờ vào không thể nhỏ hơn 1h.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtgiovao.Text = "";
                        txtgiovao.Focus();
                    }
                    else
                    {
                        txtgiora.Text = "";
                        txtgiora.Focus();
                    }
                }
                else
                {
                    txtgiora.Text = "";
                    txtgiora.Focus();
                }
            }
        }

        private void txtgiora_KeyDown(object sender, KeyEventArgs e)
        {
            DateTime date = dateTimePicker.Value;
            if ((e.KeyCode == Keys.Enter))
            {
                if (cmbhoten.Text == "" || txtluong.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn hoặc nhập đầy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtgiovao.Text != "" && txtgiora.Text != "")
                    {
                        int gv = int.Parse(txtgiovao.Text);
                        int gr = int.Parse(txtgiora.Text);
                        if (gv > gr)
                        {
                            MessageBox.Show("Giờ vào không thể lớn hơn giờ ra.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (gr > 2359)
                            {
                                MessageBox.Show("Giờ ra không thể lớn hơn 23h59.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtgiora.Text = "";
                                txtgiora.Focus();
                            }
                            else
                            {
                                string time_in = txtgiovao.Text;
                                string time_out = txtgiora.Text;
                                string salary = txtluong.Text;
                                int num_salary = Convert.ToInt16(salary);
                                string into_money = "";


                                string timeinh = time_in.Substring(0, 2);
                                string timeinm = time_in.Substring(time_in.Length - 2, 2);
                                string timeouth = time_out.Substring(0, 2);
                                string timeoutm = time_out.Substring(time_out.Length - 2, 2);

                                int num_timeinh, num_timeinm, num_timeouth, num_timeoutm;
                                num_timeinh = Convert.ToInt16(timeinh);
                                num_timeinm = Convert.ToInt16(timeinm);
                                num_timeouth = Convert.ToInt16(timeouth);
                                num_timeoutm = Convert.ToInt16(timeoutm);



                                float totaltimeh, totaltimem;
                                string totaltime = "";
                                if (num_timeouth > num_timeinh && num_timeoutm > num_timeinm)
                                {
                                    totaltimeh = num_timeouth - num_timeinh;
                                    totaltimem = num_timeoutm - num_timeinm;
                                    if (num_timeoutm - num_timeinm > 9)
                                        totaltime = totaltimeh.ToString() + "h" + totaltimem.ToString();
                                    else
                                        totaltime = totaltimeh.ToString() + "h0" + totaltimem.ToString();
                                }
                                else if (num_timeouth > num_timeinh && num_timeoutm < num_timeinm)
                                {
                                    totaltimeh = num_timeouth - num_timeinh - 1;
                                    totaltimem = 60 - num_timeinm + num_timeoutm;
                                    totaltime = totaltimeh.ToString() + "h" + totaltimem.ToString();
                                }
                                else if (num_timeouth == num_timeinh && num_timeoutm > num_timeinm)
                                {
                                    totaltimeh = num_timeouth - num_timeinh;
                                    totaltimem = num_timeoutm - num_timeinm;
                                    totaltime = totaltimeh.ToString() + "h" + totaltimem.ToString();
                                }
                                else
                                {
                                    totaltimeh = num_timeouth - num_timeinh;
                                    totaltimem = 0;
                                    totaltime = totaltimeh.ToString() + "h00";
                                }

                                float num_intomoney = totaltimeh * num_salary + totaltimem / 60 * num_salary;
                                string num_intomoney_temp = String.Format("{0:0,0}", num_intomoney);
                                into_money = num_intomoney_temp.ToString();

                                float tongtien = float.Parse(txttongtien.Text);
                                tongtien = tongtien + num_intomoney;
                                string tongtien_temp = String.Format("{0:0,0}", tongtien);
                                txttongtien.Text = tongtien_temp;

                                
                                string[] row = { dateTimePicker.Text, timeinh + "h" + timeinm, timeouth + "h" + timeoutm, totaltime, salary, into_money };
                                dataGridView.Rows.Add(row);
                                DateTime date2 = date.AddDays(+1);
                                dateTimePicker.Value = date2;
                                txtgiovao.Text = "";
                                txtgiovao.Focus();
                            }
                        }
                    }
                    else
                    {
                        string salary = txtluong.Text;
                        string[] row = { dateTimePicker.Text, "", "", "", salary, "" };
                        dataGridView.Rows.Add(row);
                        DateTime date2 = date.AddDays(+1);
                        dateTimePicker.Value = date2;
                        txtgiovao.Text = "";
                        txtgiovao.Focus();
                    }

                }
            }
        }

        private void txtngay_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                txtgiovao.Text = "";
                txtgiovao.Focus();
            }
        }

        /*
        private void txtngay_TextChanged(object sender, EventArgs e)
        {
            int num_ngay, num_thang;
            if (txtngay.Text != "" && txtthang.Text != "")
            {
                num_ngay = int.Parse(txtngay.Text);
                num_thang = int.Parse(txtthang.Text);
                if (1 > num_ngay || num_ngay > 31)
                {

                    MessageBox.Show("Vui lòng nhập ngày trong phạm vi từ 1 đến 31.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtngay.Text = "";
                }
                else
                {
                    if (num_ngay == 31 && (num_thang == 4 || num_thang == 6 || num_thang == 9 || num_thang == 11))
                    {
                        MessageBox.Show("Tháng " + txtthang.Text + " chỉ có 30 ngày.");
                    }
                    if ((num_ngay == 31 || num_ngay == 30) && num_thang == 2)
                    {
                        MessageBox.Show("Tháng " + txtthang.Text + " chỉ có 28 hoặc 29 ngày.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (txtngay.Text != "" && txtthang.Text == "")
            {

                num_ngay = int.Parse(txtngay.Text);
                if (1 > num_ngay || num_ngay > 31)
                {
                    MessageBox.Show("Vui lòng nhập ngày trong phạm vi từ 1 đến 31.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtngay.Text = "";
                }

            }

        }

        private void txtngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtthang_TextChanged(object sender, EventArgs e)
        {
            int num_ngay, num_thang;
            if (txtngay.Text != "")
            {
                if (txtthang.Text != "")
                {
                    num_ngay = int.Parse(txtngay.Text);
                    num_thang = int.Parse(txtthang.Text);
                    if (1 > num_thang || num_thang > 12)
                    {
                        MessageBox.Show("Vui lòng nhập tháng trong phạm vi từ 1 đến 12.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtthang.Text = "";
                    }
                    else
                    {
                        if (num_ngay >= 31 && (num_thang == 4 || num_thang == 6 || num_thang == 9 || num_thang == 11))
                        {
                            MessageBox.Show("Tháng " + txtthang.Text + " chỉ có 30 ngày.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if ((num_ngay >= 29) && num_thang == 2)
                        {
                            MessageBox.Show("Tháng " + txtthang.Text + " chỉ có 28 hoặc 29 ngày.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            else
            {
                if (txtthang.Text != "")
                {
                    num_thang = int.Parse(txtthang.Text);
                    if (1 > num_thang || num_thang > 12)
                    {
                        MessageBox.Show("Vui lòng nhập tháng trong phạm vi từ 1 đến 12.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtthang.Text = "";
                    }
                }
            }
        }

        private void txtthang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtnam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 1)
            {
                if (this.dataGridView.SelectedRows.Count > 0)
                {
                    int tongsodongdemtu1 = dataGridView.Rows.Count;
                    int tongsodongdemtu0 = this.dataGridView.SelectedRows[0].Index;
                    if (tongsodongdemtu1 - tongsodongdemtu0 > 1)
                        dataGridView.Rows.RemoveAt(this.dataGridView.SelectedRows[0].Index);
                    Double sum = 0;
                    for (int i = 0; i < dataGridView.Rows.Count; ++i)
                    {
                        if (dataGridView.Rows[i].Cells[5].Value != "")
                        {
                            sum += Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value);
                        }
                    }
                    string sum_temp = String.Format("{0:0,0}", sum);
                    txttongtien.Text = sum_temp;
                }
            }
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.ColumnHeader || hit.Type == DataGridViewHitTestType.None || hit.Type == DataGridViewHitTestType.TopLeftHeader || hit.Type == DataGridViewHitTestType.RowHeader)
                {
                    
                }
                else
                {
                    dataGridView.ClearSelection();
                    dataGridView[hit.ColumnIndex, hit.RowIndex].Selected = true;
                    int tongsodongdemtu1 = dataGridView.Rows.Count;
                    int tongsodongdemtu0 = this.dataGridView.SelectedRows[0].Index;
                    if (tongsodongdemtu1 - tongsodongdemtu0 > 1)
                    {
                        int currentMouseOverRow = dataGridView.HitTest(e.X, e.Y).RowIndex;
                        ContextMenu m = new ContextMenu();
                        System.Windows.Forms.MenuItem salarynhan = new System.Windows.Forms.MenuItem("Nhân lương");
                        System.Windows.Forms.MenuItem salarychia = new System.Windows.Forms.MenuItem("Chia lương");
                        salarynhan.MenuItems.Add(new System.Windows.Forms.MenuItem("Nhân 2", MenuItemnhan2_Click));
                        salarynhan.MenuItems.Add(new System.Windows.Forms.MenuItem("Nhân 3", MenuItemnhan3_Click));
                        salarynhan.MenuItems.Add(new System.Windows.Forms.MenuItem("Khác...", MenuItemnhankhac_Click));
                        salarychia.MenuItems.Add(new System.Windows.Forms.MenuItem("Chia 2", MenuItemchia2_Click));
                        salarychia.MenuItems.Add(new System.Windows.Forms.MenuItem("Chia 3", MenuItemchia3_Click));
                        //salarychia.MenuItems.Add(new System.Windows.Forms.MenuItem("Khác...", MenuItemchiakhac_Click));
                        m.MenuItems.Add(salarynhan);
                        m.MenuItems.Add(salarychia);
                        m.Show(dataGridView, new System.Drawing.Point(e.X, e.Y));
                    }
                }    
            }
        }

        private void MenuItemnhan2_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows[0].Cells[4].Value.ToString() != "" && dataGridView.SelectedRows[0].Cells[5].Value.ToString() != "")
            {
                if (this.dataGridView.SelectedRows.Count > 0)
                {
                    // nhân đôi lương
                    string salaryold = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    Double salarynew_temp = Convert.ToDouble(salaryold);
                    Double salarynew_temp2 = salarynew_temp * 2;
                    string salarynew = String.Format("{0:0,0}", salarynew_temp2);
                    dataGridView.SelectedRows[0].Cells[4].Value = salarynew.ToString();
                    // nhân đôi thành tiền
                    string into_moneyold = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    Double into_money_temp = Convert.ToDouble(into_moneyold);
                    Double into_money_temp2 = into_money_temp * 2;
                    string into_money = String.Format("{0:0,0}", into_money_temp2);
                    dataGridView.SelectedRows[0].Cells[5].Value = into_money.ToString();

                    // tính tổng tiền sau khi nhân lương
                    Double sum = 0;
                    for (int i = 0; i < dataGridView.Rows.Count; ++i)
                    {
                        if (dataGridView.Rows[i].Cells[5].Value != "")
                        {
                            sum += Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value);
                        }
                    }
                    string sum_temp = String.Format("{0:0,0}", sum);
                    txttongtien.Text = sum_temp;
                }
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để nhân lương.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuItemnhan3_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows[0].Cells[4].Value.ToString() != "" && dataGridView.SelectedRows[0].Cells[5].Value.ToString() != "")
            {
                if (this.dataGridView.SelectedRows.Count > 0)
                {
                    // nhân 3 lương
                    string salaryold = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    Double salarynew_temp = Convert.ToDouble(salaryold);
                    Double salarynew_temp2 = salarynew_temp * 3;
                    string salarynew = String.Format("{0:0,0}", salarynew_temp2);
                    dataGridView.SelectedRows[0].Cells[4].Value = salarynew.ToString();
                    // nhân 3 thành tiền
                    string into_moneyold = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    Double into_money_temp = Convert.ToDouble(into_moneyold);
                    Double into_money_temp2 = into_money_temp * 3;
                    string into_money = String.Format("{0:0,0}", into_money_temp2);
                    dataGridView.SelectedRows[0].Cells[5].Value = into_money.ToString();

                    // tính tổng tiền sau khi nhân lương
                    Double sum = 0;
                    for (int i = 0; i < dataGridView.Rows.Count; ++i)
                    {
                        if (dataGridView.Rows[i].Cells[5].Value != "")
                        {
                            sum += Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value);
                        }
                    }
                    string sum_temp = String.Format("{0:0,0}", sum);
                    txttongtien.Text = sum_temp;
                }
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để nhân lương.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuItemnhankhac_Click(object sender, EventArgs e)
        {
            //string content = Interaction.InputBox("Tùy chọn số lương cần nhân.", "Khác...", "0");
            //if (content != "")
            //{
            //    if (dataGridView.SelectedRows[0].Cells[4].Value.ToString() != "" && dataGridView.SelectedRows[0].Cells[5].Value.ToString() != "")
            //    {
            //        if (this.dataGridView.SelectedRows.Count > 0)
            //        {
            //            // nhân lương
            //            string salaryold = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            //            Double salarynew_temp = Convert.ToDouble(salaryold);
            //            Double salarynew_temp2 = salarynew_temp * int.Parse(content);
            //            string salarynew = String.Format("{0:0,0}", salarynew_temp2);
            //            dataGridView.SelectedRows[0].Cells[4].Value = salarynew.ToString();
            //            // nhân thành tiền
            //            string into_moneyold = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            //            Double into_money_temp = Convert.ToDouble(into_moneyold);
            //            Double into_money_temp2 = into_money_temp * int.Parse(content);
            //            string into_money = String.Format("{0:0,0}", into_money_temp2);
            //            dataGridView.SelectedRows[0].Cells[5].Value = into_money.ToString();

            //            // tính tổng tiền sau khi nhân lương
            //            Double sum = 0;
            //            for (int i = 0; i < dataGridView.Rows.Count; ++i)
            //            {
            //                if (dataGridView.Rows[i].Cells[5].Value != "")
            //                {
            //                    sum += Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value);
            //                }
            //            }
            //            string sum_temp = String.Format("{0:0,0}", sum);
            //            txttongtien.Text = sum_temp;
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Không đủ dữ liệu để nhân lương.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            string value = "1";
            if (LKInputBox("Khác...", "Tùy nhập số lương cần nhân.", ref value) == DialogResult.OK)
            {
                if (dataGridView.SelectedRows[0].Cells[4].Value.ToString() != "" && dataGridView.SelectedRows[0].Cells[5].Value.ToString() != "")
                {
                    if (this.dataGridView.SelectedRows.Count > 0)
                    {
                        // nhân lương
                        string salaryold = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                        Double salarynew_temp = Convert.ToDouble(salaryold);
                        Double salarynew_temp2 = salarynew_temp * int.Parse(value);
                        string salarynew = String.Format("{0:0,0}", salarynew_temp2);
                        dataGridView.SelectedRows[0].Cells[4].Value = salarynew.ToString();
                        // nhân thành tiền
                        string into_moneyold = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                        Double into_money_temp = Convert.ToDouble(into_moneyold);
                        Double into_money_temp2 = into_money_temp * int.Parse(value);
                        string into_money = String.Format("{0:0,0}", into_money_temp2);
                        dataGridView.SelectedRows[0].Cells[5].Value = into_money.ToString();

                        // tính tổng tiền sau khi nhân lương
                        Double sum = 0;
                        for (int i = 0; i < dataGridView.Rows.Count; ++i)
                        {
                            if (dataGridView.Rows[i].Cells[5].Value != "")
                            {
                                sum += Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value);
                            }
                        }
                        string sum_temp = String.Format("{0:0,0}", sum);
                        txttongtien.Text = sum_temp;
                    }

                }
                else
                {
                    MessageBox.Show("Không đủ dữ liệu để nhân lương.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void MenuItemchia2_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows[0].Cells[4].Value.ToString() != "" && dataGridView.SelectedRows[0].Cells[5].Value.ToString() != "")
            {
                if (this.dataGridView.SelectedRows.Count > 0)
                {
                    // nhân đôi lương
                    string salaryold = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    Double salarynew_temp = Convert.ToDouble(salaryold);
                    Double salarynew_temp2 = salarynew_temp / 2;
                    string salarynew = String.Format("{0:0,0}", salarynew_temp2);
                    dataGridView.SelectedRows[0].Cells[4].Value = salarynew.ToString();
                    // nhân đôi thành tiền
                    string into_moneyold = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    Double into_money_temp = Convert.ToDouble(into_moneyold);
                    Double into_money_temp2 = into_money_temp / 2;
                    string into_money = String.Format("{0:0,0}", into_money_temp2);
                    dataGridView.SelectedRows[0].Cells[5].Value = into_money.ToString();

                    // tính tổng tiền sau khi nhân lương
                    Double sum = 0;
                    for (int i = 0; i < dataGridView.Rows.Count; ++i)
                    {
                        if (dataGridView.Rows[i].Cells[5].Value != "")
                        {
                            sum += Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value);
                        }
                    }
                    string sum_temp = String.Format("{0:0,0}", sum);
                    txttongtien.Text = sum_temp;
                }

            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để chia lương.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MenuItemchia3_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows[0].Cells[4].Value.ToString() != "" && dataGridView.SelectedRows[0].Cells[5].Value.ToString() != "")
            {
                if (this.dataGridView.SelectedRows.Count > 0)
                {
                    // nhân 3 lương
                    string salaryold = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
                    Double salarynew_temp = Convert.ToDouble(salaryold);
                    Double salarynew_temp2 = salarynew_temp / 3;
                    string salarynew = String.Format("{0:0,0}", salarynew_temp2);
                    dataGridView.SelectedRows[0].Cells[4].Value = salarynew.ToString();
                    // nhân 3 thành tiền
                    string into_moneyold = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
                    Double into_money_temp = Convert.ToDouble(into_moneyold);
                    Double into_money_temp2 = into_money_temp / 3;
                    string into_money = String.Format("{0:0,0}", into_money_temp2);
                    dataGridView.SelectedRows[0].Cells[5].Value = into_money.ToString();

                    // tính tổng tiền sau khi nhân lương
                    Double sum = 0;
                    for (int i = 0; i < dataGridView.Rows.Count; ++i)
                    {
                        if (dataGridView.Rows[i].Cells[5].Value != "")
                        {
                            sum += Convert.ToDouble(dataGridView.Rows[i].Cells[5].Value);
                        }
                    }
                    string sum_temp = String.Format("{0:0,0}", sum);
                    txttongtien.Text = sum_temp;
                }
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu để chia lương.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void timer_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString();
        }
        public static DialogResult LKInputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            System.Windows.Forms.Button buttonOk = new System.Windows.Forms.Button();
            System.Windows.Forms.Button buttonCancel = new System.Windows.Forms.Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Hủy";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 18, 372, 13);
            textBox.SetBounds(12, 36, 140, 20);
            buttonOk.SetBounds(49, 72, 50, 23);
            buttonCancel.SetBounds(103, 72, 50, 23);

            //label.AutoSize = true;
            //textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            //buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(164, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}
