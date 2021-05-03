using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SImpleApp.Models
{
    public interface IAppObjectRepository
    {
        IQueryable<AppObject> appObjects { get; }
    }
}
