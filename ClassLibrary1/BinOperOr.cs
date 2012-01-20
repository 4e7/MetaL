using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLLexems
{
    public class BinOperOr:BinOper<BinOperOr>
    {
        public BinOperOr()
        { m_regex = "[|]"; }
    }
}
