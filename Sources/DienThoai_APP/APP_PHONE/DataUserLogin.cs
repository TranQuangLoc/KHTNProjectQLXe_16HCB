using APP_PHONE.Class;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_PHONE
{
    class DataUserLogin
    {
        public static NhanVien nhanvien { get; set; }
    }

    class FB_Helpers
    {
        private static FirebaseClient firebase = new FirebaseClient("https://khtnproject.firebaseio.com/");

        public static FirebaseClient GetFireBase()
        {
            return firebase;
        }
    }
}
