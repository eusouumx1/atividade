using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividade
{
    internal class Empregado
    {
        public string primeironome { get;private set; }
        public string sobrenome { get; private set; }
        private int matricula { get; set; }
        public int Matricula
        {
            get 
            {
                return matricula;
            }
            set 
            {
                matricula = value;
            }
        }
        public int idade { get; private set; }
        public DateTime dataNascimento { get; private set; }
        private DateTime? dataContratacao { get; set; } = null;
        public DateTime? DataContratacao
        {
            get
            {
                return dataContratacao;
            }
            set 
            {
                dataContratacao = value; 
            }
        }

        private double salarioMensal;
        public double SalarioMensal

        {

            get
            {

                return salarioMensal;

            }
            set
            {
                if (value < 1320)
                {
                    SalarioMensal = 1320;
                }
                else
                {
                    salarioMensal = value;
                }
            }
        }


        internal Empregado(string primeironome, string sobrenome, int idade, DateTime dataNascimento)
        {
            this.primeironome = primeironome; 
            this.sobrenome = sobrenome;
            this.idade = idade;
            this.dataNascimento = dataNascimento;
                       
        }
        internal Empregado(string primeironome, string sobrenome,int idade,  DateTime dataNascimento, int matricula, DateTime dataContratacao, double salarioMensal)
        {
            this.primeironome = primeironome;
            this.sobrenome = sobrenome;
            this.idade = idade;
            this.dataNascimento = dataNascimento;
            this.matricula = matricula;
            this.SalarioMensal = salarioMensal;
            this.dataContratacao = dataContratacao;

        }

        internal void AumentarSalario()
        {
            SalarioMensal += SalarioMensal * 0.1;
        }

        

    }
}
