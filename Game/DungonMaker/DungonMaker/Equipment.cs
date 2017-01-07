using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungonMaker
{
    class Equipment
    {
        string name = "none";
        string type = null;
        int ihp = 0;

        public Equipment()
        {
            
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int IHP
        {
            get { return ihp; }
            set { ihp = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
