using BillsApplicationDomain.Repository;
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
        private IGenericRepository _repo;

        public BillService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public List<Bill> GetBills()
        {
            return _repo.FindAll<Bill>().ToList();
        }

        public void Add(Bill bill)
        {
            _repo.Create<Bill>(bill);
        }

        public Bill GetBillById(int id)
        {
            return _repo.GetById<Bill>(id);
        }
       
        public void Update(Bill bill)
        {
            _repo.Update<Bill>(bill);
        }
               
        public void DeleteBillById(int id)
        {
            _repo.Delete<Bill>(id);
        }
    }
}