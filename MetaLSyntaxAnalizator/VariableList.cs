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
        public VariableList(Analizator a)
            : base(a)
        {
            
        }
        public override string go()
        {
            SyntaxError error = null;
            Lexems.Lexema l = null;
            string s = null;
            s = "";
            if (analizator.ids.Count <= 0)
            {
                s = "SEG1 SEGMENT\n";
            }
            string i = new MetaLSyntaxAnalizator.Indetifire(analizator).go();
            if (i != null)
            {

                s += i;
                l = analizator.getToken();
                string type = l.GetType().Name;
                switch (type)
                {
                    case "Comma":
                        {
                            string nextIndetifire = new VariableList(analizator).go();
                            if (nextIndetifire == null)
                            {
                                error = new IndetifierMissedError();
                                error.position = analizator.position;
                                analizator.errors.Add(error);
                                s = null;
                            }
                            else
                            {
                                s += nextIndetifire;
                            }
                        }
                        break;
                    case "Endl":
                        s += "SEG1 ENDS\n";
                        analizator.position++;
                        break;
                    default:
                        error = new CommaOrEndlMissedError();
                        error.position = analizator.position;
                        analizator.errors.Add(error);
                        s = null;
                        break;
                }


            }
            else
            {
                s = null;
            }
          
            return s;
        }
    }
}
