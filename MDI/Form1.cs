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
    public partial class Form1 : Form
    {
        Point _imageLocation = new Point(20, 4);
        Point _imgHitArea = new Point(20, 4);
        Image closeImage;
        public Form1()
        {
            InitializeComponent();
        }

        //private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    bool isOpen = false;
        //    foreach (Form f in Application.OpenForms)
        //    {
        //        if (f.Text == "Form2")
        //        {
        //            isOpen = true;
        //            f.Focus();
        //            break;
        //        }
        //    }
        //    if (isOpen == false)
        //    {
        //        Form2 f2 = new Form2();
        //        f2.MdiParent = this;
        //        //f2.Text = "New Window";
        //        f2.Show();
        //    }
        //}
        //private Form curentChildForm;
        public void openChildForm( Form childForm, string formName)
        {
            //if (curentChildForm!=null)
            //{
            //    curentChildForm.Close();
            //}
            //curentChildForm = childForm;
            foreach (TabPage tp in tclBody.TabPages)
            {
                if (tp.Controls.Count > 0 && tp.Controls[0].GetType().Equals(childForm.GetType()))
                {
                    tclBody.SelectedTab = tp;
                    return;
                }
            }
            childForm.TopLevel = false;
            TabPage tabPage = new TabPage();
            tabPage.Text = formName;
            tabPage.Controls.Add(childForm);
            //childForm.MdiParent = this;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            //tp1.Controls.Add(childForm);
            //tp1.Tag = childForm;
            childForm.BringToFront();
            tclBody.Controls.Add(tabPage);
            tclBody.SelectedTab = tabPage;
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2(), button1.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3(), button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4(), button3.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            closeImage = Properties.Resources.close;
            tclBody.Padding = new Point(20, 4);
        }

        private void tclBody_DrawItem(object sender, DrawItemEventArgs e)
        {
            Image img = new Bitmap(closeImage);
            Rectangle r = e.Bounds;
            r = this.tclBody.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tclBody.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (this.tclBody.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
        }

        private void tclBody_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tclBody.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tclBody.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tclBody.SelectedIndex >= 0)
            {
                if (r.Contains(p))
                {
                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    tabControl.TabPages.Remove(tabPage);
                }
            }
        }

    }
}
