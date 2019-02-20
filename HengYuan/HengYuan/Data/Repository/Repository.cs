using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HengYuan.Models;

namespace HengYuan.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddVisitor(Visitor visitor)
        {
            _ctx.Visitors.Add(visitor);
        }

        public List<Visitor> GetAllVisitors()
        {
            return _ctx.Visitors.ToList();
        }

        public Visitor GetVisitor(string ip)
        {
            return _ctx.Visitors.FirstOrDefault(p => p.IPAddress == ip);
        }

        public void RemoveVisitor(string ip)
        {
            _ctx.Visitors.Remove(GetVisitor(ip));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
                return true;
            return false;
        }

        public void UpdateVisitor(Visitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
