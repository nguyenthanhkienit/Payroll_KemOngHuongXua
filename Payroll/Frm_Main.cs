using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btncapnhatnhanvien_Click(object sender, EventArgs e)
        {
            Frm_Staff frm_staff = new Frm_Staff();
            frm_staff.ShowDialog();
        }

        private void btntinhluongnhanvien_Click(object sender, EventArgs e)
        {
            Frm_Salary frm_salary = new Frm_Salary();
            frm_salary.ShowDialog();
        }
    }
}
