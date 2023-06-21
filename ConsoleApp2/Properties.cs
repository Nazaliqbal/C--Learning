using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    //properties(get,set)
    class College
    {
        public string collegeName;
        private string place;
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        //using constructor
        public College(string college, string place)
        {
            collegeName = college;
            Place = place;

        }
    }
}
