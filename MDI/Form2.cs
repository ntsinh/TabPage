using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABPAGE
{
    public partial class Form2 : Form
    {
        List<Cbnv> list;
        public Form2()
        {
            InitializeComponent();
            dgv2.AutoGenerateColumns = false;
            //dgv2.RowHeadersVisible = false;
        }
        public void HienThi()
        {
            ApiBLL apiBLL = new ApiBLL();
            var data = apiBLL.getDataForGUI();
            list = (List<Cbnv>)data;
            dgv2.DataSource = list;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
