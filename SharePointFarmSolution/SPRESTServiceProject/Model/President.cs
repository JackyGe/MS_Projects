using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SPRESTService.Model
{
    [DataContract]
    public class President
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}
