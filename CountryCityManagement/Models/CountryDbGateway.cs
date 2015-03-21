using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CountryCityManagement.Models
{
    public class CountryDbGateway
    {

        public void SaveCountry(Country aCountry)
        {
            string connctionStr = ConfigurationManager.ConnectionStrings["CountryConnectionStr"].ConnectionString;
            SqlConnection aSqlConnection = new SqlConnection();
            aSqlConnection.ConnectionString = connctionStr;
            string query = "INSERT INTO t_country VALUES ('" + aCountry.Name + "','" + aCountry.About + "','" +
                           aCountry.ImageLocation + "')";
            aSqlConnection.Open();
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();

        }


        public List<Country> GetAll()
        {
            string connctionStr = ConfigurationManager.ConnectionStrings["CountryConnectionStr"].ConnectionString;
            SqlConnection aSqlConnection = new SqlConnection();
            aSqlConnection.ConnectionString = connctionStr;
            string query = "SELECT * FROM t_country";
            aSqlConnection.Open();
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aReader = aSqlCommand.ExecuteReader();
            List<Country> countries = new List<Country>();
            while (aReader.Read())
            {
                Country aCountry = new Country();
                aCountry.CountryId = Convert.ToInt32(aReader["id"]);
                aCountry.Name = aReader["name"].ToString();
                aCountry.ImageLocation = aReader["image_location"].ToString();
                aCountry.About = aReader["about"].ToString();
                countries.Add(aCountry);
            }
            aSqlConnection.Close();
            return countries;

        }

    }
}