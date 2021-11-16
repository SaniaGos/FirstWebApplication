using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNew.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SName { get; set; }
        public string ConpanyLink { get; set; }
        public int Transaction_ { get; set; }

        public void Check_URL()
        {
            if (ConpanyLink == null || ConpanyLink == "#") ConpanyLink = "#";
            else if (!ConpanyLink.StartsWith("https://")) ConpanyLink = ConpanyLink.Insert(0, "https://");
        }
    }
}
