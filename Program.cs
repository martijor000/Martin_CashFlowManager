using System;
using System.Text.RegularExpressions;

//Jordan Martin
//IT112
//Notes: I used the ledgertype to determine what class to use for the getpayable amount.
//Behaviors not implemented: I did not implement the Earnings method. I used the IPayable array and grabbed all the get payable amount for each
//employee and added them together for a total amount.

namespace Martin_CashFlowManager
{
    class Program
    {
        static ConsoleKeyInfo userInput;
        static IPayable [] IP = new IPayable[100];
        static decimal totalweekpayout;
        static decimal totalinvoicepayout;
        static decimal totalsalarypayout;
        static decimal totalhourlypayout;
        static string newVariable;
        static string SSN;


        static void Main(string[] args)
        {


            IP[0] = new HourlyEmployee("Jordan", "Martin", "111111111", 10.33M, 32);
            IP[1] = new HourlyEmployee("Bob", "The-Builder", "222222222", 3.20M, 4);
            IP[2] = new HourlyEmployee("Rudolph", "The-Red-Nose-Reindeer", "333333333", 2M, 3);

            IP[3] = new SalariedEmployee("Cliffard", "The-Red-Dog", "444444444", 10M);
            IP[4] = new SalariedEmployee("Dora", "The-Explorer", "555555555", 10M);
            IP[5] = new SalariedEmployee("Cookie", "Monster", "666666666", 10M);

            IP[6] = new Invoice("1234", 4, "Cookies", 3.99M);
            IP[7] = new Invoice("5678", 2, "Milk", 2.43M);
            IP[8] = new Invoice("9101", 3, "Soda", 0.99M);


            OptionsMenu();


        }

        static void OptionsMenu()
        {
            do
            {
                Console.WriteLine("Choose from the following options:");
                Console.WriteLine("1. Add an invoice:");
                Console.WriteLine("2. Add an hourly employee:");
                Console.WriteLine("3. Add a salary employee:");
                Console.WriteLine("4. List total Weekly payout:");

                userInput = Console.ReadKey();
                Console.WriteLine("");
                Console.Clear();
                ValidateInput(userInput);

            } while (userInput.Key != ConsoleKey.D4);
        }

        static void ValidateInput(ConsoleKeyInfo testInput)
        {
            if (!Regex.Match(testInput.Key.ToString(), ".*[1-4].*").Success)
            {
                BadInput();
            }
            else if (testInput.Key == ConsoleKey.D1)
            {
                AddInvoice();
                PressKey();
            }
            else if (testInput.Key == ConsoleKey.D2)
            {

                AddHourly();
                PressKey();

            }
            else if (testInput.Key == ConsoleKey.D3)
            {
                AddSalary();
                PressKey();
            }
            else if (testInput.Key == ConsoleKey.D4)
            {

                DisplaySalaryEmployees();
                Console.WriteLine("");
                DisplayHourlyEmployees();
                Console.WriteLine("");
                DisplayInvoices();
                Console.WriteLine("");
                DisplayTotals();

                PressKey();
            }
        }

        static bool SSN_Validator(string SSN_Validate)
        {
            string SSN_Number = @"^\d{3}\-?\d{2}\-?\d{4}$";
            Regex regex = new Regex(SSN_Number);
            bool is_it_the_correct_format = regex.IsMatch(SSN_Validate);
            return is_it_the_correct_format;
        }

        static void SSN_Loop()
        {
            do
            {
                Console.WriteLine("Wrong Input or Wrong amount of numbers. Please enter SSN again.");
                newVariable = Console.ReadLine();
                Console.Clear();
            } while (!SSN_Validator(newVariable));

        }

        static void AddInvoice()
        {
            Random rnd = new Random();
            int test = rnd.Next(1000000);
            int test2 = rnd.Next(10000);

            string wow = test + "_" + test2;
            decimal productPrice = 0;
            int quantity = 0;

            Console.WriteLine("Enter the product name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the price of the product:");
            newVariable = Console.ReadLine();
            
            do
            {
                if (ParsingDecimalVariables(newVariable))
                {
                    productPrice = decimal.Parse(newVariable);
                }
                else
                {
                    ParseDecimalFailed();
                }

            } while (!ParsingDecimalVariables(newVariable));

            productPrice = decimal.Parse(newVariable);

            Console.WriteLine("Enter the quantity:");
            newVariable = Console.ReadLine();


            do
            {
                if (ParsingIntVariables(newVariable))
                {
                    quantity = int.Parse(newVariable);
                }
                else
                {
                    ParseIntFailed();
                }

            } while (!(ParsingIntVariables(newVariable)));

            quantity = int.Parse(newVariable);

            for (int i = 0; i < IP.Length; i++)
            {
                if (IP[i] == null)
                {
                    IP[i] = new Invoice(wow, quantity, productName, productPrice);
                    break;
                }
            }
        }

        static void AddSalary()
        {
            decimal sal = 0;

            Console.WriteLine("Enter the employee last name:");
            string lastName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter the employees first name:");
            string firstName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter the employees SSN:");
            newVariable = Console.ReadLine();
            do
            {
                if (SSN_Validator(newVariable))
                {
                    SSN = newVariable;
                }
                else
                {
                    SSN_Loop();
                }

            } while (!SSN_Validator(newVariable));

            SSN = newVariable;
            Console.Clear();

            Console.WriteLine("Enter the employees salary:");
            newVariable = Console.ReadLine();

            do
            {
                if (ParsingDecimalVariables(newVariable))
                {
                    sal = decimal.Parse(newVariable);
                }
                else
                {
                    ParseDecimalFailed();
                }

            } while (!ParsingDecimalVariables(newVariable));

            sal = decimal.Parse(newVariable);

            decimal weeklySal = sal / 4;


            for (int i = 0; i < IP.Length; i++)
            {
                if (IP[i] == null)
                {
                    IP[i] = new SalariedEmployee(firstName, lastName, SSN, weeklySal);
                    break;
                }
            }
        }

        static void AddHourly()
        {
            decimal HourlyWage = 0;
            int HoursWorked = 0;

            Console.WriteLine("Enter the employee last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the employees first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the employees SSN:");
            newVariable = Console.ReadLine();

            do
            {
                if (SSN_Validator(newVariable))
                {
                    SSN = newVariable;
                }
                else
                {
                    SSN_Loop();
                }

            } while (!SSN_Validator(newVariable));

            Console.WriteLine("Enter the employees hourly wage:");
            newVariable = Console.ReadLine();

            do
            {
                if (ParsingDecimalVariables(newVariable))
                {
                    HourlyWage = decimal.Parse(newVariable);
                }
                else
                {
                    ParseDecimalFailed();
                }

            } while (!ParsingDecimalVariables(newVariable));

            HourlyWage = decimal.Parse(newVariable);


            Console.WriteLine("Employees hours worked:");
            newVariable = Console.ReadLine();

            do
            {
                if (ParsingIntVariables(newVariable))
                {
                    HoursWorked = int.Parse(newVariable);
                }
                else
                {
                    ParseIntFailed();
                }

            } while (!(ParsingIntVariables(newVariable)));
            

            HoursWorked = int.Parse(newVariable);

            for (int i = 0; i < IP.Length; i++)
            {
                if (IP[i] == null)
                {
                    IP[i] = new HourlyEmployee(firstName, lastName, SSN, HourlyWage, HoursWorked);
                    break;
                }
            }
        }

        static void DisplaySalaryEmployees()
        {
            for (int i = 0; i < IP.Length; i++)
            {
                if (IP[i] == null)
                {
                    break;
                }

                if (IP[i].GetType() == LedgerType.Salaried)
                {
                    SalariedEmployee SE = (SalariedEmployee)IP[i];

                    Console.WriteLine("Salaried employee: " + SE.FirstName + " " + SE.LastName);
                    Console.WriteLine("SSN: " + (SE.SSN).Insert(5, "-").Insert(3, "-"));
                    Console.WriteLine("Weekly Salary: " + SE.GetPayableAmount.ToString("C"));
                    Console.WriteLine("Earned: " + SE.GetPayableAmount.ToString("C"));
                    Console.WriteLine("");
                }
            }
        }

        static void DisplayHourlyEmployees()
        {
            for (int i = 0; i < IP.Length; i++)
            {
                if (IP[i] == null)
                {
                    break;
                }

                if (IP[i].GetType() == LedgerType.Hourly)
                {
                    HourlyEmployee HE = (HourlyEmployee)IP[i];

                    Console.WriteLine("Hourly employee: " + HE.FirstName + " " + HE.LastName); ;
                    Console.WriteLine("SSN:" + (HE.SSN).Insert(5, "-").Insert(3, "-"));
                    Console.WriteLine("Hourly wage Salary: " + HE.HourlyPay.ToString("C"));
                    Console.WriteLine("Hours Worked: " + HE.TotalWorkHours);
                    Console.WriteLine("Earned: " + HE.Earnings().ToString("C"));
                    Console.WriteLine("");
                }
            }
        }

        static void DisplayInvoices()
            {
                for (int i = 0; i < IP.Length; i++)
                {
                    if (IP[i] == null)
                    {
                        break;
                    }

                    if (IP[i].GetType() == LedgerType.Invoice)
                    {
                        Invoice inv = (Invoice)IP[i];

                        Console.WriteLine("Invoice: " + inv.PartNumber); ;
                        Console.WriteLine("Quantity: " + inv.Quantity);
                        Console.WriteLine("Part Description: " + inv.PartDescription);
                        Console.WriteLine("Unit Price: " + inv.Price.ToString("C"));
                        Console.WriteLine("Extended Price: " + inv.GetPayableAmount.ToString("C"));
                        Console.WriteLine("");
                    }
                }
            }

        static void DisplayTotals()
        {
            for (int i = 0; i < IP.Length; i++)
            {
                if (IP[i] == null)
                {
                    break;
                }

                totalweekpayout = totalweekpayout + IP[i].GetPayableAmount;

                if(IP[i].GetType() == LedgerType.Invoice)
                {
                    totalinvoicepayout = totalinvoicepayout + IP[i].GetPayableAmount;
                }
                else if (IP[i].GetType() == LedgerType.Hourly)
                {
                    totalhourlypayout = totalhourlypayout + IP[i].GetPayableAmount;
                }
                else if(IP[i].GetType() == LedgerType.Salaried)
                {
                    totalsalarypayout = totalsalarypayout+ IP[i].GetPayableAmount;
                }


            }
                Console.WriteLine("Total Weekly Payout: " + totalweekpayout);
                Console.WriteLine("Category Breakdown:");
                Console.WriteLine("Invoices: " + totalinvoicepayout);
                Console.WriteLine("Salaried Payroll: " + totalsalarypayout);
                Console.WriteLine("Hourly Payroll: " + totalhourlypayout);
            
            
        }

        static void BadInput()
        {
            Console.WriteLine("Bad input please enter one of the following digits.");
            OptionsMenu();
            ConsoleKeyInfo newKey = Console.ReadKey();
            userInput = newKey;
        }

        static void PressKey()
        {
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
            Console.Clear();
        }

        static bool ParsingDecimalVariables(string testDecimal)
        {
            bool diddecimalwork = decimal.TryParse(testDecimal, out decimal decWorked);
            return diddecimalwork;
        }

        static bool ParsingIntVariables(string testInt)
        {
            bool didintwork = int.TryParse(testInt, out int intWorked);
            return didintwork;
        }

        static void ParseIntFailed()
        {
            do
            {
                Console.WriteLine("Bad input. Please enter a numbers only.");
                newVariable = Console.ReadLine();
                Console.Clear();

            } while (!ParsingIntVariables(newVariable));
        }

        static void ParseDecimalFailed()
        {

            do
            {
                Console.WriteLine("Bad input. Please enter a numbers only.");
                newVariable = Console.ReadLine();
                Console.Clear();

            } while (!ParsingDecimalVariables(newVariable));


        }
        


    }
}
 