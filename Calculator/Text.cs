using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
    public class Text:RegexLexema<Text>
    {
        public Text() { m_regex = "\\w"; }
    }
}
