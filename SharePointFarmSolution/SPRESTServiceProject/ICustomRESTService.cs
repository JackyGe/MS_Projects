using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using SPRESTService.Model;

namespace SPRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICustomRESTService
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllPresidents")]
        List<President> GetAllPresidents();

        [OperationContract(Name ="GetPresidentsByLastName")]
        [WebGet(ResponseFormat =WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate ="GetPresidentsByLastName/{lastName}")]
        List<President> GetPresidentsByName(string lastName);

        [OperationContract(Name ="GetPresidentsByLastFirstName")] //returned JSON: {"GetPresidentsByLastFirstNameResult":[{"EmailAddress":"jmadison@email.com","FirstName":"James","Id":"4","LastName":"Madison"}]}
        [WebGet(ResponseFormat =WebMessageFormat.Json, BodyStyle =WebMessageBodyStyle.Wrapped, UriTemplate = "GetPresidentsByFirstName/{lastName}/{firstName}")]
        List<President> GetPresidentsByName(string lastName, string firstName);
        

        [OperationContract]
        [WebGet(ResponseFormat =WebMessageFormat.Json, UriTemplate ="GetPresidentById/{Id}")]
        President GetPresidentById(string Id);

        [OperationContract]
        [WebInvoke(ResponseFormat =WebMessageFormat.Json, UriTemplate ="AddPresident", Method="POST", RequestFormat =WebMessageFormat.Json)]
        bool AddPresident(President president);
    }
}
