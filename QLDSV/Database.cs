using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV {
    public class Database {
        public static string DatabaseName = "QLDSV_TC";
        public static string PublisherServerName = "DESKTOP-FJ9S2JN";

        public static string PublisherConnectionString =
            $"Data Source={PublisherServerName};Initial Catalog={DatabaseName};Integrated Security=True";

        public static SqlConnection Connection = new SqlConnection();
        public static string ConnectionString;

        public static SqlDataReader DataReader;
        public static string ServerName = "";
        public static string LoginName = "";
        public static string LoginPassword = "";

        public static string RemoteLoginName = "htkn";
        public static string RemoteLoginPassword = "123456";

        public static string CurrentLoginName = "";
        public static string CurrentLoginPassword = "";

        public static string Username = "";
        public static string UserRole = "";
        public static string UserFullName = "";
        public static int KhoaId = 0;

        // login vao server
        public static string SinhVienLoginName = "sinhvien";
        public static string SinhVienLoginPassword = "1";

        // mssv + pass tu input
        public static string MSSV = "";
        public static string SinhVienPassword = "";

        public static BindingSource BindingSourcePhanManh = new BindingSource(); // giữ bdsPM khi đăng nhập

        public static Result Connect(bool showExceptionMsg = false) {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
            try {
                ConnectionString =
                    $"Data Source={ServerName};Initial Catalog={DatabaseName};User ID={LoginName};password={LoginPassword}";

                Connection.ConnectionString = ConnectionString;
                Connection.Open();

                return Result.Success;
            }
            catch (Exception e) {
                if (showExceptionMsg) {
                    MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK);
                }

                return Result.Failure;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String rawStatement) {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(rawStatement, Connection);
            sqlcmd.CommandType = CommandType.Text;
            if (Connection.State == ConnectionState.Closed) Connection.Open();
            try {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex) {
                Connection.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ExecSqlDataTable(String rawStatement) {
            DataTable dt = new DataTable();
            if (Connection.State == ConnectionState.Closed) Connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(rawStatement, Connection);

            try {
                da.Fill(dt);
                Connection.Close();
                return dt;
            }
            catch (SqlException ex) {
                Connection.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static int ExecSqlNonQuery(String rawStatement) {
            SqlCommand Sqlcmd = new SqlCommand(rawStatement, Connection);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600; // 10 phut
            if (Connection.State == ConnectionState.Closed) Connection.Open();
            try {
                Sqlcmd.ExecuteNonQuery();
                Connection.Close();
                return 0;
            }
            catch (SqlException ex) {
                // if (ex.Message.Contains("Error converting data type varchar to int"))
                //     MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                // else MessageBox.Show(ex.Message);
                MessageBox.Show(ex.Message);
                Connection.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }
    }
}