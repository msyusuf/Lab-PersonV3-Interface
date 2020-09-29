using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonV2
{
    static class PersonExtensions
    {
        // displayPerson
        public static void DisplayPerson(this Person p)
        {
            try
            {
                Console.WriteLine(
                    $"{p.FirstName,12} {p.LastName,-12} " +
                    $"{p.Address,15}, {p.City,8}, {p.State,2} {p.Zip}");

            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine($"{ne.Message}. Some records had null values.");
            }
        } // displayPerson
    }
}
