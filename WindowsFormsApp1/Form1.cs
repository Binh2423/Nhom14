using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frm : Form
    {
        public frm()
        {
            InitializeComponent();
        }
        private QLNV context = new QLNV();
        private void frm_Load(object sender, EventArgs e)
        {

            try
            {
                List<NhanVien> listNV = context.NhanVien.ToList();
                List<PhongBan> listPb = context.PhongBan.ToList();
                FillComboBox(listPb);
                BindGrid(listNV);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        private void FillComboBox(List<PhongBan> list)
        {
            cmbPB.DataSource = list;
            cmbPB.DisplayMember = "TenPB";
            cmbPB.ValueMember = "MaPB";
        }
        private void BindGrid(List<NhanVien> list)
        {
            listView1.Items.Clear();
            foreach (NhanVien nv in list)
            {
                ListViewItem item = listView1.Items.Add(nv.MaNV);
                item.SubItems.Add(nv.TenNV);
                item.SubItems.Add(nv.NgaySinh.ToString());
                item.SubItems.Add(nv.PhongBan.TenPB);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ListViewItem item = listView1.Items.Add(txtMa.Text);
            item.SubItems.Add(txtTen.Text);
            item.SubItems.Add(dtpNS.Value.ToString());
            item.SubItems.Add(cmbPB.DisplayMember.ToString());
            NhanVien nhanVien = new NhanVien(txtMa.Text,txtTen.Text,dtpNS.Value,cmbPB.SelectedValue.ToString());
            context.NhanVien.Add(nhanVien);
            context.SaveChanges();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Bạn có muốn xóa?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult.Yes)
            {

                listView1.Items.Remove(listView1.SelectedItems[0]);
                NhanVien nv = context.NhanVien.FirstOrDefault(p => p.MaNV == txtMa.Text);
                if (nv != null)
                {
                    context.NhanVien.Remove(nv);
                }
                context.SaveChanges();  
            }
        }

        private void btnKLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVien nv = context.NhanVien.FirstOrDefault(p => p.MaNV == txtMa.Text);
            if (nv != null)
            {
                nv.TenNV = txtTen.Text;
                nv.NgaySinh = dtpNS.Value;
                nv.MaPB = cmbPB.SelectedValue.ToString();
            }
            listView1.SelectedItems[0].SubItems[0].Text = txtMa.Text;
            listView1.SelectedItems[0].SubItems[1].Text = txtTen.Text;
            listView1.SelectedItems[0].SubItems[2].Text = dtpNS.Text;
            listView1.SelectedItems[0].SubItems[3].Text = cmbPB.Text;
            context.SaveChanges();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
            {
                txtMa.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtTen.Text = listView1.SelectedItems[0].SubItems[1].Text;
                dtpNS.Text = DateTime.Parse( listView1.SelectedItems[0].SubItems[2].Text).ToString(); 
                cmbPB.Text = listView1.SelectedItems[0].SubItems[3].Text;
            }
        }
    }
}
