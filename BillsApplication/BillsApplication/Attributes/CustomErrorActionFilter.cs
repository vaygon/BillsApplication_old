using BillsApplicationDomain;
using BillsApplicationDomain.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillsApplication.Attributes
{
    public class CustomErrorActionFilter : HandleErrorAttribute
    {
        [Inject]
        public IGenericRepository Repo { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            var error = new Error()
            {
                Date = DateTime.Now,
                ErrorMessage = filterContext.Exception.ToString()
            };

            Repo.Create<Error>(error);          

        }
    }
}