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
    public class ItemAuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ItemAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public JsonResult Post(Items it)
        {
            string query = @"select * from dbo.items where itemname='" + it.itemname+ "' ";
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
