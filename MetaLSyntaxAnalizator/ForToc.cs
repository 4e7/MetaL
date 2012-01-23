using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class ToKeyWordMissed : SyntaxError
    {
        public override string message()
        {
            return "Пропущенно ключевое слово To";
        }
    }
    public class ForTo:SyntaxExpression
    {
        public ForTo(SyntaxExpression e)
            : base(e)
        {
 
        }
        public override string go()
        {
            string register = "cx";
            string loop = "";
            string label = "LOOP" + root.loopCount.ToString() + ":";
            int loopCountQ = root.loopCount++; 
            
            string header = label;
             
           
            Assignment a=new Assignment(this.parent);
            string assignment =a.go() ;
            header+= "\tmov "+register+"," + a.indetifier.Data+"\n";
            Lexems.Lexema l = getToken();
            if (l == null || l.GetType().Name != "To")
            {
                addError(new ToKeyWordMissed(), 0);
                if (l != null) this.lexems.Add(l);
            }
            
            while ((l = getToken()) != null)
            {
                this.lexems.Add(l);
            }
            
            int position = m_tokenPosition;
            Expression e = new Expression(this);
            string expression=e.go();
            string condition = "\txor "+register+"," + e.result +"\n\tdec "+e.result+ "\n\tjnz " + label+"\n";
            m_tokenPosition = position;


            loop += ";----------Begin loop " + (loopCountQ).ToString() + "----------------\n";
            loop += assignment+"\n";
            loop += expression;
            loop += header;
            loop += "\t\tpush "+register+"\n";
            loop += "\t\tpush " + e.result + "\n";
            loop += e.calculations;
            loop += "\t\tpop "+register+"\n";
            loop += "\t\tpop " + e.result + "\n";
            loop += condition;
            loop += ";----------End loop " + (loopCountQ ).ToString() + "----------------\n";
            
            return loop;
        }
    }
}
