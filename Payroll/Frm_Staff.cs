using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Payroll
{
    public partial class Frm_Staff : Form
    {
        public Frm_Staff()
        {
            InitializeComponent();
        }
        private void Frm_Staff_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(Application.StartupPath + "/.../.../bin/Debug/Staff.txt");
            string[] data;
            for (int i = 0; i < lines.Length; i++)
            {
                data = lines[i].ToString().Split('|');
                string[] row = new string[data.Length];

                for (int j = 0; j < data.Length; j++)
                {
                    row[j] = data[j].Trim();
                }
                dataGridViewS.Rows.Add(row);
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txthoten.Text == "" || txtnoilam.Text == "") 
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // lưu xuống dataGridView
                //int a = 1;//dataGridViewS.Rows.Count-1;
                string[] row = { txthoten.Text, txtnoilam.Text };
                dataGridViewS.Rows.Add(row);
                //// lưu vào txt

                TextWriter write = new StreamWriter(Application.StartupPath + "/.../.../bin/Debug/Staff.txt");
                for (int i = 0; i < dataGridViewS.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridViewS.Columns.Count; j++)
                    {
                        if (j == dataGridViewS.Columns.Count - 1)
                            write.Write(dataGridViewS.Rows[i].Cells[j].Value.ToString());
                        else
                            write.Write(dataGridViewS.Rows[i].Cells[j].Value.ToString() + "|");
                    }
                    write.WriteLine("");
                }
                write.Close();
                //MessageBox.Show("Lưu thành công.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btlxoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewS.Rows.Count > 1)
            {
                if (this.dataGridViewS.SelectedRows.Count > 0)
                {
                    dataGridViewS.Rows.RemoveAt(this.dataGridViewS.SelectedRows[0].Index);
                }
                TextWriter write = new StreamWriter(Application.StartupPath + "/.../.../bin/Debug/Staff.txt");
                for (int i = 0; i < dataGridViewS.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridViewS.Columns.Count; j++)
                    {
                        if (j == dataGridViewS.Columns.Count - 1)
                            write.Write("\t" + dataGridViewS.Rows[i].Cells[j].Value.ToString());
                        else
                            write.Write("\t" + dataGridViewS.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }
                    write.WriteLine("");
                }
                write.Close();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang cập nhật.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
