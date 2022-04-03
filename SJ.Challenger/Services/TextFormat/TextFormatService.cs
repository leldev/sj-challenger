using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJ.Challenger.Services.TextFormat
{
    public class TextFormatService
    {
        private Dictionary<char, char> mappedEnclosingChars;

        public TextFormatService()
        {
            this.mappedEnclosingChars = this.GetMappedEnclosingChar();
        }

        public bool IsTextFormatted(string text)
        {
            var result = true;
            var expectedCloseingChars = new List<char>();

            foreach (var ch in text)
            {
                if (this.IsSpecialChar(ch))
                {
                    if (this.IsSpecialStartChar(ch))
                    {
                        expectedCloseingChars.Add(this.GetClosingChar(ch));
                    }
                    else
                    {
                        // Check if there is an expected closing char
                        if (expectedCloseingChars.Any() && ch.Equals(expectedCloseingChars.Last()))
                        {
                            expectedCloseingChars.RemoveAt(expectedCloseingChars.Count() - 1);
                        }
                        else
                        {
                            // Closing char does not match
                            return false;
                        }
                    }
                }
            }

            // Check if there are missing closing char
            result = !expectedCloseingChars.Any();

            return result;
        }
        Dictionary<char, char> GetMappedEnclosingChar()
        {
            // TODO: move to constants or get from args
            return new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };
        }

        private char GetClosingChar(char ch)
        {
            return this.mappedEnclosingChars[ch];
        }

        private bool IsSpecialChar(char ch)
        {
            return this.IsSpecialStartChar(ch) || this.IsSpecialEndChar(ch);
        }

        private bool IsSpecialStartChar(char ch)
        {
            return this.mappedEnclosingChars.ContainsKey(ch);
        }

        private bool IsSpecialEndChar(char ch)
        {
            return this.mappedEnclosingChars.ContainsValue(ch);
        }
    }
}
