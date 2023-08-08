using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Cbnv
    {
        public string maNhanVien { get; set; }
        public string tenNhanVien { get; set; }
        public string phongBan { get; set; }
        public string chucVu { get; set; }
        public string email { get; set; }
        public string soDt { get; set; }
        public string userMiddlewares { get; set; }
        public Cbnv()
        {
            
        }

        public Cbnv(string maNhanVien, string tenNhanVien, string phongBan, string chucVu, string email, string soDt, string userMiddlewares)
        {
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.phongBan = phongBan;
            this.chucVu = chucVu;
            this.email = email;
            this.soDt = soDt;
            this.userMiddlewares = userMiddlewares;
        }
    }
}
