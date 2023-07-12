using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi3
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            //dtP.CustomFormat("dd/MM/yyyy hh:mm:ss tt");
            cboLop.SelectedIndex = 0;
            ListViewItem item1 = lvSV.Items.Add("SV001");
            item1.SubItems.Add("Trần Văn Nam");
            item1.SubItems.Add("20/08/1985");
            item1.SubItems.Add(cboLop.Text);
            cboLop.SelectedIndex = 1;
            ListViewItem item2 = lvSV.Items.Add("SV002");
            item2.SubItems.Add("Nguyên Thị Tuyết");
            item2.SubItems.Add("25/08/1986");
            item2.SubItems.Add(cboLop.Text);

            ListViewItem item3 = lvSV.Items.Add("SV003");
            item3.SubItems.Add("Nguyễn Kim Tuyến");
            item3.SubItems.Add("21/03/1983");
            item3.SubItems.Add(cboLop.Text);

            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count > 0)
            {
                lvSV.Items.Remove(lvSV.SelectedItems[0]);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           lvSV.SelectedItems[0].SubItems[0].Text = txtMa.Text ;
           lvSV.SelectedItems[0].SubItems[1].Text = txtTen.Text;
           lvSV.SelectedItems[0].SubItems[2].Text = dtP.Text;
           lvSV.SelectedItems[0].SubItems[3].Text = cboLop.Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "" || txtTen.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
            }
            else
            {


                ListViewItem item = lvSV.Items.Add(txtMa.Text);
                item.SubItems.Add(txtTen.Text);
                item.SubItems.Add(dtP.Text);
                item.SubItems.Add(cboLop.Text);
            }
            txtMa.Text = "";
            txtTen.Text = "";

            
        }

      

        private void lvSV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvSV.SelectedItems.Count>0)
            {
                txtMa.Text = lvSV.SelectedItems[0].SubItems[0].Text;
                txtTen.Text = lvSV.SelectedItems[0].SubItems[1].Text;
                dtP.Text = lvSV.SelectedItems[0].SubItems[2].Text;
                cboLop.Text = lvSV.SelectedItems[0].SubItems[3].Text; 
            }
        }
    }
}
