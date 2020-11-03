using System;

namespace assignment_2_cplaatjes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declares and sets the dinner selection variables, will probably make this an array later
            string dinner1 = "Italian Wedding Soup";
            string dinner2 = "Pepperoni Pizza";

            // Declares and sets the price of the dinners
            double costDinner1 = 8.50;
            double costDinner2 = 13.20;
            double taxRate = 0.13;

            double totalPrice = 0;
            double subTotal = 0;
            double total = 0;

            // Declare customer info variables
            string firstName;
            string lastName;
            string address;
            string city;
            string province;
            string postalCode;
            string phoneNum;
            string isStudent = "Empty";

            //Variables to store user input
            string selection = "None";
            double selectionCost = 0;
            double studentDiscount = 0;
            int itemNumber = 0;

            string orderConfirmed = "Empty";
            
            //Main order loop
            do {
                //Read customer information
                Console.WriteLine("Welcome to Arnold's Amazing Eats!");
                Console.Write("Please enter your first name: ");
                firstName = Console.ReadLine();
                Console.Write("Please enter your last name: ");
                lastName = Console.ReadLine();

                Console.Write("Please enter your address: ");
                address = Console.ReadLine();

                Console.Write("Please enter your city: ");
                city = Console.ReadLine();

                Console.Write("Please enter your Province: ");
                province = Console.ReadLine();

                Console.Write("Please enter your Postal Code: ");
                postalCode = Console.ReadLine();

                Console.Write("Please enter your Phone Number: ");
                phoneNum = Console.ReadLine();

                //Checks if the user is a student                
                Console.Write("Are you a student? (Y/N): ");
                do {
                    ConsoleKey input = Console.ReadKey(true).Key;

                    if(input == ConsoleKey.Y) {
                        isStudent = "Y";
                        break;
                    }
                    else if(input == ConsoleKey.N) {
                        isStudent = "N";
                        break;
                    }
                    else {
                        Console.WriteLine("\nPlease select Y or N: ");
                    }
                } while(!isStudent.Equals("Y") || !isStudent.Equals("N"));

                //Takes user input for meal selection
                Console.WriteLine("\n\nWelcome {0}! What meal would you like to order?", firstName);
                Console.WriteLine("1. {0}\n2. {1}", dinner1, dinner2);
                Console.Write("Make a selection: ");

                do {
                    ConsoleKey input = Console.ReadKey(true).Key;

                    if(input == ConsoleKey.D1 || input == ConsoleKey.NumPad1) {
                        selection = dinner1;
                        selectionCost = costDinner1;
                        break;
                    }
                    else if(input == ConsoleKey.D2 || input == ConsoleKey.NumPad2) {
                        selection = dinner2;
                        selectionCost = costDinner2;
                        break;
                    }
                    else {
                        Console.WriteLine("Please select Option 1 or 2.");
                    }
                } while(!selection.Equals(dinner1) || !selection.Equals(dinner2));

                Console.WriteLine("\nHow many {0}'s would you like?", selection);
                Console.Write("Enter Number: ");
                
                //Error check to see if the value was actually a numver
                while(itemNumber == 0) {
                    string input = Console.ReadLine();
                    if(int.TryParse(input, out itemNumber) == true) {
                        itemNumber = int.Parse(input);
                    }
                    else {
                        Console.Write("Enter a valid Number: ");
                    }
                }

                //Calculate the price before tax based on which dinner was selection and the amount
                if(selection.Equals(dinner1)) {
                    total = costDinner1 * itemNumber;
                }
                else if(selection.Equals(dinner2)) {
                    total = costDinner2 * itemNumber;
                }

                //Subtract 10% if the customer is a student
                if(isStudent.Equals("Y")) {
                    studentDiscount = total *  0.10;
                }
                else {
                    //Do nothing because the price doesn't need to be reduced
                }

                //Prints the receipt
                Console.WriteLine("Here is your receipt as follows: ");
                Console.WriteLine("\nCustomer Info" + "\n---------------------");
                Console.WriteLine("Name: \t\t{0} {1}", firstName, lastName);
                Console.WriteLine("Address: \t{0}", address);
                Console.WriteLine("City: \t\t{0}", city);
                Console.WriteLine("Province: \t{0}", province);
                Console.WriteLine("Postal Code: \t{0}", postalCode);
                Console.WriteLine("Phone #: \t{0}", phoneNum);

                Console.WriteLine("\n\t\t\t\tItem\t\tItem" + "\nOrder\t\t\tAmt\tPrice\t\tTotal" + "\n-------------\t\t----\t------\t\t--------");
                Console.WriteLine("\n{0}\t\t{1}\t${2:#0.00}\t\t ${3:###,##0.00}", selection, itemNumber, selectionCost, total);
                if(isStudent.Equals("Y")) {
                    Console.WriteLine("\n10% Student savings\t\t\t\t-${0:#0.00}", studentDiscount);
                }
                else if(isStudent.Equals("N"))
                {
                    Console.WriteLine("\nNo Student Savings\t\t\t\t $0");
                }

                //Calculate the subtotal
                subTotal = total - studentDiscount;


                Console.WriteLine("\t\t\t\tSub Total\t ${0:#0.00}", subTotal);
                Console.WriteLine("\t\t\t\tTax ({0}%)\t ${1:#0.00}", taxRate * 100, subTotal * taxRate);
                Console.WriteLine("\t\t\t\t\t\t---------");

                //Calculate the total price
                totalPrice = subTotal + (subTotal * taxRate);
                Console.WriteLine("\t\t\t\tTOTAL\t\t ${0:###,##0.00}", totalPrice);

                //Confirm order
                Console.Write("Is this information correct? Confirm (Y/N): ");
                do {
                    ConsoleKey input = Console.ReadKey(true).Key;

                    if(input == ConsoleKey.Y) {
                        orderConfirmed = "Y";
                        break;
                    }
                    else if(input == ConsoleKey.N) {
                        orderConfirmed = "N";
                        
                        //Resets variables to default values
                        totalPrice = 0;
                        subTotal = 0;
                        total = 0;
                        isStudent = "Empty";
                        selection = "None";
                        selectionCost = 0;
                        studentDiscount = 0;
                        itemNumber = 0;

                        break;
                    }
                    else {
                        Console.WriteLine("Please select Y or N");
                    }
                } while(!orderConfirmed.Equals("Y") || !orderConfirmed.Equals("N"));

            } while(orderConfirmed.Equals("N") || orderConfirmed.Equals("Empty"));

            Console.WriteLine("\n\nThank you for using Arnold's Amazing Eats! Your order is confirmed.");
        }
    }
}
