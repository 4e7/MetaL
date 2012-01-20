using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Lexems
{
   public class Digit:RegexLexema<Digit>
    {
       public Digit() { m_regex="[0-9]*[.,]?[0-9]*"; }
       public double value()
       {
           return double.Parse(m_data);
       }
    }
}
