using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRESTService.Model
{
    public static class SampleData
    {
        // This array is purposely abbreviated for readability in this article.
        // The complete list of presidents is available in the source download.
        public static President[] SamplePresidents = new President[]
        {
            new President {
                Id =  "1", FirstName = "George", LastName = "Washington",
                EmailAddress = "gwashington@email.com" },
            new President {
                Id =  "2", FirstName = "John", LastName = "Adams",
                EmailAddress = "jadams@email.com" },
            new President {
                Id =  "3", FirstName = "Thomas", LastName = "Jefferson",
                EmailAddress = "tjefferson@email.com" },
            new President {
                Id =  "4", FirstName = "James", LastName = "Madison",
                EmailAddress = "jmadison@email.com" },
            new President {
                Id =  "5", FirstName = "James", LastName = "Monroe",
                EmailAddress = "jmonroe@email.com" },
            new President {
                Id = "43", FirstName = "George W.", LastName = "Bush",
                EmailAddress = "gbush@email.com" },
            new President {
                Id = "44", FirstName = "Barack", LastName = "Obama",
                EmailAddress = "bobama@email.com" },
        };
    }
}
