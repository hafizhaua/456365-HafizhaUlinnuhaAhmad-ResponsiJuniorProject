using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiJunproHafizha
{
    internal class Karyawan
    {
        private string idKaryawan;
        private string nama;
        private string idDep;

        public Karyawan(string nama, string idDep)
        {
            this.Nama = nama;
            this.IdDep = idDep;
        }

        public Karyawan(string idKaryawan, string nama, string idDep)
        {
            this.IdKaryawan = idKaryawan;
            this.Nama = nama;
            this.IdDep = idDep;
        }

        public string IdKaryawan { get => idKaryawan; set => idKaryawan = value; }
        public string Nama { get => nama; set => nama = value; }
        public string IdDep { get => idDep; set => idDep = value; }
    }
}
