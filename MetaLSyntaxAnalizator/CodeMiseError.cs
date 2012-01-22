using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetaLSyntaxAnalizator
{
    public class CodeMiseError:SyntaxError
    {
        public override string message()
        {
            return "Исходный код пуст.";
        }
    }
}
