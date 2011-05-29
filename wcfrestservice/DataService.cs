using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Epiworx.WcfRestService
{
    // Start the service and browse to http://<machine_name>:<port>/DataService/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class DataService
    {
        // TODO: Implement the collection resource that will contain the DataItem instances

        [WebGet(UriTemplate = "")]
        public List<DataItem> GetCollection()
        {
            // TODO: Replace the current implementation to return a collection of DataItem instances
            return new List<DataItem>() { new DataItem() { Id = 1, StringValue = "Hello" } };
        }

        [WebInvoke(UriTemplate = "", Method = "POST")]
        public DataItem Create(DataItem instance)
        {
            // TODO: Add the new instance of DataItem to the collection
            throw new NotImplementedException();
        }

        [WebGet(UriTemplate = "{id}")]
        public DataItem Get(string id)
        {
            // TODO: Return the instance of DataItem with the given id
            throw new NotImplementedException();
        }

        [WebInvoke(UriTemplate = "{id}", Method = "PUT")]
        public DataItem Update(string id, DataItem instance)
        {
            // TODO: Update the given instance of DataItem in the collection
            throw new NotImplementedException();
        }

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        public void Delete(string id)
        {
            // TODO: Remove the instance of DataItem with the given id from the collection
            throw new NotImplementedException();
        }

    }
}
