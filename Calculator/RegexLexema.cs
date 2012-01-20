using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Lexems
{
  public  class RegexLexema<T> : Lexema where T:Lexema,new()
    {
        protected string m_regex = null;
        protected virtual Lexema factory(string data)
        {
            if (data == null) return null;
            T lexema = new T();
            lexema.Data = data;
            return (Lexema)lexema;
            
        }

        public override Lexema parse(ref string s)
        {
            
            if (m_regex == null) return null;
            s = s.Trim();
            m_data = parseRegEx(ref s,m_regex );
            if (m_data == null)
            {
                return null;
            }
            
            return factory(m_data);  
        }
        protected string parseRegEx(ref string s, string regEx)
        {

            s = s.Trim();
            Match m = Regex.Match(s, "^"+regEx);

            if (m.Success&&m.Length>0)
            {

                s=s.Remove(m.Index, m.Length);
                s = s.Trim();
                return m.ToString();
            }

            return null;
        }
        
    }
}
