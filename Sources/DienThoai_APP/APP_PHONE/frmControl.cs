using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using APP_PHONE.Class;

namespace APP_PHONE
{
    public partial class frmControl : Form
    {
        public frmControl()
        {
            InitializeComponent();           
        }

        private void frmControl_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable("MyTable");

            tb.Columns.Add("ID", typeof(int));
            tb.Columns.Add("Name", typeof(string));

            tb.Rows.Add(1, "Thường");
            tb.Rows.Add(2, "Premium");

            cboLoaiXe.DataSource = tb;
            cboLoaiXe.DisplayMember = "Name";
            cboLoaiXe.ValueMember = "ID";

            DataTable tb_quan = new DataTable("Quan");

            tb_quan.Columns.Add("ID", typeof(int));
            tb_quan.Columns.Add("Name", typeof(string));

            tb_quan.Rows.Add(1, "Quận 1");
            tb_quan.Rows.Add(2, "Quận 2");
            tb_quan.Rows.Add(3, "Quận 3");
            tb_quan.Rows.Add(4, "Quận 4");
            tb_quan.Rows.Add(5, "Quận 5");
            tb_quan.Rows.Add(6, "Quận 6");
            tb_quan.Rows.Add(7, "Quận 7");
            tb_quan.Rows.Add(8, "Quận 8");
            tb_quan.Rows.Add(9, "Quận 9");
            tb_quan.Rows.Add(10, "Quận 10");
            tb_quan.Rows.Add(11, "Quận 11");
            tb_quan.Rows.Add(12, "Quận 12");
            tb_quan.Rows.Add(13, "Quận Tân Bình");
            tb_quan.Rows.Add(13, "Quận Bình Tân");
            tb_quan.Rows.Add(13, "Quận Tân Phú");
            tb_quan.Rows.Add(13, "Quận Phú Nhuận");
            tb_quan.Rows.Add(13, "Quận Bình Thạnh");
            tb_quan.Rows.Add(13, "Quận Gò Vấp");
            cboQuanHuyen.DataSource = tb_quan;
            cboQuanHuyen.DisplayMember = "Name";
            cboQuanHuyen.ValueMember = "ID";

            DataTable tb_thanh = new DataTable("Thanh");

            tb_thanh.Columns.Add("ID", typeof(int));
            tb_thanh.Columns.Add("Name", typeof(string));

            tb_thanh.Rows.Add(1, "TP HCM");

            cboTinhThanh.DataSource = tb_thanh;
            cboTinhThanh.DisplayMember = "Name";
            cboTinhThanh.ValueMember = "ID";

            lblHoTen.Text = DataUserLogin.nhanvien.tennv;
            lblLoaiNV.Text = DataUserLogin.nhanvien.loainv_ten;
            lblTaiKhoan.Text = DataUserLogin.nhanvien.username;
        }

        private async void btnGhiNhan_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text;
                string dchi = txtDiaChi.Text + ", " + cboQuanHuyen.Text + ", " + cboTinhThanh.Text;
                int id = int.Parse(cboLoaiXe.SelectedValue.ToString());
                string ten = cboLoaiXe.Text;

                var res = new
                {
                    SoDienThoai = sdt,
                    DiaChi = dchi,
                    LoaiXe = id,
                    LoaiXe_Ten = ten,
                    NgayTao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                    TrangThai = "waiting",                  
                    Lat = 0,
                    Lng = 0,
                    OriginGeo = JsonConvert.SerializeObject(new
                        {
                            lat = 0,
                            lng = 0,
                            diachi = dchi
                        }
                    )
                };

                var app = FB_Helpers.GetFireBase();
                var new_nv = await app.Child("Diem").PostAsync(JsonConvert.SerializeObject(res));

               
              
                if (new_nv != null && !string.IsNullOrEmpty(new_nv.Key))
                {
                    MessageBox.Show("Đã ghi nhận thông tin, Id " + new_nv.Key, "Thông báo");

                   // var app = FB_Helpers.GetFireBase();
                    var list = await app.Child("Diem").OnceAsync<Diem>();

                    var lst = list.Select(n => n.Object).ToList();

                    grvHist.DataSource = lst;
                }
                else
                {
                    MessageBox.Show("Không thể ghi nhận được thông tin, vui lòng kiểm tra lại", "Thông báo");
                }
        }

        private async void txtSDT_Leave(object sender, EventArgs e)
        {
            
            
        }
        
        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            grvHist.DataSource = null;
        }
    }
}
