using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

namespace DXBellsAPI.Controllers
{
    public class FormsController : ApiController
    {
        //public const string hubURL = "https://dxbellhub.azure-devices.net/devices/{deviceId}/messages/events?api-version={api-version}";
       // private DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=dxbellhub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=NKNjKSZGc+fSd1WOD12Xnrtel+n6CFW+TpGgAis5s9E=");
        // GET api/forms
        [SwaggerOperation("GetAll")]
        public string Get()
        {
            return "The Forms Controller is available";
        }

        // GET api/forms/5
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/forms
        [SwaggerOperation("Create")]
        [SwaggerResponse(HttpStatusCode.Created)]
        public void Post([FromBody]string value)
        {
          //  SendMessage(value);
        }

        // PUT api/forms/5
        [SwaggerOperation("Update")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/forms/5
        [SwaggerOperation("Delete")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public void Delete(int id)
        {
        }

        //Send Message to IoT Hub
        [SwaggerOperation("SendMessage")]
        [SwaggerResponse(HttpStatusCode.OK)]
        public void SendMessage(string message)
        {
           // HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(hubURL);
            // Send message to DX Bell IoT Hub using IoT Hub SDK
            try
            {
                var content = new Message(Encoding.UTF8.GetBytes(""));
                //await deviceClient.SendEventAsync(content);

                Debug.WriteLine("Message Sent: {0}", message, null);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception when sending message:" + e.Message);
            }

        }
    }
}
