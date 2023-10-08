using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade
{
    internal class Atividade
    {
        static void Main()
        {
            Empresa empresa1 = new();




            Empregado jooj = new Empregado("Pedro", "Augusto", 45, DateTime.Now);
            empresa1.EmpregadosLista.Add(jooj);


            empresa1.Menu();
            

        }
    }
}
