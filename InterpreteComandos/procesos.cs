using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace InterpreteComandos
{
    class procesos
    {
        ///
        public lista_procesos primero;
        public int num_procesos; //Cantidad procesos activos


        /// <summary>
        /// Crea la lista de los procesos actuales
        /// </summary>
        public void procesos_ejecución() {
           primero = null;
           Process[] procesos = Process.GetProcesses();
           int cantidad = 0;
            foreach (Process p in procesos)
           {
               cantidad++;
               String descripcion = getdescrip(p);
               String user = getUser(p.Id);
               String id = Convert.ToString(p.Id);
               String cpu = getcpu(p);
               String memoria = Convert.ToString(p.PrivateMemorySize64 / 1024);
               lista_procesos temp = new lista_procesos(id, p.ProcessName, descripcion, cpu, memoria, user);
               if (primero == null)
               {                
                   primero = temp;
               }
               else {
                   temp.sig = primero;
                   primero = temp;
               }
           }
            num_procesos = cantidad;
        
        }


        /// <summary>
        /// Retorna la descripción del proceso que recibe como parámetro
        /// </summary>
        public string getdescrip(Process p)
        {
            try
            {
                return p.MainModule.FileVersionInfo.FileDescription;
            }
            catch
            {
                return "";
            }
        }

         
        /// <summary>
        /// Retorna el nombre usuario por el proceso que recibe de parámetro
        /// </summary>
        public string getUser(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    return //argList[1] //+ "\\" + 
                        argList[0];
                }
            }

            return "-";
        }


       /// <summary>
       /// Retorna el porcentaje de uso del CPU, del proceso que recibe como parámetro
       /// </summary>
       public String getcpu(Process p)
        {
            try
            {
                Process proceso = p;
                System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
                // Calcular el uso de CPU
                Double CPU = (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100;
                return Convert.ToString(CPU);
            }
            catch { return ""; }
        }

        /// <summary>
        /// Actualiza la lista de procesos, compara la cantidad enlazada con la lista, además comprueba si hay creados
        /// </summary>
       public Boolean actualizar() {
           Boolean estado = false;
           int cantidad = 0;
           lista_procesos temp = primero;
           while (temp != null) {
               temp = temp.sig;
               cantidad++;
           }
           if (cantidad > num_procesos)//si es menor cantidad actualiza
           {
               estado = true;
               return estado;
           }
           else { //sino busca procesos nuevos
           
           Process[] procesos = Process.GetProcesses();
           foreach (Process p in procesos)
           {
               estado=buscar_proceso(p.Id);
               cantidad++;
           }
             return estado;
           }
           
           
       }


        /// <summary>
        /// Busca si existe en la lista el proceso
        /// </summary>
       public Boolean buscar_proceso(int id) {

           String pid = Convert.ToString(id);
           lista_procesos temp = primero;
           Boolean estado = false;
           while (temp.sig != null) {

               if (primero.id == pid) { estado = true; }
               temp = temp.sig;
           }
           return estado;
       }
 

    }
}
