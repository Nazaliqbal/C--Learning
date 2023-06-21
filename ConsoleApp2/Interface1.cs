using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    interface Company
    {
        void companyMotto();
    }
    public class Google : Company
    {
        public void companyMotto()
        {
            Console.WriteLine("Make life easier with a little help from our products.");
        }
    }
}
