using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Entites;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL.Operations
{
   public class OProduct
    {
       SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["shop"].ConnectionString);
       public int Insert(EProduct prod)
       {
           conn.Open();
           string query="insert into Product(ProdName,ProdPrice,ProdDescription,ProdImagePath,CategoryId)values(@ProdName,@ProdPrice,@ProdDescription,@ProdImagePath,@CategoryId)";
           SqlCommand cmd=new SqlCommand(query,conn);
           cmd.Parameters.AddWithValue("@ProdName",prod.ProdName);
           cmd.Parameters.AddWithValue("@ProdPrice",prod.ProdPrice);
           cmd.Parameters.AddWithValue("@ProdDescription",prod.ProdDecription);
           cmd.Parameters.AddWithValue("@ProdImagePath",prod.ProdImagePath);
           cmd.Parameters.AddWithValue("@CategoryId",prod.CategoryId);
           int rows=cmd.ExecuteNonQuery();
           return rows;

       }
         
       public DataTable  Select()
       {
           string query = @"SELECT * FROM  Product";
           SqlDataAdapter da=new SqlDataAdapter(query,conn);
           DataTable dt=new DataTable();
           da.Fill(dt);
           return dt;


       }
      public int Delete(EProduct prod)
       {
           conn.Open();
           string query = @"Delete from Product 
                where ProdId=@ProdId";
           SqlCommand cmd = new SqlCommand(query, conn);
           cmd.Parameters.AddWithValue("@ProdId", prod.ProdId);
           int rows = cmd.ExecuteNonQuery();
           return rows;

       }
       public int Update(EProduct prod)
       {

           conn.Open();
           string query = "Update Product set ProdName = @ProdName,ProdPrice = @ProdPrice,ProdDescription = @ProdDescription, CategoryId = @CategoryId   WHERE ProdId = @ProdId ";
           SqlCommand cmd = new SqlCommand(query, conn);
           cmd.Parameters.AddWithValue("@ProdId", prod.ProdId);
           cmd.Parameters.AddWithValue("@ProdName", prod.ProdName);
           cmd.Parameters.AddWithValue("@ProdPrice", prod.ProdPrice);
           cmd.Parameters.AddWithValue("@ProdDescription", prod.ProdDecription);
           cmd.Parameters.AddWithValue("@CategoryId", prod.CategoryId);
           int rows = cmd.ExecuteNonQuery();
           return rows;
       }

      
    }
}
