using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expressions=System.Collections.Generic.List<MetaLSyntaxAnalizator.SyntaxExpression>;

namespace MetaLSyntaxAnalizator
{
    
   public abstract class SyntaxExpression
    {
       public int loopCount = 0;
       protected List<Lexems.Lexema> lexems=new List<Lexems.Lexema>();
       protected HashSet<string> m_ids;
       protected void addId(string id)
       {
           root.m_ids.Add(id);
       }
      protected bool hasId(string id)
       {
           return root.m_ids.Contains(id);
       }
       
        protected SyntaxExpression parent;
        public HashSet<string> Ids
        {
            get { return root.m_ids; }
        }
        protected SyntaxExpression root
        {
            get {
                SyntaxExpression root = this.parent;
                if(root == null)return this.parent;
                while (root.parent != null)
                {
                    root = root.parent;
                }
                return root;
            }
        }
        public List<SyntaxError> errors = new List<SyntaxError>();
        protected int m_tokenPosition = 0;
        protected Lexems.Lexema getToken()
        {
            Lexems.Lexema l = null;
            if (parent.m_tokenPosition < parent.lexems.Count)
            {
                l = parent.lexems[parent.m_tokenPosition];
                parent.m_tokenPosition++;
            }

            return l;
        }
        protected Lexems.Lexema getMyToken()
        {
            Lexems.Lexema l = null;
            if (m_tokenPosition < lexems.Count)
            {
                l = lexems[m_tokenPosition];
                m_tokenPosition++;
            }

            return l;
         }
        protected void addError(SyntaxError error, int position)
        {
            error.position = position;
            root.errors.Add(error);
        }
        
        protected SyntaxExpression() { }
        
        public SyntaxExpression(SyntaxExpression parent)
        {
            this.parent = parent;
        }
        public abstract string go();
        
    }
}
