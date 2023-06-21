using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
            //method with no return value
            static void dummyMethod(string name)
            {
                Console.WriteLine("My name is" + name);
            }

            //method with return value
            static int findSum(int a, int b)
            {
                return a + b;
            }
            static void Main(string[] args)
            {

                //polymorphism

                Animal myAnimal = new Animal();  
                Animal myPig = new Pig();  
                Animal myDog = new Dog();  

                myAnimal.animalSound();
                myPig.animalSound();
                myDog.animalSound();


                //constructors from book.cs


                Book book1 = new Book("harry potter","JK",800);
                Book book2 = new Book("Life of PI", "Anant SHarma", 400);
                Console.WriteLine(book1.pages);
                Console.WriteLine(book2.book);
                Book.BookCall();

                //inheritance from inheritance.cs


                Car myCar = new Car();
                myCar.honk();
                Console.WriteLine(myCar.brand + " " + myCar.modelName);
                Level myVar = Level.Medium;
                Console.WriteLine(myVar);

                //abstraction

                Settings myLang = new Settings();
                myLang.display1();
                myLang.display2();

                //interfaces

                Google myGoogle=new Google();
                myGoogle.companyMotto();

                //enum 
                Level temp = Level.Medium;
                Console.WriteLine(temp);

                Months april = Months.April;
                Console.WriteLine(april);


                //properties
                College pa = new College("PA College of Engineering","Manglore");
                Console.WriteLine("I am from " + pa.collegeName);
                pa.Place = "Kasargod";
                Console.WriteLine("I am from " + pa.Place);

                //variables
                dummyMethod("Nazal");
                Console.WriteLine(findSum(29, 23));

                int age = 25; //variable of type number

                //string operations

                string name = "Nazal";//variable of type string
                Console.WriteLine("Hello World");
                Console.WriteLine(name.Length);
                Console.WriteLine(name.ToLower());
                Console.WriteLine(name.ToUpper());
                Console.WriteLine(name.Length);
                Console.WriteLine("My name is " + name);
                Console.WriteLine("I am " + age + " years old");

                //concat

                string firstName = "Nazal ";
                string lastName = "Iqbal";
                string name1 = string.Concat(firstName, lastName);
                Console.WriteLine(name1);

                //interpolation

                string name2 = $"My full name is: {firstName} {lastName}";
                Console.WriteLine(name2);

                //getting user input and store in variable
                //Console.WriteLine("Enter username:");

                //string userName = Console.ReadLine();

                //Console.WriteLine("Username is: " + userName);

                //Console.WriteLine("Enter your age:");
                //int myAge = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Your age is: " + myAge);

                //c# math
                int x = 5;
                int y = 10;
                Console.WriteLine(Math.Max(x, y));
                Console.WriteLine(Math.Min(x, y));
                Console.WriteLine(Math.Sqrt(49));

                //boolean 

                bool isTurned = true;
                bool isCalled = false;
                Console.WriteLine(isTurned);
                Console.WriteLine(isCalled);

                int a = 10;
                int b = 9;
                Console.WriteLine(a > b);

                //  if/else

                int eligible = 18;
                if (eligible > 18)
                {
                    Console.WriteLine("old enough to vote");
                }
                Console.WriteLine("not old enough  to vote");

                //switch statement

                int day = 0;
                switch (day)
                {
                    case 1:
                        Console.WriteLine("Monday");
                        break;
                    case 2:
                        Console.WriteLine("Tuesday");
                        break;
                    case 3:
                        Console.WriteLine("Wednesday");
                        break;
                    case 4:
                        Console.WriteLine("Thursday");
                        break;
                    case 5:
                        Console.WriteLine("Friday");
                        break;
                    case 6:
                        Console.WriteLine("Saturday");
                        break;
                    case 7:
                        Console.WriteLine("Sunday");
                        break;
                    default:
                        Console.WriteLine("Nothing");
                        break;

                }

                // while 

                int i = 0;
                while (i < 3)
                {
                    Console.WriteLine(i);
                    i++;
                }

                //for

                int[] salaries = { 2500, 3500, 4500, 3000, 4000 };

                // Calculate the total salary using a for loop
                int totalSalary = 0;

                for (int s = 0; s < salaries.Length; s++)
                {
                    totalSalary += salaries[s];
                }
                Console.WriteLine("Total salary: " + totalSalary);

                //foreach

                ////string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
                ////foreach (string car in cars)
                ////{
                ////    Console.WriteLine(car);
                ////}

                //break

                for (int n = 0; n < 10; n++)
                {
                    if (n == 4)
                    {
                        break;
                    }
                    Console.WriteLine(n);
                }

                //Arrays

                string[] brand = { "Volvo", "BMW", "Ford", "Mazda" };
                Console.WriteLine(brand.Length);
                brand[0] = "Opel";
                Console.WriteLine(brand[0]);

                //loop through an array

                string[] cars1 = { "benzz", "BMW", "Ford", "Mazda" };
                for (int c = 0; c < cars1.Length; c++)
                {
                    Console.WriteLine(cars1[c]);
                }



                int[] salaryEmp = { 200, 300, 500, 600 };
                totalSalary = 0;
                foreach (int salary in salaryEmp)
                {
                    totalSalary += salary;

                }
                Console.WriteLine("total salary is " + totalSalary);

                ////calculator

                //Console.WriteLine("Enter first number:");
                //double firstNo = Convert.ToDouble(Console.ReadLine());

                //Console.WriteLine("Enter second number:");
                //double secondNo = Convert.ToDouble(Console.ReadLine());

                //Console.WriteLine("Enter Operator:");
                //string operatorName = Console.ReadLine();

                //double result = Calculator.Calculate(firstNo, secondNo, operatorName);

                //Console.WriteLine("Result: " + result);


                ////guessing game 

                //GuessingGame.Play();

            Console.ReadLine();
            }
        }
    }

