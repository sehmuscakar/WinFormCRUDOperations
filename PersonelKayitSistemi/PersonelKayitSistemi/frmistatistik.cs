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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-PBFD0LU; Initial Catalog=PersonelKayitDB; integrated security=true");
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            sqlConnection.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from personel", sqlConnection);
            SqlDataReader oku=komut1.ExecuteReader();
            while(oku.Read())
            {
                lbltoplampersonel.Text = oku[0].ToString();//oku dan gelen 0 ıncı index ten gelen değer yani
            }
            sqlConnection.Close();
            ////evli personel sayısı
            //sqlConnection.Open();
            //SqlCommand komut2 = new SqlCommand("select count(*) from personel where PerDurum=1", sqlConnection);
            //SqlDataReader oku2 = komut2.ExecuteReader();
            //while (oku2.Read())
            //{
            //   lbltoplamevlipersonel.Text = oku2[0].ToString();
            //}
            //sqlConnection.Close();

            ////Bekar personel sayısı
            //sqlConnection.Open();
            //SqlCommand komut3 = new SqlCommand("select count(*) from personel where PerDurum=0", sqlConnection);
            //SqlDataReader oku3 = komut3.ExecuteReader();
            //while (oku3.Read())
            //{
            //    lbltoplambekarpersonel.Text = oku3[0].ToString();
            //}
            //sqlConnection.Close();

            //Toplam Şehir sayısı
            sqlConnection.Open();
            SqlCommand komut4 = new SqlCommand("select count(PerSehir) from personel", sqlConnection);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lbltoplamsehir.Text = oku4[0].ToString();
            }
            sqlConnection.Close();

            //Toplam Farklı Şehir sayısı
            sqlConnection.Open();
            SqlCommand komut5 = new SqlCommand("select count(distinct (PerSehir)) from personel ", sqlConnection);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                lbltoplamfarklisehir.Text = oku5[0].ToString();
            }
            sqlConnection.Close();


            //Toplam Verilen Maaş
            sqlConnection.Open();
            SqlCommand komut6 = new SqlCommand("select sum(PerMaas) from personel ", sqlConnection);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                lbltoplamverilenmaas.Text = oku6[0].ToString();
            }
            sqlConnection.Close();

            //Toplam Verilen Maaş
            sqlConnection.Open();
            SqlCommand komut7 = new SqlCommand("select avg(PerMaas) from personel ", sqlConnection);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                lblortalamamaas.Text = oku7[0].ToString();
            }
            sqlConnection.Close();






        }


    }
}
