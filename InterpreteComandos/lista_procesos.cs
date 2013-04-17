using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreteComandos
{
    class lista_procesos
    {   
        /// <summary>
        /// Variables de los procesos
        /// </summary>
        public String id;
        public String nombre;
        public String descripcion;
        public String cpu;
        public String memoria;
        public String usuario;
        public lista_procesos sig;
 
 
   
          //Constructor
        public lista_procesos(String _id, String _nombre, String _descrip, String _cpu, String _memo, String _user) {

            id = _id;
            nombre = _nombre;
            descripcion = _descrip;
            cpu = _cpu;
            memoria = _memo;
            usuario = _user;
            sig = null;
        }


      }

}
