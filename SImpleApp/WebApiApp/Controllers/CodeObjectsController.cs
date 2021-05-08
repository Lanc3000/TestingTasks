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
        List<CodeObject> initialList = new List<CodeObject>(){
                                                new CodeObject { Code = 10, Value = "value10" },
                                                new CodeObject { Code = 1, Value = "value1" },
                                                new CodeObject { Code = 5, Value = "value5" },
                                                new CodeObject { Code = 20, Value = "value20" },
                                                new CodeObject { Code = 15, Value = "value32" }
        };
        CodeObjectsContext db;
        public CodeObjectsController(CodeObjectsContext context)
        {
            db = context;

            db.CodeObjects.RemoveRange(db.CodeObjects); // очистка бд
            db.SaveChanges();                           // удалить после тестирования метода Post

            if (!db.CodeObjects.Any()) {
                Post(initialList);
                Get();
                //db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeObject>>> Get()
        {
            return await db.CodeObjects.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<CodeObject>> Post(List<CodeObject> codeObject)
        {
            //db.CodeObjects.RemoveRange(db.CodeObjects); // очистка бд
            //db.SaveChanges();
            var sortedList = codeObject.OrderBy(c => c.Code);
            if (codeObject == null)
            {
                return BadRequest();
            }

            foreach (CodeObject elem in sortedList)
            {
                db.CodeObjects.Add(elem);
            }
            await db.SaveChangesAsync();
            return Ok(sortedList);
        }
        //public async Task<ActionResult<CodeObject>> Post(CodeObject codeObject)
        //{
        //    db.CodeObjects.RemoveRange(db.CodeObjects); // очистка бд
        //    db.SaveChanges();

        //    if (codeObject == null)
        //    {
        //        return BadRequest();
        //    }
        //    db.CodeObjects.Add(codeObject);
        //    await db.SaveChangesAsync();
        //    return Ok(codeObject);
        //}
    }
}
