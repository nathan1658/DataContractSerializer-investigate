using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WcfServiceTest;

namespace WcfTest
{
    public class Maina
    {
        public static void Main(string[] args)
        {
            //var binding = new BasicHttpBinding();
            //var endpoint = new EndpointAddress("http://localhost:4723/Service1.svc");
            //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate {
            //    return true;
            //};
            //var channelFactory = new ChannelFactory<IService1>(binding, endpoint);
            //var inspector = new InspectorBehavior();
            //channelFactory.Endpoint.Behaviors.Add(inspector);
            //IService1 svc = channelFactory.CreateChannel();
            //var ass = svc.GetClassA();

            //var aaa = inspector.LastRequestXML;
            //var bbb = inspector.LastResponseXML;
            ClassA ass = null;
            if (!true)
            {

                FileStream writer = new FileStream("./tmp.xml", FileMode.Create);
                DataContractSerializer ser = new DataContractSerializer(typeof(ClassA));
                ser.WriteObject(writer, ass);
                writer.Close();
            }
            else
            {
                FileStream fs = new FileStream("./tmp.xml", FileMode.Open);
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(ClassA));

                // Deserialize the data and read it from the instance.
                ass = (ClassA)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
            }



        }
    }
    public class InspectorBehavior : IEndpointBehavior
    {
        public string LastRequestXML
        {
            get
            {
                return myMessageInspector.LastRequestXML;
            }
        }

        public string LastResponseXML
        {
            get
            {
                return myMessageInspector.LastResponseXML;
            }
        }


        private MyMessageInspector myMessageInspector = new MyMessageInspector();
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }


        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(myMessageInspector);
        }
    }





    public class MyMessageInspector : IClientMessageInspector
    {
        public string LastRequestXML
        {
            get; private set;
        }
        public string LastResponseXML
        {
            get; private set;
        }
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            LastResponseXML = reply.ToString();
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            LastRequestXML = request.ToString();
            return request;
        }
    }
}
