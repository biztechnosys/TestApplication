using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TestApplication.Models;

namespace TestApplication.Repository
{
    public class EmployeeRepo
    {
        string connStr = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
        public List<Empmodel> GetDisplayData()
        {
            List<Empmodel> empList = new List<Empmodel>();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "";
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        con.Close();
                        foreach(DataRow dr in dt.Rows)
                        {
                            empList.Add(new Empmodel
                            {
                                eid = Convert.ToInt32(dr["eid"]),
                                ename = dr["Name"].ToString(),
                                edob = Convert.ToDateTime(dr["Dob"].ToString()),
                                egender = dr["Gender"].ToString(),
                                ecity = dr["City"].ToString(),
                                subject = dr["subject"].ToString()
                            });
                        }
                    }
                }
                return empList;
            }
        }
    }
}