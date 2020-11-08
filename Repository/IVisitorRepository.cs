using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microMantra
{
    public interface IVisitorRepository
    {

        public void addVisitor(visitor objvisitor);
        public void updateVisitor(visitor objvisitor);
        public void Save();
        public IEnumerable<visitor> GetVisitors();
        public visitor GetVisitorByID(int visitorID);
        public void DeleteVisitor(int visitorID);

    }
}
