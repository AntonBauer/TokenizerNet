namespace TokenizerNet.Core.Domain
{
    public struct CodeSpan
    {
        public int Start { get; }

        public int End { get; }

        public CodeSpan(int start, int end)
        {
            Start = start;
            End = end;
        }

        public CodeSpan(int singlePosition) : this(singlePosition, singlePosition) { }

        public bool Contains(CodeSpan span) => Start <= span.Start && span.End <= End;
    }
}
