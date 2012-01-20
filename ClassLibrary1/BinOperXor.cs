using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLLexems
{
    public class BinOperXor:BinOper<BinOperXor>
    {
        public BinOperXor()
        { m_regex = "[\\^]"; }
    }
}
