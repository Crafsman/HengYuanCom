using HengYuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HengYuan.Data.Repository
{
    public interface IRepository
    {
        Visitor GetVisitor(string ip);
        List<Visitor> GetAllVisitors();
        void AddVisitor(Visitor visitor);
        void UpdateVisitor(Visitor visitor);
        void RemoveVisitor(string ip);

        Task<bool> SaveChangesAsync();
    }
}
