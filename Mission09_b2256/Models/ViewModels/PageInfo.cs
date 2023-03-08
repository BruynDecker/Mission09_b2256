using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_b2256.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((double) TotalNumProjects / (double) ProjectsPerPage);
    }
}
