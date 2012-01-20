using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLLexems
{
    public class BinOperAnd:BinOper<BinOperAnd>
    {
        public BinOperAnd()
        { m_regex = "[&]"; }
    }
}
