using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace atividade
{

    internal class Empresa
    {

          public List<Empregado> EmpregadosLista { get; set; } = new List<Empregado>();

         internal void Menu()
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1: Lista de Empregados");
                Console.WriteLine("2: Cadastrar um Empregado");
                Console.WriteLine("3: Promover um Empregado");
                Console.WriteLine("4: Demitir um Empregado");
                Console.WriteLine("5: Completar Cadastro");

                switch (Console.ReadLine())
                {
                        case "1": ListaEmpregados();
                        break;
                        case "2": CadastrarEmpregado();
                        break;
                        case "3": PromoverEmpregado();
                        break;
                        case "4": DemitirEmpregado();
                        break;
                        case "5": CompletarCadastro();
                        break;

                }
            }
        }

        internal void ListaEmpregados()
        {
            Console.Clear();
            foreach (var item in EmpregadosLista)
            {
                Console.WriteLine(item.primeironome);
                Console.WriteLine(item.sobrenome);
                Console.WriteLine(item.idade);
                Console.WriteLine(item.Matricula);
                Console.WriteLine(item.DataContratacao);
                Console.WriteLine(item.dataNascimento);

            }
        }

        internal void CadastrarEmpregado()
        {
            Console.WriteLine("Digite seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite seu sobrenome");
            string sobrenome = Console.ReadLine();
            Console.WriteLine("Digite sua Idade");
            int idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite sua Data de nascimento");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite a matricula");
            int matricula = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a data de contratação");
            DateTime dataContratacao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("digite o salario");
            double salarioMensal = double.Parse(Console.ReadLine());

            Empregado empregadonovo = new Empregado(nome, sobrenome, idade, dataNascimento);
            
            EmpregadosLista.Add(empregadonovo);
            Console.WriteLine("Sucesso");
        }

        internal void PromoverEmpregado()
        {
           

            int indiceEmpregado = BuscaEmpregado();

            if (indiceEmpregado != 0 && EmpregadosLista[indiceEmpregado].SalarioMensal != 0)
            {
                EmpregadosLista[indiceEmpregado].AumentarSalario();
                Console.WriteLine($"Empregado {EmpregadosLista[indiceEmpregado].primeironome} " + $"{EmpregadosLista[indiceEmpregado].sobrenome} promovido com sucesso" );
                Console.WriteLine(EmpregadosLista[indiceEmpregado].SalarioMensal);
            }
            else
            {
                Console.WriteLine("Salario não aumentado");
            }
            
        }

        internal void DemitirEmpregado()
        {
            int indiceEmpregado = BuscaEmpregado();
            if(indiceEmpregado != 0)
            {
                Console.WriteLine($"Empregado {EmpregadosLista   [indiceEmpregado].primeironome} " + $"{EmpregadosLista[indiceEmpregado].sobrenome} Demitido com sucesso");
            }
        }

        internal double SalarioAnual(Empregado empregado) 
        {
            double salarioAno = empregado.SalarioMensal * 12;

               return salarioAno;
        }

        private int BuscaEmpregado()
        {
            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome");
            string sobrenome = Console.ReadLine();

            int indiceEmpregado = EmpregadosLista.FindIndex(e => e.primeironome.Equals(nome, StringComparison.OrdinalIgnoreCase)
           && e.sobrenome.Equals(sobrenome, StringComparison.OrdinalIgnoreCase));



            return indiceEmpregado;
        }

        internal void CompletarCadastro()
        {
             Empregado empregadoEncontrado = EmpregadosLista[BuscaEmpregado()];

            if (empregadoEncontrado.Matricula == 0)
            {
                Console.WriteLine("digite a matricula");
                empregadoEncontrado.Matricula = int.Parse(Console.ReadLine());
            }
            if (empregadoEncontrado.DataContratacao == null)
            {
                Console.WriteLine("Digite a data de contratação");
                empregadoEncontrado.DataContratacao = DateTime.Parse(Console.ReadLine());
            }
            if (empregadoEncontrado.SalarioMensal == 0)
            {
                Console.WriteLine("digite o salario mensal");
                empregadoEncontrado.SalarioMensal = double.Parse(Console.ReadLine());
            }
        }
    }
}
