using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    public class AssignmentList:SyntaxExpression
    {
        public AssignmentList (Analizator a):base(a)
        {
            
        }
        public override string go()
        {
            string s = null;
            string assignment=new Assignment(analizator).go();
            if (assignment != null)
            {
                s += assignment;
                string next = new AssignmentList(analizator).go();
                if (next != null) s += next;
            }
            
            return s;
        }
    }
}
