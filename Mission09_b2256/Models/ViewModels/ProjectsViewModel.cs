using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_b2256.Models.ViewModels
{
    public class ProjectsViewModel
    {
        public IQueryable<Books> Book { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
