using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Data.Infrastructure
{
    public class DbFactory :Disposable,IDbFactory
    {
        private MyVocalDbContext dbContext;

        public MyVocalDbContext Init()
        {
            return dbContext ?? (dbContext = new MyVocalDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
