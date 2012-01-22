using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;

namespace MetaLLexems
{
    public class Identifire:RegexLexema<Identifire>
    {
        public Identifire()
        { m_regex = "[A-Za-z]*";} 
    }
}
