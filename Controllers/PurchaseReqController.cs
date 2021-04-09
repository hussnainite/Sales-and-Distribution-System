using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using FYP_API.Models;
using Microsoft.Extensions.Configuration;
namespace FYP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseReqController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PurchaseReqController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select * from dbo.pr_request";
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

        public JsonResult Post(pr_request prq)
        {

            string query = @"insert into dbo.pr_request (ledger_id,requested_user,inserted_date,pr_name) values (  '" +  prq.ledger_id + @"' , '" + prq.requested_user + @"' , '" + prq.inserted_date + @"' , '" + prq.pr_name + @"') ";
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


    }
}
