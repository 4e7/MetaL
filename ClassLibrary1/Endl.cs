using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
namespace MetaLLexems
{
   public class Endl:RegexLexema<Endl>
    {
        public Endl() { m_regex = "[\\;]{1}"; }
    }
}
