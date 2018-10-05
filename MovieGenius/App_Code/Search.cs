using System.ServiceModel.Activation;
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