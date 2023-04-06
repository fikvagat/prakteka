using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakteka
{
    internal class Instances
    {
        private static prakteka_deEntities db = null;

        public static prakteka_deEntities Context
        {
            get
            {
                if (db == null)
                    db = new prakteka_deEntities();
                return db;
            }
        }
    }
}
