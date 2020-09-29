using System;
using System.IO;

namespace PersonV2
{
    class DataController
    {
        private readonly int maxSize;       // array size
        public Person[] arr;                // reference to array
        public int NumElems { get; private set; }
        private readonly string inputFilePath;      // must be initialized in the constructor.

        public DataController(int arrSize, string path) // constructor
        {
            try
            {
                maxSize = arrSize;
                arr = new Person[maxSize];  // create the array
                NumElems = 0;                 // no items yet
                inputFilePath = path;
                NumElems = LoadData(inputFilePath);

            }
            catch (Exception e)
            {
                Console.WriteLine(
                    $"An exception occurred in the constructor\r\n" +
                    $"Type: {e.GetType()}\r\nMessage: {e.Message}\r\n{e.StackTrace}");
                System.Environment.Exit(-1);
            }
        } // no-arg constructor

        public int LoadData(string path)
        {
            string lineOfData;
            string[] words;
            int count = 0;

            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                throw new FileNotFoundException();
            }
                
            
            //Clear the array first.
            Array.Clear(arr, 0, maxSize - 1); //name, starting index, last index
            NumElems = 0;
            StreamReader reader;
            Person p;


            reader = new StreamReader(path);
            do
            {
                try
                {
                    lineOfData = reader.ReadLine();
                    words = lineOfData.Split(new string[] { ",", ", " }, StringSplitOptions.RemoveEmptyEntries);

                    p = new Person(words[0], words[1], words[2], words[3], words[4], words[5]);
                    arr[count++] = p;
                    // Console.WriteLine($"{Person.Count,6} - {lineOfData}");

                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    if (reader != null)
                        reader.Close();
                    Environment.Exit(0);
                }

                catch (FileLoadException e)
                {
                    Console.WriteLine(e.Message);
                    if (reader != null)
                        reader.Close();
                    Environment.Exit(0);
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine($"Input has wrong number of records. {e.GetType()}\n{e.Message}");
                    // Environment.Exit(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.GetType()}\n{e.Message}");
                    if (reader != null)
                        reader.Close();
                    Environment.Exit(0);
                }

                // Console.WriteLine($"Number of records read: {count}"); 
            } while (reader.Peek() != -1);

            if (reader != null)
                reader.Close();
            return count;


        } // end loadData

        /***
         * GetPerson
         * Returns the person at that index
         */
        public Person GetPerson(int index)
        {
            return arr[index];
        }

        /***
         * Method FindPerson. Overloaded. Uses a last name as an argument.
         * Searches for a person in the array. If person is found,
         * it is returned, else it returns a null.
         */
        public Person FindPerson(string searchName)
        { // find specified value
            int j;
            for (j = 0; j < NumElems; j++)
            {
                if (arr[j].LastName.Equals(searchName)) // found item?
                    break;      // exit loop before end
            }

            // If we are here and count is 1 pass the last index,
            // then we couldn't find it, exit the method.                        
            if (j == NumElems)    // gone to end?
                return null;    // yes, can't find it
            else
                return arr[j];  // no, found it
        } // end Find

        /***
         * Method FindPerson. Overloaded. Uses a Person as an argument.
         * Searches for a person in the array. If person is found,
         * it is returned, else it returns a null.
         */
        public Person FindPerson(Person otherPerson)
        { // find specified value
            int j;
            for (j = 0; j < NumElems; j++)
            {
                if (arr[j].Equals(otherPerson)) // found item?      // to use of Equals method of IEquatable
                    break;      // exit loop before end
            }

            // If we are here and count is 1 pass the last index,
            // then we couldn't find it, exit the method.            
            if (j == NumElems)    // gone to end?
                return null;    // yes, can't find it
            else
                return arr[j];  // no, found it
        } // end Find

        /***
         * Method Insert
         * Inserts a person in the array.
         * Increments the number of persons in the array.
         */

        public void InsertPerson(string first, string last, string addr, string city, string st, string zip)
        {
            arr[NumElems++] = new Person(first, last, addr, city, st, zip); // increment NumElems after inserting new person
            return;
        }

        /***
         * Method DeletePerson
         * Deletes a person from the array.
         * Decrements the number of persons in the array.
         */
        public bool DeletePerson(string searchName)
        { // delete person from array
            int j;
            for (j = 0; j < NumElems; j++)
            {
                // look for it. If found, exit loop.
                if (arr[j].LastName.Equals(searchName))
                    break;
            }

            // If we are here and count is 1 pass the last index,
            // then we couldn't find it, exit the method.
            if (j == NumElems)
            {
                return false;
            }
            // found it. Overwrite the existing item with the next one
            // and move each item up by one. Decrement the count of 
            // persons in the array
            else
            {
                for (int k = j; k < NumElems; k++)
                {
                    arr[k] = arr[k + 1];
                }

                NumElems--; // decrement size
                Person.Count--;                 // Note use of class instead of object
                return true;
            }
        } // end delete()

        /***
         * Method DisplayAllPersons
         * Displays all the persons from the array.
         */
        public void DisplayAllPersons() // displays array contents
        {
            for (int j = 0; j < NumElems; j++)
            {
                Console.WriteLine($"{(j + 1),2} {arr[j]})");
            }
        }

        /***
        * Method BubbleSort
        * Displays all the persons from the array.
        */
        public void BubbleSort()
        {
            int outter, inner;
            Person temp;

            for (outter = NumElems - 1; outter > 0; outter--) // outer loop (backward)
            {
                for (inner = 0; inner < outter; inner++) // inner loop (forward)
                {
                    if (arr[inner].CompareTo(arr[inner + 1]) > 0)
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                    }
                } // inner for loop
            } // outer for loop
        } // end bubbleSort()	


        /*
        public void SaveData()
        {
            string sPath = @"..\..\..\";
            string sNewFile = "Person200Age_output.txt";

            DateTime dt = DateTime.Now;
            string dateTimeNow = dt.ToString();
            StreamWriter writer = new StreamWriter(sPath + sNewFile);
            writer.WriteLine(dateTimeNow);
            // You can also use count to decide how many persons to print.
            int i = 0;
            foreach (var person in arr)
            {
                if (person != null)
                    writer.WriteLine($"{++i,4} {person}");
            }
            writer.Close();
        }
        */
    }
}
