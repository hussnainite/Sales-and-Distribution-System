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
    public class PurchaseReqDetailsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PurchaseReqDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select * from dbo.pr_request_details";
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

        public JsonResult Post(pr_request_details prqd)
        {

            string query = @"insert into dbo.pr_request_details (item_id,quantity,price,pr_request_id,inserted_date,status) values (  '" + prqd.item_id + @"' , '" + prqd.quantity + @"' , '" + prqd.price + @"' , '" + prqd.pr_request_id + @"', '" + DateTime.Now.ToString() + @"', '" + prqd.status + @"') ";
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
