using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

using SPRESTService.Model;

namespace SPRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CustomRESTService : ICustomRESTService
    {
        #region Private Members

        private List<President> _presidents;
        private List<President> Presidents
        {
            get
            {
                _presidents = _presidents ?? new List<President>(SampleData.SamplePresidents);
                return _presidents;
            }        
        }

        #endregion

        #region ISPRESTService Implementation

        public List<President> GetAllPresidents()
        {
            return Presidents;
        }

        public List<President> GetPresidentsByName(string lastName)
        {
            return GetPresidentsByName(lastName, string.Empty);
        }

        public List<President> GetPresidentsByName(string lastName, string firstName)
        {
            var query = from President p in Presidents
                        where p.LastName.ToLower().Contains(lastName.ToLower())
                            && (string.IsNullOrWhiteSpace(firstName)
                                ? true
                                : p.FirstName.ToLower().Contains(firstName.ToLower()))
                        select p;

            return query.ToList();
        }

        public President GetPresidentById(string id)
        {
            var query = from President p in Presidents
                        where p.Id == id
                        select p;
            return query.FirstOrDefault();
        }

        public bool AddPresident(President president)
        {
            Presidents.Add(president);
            return true;
        }

        #endregion
    }
}
