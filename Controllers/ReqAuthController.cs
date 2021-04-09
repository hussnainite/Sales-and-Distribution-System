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
    public class ReqAuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ReqAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public JsonResult Post(pr_request pr)
        {
            string query = @"select request_id from dbo.pr_request where  pr_name LIKE  '%" +pr.pr_name + "%' ";
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

    }
}
