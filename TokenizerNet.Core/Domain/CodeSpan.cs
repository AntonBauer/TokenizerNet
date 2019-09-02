using TokenizerNet.Utils;

namespace TokenizerNet.Core.Domain
{
    public struct CodeSpan
    {
        public byte[] Start { get; }

        public byte[] End { get; }

        public CodeSpan(byte[] start, byte[] end)
        {
            Start = start.Length == 1 ? new byte[] { 0, start[0]} : start;
            End = end.Length == 1 ? new byte[] { 0, end[0] } : end;
        }

        public CodeSpan(byte[] single) : this(single, single) { }

        public bool Contains(CodeSpan span)
        {
            var isStartLess = Start.IsLessThan(span.Start) || Start.IsEqualTo(span.Start);
            var isEndGreater = End.IsGreaterThan(span.End) || End.IsEqualTo(span.End);

            return isStartLess && isEndGreater;
        }
    }
}
