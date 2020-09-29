using System;
/***
 * Lab PersonV3
 * Adding to interfaces to model class and implementing the methods
 */

namespace PersonV2
{
    class PersonApp
    {
        static void Main(string[] args)
        {
            int MaxNumberOfPersons = 20;
           
            string inputFilename = @"..\..\..\Data\Person10Address.csv";  // go up 3 from .exe's location.
           
            DataController dc = new DataController(MaxNumberOfPersons, inputFilename);
            Console.WriteLine($"\nNumber of persons present from static count: {Person.Count}");

            //************************************************************
            Console.WriteLine("\n1. Display All");
            dc.DisplayAllPersons(); // display items
            //************************************************************

            String searchKey = "Jones";   // search for item
            //************************************************************
            Console.WriteLine($"\n2a. Find a person {searchKey}, using lastname.");
            //************************************************************            
            Person personFound;
            personFound = dc.FindPerson(searchKey);
            if (personFound != null)
            {
                Console.Write("Found ");
                Console.WriteLine(personFound); // personFound calls ToString Method.
            }
            else
                Console.WriteLine("Can't find " + searchKey);


            searchKey = "Valdez"; // search for item
            //************************************************************
            Console.WriteLine($"\n2b. Find a person {searchKey}, using lastname.");
            //************************************************************            
            personFound = null;
            personFound = dc.FindPerson(searchKey);
            if (personFound != null)
            {
                Console.Write("Found ");
                Console.WriteLine(personFound);
            }
            else
                Console.WriteLine("Can't find " + searchKey);


            //************************************************************
            Console.WriteLine($"\n3a. Compare 2 people.\n{dc.GetPerson(1)}\n{dc.GetPerson(8)}.");
            //************************************************************            
            if (dc.GetPerson(1).Equals(dc.GetPerson(8)))
            {
                Console.Write("Same person.");
            }
            else
                Console.WriteLine("The are not same person.");


            //************************************************************
            Console.WriteLine($"\n3b. Compare 2 people.\n{dc.GetPerson(0)}\n{dc.GetPerson(0)}.");
            //************************************************************            
            if (dc.GetPerson(0).Equals(dc.GetPerson(0)))
            {
                Console.Write("Same person.");
            }
            else
                Console.WriteLine("The are not same person.");
            Console.WriteLine();


            //************************************************************
            Console.WriteLine("\n4. Delete Miller, Brown, and Thompson");
            //************************************************************
            searchKey = "Miller";
            if (dc.DeletePerson(searchKey))
                Console.WriteLine($"Successfully deleted \"{searchKey}\"");
            else
                Console.WriteLine($"Not Found. Could not delete \"{searchKey}\"");

            searchKey = "Brown";
            if (dc.DeletePerson(searchKey))
                Console.WriteLine($"Successfully deleted \"{searchKey}\"");
            else
                Console.WriteLine($"Not Found. Could not delete \"{searchKey}\"");

            searchKey = "Thompson";
            if (dc.DeletePerson(searchKey))
                Console.WriteLine($"Successfully deleted \"{searchKey}\"");
            else
                Console.WriteLine($"Not Found. Could not delete \"{searchKey}\"");

            //************************************************************
            Console.WriteLine("\n5. Display all after deleting Miller, Brown and Thompson.");
            dc.DisplayAllPersons(); // display items again
            Console.WriteLine($"Number of people in the database {Person.Count}");
            //************************************************************

            //************************************************************
            Console.WriteLine("\n6. Insert Ethan Miller 233 Bakers Rd Canton OH 20021).");
            dc.InsertPerson("Ethan", "Miller", "233 Bakers Rd", "Canton", "OH", "20021");
            Console.WriteLine($"Number of people in the database {Person.Count}");
            //************************************************************


            //************************************************************
            Console.WriteLine("\n7. Sort all persons in the array and then display them");
            //************************************************************
            dc.BubbleSort();
            dc.DisplayAllPersons(); // display items again

        } // end main
    } // end Class PersonApp
}  // end namespace PersonV1
