using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeObjectsController : ControllerBase
    {
        CodeObjectsContext db;
        public CodeObjectsController(CodeObjectsContext context)
        {
            db = context;
            if (!db.CodeObjects.Any()) {
                db.CodeObjects.Add(new CodeObject { Code = 1, Value = "value1" });
                db.CodeObjects.Add(new CodeObject { Code = 5, Value = "value5" });
                db.CodeObjects.Add(new CodeObject { Code = 10, Value = "value10" });
                db.CodeObjects.Add(new CodeObject { Code = 15, Value = "value32" });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeObject>>> Get()
        {
            return await db.CodeObjects.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<CodeObject>> Post(CodeObject codeObject)
        {
            if(codeObject == null)
            {
                return BadRequest();
            }
            db.CodeObjects.Add(codeObject);
            await db.SaveChangesAsync();
            return Ok(codeObject);
        }
    }
}
