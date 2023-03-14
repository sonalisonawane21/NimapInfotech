using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NimapInfotech.Models
{
    public class CategoryNAT
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public CategoryNAT(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public List<Category> CatList()
        {
            List<Category> catlist = new List<Category>();
            string qry = "select * from Category";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Category cat = new Category();
                    cat.CategoryID = Convert.ToInt32(dr["categoryID"]);
                    cat.CategoryName = dr["categoryName"].ToString();
                    catlist.Add(cat);
                }
            }
            con.Close();
            return catlist;
        }
        public Category GetCatById(int id)
        {
            Category cat = new Category();
            string qry = "select * from category where categoryID=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cat.CategoryID = Convert.ToInt32(dr["categoryID"]);
                    cat.CategoryName = dr["categoryName"].ToString();
                }
            }
            con.Close();
            return cat;
        }
        public int AddCat(Category cat)
        {
            int result = 0;
            string qry = "insert into category values(@categoryname)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryname", cat.CategoryName);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCat(Category cat)
        {
            int result = 0;
            string qry = "update category set categoryName=@categoryname where categoryID=@categoryid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryname", cat.CategoryName);
            cmd.Parameters.AddWithValue("@categoryid", cat.CategoryID);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCat(int id)
        {
            int result = 0;
            string qry = "delete from  category where categoryid=@categoryid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@categoryid", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}
