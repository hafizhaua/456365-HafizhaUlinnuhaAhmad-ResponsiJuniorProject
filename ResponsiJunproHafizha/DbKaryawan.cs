using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace ResponsiJunproHafizha
{
    internal class DbKaryawan : IDbKaryawan
    {
        private NpgsqlConnection conn;
        private string connstring = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=ResponsiHafizhaUA";
        private string sql = null;
        public NpgsqlCommand cmd;

        
        public DbKaryawan()
        {
            conn = new NpgsqlConnection(connstring);
        }
        public int Create(Karyawan kr)
        {
            try
            {
                conn.Open();
                sql = @"select * from karyawan_insert(:_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_nama", kr.Nama);
                cmd.Parameters.AddWithValue("_id_dep", kr.IdDep);

                int status = (int)cmd.ExecuteScalar();

                conn.Close();

                return status;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return 0;
            }
        }
        public DataTable Select()
        {
            try
            {
                conn.Open();
                //sql = @"select * from karyawan_select()";
                sql = @"SELECT * FROM karyawan INNER JOIN departemen ON departemen.id_dep = karyawan.id_dep;";
                cmd = new NpgsqlCommand(sql, conn);

                NpgsqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();

                dt.Load(rd);

                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public int Update(Karyawan kr)
        {
            try
            {
                conn.Open();
                sql = @"select * from karyawan_update(:_id_karyawan, :_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_id_karyawan", kr.IdKaryawan);
                cmd.Parameters.AddWithValue("_nama", kr.Nama);
                cmd.Parameters.AddWithValue("_id_dep", kr.IdDep);

                int status = (int)cmd.ExecuteScalar();

                conn.Close();

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return 0;
            }
        }

        public int Delete(Karyawan kr)
        {
            try
            {
                conn.Open();
                sql = @"select * from karyawan_delete(:_id_karyawan)";
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("_id_karyawan", kr.IdKaryawan);

                int status = (int)cmd.ExecuteScalar();

                conn.Close();

                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return 0;
            }
        }
    }
}
