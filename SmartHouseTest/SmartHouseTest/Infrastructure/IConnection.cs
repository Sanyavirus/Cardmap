using System.Security.Cryptography.X509Certificates;

namespace SmartHouseTest.Infrastructure
{
    public interface IConnection
    {
        void SendMessage(string message);
        void GetMessage(byte[] message);
    }
}