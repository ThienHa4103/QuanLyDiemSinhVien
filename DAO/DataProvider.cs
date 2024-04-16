using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
    {
        public class DataProvider
        {
            public static SqlConnection MoKetNoi()
            {
                string con = @"Data Source=ALPHATS;Initial Catalog=QLNV;Integrated Security=True";
                SqlConnection KetNoi = new SqlConnection(con);
                KetNoi.Open();
                return KetNoi;
            }

            public static void DongKetNoi(SqlConnection connection)
            {
                connection.Close();
            }


            // Thực hiện truy vấn trả về bảng dữ liệu
            public static DataTable TruyVanLayDuLieu(string sTruyVan, SqlConnection connection)
            {
                SqlDataAdapter da = new SqlDataAdapter(sTruyVan, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

            // Thực hiện truy vấn không trả về dữ liệu
            public static bool TruyVanKhongLayDuLieu(string sTruyVan, SqlConnection connection)
            {
                try
                {
                    SqlCommand cm = new SqlCommand(sTruyVan, connection);
                    cm.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
    }

