using System.Configuration;
using System.Text;

namespace SmartHouseTest.Infrastructure
{
    public class MessageManager
    {
        public void SendMessage<T>(T message)
        {
            Encoding encoding = ConfigurationManager.AppSettings["programEncoding"];
            string message = SerializationProvider.Serialize(message);
            byte[] byteArr = encoding.GetBytes(message);
            ConnectionManager.Send(byteArr)
        }
    }


}