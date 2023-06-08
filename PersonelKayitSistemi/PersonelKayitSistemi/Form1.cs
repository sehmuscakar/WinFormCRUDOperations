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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-PBFD0LU; Initial Catalog=PersonelKayitDB; integrated security=true");
        PersonelDal _personelDal = new PersonelDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            Veriyukle();
        }

        void Veriyukle()
        {
            dataGridView1.DataSource = _personelDal.GetAll();
        }

        void Temizle()
        {
            txtpersonelad.Focus();//imlec burda olacak başta
            txtpersonelad.Text = "";
            txtpersonelsoyad.Text = "";
            txtperosnelmeslek.Clear();
            cmbpersonelsehir.Text = "";
            mskmaas.Text = "";
         
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            Veriyukle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel
            {
                // ID = Convert.ToInt32(txtpersonelid.Text),
                Name = txtpersonelad.Text,
                LastName = txtpersonelsoyad.Text,
                City = cmbpersonelsehir.Text,
                Wage = Convert.ToInt32(mskmaas.Text),
                Status = Convert.ToBoolean(checkBox1.Checked),
                Job =txtperosnelmeslek.Text,
            };
            _personelDal.AddPersonel(personel);
            MessageBox.Show("personel eklendi");
            Temizle();
        }

     

       
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)// iki defa tıklandğında 
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtpersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtpersonelad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtpersonelsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbpersonelsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
           mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
           txtperosnelmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();           
        }

       

        private void btnsil_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand komutsil = new SqlCommand("delete from personel where Perid=@p1 ", sqlConnection);
            komutsil.Parameters.AddWithValue("@p1", txtpersonelid.Text);//veriyi daldan çağrımadık direk form dan haletik
            komutsil.ExecuteNonQuery();
            sqlConnection.Close();

            // int deger=Convert.ToInt32(txtpersonelid.Text);
            //_personelDal.DeletePersonel(deger);
            MessageBox.Show("kayıt silindi");
            Temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel
            {
                ID = Convert.ToInt32(txtpersonelid.Text),
                Name = txtpersonelad.Text,
                LastName = txtpersonelsoyad.Text,
                City = cmbpersonelsehir.Text,
                Wage = Convert.ToInt32(mskmaas.Text),
                Job=txtperosnelmeslek.Text,
            };
            _personelDal.UpdatePersonel(personel);
            MessageBox.Show("Günceleme yapıldı");

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr=new frmistatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            frmgrafikler fr= new frmgrafikler();
            fr.Show();
        }
    }
}
