using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class TrataErros : Exception
    {
        public TrataErros() { }

        public TrataErros(string message) : base(message) { }

        public TrataErros(string message, Exception inner) : base(message, inner) { }
    }
}
