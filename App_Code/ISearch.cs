using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace SearchService
{
    [ServiceContract(Name="Search", Namespace = "SearchService")]
    public interface ISearch
    {

        [OperationContract]
        [ServiceKnownType(typeof(Search))]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
        ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool addSession(string movieID);

    }
}