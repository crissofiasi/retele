using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenRing
{
    class Token
    {
        public bool IsFree { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }
        public int CurrentCalculator { get; set; }
        public string msg { get; set; }
        public string response { get; set; }
        public bool IsAnswer { get; set; }



        public Token()
        {
            this.IsFree = true;

        }



    }
}
