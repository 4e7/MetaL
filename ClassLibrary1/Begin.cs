using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;

namespace MetaLLexems
{
    public class Begin:KeyWord<Begin>
    {
        public Begin()
        { m_regex = "Begin"; }
    }
}
