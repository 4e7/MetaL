using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    class CommaOrEndlMissedError : SyntaxError
    {
        public override string message()
        {
            return "Требуется , или ;";
        }
    }
    class IndetifireRedefinitionError : SyntaxError
    {
        string m_name;
        public IndetifireRedefinitionError(string name)
        {
            m_name = name;
        }
        public override string message()
        {
            return "Переопределение интендификатора " + m_name;
        }
    }

    class IndetifierMissedError : SyntaxError
    {
        public override string message()
        {
            return "Пропущен интендификатор";
        }
    }
    public class VariableList:SyntaxExpression
    {
        public VariableList(SyntaxExpression a)
            : base(a)
        {
            
        }
        public override string go()
        {
            
            Lexems.Lexema l = null;
            string s = "";
            bool waitIndetifire = true;
            while ((l = getToken()) != null)
            {
                string type = l.GetType().Name;
                if (waitIndetifire)
                {
                    if (type == "Identifire")
                    {
                        if (!hasId(l.Data))
                        {
                            addId(l.Data);
                            s += "\t" + l.Data + " dw ?";
                        }
                        else
                        {
                            addError(new IndetifireRedefinitionError(l.Data), 0);
                        }
                        waitIndetifire = false; 
                    }
                    else
                    {
                        waitIndetifire = true;
                        addError(new IndetifierMissedError(), 0);
                    }
                    
                }
                else
                {
                    if (type == "Comma")
                    {
                        s += "\n";
                        waitIndetifire = true;
                    }
                    else
                    {
                        waitIndetifire = false; 
                        addError(new CommaOrEndlMissedError(), 0);
                    }
                    
                    
                }
                
            }
            return s;
        }
    }
}
