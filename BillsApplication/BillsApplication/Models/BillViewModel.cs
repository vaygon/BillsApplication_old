using BillsApplicationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillsApplication.Models
{
    public class BillViewModel : Bill
    {
        public string DueDayString { get; set; }
    }
}