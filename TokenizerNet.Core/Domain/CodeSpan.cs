namespace TokenizerNet.Core.Domain
{
    public struct CodeSpan
    {
        public byte[] Start { get; }

        public byte[] End { get; }

        public CodeSpan(byte[] start, byte[] end)
        {
            Start = start;
            End = end;
        }

        public CodeSpan(byte[] single) : this(single, single) { }

        public bool Contains(CodeSpan span)
        {
            return false;
        }
    }
}
