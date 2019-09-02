namespace TokenizerNet.Core.Domain
{
    public struct CodeSpan
    {
        public int Start { get; }

        public int End { get; }

        public CodeSpan(int start, int end)
        {
            // ToDo use int instead of byte[]
            //var test = 0xff66;

            Start = start;
            End = end;
        }

        public CodeSpan(int singlePosition) : this(singlePosition, singlePosition) { }

        public bool Contains(CodeSpan span) => Start <= span.Start && End <= span.End;
    }
}
