using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        delegate bool Filtro(Conta c);

        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>
            {
                new Conta { Numero = 1, Saldo = 35700 },
                new Conta { Numero = 3, Saldo = -700 },
                new Conta { Numero = 5, Saldo = 85 },
                new Conta { Numero = 42, Saldo = 15400 },
                new Conta { Numero = 102, Saldo = 1700 },
                new Conta { Numero = 500, Saldo = -300 },
                new Conta { Numero = 203, Saldo = 600 }
            };

            //Filtro filtroContasParaOferecerCredito = FiltraContaNegativa;
            Filtro filtroContasParaOferecerCredito = c => c.Saldo < 0;
            //Filtro filtroContasParaOferecerInvestimento = FiltraContaParaInvestimento;
            Filtro filtroContasParaOferecerInvestimento = c => c.Saldo >= 10000;

            // Contas com saldo negativo
            Console.WriteLine("Contas com saldo negativo: ");
            List<Conta> contasSaldoNegativo = Filtrar(contas, filtroContasParaOferecerCredito);
            Imprime(contasSaldoNegativo);

            // Contas com saldo acima de 10k
            Console.WriteLine("Contas com saldo acima de R$ 10.000,00: ");
            List<Conta> contasSaldoAcima10k = Filtrar(contas, filtroContasParaOferecerInvestimento);
            Imprime(contasSaldoAcima10k);

            Console.ReadKey();
        }

        static List<Conta> Filtrar(List<Conta> contas, Filtro filtro)
        {
            List<Conta> ContasFiltradas = new List<Conta>();

            foreach(var conta in contas)
            {
                if(filtro(conta))
                {
                    ContasFiltradas.Add(conta);
                }
            }

            return ContasFiltradas;
        }

        //static bool FiltraContaNegativa(Conta conta)
        //{
        //    return conta.Saldo < 0;
        //}

        //static bool FiltraContaParaInvestimento(Conta conta)
        //{
        //    return conta.Saldo >= 10000;
        //}

        static void Imprime(List<Conta> contas)
        {
            foreach (var conta in contas)
            {
                Console.WriteLine("Número: {0}, Saldo: {1:c}", conta.Numero, conta.Saldo);
            }
            Console.WriteLine();
        }

    }
}
