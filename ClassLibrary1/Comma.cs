using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
namespace MetaLLexems
{
   public class Comma:RegexLexema<Comma>
    {
        public Comma()
        {
            m_regex = "[\\,]{1}";
        }
    }
}
