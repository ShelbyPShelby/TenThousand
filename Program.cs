using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ten_Thousand_Shelby
{
    class Program
    {   
        /// <summary>
        /// This Class holds all the information pertaining to the amount of time it takes to reach 10000 hrs
        /// </summary>
        class Thousand
        {
            public double days,
                       weeks,
                       months,
                       years;
            public const double WeekInYear = 52.1429,
                                DayInMonth = 30.4167,
                                TenThousand = 10000;

            public Thousand()
            {
                days = 0.0;
                weeks = 0.0;
                months = 0.0;
                years = 0.0;
            }

            //This will be divided by 10000 to get how many weeks it will take to reach it
            public void calculateWeeks(int hours)
            {
                weeks = TenThousand / hours;
            }
            
            //This will take the info from the previous function to convert the weeks into the rest of the variables
            //Modulo is used to get the remainder
            public void tenThousandTimes(double week)
            {
                years = week / WeekInYear;
                months = (years % 1) * 12;
                days = (months % 1) * DayInMonth;

            }

            public void printResults()
            {
                Console.WriteLine("\nIt will take \n{0} year(s)\n{1} month(s) and\n{2} day(s)\nto reach 10,000 hours.", (int)years, (int)months, (int)days);
            }
 
        }    


        //Main starts here
        //
        //**************************************************************************
        static void Main(string[] args)
        {
            Thousand yeah = new Thousand();
            int test;

            Console.WriteLine("Please enter the amount of hours per week you plan on practicing.");
           //Input Validation to prevent any non Int or negative values from being entered
            while(!int.TryParse(Console.ReadLine(), out test))
            {
                 Console.WriteLine("Invalid Input. Please enter a positive whole number.");
            }
              while (test < 0)
            {
                Console.WriteLine("Invalid Input. Please enter a positive whole number.");
                while (!int.TryParse(Console.ReadLine(), out test))
                {
                    Console.WriteLine("Invalid Input. Please enter a positive whole number.");
                }
            }   

            yeah.calculateWeeks(test);
            yeah.tenThousandTimes(yeah.weeks);


            //Console.WriteLine(yeah.weeks);
            //Console.WriteLine(yeah.days);
            //Console.WriteLine(yeah.months);
            //Console.WriteLine(yeah.years);
            
            //DateTime is used to get the exact date when the program is run
            //The class variables are then used to add the time to the current date.
            //Variables are typecasted to integers in order for it to work
            DateTime now = DateTime.UtcNow.Date;
            DateTime days = now.AddDays((int)yeah.days);
            DateTime months = days.AddMonths((int)yeah.months);
            DateTime later = months.AddYears((int)yeah.years);

            yeah.printResults();
            
            
            Console.Write("\nCurrent Date is : ");
            Console.WriteLine(now.ToString("MM/dd/yyyy"));
            Console.Write("You will reach your Ten Thousand Hours on : ");
            Console.WriteLine(later.ToString("MM/dd/yyyy"));
            Console.ReadLine();
        }
    }
}
