﻿using System;
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

                MessageBox.Show("Lay data Login");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void ChangeFunction(Firebase.Database.Streaming.FirebaseEvent<NhanVien> fb)
        {
            string type = fb.EventType.ToString();
            string result = string.Concat(type, "-",fb.Key, "-", JsonConvert.SerializeObject(fb.Object));
            Console.WriteLine(result);
        }
    }
}
