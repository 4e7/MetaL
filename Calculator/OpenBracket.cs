using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
    public class OpenBracket:RegexLexema<OpenBracket>
    {
        public OpenBracket() { m_regex = "[(]{1}"; }
    }
}
