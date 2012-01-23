using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class BinaryOperatorOperandMissed : SyntaxError
    {
        public override string message()
        {
            return "Бинарный оператор должен принимать в качестве операнда выражение.";
        }
    }
    class BinaryOperator:Expression
    {
        public BinaryOperator(SyntaxExpression a)
            : base(a)
        { }
        string isBinaryOperand(Lexems.Lexema l)
        {
            if (l == null) return null;
            switch (l.GetType().Name)
            {
                case "BinOperAnd":
                    return "and";
                case "BinOperOr":
                    return "or";
                case "BinOperXor":
                    return "xor";
                default:
                    return null;

            }
        }
        public string command=null;
        public override string go()
        {
            Lexems.Lexema l=null;
            this.result = "ax";
            string s=null;

            while ((l = getToken()) != null && (this.command = isBinaryOperand(l)) == null)
            {
                if (l.GetType().Name == "Begin")
                {
                    
                        this.lexems.Add(l);

                        while ((l = getToken()) != null)
                        {
                            this.lexems.Add(l);
                        }

                    
                    Operand o = new Operand(this);
                    string operand = o.go();
                    this.result = operand;
                    this.calculations = o.calculations;
                    return "\n";
                    
                }
                this.lexems.Add(l);
            }
            if (l == null)
            {

                Operand o =new Operand(this);
                string operand = o.go();
                calculations = o.calculations;
                if (operand != null)
                {
                    
                    
                }
                else
                {
                    addError(new BinaryOperatorOperandMissed(), 0);
                }
                return "\tmov ax," + operand+"\n"; 
            }
            SubExpression eL = new SubExpression(this);
            string lOperand = eL.go();
            
            while ((l = getToken()) != null )
            {
                this.lexems.Add(l);
            }

            SubExpression eR = new SubExpression(this);
            string rOperand = eR.go();

            if (lOperand == null||rOperand==null)
            {
                addError(new BinaryOperatorOperandMissed(), 0);
            }
            else
            {
                this.result="ax";
                s = lOperand + "\n";
                s += "\tmov ax," + eL.result+"\n";
                s += rOperand + "\n";
                s += "\t" + command + " ax," + eR.result+"\n";

            }
            return s;
        }
    }
}
