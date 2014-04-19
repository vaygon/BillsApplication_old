using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BillsApplicationDomain
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }

        [Range(1,31)]
        public int DueDay { get; set; }

        public string User { get; set; }
        public Tag Tag { get; set; }
       
    }

    public enum Tag
    { 
        Utility = 0,
        Housing,
        Leisure
    }
}