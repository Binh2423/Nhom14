using Buoi6_1.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi6_1
{
    public partial class frmSV : Form
    {
        public frmSV()
        {
            InitializeComponent();
        }
        private QLSV context = new QLSV();  
        string strcnn = "Server = DESKTOP-JSNGUYE\\JSPARK;Database=QLSV;user id=sa;password=12345;";
        BindingSource bs = null;
        private void frmSV_Load(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            if(cnn == null)
                cnn = new SqlConnection(strcnn);
            SqlDataAdapter adt = new SqlDataAdapter("Select * from Student",cnn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adt);
            DataSet ds = new DataSet();
            adt.Fill(ds, "Student");
            bs = new BindingSource(ds,"student");
            txtMa.DataBindings.Add("text", bs, "StudenID");
            txtTen.DataBindings.Add("text", bs, "Fullname");
            txtDTB.DataBindings.Add("text", bs, "AverageScore");
            txtKhoa.DataBindings.Add("text", bs, "FacultyID");

        }
        private void Insert()
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            if (cnn == null)
                cnn = new SqlConnection(strcnn);
            SqlCommand cm = new SqlCommand("INSERT into [dbo].[Student] ([StudenID], [Fullname], [AverageScore], [FacultyID]) " +
                "VALUES (txtMa.Text,txtTen.Text,float.Parse(txtDTB.Text), int.Parse(txtKhoa.Text))\r\n");
            cnn.Open();
            cm.ExecuteNonQuery();
            
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (bs.Position > 0)
                bs.Position--;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if(bs.Position < bs.Count-1)
                bs.Position++;
        }

        private void btnEndLeft_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
        }

        private void btnEndRight_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count-1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Student sv = new Student()
            //{
            //    StudenID = txtMa.Text,
            //    Fullname = txtTen.Text,
            //    AverageScore = float.Parse(txtDTB.Text),
            //    FacultyID = int.Parse(txtKhoa.Text),
            //};
            //context.Student.Add(sv);
            //context.SaveChanges();
            Insert();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(strcnn);
            if (cnn == null)
                cnn = new SqlConnection(strcnn);
            SqlCommand cm = new SqlCommand("delete from Student where StudenID = 'txtMa.Text'", cnn);
            cnn.Open();
            cm.ExecuteNonQuery();
        }
    }
}
