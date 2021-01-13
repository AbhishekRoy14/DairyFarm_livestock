using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TM1
{
    class Goat : Livestock // Goat is a subclass of Livestock
    {
        public Goat(int id, string livestockType, int yearBorn, double costPerMonth, double costOfVaccination, double amountMilk)
             : base(id, livestockType, yearBorn, costPerMonth, costOfVaccination, amountMilk)
        { }

    }

}