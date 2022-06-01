using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakIsletmeleri
{
    internal class PstgreConnection
    {
        public NpgsqlConnection baglanti()
        {
            NpgsqlConnection baglanti1 = new NpgsqlConnection("server=localHost; port=5432; Database=Dbo_Emlak; user Id=postgres; password=Samsun1864");
            baglanti1.Open();
            return baglanti1;
        }

    }
}
