using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLLexems
{
    public class UnOperNot:UnOper<UnOperNot>
    {
        public UnOperNot()
        { m_regex = "[!]"; }
    }
}
