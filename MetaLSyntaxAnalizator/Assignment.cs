using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    public class Assignment:SyntaxExpression
    {
        public Assignment(Analizator a):base(a)
        {
            
        }
        public override string go()
        {
            string s = "assignment\n";
            return s;
        }
    }
}
