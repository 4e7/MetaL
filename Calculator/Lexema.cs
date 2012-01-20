using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
 
  public abstract class Lexema
    {
        protected string m_data;
        
        public string Data
        {
            get { return m_data; }
            set { m_data = value; }
        }

        public abstract Lexema parse(ref string s);
    
    }
}
