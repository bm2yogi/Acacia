using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Acacia.Controllers
{
    public class MonkeyController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            //CustomLogger.LogInfo("Entered Monkey.Get");
            //Thread.Sleep(5000);
            //CustomLogger.LogInfo("Exiting Monkey.Get");
            return new[] { "Woolly", "Spider", "Rhesus" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            if (id == 7)
            {
                throw new ApplicationException("You have thrown the robber.");
            }
            return "Capuchin";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
