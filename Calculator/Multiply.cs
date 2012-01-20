using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
   public class Multiply:RegexLexema<Multiply>
    {
       public Multiply() { m_regex = "[*]{1}"; }
    }
}
