using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TM1
{
    class Livestock
    {
        /*
         * Variables used inside Livestock class
         */
        private int id; //ID Number of livestock
        private string livestockType; //Value of livestockType "Cow" or "Goat"
        private int yearBorn; //Year of birth with format YYYY
        private double costPerMonth; //The cost per month
        private double costOfVaccination; //Annual vaccination cost
        private double amountMilk; //The amount of milk produced per day in liters

        Data data = new Data();
       

        private double todaysMilk;

        /*
         * Main Constructor for Livestock object
         */

        public Livestock(int id, string livestockType, int yearBorn, double costPerMonth, double costOfVaccination, double amountMilk)
        {
            this.id = id;
            this.livestockType = livestockType;
            this.yearBorn = yearBorn;
            this.costPerMonth = costPerMonth;
            this.costOfVaccination = costOfVaccination;
            this.amountMilk = amountMilk;

        }

        /*
        * Setter / Getter method for ID
        */

        public virtual int GetID
        {
            get { return id; }
            set { id = value; }
        }

        /*
        * Setter / Getter method for livestockType
        */

        public virtual string GetLivestockType
        {
            get { return livestockType; }
            set { livestockType = value; }
        }

        /*
        * Setter / Getter method for yearBorn
        */

        public virtual int GetYearBorn
        {
            get { return yearBorn; }
            set { yearBorn = value; }
        }

        /*
        * Setter / Getter method for costPerMonth
        */

        public virtual double GetCostPerMonth
        {
            get { return costPerMonth; }
            set { costPerMonth = value; }
        }

        /*
        * Setter / Getter method for costOfVaccination
        */

        public virtual double GetCostOfVaccination
        {
            get { return costOfVaccination; }
            set { costOfVaccination = value; }
        }

        /*
        * Setter / Getter method for amountMilk
        */

        public virtual double GetAmountMilk
        {
            get { return amountMilk; }
            set { amountMilk = value; }
        }

        /*
        * Setter / Getter method for todaysMilk
        */

        public virtual double GetTodaysMilk
        {
            get { return todaysMilk; }
            set { todaysMilk = value; }
        }

        /*
         * Dsiplay livestock details
         */

        public void displayInfo()
        {
            Console.WriteLine("ID: " + id);


        }

        
    }
}

