using System;

namespace treinamento_poo.Classes_e_Objetos
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, int idade, string telefone, string email, Conta conta)
        {
            Nome = nome;
            Cpf = cpf;
            if(idade<0) throw new Exception("Idade não pode ser negativa");
            Idade = idade;
            Telefone = telefone;
            Email = email;
            Conta = conta;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Conta Conta { get; set; }

        public override string ToString()
        {
            return $"{nameof(Nome)}: {Nome}\n" +
                   $"CPF: {Cpf}\n" +
                   $"{nameof(Idade)}: {Idade}\n" +
                   $"{nameof(Telefone)}: {Telefone}\n" +
                   $"{nameof(Email)}: {Email}\n" +
                   $"Banco: {Conta.Banco}\n" +
                   $"Agência: {Conta.Agencia}\n" +
                   $"Número de Conta: {Conta.NumeroConta}\n" +
                   $"Saldo: {Conta.Saldo}";
        }
    }
}