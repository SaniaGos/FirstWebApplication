using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNew.Models
{
    public interface ILeadRepository
    {
        void Create(Lead lead);
        void Delete(int id);
        Lead Get(int id);
        List<Lead> GetLeads();
        void Update(Lead lead);
    }

    public class LeadRepository : ILeadRepository
    {
        string connectionString = null;
        public LeadRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Lead> GetLeads()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                List<Lead> a = db.Query<Lead>("SELECT * FROM Leads").ToList();
                return a;
                //return db.Query<Lead>("SELECT * FROM Lead").ToList();
            }
        }

        public Lead Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Lead>("SELECT * FROM Leads WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Lead lead)
        {
            lead.Check_URL();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Leads (Name, Sname, ConpanyLink, Transaction_) VALUES(@Name, @Sname, @ConpanyLink, @Transaction_)";
                db.Execute(sqlQuery, lead);
            }
        }

        public void Update(Lead lead)
        {
            lead.Check_URL();

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Leads SET Name = @Name, SName = @SName, ConpanyLink = @ConpanyLink, Transaction_ = @Transaction_ WHERE Id = @Id";
                db.Execute(sqlQuery, lead);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Leads WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
