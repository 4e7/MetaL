using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class Print:Expression
    {
        public Print(SyntaxExpression parent)
            : base(parent)
        { }
        public override string go()
        {
            Lexems.Lexema l = null;
            while ((l = getToken()) != null && l.GetType().Name != "Endl")
            {
                this.lexems.Add(l);
            }
            if (l == null)
            {
                addError(new EndlMissedError(), 0);
            }
            string operand = new Operand(this).go();
            return "\t------------------fake print of "+operand+" \n";
        }
    }
}
