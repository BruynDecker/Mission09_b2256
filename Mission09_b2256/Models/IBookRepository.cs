using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_b2256.Models
{
    public interface IBookRepository
    {
        public IQueryable<Books> Book { get; }
    }
}
