using System;

namespace PersonV2
{
    class Person : IComparable<Person>, IEquatable<Person>
    {
       #region Person Data
       public String FirstName { get; set; }
       public String LastName { get; set; }
       public string Address { get; set; }
       public string City { get; set; }
       public string State { get; set; }
       public string Zip { get; set; }
       #endregion Person Data
       
       public static int Count { get; set; }

        #region Constructors
        public Person()
        {
            Count++;        // keep track of how many persons have been created
        } // Default or no-arg Constructor

        public Person(String first, String last, String addr, String city, String st, string zip)
        { // constructor
            FirstName = first;
            LastName = last;
            Address = addr;
            City = city;
            State = st;
            Zip = zip;
            Count++;        // keep track of how many persons have been created
        } // Constructor
        #endregion Constructors

        public override string ToString() => string.Format($"{FirstName} {LastName} {Address} {City} {State} {Zip}");


        /*
         * The following method implements interface IEquatable<Person>
         * It does not put the name of the interface explictly with the name of the method.
         */
        // public bool Equals([AllowNull] Person other)     // in newer version of C#, null allowed.
        public bool Equals(Person other)
        {
            // if last names are the same check first names
            if (this.LastName.Equals(other.LastName))
            {
                if (this.FirstName.Equals(other.FirstName))
                {
                    // Both firstname and last names were equal.
                    // Zip determines the comparison.
                    return this.Zip == other.Zip;       // if equal, return true, else false.
                }
                else
                {   //Lastnames were equal, but firstnames were not.
                    return false;  // two objects are not same
                }
            }
            //Last names were not equal, different person
            return false;
        }

        /*
         * The following method implements interface IComparable<Person>
         * It does puts the name of the interface explictly with the name of the method.
         */
        public int CompareTo(Person other)
        {
            // if last names are the same compare first names
            if (this.LastName.Equals(other.LastName))
            {
                if (this.FirstName.Equals(other.FirstName))
                {
                    // Both firstname and last names were equal.
                    // Zip determines the comparison.
                    return this.Zip.CompareTo(other.Zip);
                }
                else
                {   //Lastnames were equal, but firstnames were not.
                    return this.FirstName.CompareTo(other.FirstName);
                }
            }
            //Last names were not equal
            return this.LastName.CompareTo(other.LastName);
        } // end CompareTo
    } // end Person Class
} // end namespace
