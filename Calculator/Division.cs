using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
    public class Division:RegexLexema<Division>
    {
        public Division() { m_regex = "[/]{1}"; }
    }
}
