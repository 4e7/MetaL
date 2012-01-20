using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
   public class Minus:RegexLexema<Minus>
    {
        public Minus() { m_regex = "[-]{1}"; }
    }
}
