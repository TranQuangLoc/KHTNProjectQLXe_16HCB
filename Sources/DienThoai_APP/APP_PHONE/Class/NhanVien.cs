using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_PHONE.Class
{
    class NhanVien
    {
        public string tennv { get; set; }
        public int loainv_id { get; set; }
        public string loainv_ten { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }

    class Diem
    {
        public string NgayTao { get; set; }
        public string TrangThai { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }
}