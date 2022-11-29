using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ResponsiJunproHafizha
{
    internal interface IDbKaryawan
    {
        public int Create(Karyawan kr);
        public DataTable Select();
        public int Update(Karyawan kr);
        public int Delete(Karyawan kr);
    }
}
