using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using APP_PHONE.Class;
using Newtonsoft.Json;

namespace APP_PHONE
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Error !");
                    return;
                }
                else
                {
                    var app = FB_Helpers.GetFireBase();
                    var ls = await app.Child("NhanVien/NhanVienTongDai").OnceAsync<NhanVien>();

                    var user = ls.Where(n => n.Object.username.Equals(username) && n.Object.password.Equals(password)).FirstOrDefault();

                    if (user == null)
                    {
                        MessageBox.Show("Not Exists !");
                    }
                    else
                    {
                        DataUserLogin.nhanvien = user.Object;
                        frmControl frm = new frmControl();
                        frm.Show();
                        this.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            var app = FB_Helpers.GetFireBase();
            var observable = app.Child("NhanVien")
              .AsObservable<NhanVien>()
              .Subscribe(d => ChangeFunction(d));
        }

        private void ChangeFunction(Firebase.Database.Streaming.FirebaseEvent<NhanVien> fb)
        {
            string type = fb.EventType.ToString();
            string result = string.Concat(type, "-",fb.Key, "-", JsonConvert.SerializeObject(fb.Object));
            Console.WriteLine(result);
        }
    }
}
