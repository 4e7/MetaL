using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
   public class Plus:RegexLexema<Plus>
    {
        public Plus() { m_regex = "[+]{1}"; }
    }
}
