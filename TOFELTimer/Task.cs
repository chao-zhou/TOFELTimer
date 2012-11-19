using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOFELTimer
{
    class Task
    {
        public string Name { get; set; }
        public int PreparedSeconds { get; set; }
        public int ResponseSeconds { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
