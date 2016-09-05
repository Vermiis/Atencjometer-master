using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class ConnectionTest
    {
        public static bool DoesExist(string mirek1, string mirek2)
        {
            if (mirek1.Length == 0 || mirek2.Length == 0)
            {
                return false;
            }
            else
                return true;
        }
    }
}
