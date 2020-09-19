using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class QL_TextBox
    {
        public QL_TextBox()
        {

        }
        public bool ktraSDT(string sdt)
        {

            int l = sdt.Length;
            int i = 0, chuCai = 0, chuSo = 0, kyTuDacBiet = 0, khoanTrang = 0;
            string kytudautien = sdt.Substring(0, 1);
            while (i < l)
            {
                if ((sdt[i] >= 'a' && sdt[i] <= 'z') || (sdt[i] >= 'A' && sdt[i] <= 'Z'))
                {
                    chuCai++;
                }
                else if (sdt[i] >= '0' && sdt[i] <= '9')
                {
                    chuSo++;
                }
                else if (sdt[i].Equals(" "))
                {
                    khoanTrang++;
                }
                else
                {
                    kyTuDacBiet++;
                }
                i++;
            }
            if (string.Compare(kytudautien, "0", true) == 0 && chuSo == 10 && chuCai == 0 && kyTuDacBiet == 0 && khoanTrang >= 0)
                return true;
            return false;

        }
        public bool ktraCMND(string cmnd)
        {
            int l = cmnd.Length;
            int i = 0, chuCai = 0, chuSo = 0, kyTuDacBiet = 0, khoanTrang = 0;

            while (i < l)
            {
                if ((cmnd[i] >= 'a' && cmnd[i] <= 'z') || (cmnd[i] >= 'A' && cmnd[i] <= 'Z'))
                {
                    chuCai++;
                }
                else if (cmnd[i] >= '0' && cmnd[i] <= '9')
                {
                    chuSo++;
                }
                else if (cmnd[i].Equals(" "))
                {
                    khoanTrang++;
                }
                else
                {
                    kyTuDacBiet++;
                }
                i++;
            }
            if (cmnd.Length == 9 || cmnd.Length == 11)
            {
                if (chuCai == 0 && kyTuDacBiet == 0 && khoanTrang == 0)
                    return true;
            }
            return false;
        }
        public bool ktraNgaySinh(string ngaysinh)
        {
            string[] arr = ngaysinh.Split('/');
            int namsinh = int.Parse(arr[2]);
            int thang = int.Parse(arr[1]);
            int ngay = int.Parse(arr[0]);
            int namht = DateTime.Now.Year;
            int tuoi = namht - namsinh;
            if (ngay <= 0 || thang <= 0 || namsinh <= 0)
                return false;
            else if (tuoi < 18 || tuoi > 65)
                return false;
            else
                return true;
        }
        public bool ktraHoTen(string hoten)
        {
            string str = "^[a-zA-Z0-9]*$";
            if (Regex.IsMatch(hoten, str) && hoten.Length > 1 && hoten.Length < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ktraNhapChu(string hoten)
        {
            int l = hoten.Length;
            for(int i = 0; i < l; i++)
            {
                if ((hoten[i] >= 'a' && hoten[i] <= 'z') || hoten[i] >= 'A' && hoten[i] <= 'Z')
                {
                    return true;
                }
            }
            return false;
        }
        public bool ktraDangNhap(string chuoi)
        {
            string str = "^[a-zA-Z0-9]*$";
            if (Regex.IsMatch(chuoi, str) && chuoi.Length != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
