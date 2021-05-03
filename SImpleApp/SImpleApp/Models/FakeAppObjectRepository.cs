using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SImpleApp.Models
{
    public class FakeAppObjectRepository : IAppObjectRepository
    {
        public IQueryable<AppObject> appObjects => new List<AppObject> { 
            new AppObject { Code = 1, Value = "value1" },
            new AppObject { Code = 5, Value = "value2" },
            new AppObject { Code = 10, Value = "value32" }
        }.AsQueryable<AppObject>();
    }
}
