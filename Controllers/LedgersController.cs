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
    public class LedgersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LedgersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select * from dbo.ledgers";
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

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"select * from dbo.ledgers where ledgerid='" + id + "'";
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

        public JsonResult Post(Ledgers ld)
        {

            string query = @"insert into dbo.ledgers (ledger_name,legder_phone,ledger_type,inserted_date,ledger_address, ledger_email) values ('" + ld.ledger_name+ @"' ,  '" + ld.legder_phone+ @"' , '" + ld.ledger_type+ @"' , '" + ld.inserted_date+ @"' , '" + ld.ledger_address+ @"' , '" + ld.ledger_email+ @"') ";
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

        public JsonResult Put(int id, Ledgers ld)
        {


            string query = @"update dbo.ledgers set
            ledger_name= '" + ld.ledger_name+ @"' , legder_phone= '" + ld.legder_phone+ @"' , ledger_type = '" + ld.ledger_type + @"' , ledger_address = '" + ld.ledger_address + @"' , ledger_email = '" + ld.ledger_email + @"'  where ledgerid = '" + id + "'";
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


            string query = @"delete from dbo.ledgers where ledgerid = '" + id + "'";
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
