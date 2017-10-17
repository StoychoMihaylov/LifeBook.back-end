using Lifebook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifebook.Services
{
    public class Service
    {
        public Service()
        {
            this.Context = new LifebookDbContext();
        }

        protected LifebookDbContext Context { get; set; }
    }
}
