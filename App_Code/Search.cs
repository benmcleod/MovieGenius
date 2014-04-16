using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;


namespace SearchService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Search : ISearch
    {
        public bool addSession(string movieID)
        {
            HttpContext.Current.Session.Add("movieID", movieID);
            return true;
        }


    }
}