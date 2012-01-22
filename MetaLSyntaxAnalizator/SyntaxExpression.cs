using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expressions=System.Collections.Generic.List<MetaLSyntaxAnalizator.SyntaxExpression>;

namespace MetaLSyntaxAnalizator
{
    
   public abstract class SyntaxExpression
    {
        protected Analizator analizator;

        protected SyntaxExpression() { }
        public Analizator Parent
        {
            get { return analizator; }
        }
        public SyntaxExpression(Analizator analizator)
        {
            this.analizator = analizator;
        }
        public abstract string go();
        
    }
}
