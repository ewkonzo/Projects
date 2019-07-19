
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Mobilesasa
{
    public class sms
    {
        public token auth()
        { IRestResponse response;
            token t = new token();
            try
            {
                var client = new RestClient("https://account.mobilesasa.com/oauth/token");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", "{\n              \"grant_type\":\"client_credentials\",\n              \"client_secret\":\"iwO845qhJdMhKNLvzg2e0Bwg34ElL5R1CX0k9ujg\",\n              \"client_id\":\"19c154a0-2ada-11e9-bbb6-171d99e571c8\"\n     }", ParameterType.RequestBody);
                response = client.Execute(request);
              
                t = JsonConvert.DeserializeObject<token>(response.Content);
            }
            catch (Exception ex) {
            }
            return t;
        }
        public string sendsms(string phone, string text)
        {
         var a =   auth();
            smss s = new smss();
            s.senderID = "BANDARISACO";
            s.phone = phone;
            s.message = text;
            s.api_key = "$2y$10$ikvPFvsZKhsSg45/MzpX.OC92hM4T/7yZEMljEwB8rXxuYzfG7Gdm";

            var client = new RestClient("https://account.mobilesasa.com/api/post-sms");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer "+ a.access_token);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("undefined", new JavaScriptSerializer().Serialize(s), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public class token
        {
            public string token_type;
            public string expires_in;
            public string access_token;

        }
        public class smss
        {
            public string senderID;
            public string phone;
            public string message;
            public string api_key;
        }
    }
}
