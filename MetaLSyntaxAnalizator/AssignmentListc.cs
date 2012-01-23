using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    public class AssignmentList:SyntaxExpression
    {
        public AssignmentList (SyntaxExpression a):base(a)
        {
            
        }
        public override string go()
        {
            string s = "";
            Lexems.Lexema l=null;
            while ((l = getToken()) != null)
            {
                lexems.Add(l);
            }
            string assignment = null;
            while ((assignment = new Assignment(this).go()) != null)
            {
                s += assignment+"\n";
            }
            
            return s;
        }
    }
}
