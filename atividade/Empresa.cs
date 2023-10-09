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
        public List<Empregado> EmpregadosList { get; set; } = new List<Empregado>();

        internal void Menu()
        {
            bool rodando = true;
            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1: Lista de Empregados");
                Console.WriteLine("2: Completar Cadastro");
                Console.WriteLine("3: Cadastrar um Empregado");
                Console.WriteLine("4: Promover um Empregado");
                Console.WriteLine("5: Demitir um Empregado");
                Console.WriteLine("6: Sair");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListaEmpregados();
                        break;
                    case "2":
                        CompletarCadastro();
                        break;
                    case "3":
                        CadastrarEmpregado();
                        break;
                    case "4":
                        PromoverEmpregado();
                        break;
                    case "5":
                        DemitirEmpregado();
                        break;
                    case "6":
                        rodando = false;
                        break;
                }
            }
        }

        internal void ListaEmpregados()
        {
            Console.Clear();
            if (EmpregadosList.Count > 0)
            {
                foreach (var item in EmpregadosList)
                {
                    Console.WriteLine("Nome: " + item.primeironome);
                    Console.WriteLine("Sobrenome: " + item.sobrenome);
                    Console.WriteLine("Idade: " + item.idade);
                    Console.WriteLine("Matricula: " + item.Matricula);
                    Console.WriteLine("Data de contratação: " + item.DataContratacao);
                    Console.WriteLine("Data de nascimento: " + item.dataNascimento);
                    Console.WriteLine("Salário mensal: " + item.SalarioMensal.ToString("C"));
                    Console.WriteLine("Salário anual: " + SalarioAnual(item).ToString("C"));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Sem empregados cadastrados.");
            }
            Console.ReadKey();
        }

        internal void CadastrarEmpregado()
        {
            Console.Clear();
            Console.WriteLine("1: Cadastrar empregado com todas as informações.");
            Console.WriteLine("2: Cadastrar empregado com informações básicas.");

            Empregado? empregadoNovo = null;
            string nome;
            string sobrenome;
            int idade;
            DateTime dataNascimento;
            int matricula;
            DateTime dataContratacao;
            double salarioMensal;

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Digite o nome do empregado:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite o sobrenome:");
                    sobrenome = Console.ReadLine();
                    Console.WriteLine("Digite a Idade:");
                    idade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a Data de nascimento (DD/MM/AAAA):");
                    dataNascimento = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a matricula:");
                    matricula = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a data de contratação:");
                    dataContratacao = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("digite o salario:");
                    salarioMensal = double.Parse(Console.ReadLine());

                    empregadoNovo = new Empregado(nome, sobrenome, idade, dataNascimento, matricula, dataContratacao, salarioMensal);
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Digite o nome do empregado:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite o sobrenome:");
                    sobrenome = Console.ReadLine();
                    Console.WriteLine("Digite a Idade:");
                    idade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite a Data de nascimento:");
                    dataNascimento = DateTime.Parse(Console.ReadLine());

                    empregadoNovo = new Empregado(nome, sobrenome, idade, dataNascimento);
                    break;
            }

            if (empregadoNovo != null)
            {
                if (BuscaEmpregado(empregadoNovo.primeironome, empregadoNovo.sobrenome) < 0)
                {
                    EmpregadosList.Add(empregadoNovo);
                    Console.WriteLine("Empregado cadastrado!");
                }
                else
                {
                    Console.WriteLine("Empregado já cadastrado.");
                }
            }
            else
            {
                Console.WriteLine("Empregado não cadastrado!");
            }
            Console.ReadKey();
        }

        internal void PromoverEmpregado()
        {
            Console.Clear();
            int indiceEmpregado = BuscaEmpregado();
            if (indiceEmpregado >= 0)
            {
                Empregado empregado = EmpregadosList[indiceEmpregado];

                if (indiceEmpregado >= 0 && empregado.SalarioMensal != 0)
                {
                    empregado.AumentarSalario();
                    Console.WriteLine($"Empregado {empregado.primeironome} " + $"{empregado.sobrenome} promovido com sucesso");
                    Console.WriteLine("Salário definido: " + empregado.SalarioMensal.ToString("C"));
                }
                else
                {
                    Console.WriteLine("Salario não definido, verifica o nome ou se funcionário já possui salário!");
                }
            }
            else
            {
                Console.WriteLine("Empregado não encontrado.");
            }
            Console.ReadKey();
        }

        internal void DemitirEmpregado()
        {
            Console.Clear();
            int indiceEmpregado = BuscaEmpregado();
            if (indiceEmpregado >= 0)
            {
                Empregado empregado = EmpregadosList[indiceEmpregado];
                Console.WriteLine($"Empregado {empregado.primeironome} " + $"{empregado.sobrenome} Demitido com sucesso");
                EmpregadosList.Remove(empregado);
            }
            else
            {
                Console.WriteLine("Empregado não encontado.");
            }
            Console.ReadKey();
        }

        internal void CompletarCadastro()
        {
            Console.Clear();
            int index = BuscaEmpregado();
            if (index >= 0)
            {
                Empregado empregadoEncontrado = EmpregadosList[index];

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
                Console.WriteLine("Cadastro completado.");
            }
            else
            {
                Console.WriteLine("Empregado não encontrado!");
                Console.ReadKey();
            }
        }

        private int BuscaEmpregado()
        {
            Console.WriteLine("Digite o nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome");
            string sobrenome = Console.ReadLine();

            int indiceEmpregado = EmpregadosList.FindIndex(e => e.primeironome.Equals(nome, StringComparison.OrdinalIgnoreCase)
            && e.sobrenome.Equals(sobrenome, StringComparison.OrdinalIgnoreCase));

            return indiceEmpregado;
        }

        private int BuscaEmpregado(string? nome, string? sobrenome)
        {
            int indiceEmpregado = EmpregadosList.FindIndex(e => e.primeironome.Equals(nome, StringComparison.OrdinalIgnoreCase)
            && e.sobrenome.Equals(sobrenome, StringComparison.OrdinalIgnoreCase));

            return indiceEmpregado;
        }

        internal double SalarioAnual(Empregado empregado)
        {
            return empregado.SalarioMensal * 12;
        }
    }
}
