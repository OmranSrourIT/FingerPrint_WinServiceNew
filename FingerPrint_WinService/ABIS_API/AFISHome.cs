using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web; 
using System.Net;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using FingerPrint_WinService;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Collections;
using FingerPrint_WinService.ABIS_API.JsonResult;
using FingerPrint_WinService.Modilty;
using Innovatrics.Sdk.Commons;
using System.IO;
using System.Drawing;
using System.Net.Http;

namespace WinS_ABIS_APi
{
    public class AFISHomeController : ApiController
    {


        // FingerPrint Segmentation
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage FingerPrintSegemntation([FromBody] object handString)
        {

            var Resultss = JsonConvert.SerializeObject(handString);
            var RempoveHand = Resultss.Remove(0, 8);
            var EndReuslt = RempoveHand.Remove(RempoveHand.Length - 1);

            HandSegmentation sample = new HandSegmentation();
            string responsHand = string.Empty;
            try
            {
                Hand handObj = JsonConvert.DeserializeObject<Hand>(EndReuslt);
                responsHand = sample.OneHandSegmentation(handObj);
            }
            catch (IEngineException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Request.CreateResponse(HttpStatusCode.OK, responsHand, Configuration.Formatters.JsonFormatter);
        }

        // // Thumbs Segmentation
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage SigmentationThumbs([FromBody] object thumbString)
        {

            var Resultss = JsonConvert.SerializeObject(thumbString);
            var RempoveHand = Resultss.Remove(1, 10);
            var EndReuslt = RempoveHand.Remove(RempoveHand.Length - 1);

            ThumbsSegmentation sample = new ThumbsSegmentation();
            string responsHand = string.Empty;
            try
            {
                Thumbs ThumbsObj = JsonConvert.DeserializeObject<Thumbs>(EndReuslt);
                responsHand = sample.OnThumbsSegmentation(ThumbsObj);
            }
            catch (IEngineException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Request.CreateResponse(HttpStatusCode.OK, responsHand, Configuration.Formatters.JsonFormatter);
        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CheackSerivceRuning([FromBody]object handString)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Serivce Runing", Configuration.Formatters.JsonFormatter);

        }

    }
}
