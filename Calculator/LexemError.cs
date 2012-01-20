using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexems
{
    public class LexemError:Exception
    {
        public int position=-1;
        public int endPosition = -1;
        public string lexem;
    }
}
