using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;

namespace MetaLLexems
{
    public class End:KeyWord<End>
    {
        public End()
        { m_regex = "End"; }
    }
}
