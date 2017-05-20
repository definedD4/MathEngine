using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEngine.Core.StringFormat.Parse
{
    public class Tokenizer
    {
        public Tokenizer()
        {
        }

        public IEnumerable<Token> Tokenize(string input)
        {
            foreach (var part in Split(input))
            {
                if (part == "[")
                {
                    yield return new OpenBrackets();
                }
                else if (part == "]")
                {
                    yield return new CloseBrackets();
                }               
                else
                {
                    decimal val;
                    bool numeric = decimal.TryParse(part, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                        NumberFormatInfo.InvariantInfo, out val);
                    if (numeric)
                    {
                        if ((decimal) ((int) val) == val)
                        {
                            yield return new Integer((int) val);
                        }
                        else
                        {
                            yield return new Decimal(val);
                        }
                    }
                    else
                    {
                        yield return new Identifier(part);
                    }
                }
            }
        }

        private IEnumerable<string> Split(string input)
        {
            var buffer = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',')
                {
                    if (buffer.Length != 0)
                    {
                        yield return buffer.ToString();
                        buffer.Clear();
                    }
                }
                else if (input[i] == '[' || input[i] == ']')
                {
                    if (buffer.Length != 0)
                    {
                        yield return buffer.ToString();
                        buffer.Clear();
                    }
                    yield return input[i].ToString();
                }
                else if (input[i] == ' ')
                {
                    continue;
                }
                else
                {
                    buffer.Append(input[i]);
                }
            }
            if (buffer.Length != 0)
            {
                yield return buffer.ToString();
            }
        }
    }
}

