using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_ListOfObjects
// **************************************************
//
// Title: CIT195 ListOfObjects
// Description: Create custom object class
// Application Type: Console
// Author: Phinizy, Robin
// Dated Created: 1/11/2021
// Last Modified: 1/17/2021
//
// **************************************************
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Animal> ListAnimals = new List<Animal>();

            // call methods for adding and displaying objects. 
            AddObjects(ListAnimals);
            DisplayObjects(ListAnimals);
            SaveAnimals(ListAnimals);
        }
        private static void SaveAnimals(List<Animal> ListAnimals)
        {
            string dataPath = @"Data\animals.txt";
            string animalString;

            foreach (Animal animal in ListAnimals)
            {
                animalString = animal.Name + "," + animal.Age + "," + animal.IsExtinct + "," + animal.Food + Environment.NewLine;
                File.AppendAllText(dataPath, animalString);
            }

        }
        static void AddObjects(List<Animal> ListAnimals)
        {
            int count = 0;
            bool addAnother = true;
            string userResponse;
            string name;
            string food;
            int age;
            bool isExtinct;
            bool validResponse;
            string extinct;

            //*************
            // QUERY USER *
            //*************
            //user validation implemented
            do
            {
                validResponse = true;
                Console.WriteLine();
                Console.WriteLine("\t Would you like to add an Animal to the list?");
                userResponse = Console.ReadLine().ToLower();

                if (userResponse == "yes" || userResponse =="no")
                {
                    if (userResponse == "yes")
                        {
                        addAnother = true;
                        }
                    if (userResponse == "no")
                        {
                        addAnother = false;
                        }
                }
                else
                {
                  Console.WriteLine("\t Please enter a proper response option [ yes or no ]");
                  validResponse = false;
                }

                } while (!validResponse);
            
            //********************
            // CREATE NEW OBJECT *
            //********************
            //
            // use a while loop to give user ability to add as many objects as required. 
            while (addAnother == true)
            {
                // instanciate new Animal object with each cycle of the loop and store answers in a list. 
                ListAnimals.Add(new Animal());

                //
                //query user for new object traits
                //

                    //*******
                    // NAME *
                    //*******
                    Console.WriteLine("\t Enter Animal name");
                    name = Console.ReadLine();
                    ListAnimals[count].Name = name;

                    //*******
                    // AGE *
                    //*******
                    //user validation implemented
                    do
                    {
                        validResponse = true;
                        Console.WriteLine("\t Enter Animal age");
                        if (int.TryParse(Console.ReadLine(), out age))
                        {
                       
                            ListAnimals[count].Age = age;
                        }

                        else
                        {
                            Console.WriteLine("\t Please enter a proper integer");
                            validResponse = false;
                        }

                    } while (!validResponse);

                    //**********
                    // EXTINCT *
                    //**********
                    //user validation implemented
                    do
                    {
                        validResponse = true;
                        Console.WriteLine("\t Is this Animal extinct?");
                        extinct = Console.ReadLine().ToLower();
                    //
                    //convert user response string into a boolean varible to store in list.
                    if (extinct == "yes" || extinct == "no")
                    {
                        //
                        //convert user response string into a boolean varible to store in list.
                        if (extinct == "yes")
                        {
                            isExtinct = true;
                            ListAnimals[count].IsExtinct = isExtinct;
                        }
                        if (extinct == "no")
                        {
                            isExtinct = false;
                            ListAnimals[count].IsExtinct = isExtinct;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t Please enter a proper response option [ yes or no ]");
                        validResponse = false;
                    }

                    } while (!validResponse);

                //*******
                // DIET *
                //*******
                //user validation implemented
                do
                {
                    validResponse = true;
                    Console.WriteLine("\t What type of diet for this animal? (1. herbivore, 2. carnivore, 3. omnivore, 4.unknown)");
                    food = Console.ReadLine().ToLower();


                    if (food == "1" || food == "2" || food == "3" || food == "4")
                    {
                        // herbivore response
                        if (food == "1")
                        {
                            ListAnimals[count].Food = Animal.Diet.herbivore;
                        }

                        //carnivore response
                        if (food == "2")
                        {
                            ListAnimals[count].Food = Animal.Diet.carnivore;
                        }

                        //omnivore response
                        if (food == "3")
                        {
                            ListAnimals[count].Food = Animal.Diet.omnivore;
                        }

                        //unknown response
                        if (food == "4")
                        {
                            ListAnimals[count].Food = Animal.Diet.unknown;
                        }
                    }

                    else
                    {
                        Console.WriteLine("\tPlease enter a proper response option [ 1-4 ]");
                        validResponse = false;
                    }

                    //invalid response

                    //-----------------------------------------------
                    //alternate code method from class ENUM VALIDATION
                    //------------------------------------------------
                    //
                    //  if (Enum.TryParse(Console.ReadLine().ToLower(), out Animal.Diet food
                    //  {
                    //      animal.Diet = food;
                    //  }
                    //
                    //  else
                    //  {
                    //      Console.WriteLine("Please enter a proper diet");
                    //      foreach(Animal.Died name in Enum.GetValues(typeof(Animal.Diet)))
                    //      {
                    //          Console.Write("  |  " + name);
                    //      }
                    //      Console.WriteLine();
                    //  
                    //      validResponse = false;
                    //  }
                    //
                    //--------------------------------------------------
                    //--------------------------------------------------


                } while (!validResponse);

                count++;

                //**************************
                // ADD OBJECT LOOP CONTROL *
                //**************************
                Console.WriteLine("\t Would you like to add another Animal?");
                userResponse = Console.ReadLine().ToLower();
                //
                //convert user response string into a boolean varible.
                if (userResponse == "no")
                {
                    addAnother = false;
                }
                if (userResponse == "yes")
                {
                    addAnother = true;
                }
                else
                {
                    addAnother = false;
                }
            }
        }
       
        static void DisplayObjects(List<Animal> ListAnimals)
        {
            int count = 0;
            int ageTotal = 0;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t Your Animal List");
            Console.WriteLine("**************************************************");
            Console.WriteLine();

            Console.WriteLine(
              "Name".PadLeft(15) +
              "Age".PadLeft(15) +
              "Food".PadLeft(15)+
              "Extinct".PadLeft(15)
               );
            Console.WriteLine(
              "----".PadLeft(15) +
              "---".PadLeft(15) +
              "----".PadLeft(15) +
              "-------".PadLeft(15)
              );

            Console.WriteLine();

            foreach (Animal animal in ListAnimals)
            {
            Console.WriteLine(
              animal.Name.PadLeft(15) +
              animal.Age.ToString().PadLeft(15) +
              animal.Food.ToString().PadLeft(15)+
              animal.IsExtinct.ToString().PadLeft(15)
              );

             Console.WriteLine();
                count++;
                ageTotal = ageTotal + animal.Age;
            }
            Console.WriteLine();
            Console.WriteLine("\tFUN FACT: The average age of your animals is " +ageTotal/count);
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue");
            Console.ReadKey();

        }
    }

    
}

