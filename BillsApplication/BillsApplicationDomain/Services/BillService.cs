using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BillsApplicationDomain.Services
{
    public interface IBillService
    {
        List<Bill> GetBills();
        void Add(Bill bill);
        Bill GetBillById(int id);
        void Update(Bill bill);
        void DeleteBillById(int id);
    }

    public class BillService : IBillService
    {
        public List<Bill> GetBills()
        {
            var listOfBills = new List<Bill>();
            var db = new BillsDbContext();
            return db.Bills.ToList();
        }

        public void Add(Bill bill)
        {            
            var db = new BillsDbContext();
            db.Bills.Add(bill);
            db.SaveChanges();
        }

        public Bill GetBillById(int id)
        {
            var db = new BillsDbContext();
            return db.Bills.FirstOrDefault(x => x.Id == id);
        }
       
        public void Update(Bill bill)
        {
            using (var db = new BillsDbContext())
            {
                db.Bills.Attach(bill);
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
            }            
        }
               
        public void DeleteBillById(int id)
        {
            using (var db = new BillsDbContext())
            {
                var bill = db.Bills.FirstOrDefault(x => x.Id == id);
                db.Entry(bill).State = EntityState.Deleted;
                db.SaveChanges();
            };
        }
    }
}