using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TM1
{
    public class Data
    {

        private static Livestock[] livestockArray;

        public Data()
        {
        }

        internal Livestock[] animal
        {
            get { return livestockArray; }
            set { livestockArray = value; }
        }

    }

}