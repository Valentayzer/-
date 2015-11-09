using System;
using System.IO;
using System.Text;

namespace SimpleAnalyzer
{
    class Analyzer
    {
        public Token CurrentToken { get; set; }
        private readonly StreamReader _streamReader;
        private int _column;
        private int _line;
        private char _currentChar;

        public Analyzer(string programPath)
        {
            _streamReader = new StreamReader(programPath);
            _column = 0;
            _line = 1;
            _currentChar = GetChar();
        }

        public bool NextToken()
        {
            while (Char.ToLower(_currentChar) < 'a' ||
                   Char.ToLower(_currentChar) > 'z')
            {
                // EOF
                if (_currentChar == (char)26) return false;

                _currentChar = GetChar();
            }

            CurrentToken = GetKeyWord(_line, _column);
            return true;
        }

        private Token GetKeyWord(int line, int column)
        {
            var keyWordBuilder = new StringBuilder();

            while ('a' <= Char.ToLower(_currentChar) && Char.ToLower(_currentChar) <= 'z')
            {
                keyWordBuilder.Append(Char.ToLower(_currentChar));
                _currentChar = GetChar();
            }

            return GetMatchedKeyWordToken(keyWordBuilder.ToString(), line, column);
        }

        private Token GetMatchedKeyWordToken(string keyWord, int line, int column)
        {
            switch (keyWord)
            {
                case "call":
                    return new CallToken(line, column);
                case "daa":
                    return new daaToken(line, column);
                default:
                    return new IdentifierToken(line, column, keyWord);
            }
        }

        private char GetChar()
        {
            var currentChar = _streamReader.Read();
            _column += currentChar == '\t' ? 4 : 1;

            switch (currentChar)
            {
                // LF
                case 10:
                    NextLine();
                    break;
                // CR
                case 13:
                    NextLine();
                    // If next char is LF
                    if (_streamReader.Peek() == 10)
                    {
                        _streamReader.Read();
                    }
                    break;
                case -1:
                    currentChar = 26;
                    break;
            }

            return (char)currentChar;
        }

        private void NextLine()
        {
            _line++;
            _column = 0;
        }
    }
}
