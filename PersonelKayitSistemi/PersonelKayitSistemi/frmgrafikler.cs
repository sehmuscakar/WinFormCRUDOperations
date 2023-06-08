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
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-PBFD0LU; Initial Catalog=PersonelKayitDB; integrated security=true");
        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand komut1 = new SqlCommand("select PerSehir,count(*) from Personel group by PerSehir", sqlConnection);
            SqlDataReader oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                chart1.Series["Şehirler"].Points.AddXY(oku[0], oku[1]);// 0 ınci index grafiğin altındaki yazılar şehirlerden gelecek ,1 inci index gruplama yapararak şehirdeki kişileri verecek 
            }
            sqlConnection.Close();


            sqlConnection.Open();
            SqlCommand komut2 = new SqlCommand("select PerMeslek,avg(PerMaas) from Personel group by PerMeslek", sqlConnection);
            SqlDataReader ok2 = komut2.ExecuteReader();
            while (ok2.Read())
            {
                chart2.Series["Meslek-Maaş"].Points.AddXY(ok2[0], ok2[1]);// 0 ınci index grafiğin altındaki yazılar şehirlerden gelecek ,1 inci index gruplama yapararak şehirdeki kişileri verecek 
            }
            sqlConnection.Close();
        }
    }
}
