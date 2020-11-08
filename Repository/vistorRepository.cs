using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microMantra.Repository
{
    public class vistorRepository : IVisitorRepository
    {

        private readonly vistorContext  _vcontext;
        public void addVisitor(visitor objvisitor)
        {
            _vcontext.visitors.Add(objvisitor);
            Save();
        }
        public vistorRepository(vistorContext vcontext)
        {
            _vcontext = vcontext;
        }

        public void DeleteVisitor( int visitorID)
        {
            var objvisitor = _vcontext.visitors.Find(visitorID);
            _vcontext.visitors.Remove(objvisitor);
            Save();
        }

        public visitor GetVisitorByID(int visitorID)
        {
            visitor objvisitor = _vcontext.visitors.ToList().Where(v => v.visitorID == visitorID).Single();
            return objvisitor;
        }

        public IEnumerable<visitor> GetVisitors()
        {
            return _vcontext.visitors.ToList();
        }
        public void Save()
        {
            _vcontext.SaveChanges();
        }

        public void updateVisitor(visitor objvisitor)
        {
            _vcontext.Entry(objvisitor).State = EntityState.Modified;
          
        }
    }
}
