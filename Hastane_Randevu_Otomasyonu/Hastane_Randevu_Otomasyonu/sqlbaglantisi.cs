using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Randevu_Otomasyonu
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-K014IO0\\SQLEXPRESS;Initial Catalog=HastaneRandevu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
