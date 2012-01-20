using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
    public class CloseBracket:RegexLexema<CloseBracket>
    {
        public CloseBracket() { m_regex = "[)]{1}"; }
    }
}
