namespace SmartHouseTest.StateMachine
{
    public class BitConverter
    {
        public static byte[] GetBytes(short value)
        {
            byte[] bytes = new byte[2];

            bytes[0] = (byte)(value >> 8);
            bytes[1] = (byte)value;

            return bytes;
        }

    }
}