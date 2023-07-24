using De02.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace De02
{
    public partial class frmSanPham : Form
    {
        private QLSanpham context = new QLSanpham();
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btKLuu_Click(object sender, EventArgs e)
        {

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
           context.SaveChanges();
        }

        

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                List<LoaiSP> listLoaiSP = context.LoaiSP.ToList();
                List<Sanpham> listSP = context.Sanpham.ToList();
                FillComboBox(listLoaiSP);
                BindGrid(listSP);
                btKLuu.Enabled = false;
                btLuu.Enabled = false;

            }catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);  
            } 
        }

        private void FillComboBox(List<LoaiSP> list)
        {
            cboLoaiSP.DataSource = list;
            cboLoaiSP.DisplayMember = "TenLoai";
            cboLoaiSP.ValueMember = "MaLoai";
        }
        private void BindGrid(List<Sanpham> list)
        {
            lvSanpham.Items.Clear();
            foreach (Sanpham sp in list)
            {
                ListViewItem item = lvSanpham.Items.Add(sp.MaSP);
                item.SubItems.Add(sp.TenSP);
                item.SubItems.Add(sp.Ngaynhap.ToString());
                item.SubItems.Add(sp.LoaiSP.TenLoai.ToString());

            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Sanpham sp = new Sanpham()
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                Ngaynhap = dtNgayNhap.Value,
                MaLoai = (cboLoaiSP.SelectedItem as LoaiSP).MaLoai,
            };
            context.Sanpham.Add(sp);
            context.SaveChanges();
            lvSanpham.Items.Clear();
            BindGrid(context.Sanpham.ToList());
            MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
           Sanpham sp = context.Sanpham.FirstOrDefault(p => p.MaLoai == txtMaSP.Text);
            if (sp != null)
            {
                sp.TenSP = txtTenSP.Text;
                sp.Ngaynhap = dtNgayNhap.Value;
                sp.MaLoai = (cboLoaiSP.SelectedItem as LoaiSP).MaLoai;
                context.SaveChanges();
                lvSanpham.Items.Clear();
                BindGrid(context.Sanpham.ToList());
                
                MessageBox.Show("Sửa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Sanpham sp = context.Sanpham.FirstOrDefault(p => p.MaSP == txtMaSP.Text);
            if (sp != null) 
            {
                context.Sanpham.Remove(sp);
                context.SaveChanges();
                lvSanpham.Items.Clear();
                BindGrid(context.Sanpham.ToList());
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void btTim_Click(object sender, EventArgs e)
        {

        }

        private void lvSanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanpham.SelectedItems.Count > 0)
            {
                txtMaSP.Text = lvSanpham.SelectedItems[0].SubItems[0].Text;
                txtTenSP.Text = lvSanpham.SelectedItems[0].SubItems[1].Text;
                dtNgayNhap.Value = DateTime.Parse(lvSanpham.SelectedItems[0].SubItems[2].Text);
                cboLoaiSP.Text = lvSanpham.SelectedItems[0].SubItems[3].Text;
            }
        }
    }
}
