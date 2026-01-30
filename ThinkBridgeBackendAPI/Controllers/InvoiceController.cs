using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BuggyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IDbConnection _connection;

        public InvoiceController(IDbConnection connection)
        {
            _connection = connection;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var items = await _connection.QueryAsync<InvoiceItem>(
                "GetAllInvoices",
                commandType: CommandType.StoredProcedure
            );

            if (items.Any())
            {
                return Ok(items);
            }

            return NotFound("No invoices found");
        }

        [HttpGet("simple")]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _connection.QueryAsync<InvoiceItem>(
                "GetAllInvoices",
                commandType: CommandType.StoredProcedure
            );

            return Ok(new 
            { 
                count = invoices.Count(),
                invoices = invoices 
            });
        }


        public class InvoiceItem
        {
            public string Name { get; set; } = string.Empty;
            public double Price { get; set; }
        }
    }
}