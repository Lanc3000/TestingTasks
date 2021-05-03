using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SImpleApp.Models;

namespace SImpleApp.Controllers
{
    public class AppObjectController : Controller
    {
        private IAppObjectRepository _repository;

        public AppObjectController(IAppObjectRepository repository) {
            _repository = repository;
        }

        public ViewResult List() => View(_repository.appObjects);
    }
}
