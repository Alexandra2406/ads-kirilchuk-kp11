using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab6Var10
{
    public class HTMLParser
    {
        private LinkedListStack _tagsList;

        public HTMLParser()
        {
            _tagsList = new LinkedListStack();
        }

        public void ParseString(string code)
        {
            Regex reg = new Regex(@"<(\w|/)*>");
            MatchCollection matches = reg.Matches(code);
            foreach (Match match in matches)
            {
                if (!AddString(match.Value))
                    throw new Exception($"At {match.Index} position value {match.Value} is incorrect.");
            }
            if (!_tagsList.IsEmpty())
                throw new Exception("HTML code contains not closed tags");
        }

        public bool AddString(string str)
        {
            if(IsOpeningTag(str))
            {
                string tag = GetTagName(str);
                if (string.IsNullOrEmpty(tag))
                    return false;

                _tagsList.Push(tag);
                _tagsList.ConsoleOutput();
                return true;
            }
            else if(IsClosingTag(str))
            {
                string tag = GetTagName(str);
                if(!string.IsNullOrEmpty(tag) && _tagsList.Peek().Value == tag)
                {
                    _tagsList.Pop();
                    _tagsList.ConsoleOutput();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool IsOpeningTag(string str)
        {
            Regex reg = new Regex(@"^<\w+>$");
            return reg.IsMatch(str);
        }

        private bool IsClosingTag(string str)
        {
            Regex reg = new Regex(@"^</\w+>$");
            return reg.IsMatch(str);
        }

        private string GetTagName(string tag)
        {
            return new string(tag.Where(ch => Char.IsLetterOrDigit(ch)).ToArray());
        }

        public void ClearStack()
        {
            _tagsList.Clear();
        }
    }
}
