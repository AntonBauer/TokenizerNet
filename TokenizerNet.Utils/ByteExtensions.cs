namespace TokenizerNet.Utils
{
    public static class ByteExtensions
    {
        public static bool IsGreaterThan(this byte[] first, byte[] second)
        {
            if (first.Length > second.Length)
                return true;

            if (first.Length < second.Length)
                return false;

            for(var i = 0; i < first.Length; i++)
                if (first[i] > second[i])
                    return true;

            return false;
        }

        public static bool IsLessThan(this byte[] first, byte[] second)
        {
            if (first.Length > second.Length)
                return false;

            if (first.Length < second.Length)
                return true;

            for (var i = 0; i < first.Length; i++)
                if (first[i] < second[i])
                    return true;

            return false;
        }

        public static bool IsEqualTo(this byte[] first, byte[] second)
        {
            if (first.Length != second.Length)
                return false;

            for (var i = 0; i < first.Length; i++)
                if (first[i] != second[i])
                    return false;

            return true;
        }
    }
}
