using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperRawSql.Models;
using DapperRawSql.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DapperRawSql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SqlRawController : ControllerBase
    {
        [HttpGet("GetSqlQueries")]
        public IActionResult GetSqlQueries()
        {
            DapperRepository orm = new DapperRepository();
            var list = orm.Connection.Query<SqlQuery>("SELECT * FROM SqlQueries").ToList();
            if(list.Any())
                return Ok(list);

            return NotFound();
        }
        
        [HttpGet("GetById/id")]
        public IActionResult GetById(int id)
        {
            
            DapperRepository orm = new DapperRepository();
            var sqlQuery = orm.Connection.QueryFirstOrDefault<SqlQuery>("SELECT * FROM SqlQueries WHERE ID = @Id", new {Id = id});
            if (sqlQuery is null)
                return NotFound();
            var result = orm.Connection.Query(sqlQuery.Query).ToList();
            return Ok(result);
        }
    }
}