using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreteComandos
{
    class Núcleo
    {
        private Comandos comandos = new Comandos();

        public Object EjecutarComando()
        {
            return comandos.FindFile("proyector.png");
        }
    }
}
