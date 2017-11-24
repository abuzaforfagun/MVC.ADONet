using MVC.ADONet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC.ADONet.Presistances
{
    public class CompanyHandler
    {
        SqlConnection conn;
        void connection()
        {
            var conString = ConfigurationManager.ConnectionStrings["MVCSample"].ToString();
            conn = new SqlConnection(conString);
        }

        public CompanyHandler()
        {
            connection();
        }

        private DataTable ExecuteCommand(SqlCommand cmd)
        {
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();
            sd.Fill(dt);
            return dt;
        }


        private List<Company> DataTableToCompanyList(DataTable dt)
        {
            List<Company> companyList = new List<Company>();
            foreach (DataRow r in dt.Rows)
            {
                Company companyFromDb = new Company();
                companyFromDb.CompanyId = Convert.ToInt32(r["Id"]);
                companyFromDb.Name = r["CompanyName"].ToString();
                companyFromDb.Address = new Address
                {
                    AddressId = Convert.ToInt32(r["addressId"]),
                    FirstLine = r["AddressLine1"].ToString(),
                    LastLine = r["AddressLine2"].ToString(),
                    City = new City
                    {
                        CityId = Convert.ToInt32(r["cityId"]),
                        Name = r["CityName"].ToString(),
                        Country = new Country
                        {
                            CountryId = Convert.ToInt32(r["countryId"]),
                            Name = r["Country"].ToString()
                        }
                    }
                };
                companyFromDb.Name = r["CompanyName"].ToString();
                companyList.Add(companyFromDb);
            }
            return companyList;
        }

        public Company Add(Company company)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[AddComapny]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", company.Name);
            cmd.Parameters.AddWithValue("@AddressFirstLine", company.Address.FirstLine);
            cmd.Parameters.AddWithValue("@AddressLastLine", company.Address.LastLine);
            cmd.Parameters.AddWithValue("@City", company.Address.City.Name);
            cmd.Parameters.AddWithValue("@PostCode", company.Address.PostalCode);
            cmd.Parameters.AddWithValue("@Country", company.Address.City.Country.Name);

            DataTable dt = ExecuteCommand(cmd);
            var companyFromDb = new Company();

            try
            {
                companyFromDb = DataTableToCompanyList(dt)[0];
            }catch (Exception ex)
            {
                companyFromDb = null;
            }
            
            return companyFromDb;
        }

        public List<Company> GetAll()
        {
            SqlCommand cmd = new SqlCommand("[dbo].[GetCompanies]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt= ExecuteCommand(cmd);
            return DataTableToCompanyList(dt);
        }

        public Company GetOne(int id)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[GetCompany]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            DataTable dt = ExecuteCommand(cmd);
            Company company;
            try
            {
                company = DataTableToCompanyList(dt)[0];
            }
            catch
            {
                company = null;
            }
            return company;
        }
    }
}