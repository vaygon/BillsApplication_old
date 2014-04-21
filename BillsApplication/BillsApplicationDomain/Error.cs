using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillsApplicationDomain
{
    public class Error
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ErrorMessage { get; set; }
    }
}