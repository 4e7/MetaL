using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class KeyWordBeginMissed : SyntaxError
    {
        public override string message()
        {
            return "Пропущенно ключевое слово Begin";
        }
    }
    class KeyWordEndMissed : SyntaxError
    {
        public KeyWordEndMissed()
        { 
        }
        public override string message()
        {
            return "Пропущенно ключевое слово End";
        }
    }
    public class CalculationsDescription:SyntaxExpression
    {
        public CalculationsDescription(SyntaxExpression a)
            : base(a)
        {
            
            
        }
        protected List<Lexems.Lexema> findEnd()
        {
            List<Lexems.Lexema> ll = new List<Lexems.Lexema>();
            Lexems.Lexema l = null;
            while ((l = getToken()) != null && l.GetType().Name != "End")
            {
                ll.Add(l);
            }
            if (l != null)
            {
                ll.Add(l);
                ll.AddRange(findEnd());
            }
            return ll;
        }
        public override string go()
        {

            string s = "";
            Lexems.Lexema l = getToken();
            Lexems.Lexema fl = l;
            if (l!=null&&l.GetType().Name == "Begin")
            {
                s = "";
                
            }

            else
            {
                
                addError(new KeyWordBeginMissed(), 0);

            }
            this.lexems.AddRange(findEnd());
            if (lexems.Count > 0)
            {
                l = lexems.Last();

                lexems.RemoveAt(lexems.Count - 1);
            }
            if (l == null || l.GetType().Name != "End")
            {
                addError(new KeyWordEndMissed(), 0);
            }
            else
            {
                
            }

            string assignmentsList = new AssignmentList(this).go();
            if (assignmentsList != null)
            {
                s += assignmentsList + "\n";
            }

            
           
            return s;
        }
    }
}
