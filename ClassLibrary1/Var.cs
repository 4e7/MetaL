using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lexems;
namespace MetaLLexems
{
    public class Var:KeyWord<Var>
    {
        public Var()
        { m_regex = "Var"; }
    }
}
