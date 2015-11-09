namespace SimpleAnalyzer
{
    class Token
    {
        protected readonly int Line;
        protected readonly int Column;

        public Token(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }

    class UnknownToken : Token
    {
        public UnknownToken(int line, int column) : base(line, column) { }

        public override string ToString()
        {
            return "unknown";
        }
    }

    class CallToken : Token
    {
        public CallToken(int line, int column) : base(line, column) { }

        public override string ToString()
        {
            return "call: line " + Line + " column " + Column;
        }
    }

    class IdentifierToken : Token
    {
        private readonly string _procedureName;
        public IdentifierToken(int line, int column, string procedureName)
            : base(line, column)
        {
            _procedureName = procedureName;
        }

        public override string ToString()
        {
            return "identifier: value " + _procedureName + " line " + Line + " column " + Column;
        }
    }

    class daaToken : Token
    {
        public daaToken(int line, int column) : base(line, column) { }

        public override string ToString()
        {
            return "da a: line " + Line + " column " + Column;
        }
    }
}
