using System;
using System.Threading;
using System.Globalization;

namespace treinamento_poo.Classes_e_Objetos
{
    public class Banco
    {
        private readonly string _nome;
        private readonly double _taxa;

        public Banco(string nome, double taxa)
        {
            _nome = nome;
            if(taxa < 0) throw new Exception("Taxa não pode ser negativa");
            if(taxa > 1) throw new Exception("Taxa não pode ser menor que 1");
            _taxa = taxa;
        }
        public string Nome => _nome;
        public double Taxa => _taxa;

        public static void Depositar(Conta conta, double valor)
        {
            if (valor < 0) throw new Exception("O valor depositado não pode ser negativo");
            if (valor < 20) throw new Exception("O valor mínimo para deposito deve ser maior que R$20,00");
            if (valor > 5000) throw new Exception("O valor do depósito não pode ser maior que R$5000,00");
            conta.Saldo += valor;
        }

        public static void Sacar(Conta conta, double valor)
        {
            if (valor < 0) throw new Exception("O valor sacado não pode ser negativo");
            if (valor > 5000) throw new Exception("O valor do saque não pode ser maior que R$5000,00");
            if (conta.Saldo-valor < 0) throw new Exception("Saldo insuficiente");
            conta.Saldo -= valor;
        }

        public static void Transferir(Conta conta1, Conta conta2, double valor)
        {
            if(conta1.Saldo < valor) throw new Exception("Saldo insuficiente");
            if (valor < 0) throw new Exception("O valor transferido não pode ser negativo");
            if (valor > 5000) throw new Exception("O valor transferido não pode ser maior que R$5000,00");
            conta1.Saldo -= valor;
            conta2.Saldo += valor;
        }

        public override string ToString()
        {
            return $"{Nome}";
        }

        public static void Render(Conta conta, int meses)
        {
            if(meses < 0) throw new Exception("A quantidade de meses não pode ser negativa");
            for (var i = 0; i < meses; i++)
            {
                conta.Saldo += conta.Saldo * conta.Banco._taxa;
            }
        }
    }
}