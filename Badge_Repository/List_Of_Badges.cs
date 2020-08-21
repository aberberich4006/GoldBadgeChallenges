using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
  public class Badge
    {
        public List<string> Access { get; set; }
        public int ID { get; set; }
        

        public Badge(int iD, List<string> access)
        {
            Access = access;
            ID = iD;
        }
    }
}
