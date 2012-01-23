using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLLexems
{
    public class Print:Lexems.RegexLexema<Print>
    {
        public Print() {
            m_regex = "print";
        }
    }
}
