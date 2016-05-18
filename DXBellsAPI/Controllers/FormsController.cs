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
using Newtonsoft.Json.Linq;

using DXBellsAPI.Models;

namespace DXBellsAPI.Controllers
{

    public class FormsController : ApiController
    {
        dynamic form = new JObject();

        //public const string hubURL = "https://dxbellhub.azure-devices.net/devices/{deviceId}/messages/events?api-version={api-version}";
        private DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=dxbellhub.azure-devices.net;DeviceId=NatePC;SharedAccessKey=WBL+Rx8wthxVVC8HatTzal45vrOzC8YpUowI/7/Yyo8=");
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
        public async void Post([FromBody] BellForm formValues)
        {
                        // Send message to DX Bell IoT Hub using IoT Hub SDK

            var contentmessage = JsonConvert.SerializeObject(formValues);
            try
            {
                var content = new Message(Encoding.UTF8.GetBytes(contentmessage));
                await deviceClient.SendEventAsync(content);

                Debug.WriteLine("Message Sent: {0}", formValues.Description, null);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception when sending message:" + e.Message);
            }
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

    }
}
