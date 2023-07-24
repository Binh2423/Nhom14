using De01.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De01
{
    public partial class frmQLSV : Form
    {
        QuanLySV context = new QuanLySV();
        public frmQLSV()
        {
            InitializeComponent();
        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnKLuu.Enabled = false;
            BindGrid(context.SinhViens.ToList());
            FillCombo(context.Lops.ToList());
            cboLop.SelectedIndex = 0;
        }
        private void BindGrid(List<SinhVien> list)
        {
            foreach(var sw in list)
            {
                ListViewItem item = lvSV.Items.Add(sw.MaSV);
                item.SubItems.Add(sw.HoTenSV);
                item.SubItems.Add(sw.NgaySinh.ToString());
                item.SubItems.Add(sw.Lop.TenLop);
            }
        }
        private void FillCombo(List<Lop> list)
        {
            cboLop.DataSource = list;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }

        private void lvSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvSV.SelectedItems.Count > 0)
            {
                txtHoTen.Text = lvSV.SelectedItems[0].SubItems[1].Text;
                txtMaSV.Text = lvSV.SelectedItems[0].SubItems[0].Text;
                cboLop.Text = lvSV.SelectedItems[0].SubItems[3].Text;
                dtNgaySinh.Value = DateTime.Parse(lvSV.SelectedItems[0].SubItems[2].Text);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = new SinhVien()
                {
                    MaSV = txtMaSV.Text,
                    HoTenSV = txtHoTen.Text,
                    NgaySinh = dtNgaySinh.Value,
                    MaLop = (cboLop.SelectedItem as Lop).MaLop,
                };
                context.SinhViens.Add(sv);
                context.SaveChanges();
                txtHoTen.Text = "";
                txtMaSV.Text = "";

                lvSV.Items.Clear();
                BindGrid(context.SinhViens.ToList());
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = context.SinhViens.FirstOrDefault(p => p.MaSV.Equals(txtMaSV.Text));
                if (sv != null)
                {
                    sv.HoTenSV = txtHoTen.Text;
                    sv.MaLop = (cboLop.SelectedItem as Lop).MaLop;
                    sv.NgaySinh = dtNgaySinh.Value;
                    context.SaveChanges();
                    txtHoTen.Text = "";
                    txtMaSV.Text = "";

                    lvSV.Items.Clear();
                    BindGrid(context.SinhViens.ToList());
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = context.SinhViens.FirstOrDefault(p => p.MaSV.Equals(txtMaSV.Text));
                if (sv != null)
                {
                    context.SinhViens.Remove(sv);
                    context.SaveChanges();
                    txtHoTen.Text = "";
                    txtMaSV.Text = "";

                    lvSV.Items.Clear();
                    BindGrid(context.SinhViens.ToList());
                    MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Không tìm thấy sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
