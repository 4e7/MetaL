using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;

namespace MetaLLexems
{
    public class Const:RegexLexema<Const>
    {
        public Const()
        { m_regex = "[10]?"; }
    }
}
