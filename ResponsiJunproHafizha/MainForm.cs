using Npgsql;
using System.Data;

namespace ResponsiJunproHafizha
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DbKaryawan db = new DbKaryawan();
            DataTable dtRes = db.Select();
            dgvKaryawan.DataSource = dtRes;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Karyawan kr = new Karyawan(
                tbNamaKaryawan.Text,
                cbDepartemen.Text
            );

            DbKaryawan db = new DbKaryawan();
            int status = db.Create(kr);

            if (status == 1)
            {
                MessageBox.Show("Data berhasil ditambah");
                tbNamaKaryawan.Text = cbDepartemen.Text = "";
                DataTable dtRes = db.Select();
                dgvKaryawan.DataSource = dtRes;
            } else
            {
                MessageBox.Show("Data gagal ditambah");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (rowSelected != null)
            {
                Karyawan kr = new Karyawan(
                    rowSelected.Cells["id_karyawan"].Value.ToString(),
                    tbNamaKaryawan.Text,
                    cbDepartemen.Text
                    );

                DbKaryawan db = new DbKaryawan();
                int status = db.Update(kr);

                if (status == 1)
                {
                    MessageBox.Show("Data berhasil diperbarui");
                    tbNamaKaryawan.Text = cbDepartemen.Text = "";
                    DataTable dtRes = db.Select();
                    dgvKaryawan.DataSource = dtRes;

                }
                else
                {
                    MessageBox.Show("Data gagal diperbarui");
                }
            } else
            {
                MessageBox.Show("Pilih baris data yang ingin diubah");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowSelected != null)
            {
                Karyawan kr = new Karyawan(
                    rowSelected.Cells["id_karyawan"].Value.ToString(),
                    rowSelected.Cells["nama"].Value.ToString(),
                    rowSelected.Cells["id_dep"].Value.ToString()
                    );

                DbKaryawan db = new DbKaryawan();
                int status = db.Delete(kr);

                if (status == 1)
                {
                    MessageBox.Show("Data berhasil dihapus");
                    DataTable dtRes = db.Select();
                    dgvKaryawan.DataSource = dtRes;
                    tbNamaKaryawan.Text = cbDepartemen.Text = "";
                }
                else
                {
                    MessageBox.Show("Data gagal dihapus");
                }
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin dihapus");
            }
        }

        public DataGridViewRow rowSelected;
        private void dgvKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowSelected = dgvKaryawan.Rows[e.RowIndex];
                tbNamaKaryawan.Text = rowSelected.Cells["nama"].Value.ToString();
                cbDepartemen.Text = rowSelected.Cells["id_dep"].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DbKaryawan db = new DbKaryawan();
            DataTable dtRes = db.Select();
            dgvKaryawan.DataSource = dtRes;
        }
    }
}