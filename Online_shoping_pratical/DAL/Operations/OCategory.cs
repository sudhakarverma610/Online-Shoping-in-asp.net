using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using DAL.Entites;

namespace DAL.Operations
{
   public class OCategory
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["shop"].ConnectionString);
        public int Insert(ECategory Cat)
        {
            conn.Open();
            string query = "insert into Category(CategoryName)values(@CategoryName)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CategoryName", Cat.CategoryName);
            int rows = cmd.ExecuteNonQuery();
            return rows;

        }
        public int Update(ECategory Cat)
        {

            conn.Open();
            string query = @"Update Category set 
          
            CategoryName=@CategoryName
           where  CategoryId=@CategoryId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CategoryId", Cat.CategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", Cat.CategoryName);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }
        public int Delete(ECategory Cat)
        {
            conn.Open();
            string query = @"Delete from Category 
                where  CategoryId=@CategoryId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@CategoryId", Cat.CategoryId);
            int rows = cmd.ExecuteNonQuery();
            return rows;
        }
        public DataTable Select()
        {
            string query = "Select * from Category";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }

       
    }
}
