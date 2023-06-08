using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelKayitSistemi
{
    public partial class frmadmin : Form
    {
        public frmadmin()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-PBFD0LU; Initial Catalog=PersonelKayitDB; integrated security=true");
        private void btngirisyap_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand komut = new SqlCommand("select * from Admin where KulaniciAdi=@p1 and Sifre=@p2", sqlConnection);
            komut.Parameters.AddWithValue("@p1",txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@p2",txtsifre.Text);
            
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Form1 fr=new Form1();
                fr.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Girdiğiniz Bilgilerinizi Kontrool Edin");
            }
            sqlConnection.Close();
        }
    }
}
