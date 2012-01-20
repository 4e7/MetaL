using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLLexems
{
    public class BinOperEqual:BinOper<BinOperEqual>
    {
        public BinOperEqual()
        { m_regex = "[=]"; }
    }
}
