using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public static class Server
    {
        private static int Count{ get; set; } = 0;  

        public static int GetCount()
        {
            return Count;
        }
    
        public static void AddToCount(int val)
        {
            Count += val;
        }
    }
}
