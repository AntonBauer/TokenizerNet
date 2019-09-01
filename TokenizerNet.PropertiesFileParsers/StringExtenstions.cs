using System;

namespace TokenizerNet.PropertiesFileParsers
{
    public static class StringExtenstions
    {
        public static byte[] ConvertToByteArray(this string hexString)
        {
            var bytesLength = hexString.Length / 2;
            var bytes = new byte[bytesLength];

            for (var i = 0; i < bytesLength; i++)
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            return bytes;
        }
    }
}
