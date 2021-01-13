using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TM1
{
    public static class Utilities
    {

        public static void ReadFile()
        {

            Data data = new Data();

            data.animal = new Livestock[20]; //Array with 20 pointers
            try // file reader
            {
                String myLine;
                String[] words;
                int counter = 0;
                TextReader tr = new StreamReader("C:/temp/livestock.txt");

                while ((myLine = tr.ReadLine()) != null)
                {
                    words = myLine.Split(',');
                    int id = int.Parse(words[0]);
                    string livestockType = words[1];
                    int yearBorn = int.Parse(words[2]);
                    double costPerMonth = double.Parse(words[3]);
                    double costOfVaccination = double.Parse(words[4]);
                    double amountMilk = double.Parse(words[5]);


                    if (livestockType == "Cow")
                    {
                        data.animal[counter] = new Cow(id, livestockType, yearBorn, costPerMonth, costOfVaccination, amountMilk);
                    }
                    else if (livestockType == "Goat")
                    {
                        data.animal[counter] = new Goat(id, livestockType, yearBorn, costPerMonth, costOfVaccination, amountMilk);
                    }

                    counter++;
                } // end of reading file
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void Menu()
        {
           

            // A permanent pointer to Data object
            Data data = new Data();
            // Initialise the user inputs
            String userInput;
            String userSelected;
            // Output to the menu to display

        /*
         *  creates the main menu
         */

            Console.WriteLine("----------------- MENU -----------------");
            Console.WriteLine("1) Display livestock information by ID");
            Console.WriteLine("2) Display cow that produced the most milk");
            Console.WriteLine("3) Display goat that produced least amount of milk");
            Console.WriteLine("4) Calculate farm profit");
            Console.WriteLine("5) Display unprofitable livestock");
            Console.WriteLine("0) Exit");
            Console.WriteLine("");
            Console.Write("Enter an Option: ");

        /*
         * Reading user input 
         * Displaying result based on the input
         * Prompt user to try again incase of bad selection
         */

            userInput = Console.ReadLine();
            int result;
            if (int.TryParse(userInput, out result))
            {
                if (result >= 0 && result <= 5)
                {

                }
                else
                {
                    
                Console.WriteLine("Invalid Option");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                Menu();
                }
            }
            else
            {
                Console.WriteLine("\nInvalid format");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }


            switch (userInput)
            {
                case "1":
                    Console.Write("Enter Livestock ID:");
                    userSelected = Console.ReadLine();
                    DisplayLivestock(data.animal, userSelected);
                    break;

                case "2":
                    DisplayMostMilk(data.animal);
                    break;

                case "3":
                    DisplayLeastMilk(data.animal);
                    break;

                case "4":
                    DisplayFarmProfit(data.animal);
                    break;

                case "5":
                    Unprofitable(data.animal);
                    break;

                case "0":
                    Console.Clear();
                    Console.WriteLine("You are about to exit the Menu");
                    Console.WriteLine("Are you sure? Y/N");
                    string exit = Console.ReadKey().KeyChar.ToString();
                    if (exit.ToUpper() != "Y")
                    {
                        Console.Clear();
                        Menu();
                    }
                    break;

            }
        }

                
        /*
          * Method process throught the livestock Data
          * Displays results to console, based on user input
          * Display livestock information by ID
          * Prompt user of bad selection
          */

        static void DisplayLivestock(Livestock[] livestockArray, String userSelected)
        {
            bool match = false;

            for (int i = 0; i < livestockArray.Length; i++)
            {
                if (livestockArray[i].GetID == int.Parse(userSelected))
                {
                    Console.WriteLine("");
                    Console.WriteLine(livestockArray[i].GetLivestockType);
                    Console.WriteLine("ID:                 " + livestockArray[i].GetID);
                    Console.WriteLine("Year Born:          " + livestockArray[i].GetYearBorn);
                    Console.WriteLine("Maintenance Cost:  $" + livestockArray[i].GetCostPerMonth);
                    Console.WriteLine("Vaccination Cost:  $" + livestockArray[i].GetCostOfVaccination);
                    Console.WriteLine("Milk per day:       " + livestockArray[i].GetAmountMilk + " litres");
                    Console.WriteLine("");
                    match = true;
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    
                }
            }

            if (!match)
            {
                Console.Write("Invalid ID - Press any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
        }

        /*
         * Method process throught the animal produce the most milk
         * Displays results to console
         * Display cow that produced the most milk
         */

        static void DisplayMostMilk(Livestock[] livestockArray)

        {
            Double max = 0; // start max balance at 0
            List<Livestock> mostMilk = new List<Livestock>();
            foreach (Livestock m in livestockArray)
            {
                if (m.GetAmountMilk >= max)
                {
                    max = m.GetAmountMilk;
                }
            }

            foreach (Livestock m in livestockArray)
            {
                if (m.GetAmountMilk == max)  
                {
                    mostMilk.Add(m);
                }
            }

            foreach (Livestock m in mostMilk)
            {
                Console.WriteLine("                         " );
                Console.WriteLine("Cow that produced the most milk:" );
                Console.WriteLine("" + m.GetLivestockType);
                Console.WriteLine("ID:                      " + m.GetID );
                Console.WriteLine("Year:                    " + m.GetYearBorn );
                Console.WriteLine("Maintenance Cost:       $" + m.GetCostPerMonth );
                Console.WriteLine("Vaccination Cost:       $" + m.GetCostOfVaccination );
                Console.WriteLine("Milk Per Day             " + m.GetAmountMilk + " litres");
            }

            Console.WriteLine("                         ");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        /*
        * Method process throught the animal produce the least milk
        * Displays results to console
        * Display goat that produced least amount of milk
        */

        static void DisplayLeastMilk(Livestock[] livestockArray)

        {
            Double least = 100; // Setting a high value to get the lowest
            List<Livestock> leastMilk = new List<Livestock>();
            foreach (Livestock l in livestockArray)
            {
                double milk = l.GetAmountMilk;
                if (least >= milk)
                {
                    least = milk;
                }
            }

            foreach (Livestock l in livestockArray)
            {
                if (l.GetAmountMilk == least)
                {
                    leastMilk.Add(l);
                }
            }

            foreach (Livestock l in leastMilk)
            {
                Console.WriteLine("                         ");
                Console.WriteLine("Goat that produced the least amount of milk:");
                Console.WriteLine("" + l.GetLivestockType);
                Console.WriteLine("ID:                      " + l.GetID);
                Console.WriteLine("Year:                    " + l.GetYearBorn);
                Console.WriteLine("Maintenance Cost:       $" + l.GetCostPerMonth);
                Console.WriteLine("Vaccination Cost:       $" + l.GetCostOfVaccination);
                Console.WriteLine("Milk Per Day             " + l.GetAmountMilk + " litres");
            }

            Console.WriteLine("                         ");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        /*
        * Method process throught the livestock Data
        * Displays results to console
        * Calculate farm profit
        */

        static void DisplayFarmProfit(Livestock[] livestockArray)
        {
            for (int i = 0; i < livestockArray.Length; i++)
            {
                Console.WriteLine("                         ");
                Console.WriteLine("Calculation of Farm profit:");
                Console.Write("Enter price of milk: $");
                double PriceOfMilk = double.Parse(Console.ReadLine());
                double totalAmountOfMilk = livestockArray[i].GetAmountMilk * 365;
                double totalPriceOfMilk = PriceOfMilk * totalAmountOfMilk;
                double costOfMaintenance = livestockArray[i].GetCostOfVaccination + (livestockArray[i].GetCostPerMonth * 12);
                double profitability = totalPriceOfMilk - costOfMaintenance;
                Console.WriteLine("Farm Profit: ${0}"+"per Month",profitability);
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                Menu();
                
            }
        }

        /*
       * Method process throught the livestock Data
       * Displays results to console
       * Display unprofitable livestock
       */

        static void Unprofitable(Livestock[] livestockArray)
        {
            Double unprofit = 1000; // Setting a high value to get the lowest
            List<Livestock> unprofitStock = new List<Livestock>();
            foreach (Livestock u in livestockArray)
            {
                Console.WriteLine("                         ");
                Console.WriteLine("Livestock that are not profitable:");
                Console.Write("Enter price of milk: $");
                double PriceOfMilk = double.Parse(Console.ReadLine());
                double TotalMilk = PriceOfMilk * u.GetAmountMilk * 365;
                double costOfMaintenance = u.GetCostOfVaccination + (u.GetCostPerMonth * 12);
                double profit = TotalMilk - costOfMaintenance;

                if (unprofit >= profit)
                {
                    unprofit = profit;
                }

            }
            foreach (Livestock u in livestockArray)
            {
                if (u.GetID == unprofit)
                {
                    unprofit.Equals(u);
                }
            }

                foreach (Livestock u in livestockArray)
            {
                Console.WriteLine("                         ");
                Console.WriteLine("" + u.GetLivestockType);
                Console.WriteLine("ID:                      " + u.GetID);
                Console.WriteLine("Year:                    " + u.GetYearBorn);
                Console.WriteLine("Maintenance Cost:        " + u.GetCostPerMonth);
                Console.WriteLine("Vaccination Cost:        " + u.GetCostOfVaccination);
                Console.WriteLine("Milk Per Day             " + u.GetAmountMilk);
            }



            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        
    }
}
    
