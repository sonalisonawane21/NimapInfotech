using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;

namespace NimapInfotech.Models
{

    public class ProductNAT
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public ProductNAT(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Product> GetAllProduct()
        {
            List<Product> prodlist = new List<Product>();
            string qry = "select * from Product ";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product prod = new Product();
                    prod.ProductId = Convert.ToInt32(dr["ProductID"]);
                    prod.ProductName = dr["productName"].ToString();

                    prod.CategoryId = Convert.ToInt32(dr["categoryID"]);
                    prodlist.Add(prod);
                }
            }
            con.Close();
            return prodlist;

        }
        public Product GetProductById(int id)
        {
            Product prod = new Product();
            string qry = "select * from Product where productID=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    prod.ProductId = Convert.ToInt32(dr["productID"]);
                    prod.ProductName = dr["productName"].ToString();


                    prod.CategoryId = Convert.ToInt32(dr["categoryID"]);

                }
            }
            con.Close();
            return prod;
        }
        public int AddProduct(Product prod)
        {
            int result = 0;

            string qry = "insert into Product values(@productname,@catagoryid)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@productname", prod.ProductName);


            cmd.Parameters.AddWithValue("@catagoryid", prod.CategoryId);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;

        }
        public int UpdateProduct(Product prod)
        {
            int result = 0;

            string qry = "update product set productName=@name,CategoryID=@catagoryid where productID=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", prod.ProductId);
            cmd.Parameters.AddWithValue("@name", prod.ProductName);

            cmd.Parameters.AddWithValue("@catagoryid", prod.CategoryId);

            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            int result = 0;
            string qry = "delete from product where productID=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
