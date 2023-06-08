using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelKayitSistemi
{
    public  class PersonelDal
    {
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-PBFD0LU; Initial Catalog=PersonelKayitDB; integrated security=true");
        public List<Personel> GetAll()
        {
           List<Personel> personels= new List<Personel>();
       
            sqlConnection.Open();
            SqlCommand komut = new SqlCommand("select Perid ,PerAd,perSoyad,PerSehir,PerMaas,PerMeslek,MedeniHali from personel", sqlConnection);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                Personel personel = new Personel
                {
                   ID = Convert.ToInt32(oku["Perid"]),
                    Name = oku["PerAd"].ToString(),
                    LastName = oku["PerSoyad"].ToString(),
                    City = oku["PerSehir"].ToString(),
                    Wage = Convert.ToInt32(oku["PerMaas"]),
                     Status = Convert.ToBoolean(oku["MedeniHali"]),
                    Job = oku["PerMeslek"].ToString(),
                };
                personels.Add(personel);
                
            }
            sqlConnection.Close();
            return personels;
        }

        public void AddPersonel(Personel personel)
        {
            sqlConnection.Open();
            SqlCommand komut = new SqlCommand("insert into Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,MedeniHali) values (@p1,@p2,@p3,@p4,@p5,@p6)", sqlConnection);
            komut.Parameters.AddWithValue("@p1", personel.Name);
            komut.Parameters.AddWithValue("@p2", personel.LastName);
            komut.Parameters.AddWithValue("@p3", personel.City);
            komut.Parameters.AddWithValue("@p4", personel.Wage);
            komut.Parameters.AddWithValue("@p5", personel.Job);
            komut.Parameters.AddWithValue("@p6", personel.Status);
            komut.ExecuteNonQuery();//sorguyu ççalıştır,değişklikleri kaydet ,ekle güncelle ve sil de kulllanılır
            sqlConnection.Close();
        }
        public void DeletePersonel(int id)
        {
            sqlConnection.Open();
            SqlCommand komut = new SqlCommand("delete from personel where Perid=@p1 ", sqlConnection);
            komut.Parameters.AddWithValue("@p1", id);
            komut.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdatePersonel(Personel personel)
        {
            sqlConnection.Open();
            SqlCommand komut = new SqlCommand("update personel set PerAd=@p1,PerSoyad=@p2,PerSehir=@p3,PerMaas=@p4,PerMeslek=@p5 where Perid=@id " , sqlConnection);
            komut.Parameters.AddWithValue("@p1",personel.Name);
            komut.Parameters.AddWithValue("@p2",personel.LastName);
            komut.Parameters.AddWithValue("@p3",personel.City);
            komut.Parameters.AddWithValue("@p4",personel.Wage);
            komut.Parameters.AddWithValue("@p5",personel.Job);
            komut.Parameters.AddWithValue("@id",personel.ID);
            komut.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}
