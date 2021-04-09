using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using FYP_API.Models;

namespace FYP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select * from dbo.users";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("APIcon");
            SqlDataReader myReader;
            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand (query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select * from dbo.users where userid='"+id+"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("APIcon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpPost]

        public JsonResult Post(Users us)
        {

            string query = @"insert into dbo.users (username,password,user_role,inserted_date,email,phone,address) values ('"+us.username+@"' ,  '"+us.password+@"' , '"+us.user_role+@"' , '"+us.inserted_date+@"' , '"+us.email+@"' , '"+us.phone+@"' , '"+us.address+@"') ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("APIcon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut("{id}")]

        public JsonResult Put(int id, Users us)
        {
            

            string query = @"update dbo.users set
            username= '"+us.username+ @"' , password = '" + us.password + @"' , user_role = '" + us.user_role + @"' , email = '" + us.email + @"' , phone = '" + us.phone + @"' , address = '" + us.address + @"' where userid = '"+id+"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("APIcon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {


            string query = @"delete from dbo.users where userid = '"+id+"'";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("APIcon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
