using System;
using System.Collections.Generic;

namespace treinamento_poo.Classes_e_Objetos
{
    public class ClassesEObjetos
    {
        private Dictionary<string, Cliente> _clientes;

        public ClassesEObjetos()
        {
            Bancos = new Dictionary<string, Banco>();
            Clientes = new Dictionary<string, Cliente>();
            Contas = new Dictionary<string, Conta>();
        }

        public Dictionary<string, Banco> Bancos { get; set; }

        public Dictionary<string, Cliente> Clientes
        {
            get => _clientes;
            set => _clientes = value;
        }

        public Dictionary<string, Conta> Contas { get; set; }

        public Banco CadastrarBanco(string nome, double taxa)
        {
            Console.WriteLine("- Cadastrando Banco");
            Banco banco = null;
            try
            {
                if (Bancos.TryGetValue(nome, out banco)) throw new Exception("Já cadastrado");
                banco = new Banco(nome, taxa);
                Bancos.Add(banco.Nome, banco);
                Console.WriteLine($"Nome: {banco.Nome}\n" +
                                  $"Taxa: {banco.Taxa}");
            }
            catch (Exception e)
            {
                Console.Error.Write("Erro: ");
                Console.Error.WriteLine(e.Message);
            }

            Console.WriteLine("");
            return banco;
        }

        public Cliente CadastrarCliente(string nome, string cpf, int idade, string telefone, string email,
            int agencia,
            string banco, int numeroConta, double saldo)
        {
            Console.WriteLine("- Cadastrando Cliente");
            Cliente cliente = null;
            try
            {
                Banco bancoAux;
                if (!Bancos.TryGetValue(banco, out bancoAux))
                    throw new Exception("Banco não cadastrado");

                var conta = new Conta(agencia, bancoAux, numeroConta, saldo);
                cliente = new Cliente(nome, cpf, idade, telefone, email, conta);
                Contas.Add(conta.ToString(), conta);
                Clientes.Add(cliente.Cpf, cliente);
                Console.WriteLine(cliente);
            }
            catch (Exception e)
            {
                Console.Error.Write("Erro: ");
                Console.Error.WriteLine(e.Message);
            }

            Console.WriteLine("");
            return cliente;
        }
        

        public void Transferir(string conta1Ident, string conta2Ident, double valor)
        {
            Console.WriteLine("- Transferindo dinheiro: ");
            Conta conta1;
            Conta conta2;
            if (!Contas.TryGetValue(conta1Ident, out conta1)) throw new Exception("Conta 1 Inexistente");
            if (!Contas.TryGetValue(conta2Ident, out conta2)) throw new Exception("Conta 2 Inexistente");
            try
            {
                Banco.Transferir(conta1, conta2, valor);
                Console.WriteLine(
                    $"Transferindo R$ {valor} de:\n" +
                    
                    $"conta: {conta1.NumeroConta}, " +
                    $"banco: {conta1.Banco}, " +
                    $"agência: {conta1.Agencia} para \n" +
                    
                    $"conta: {conta2.NumeroConta}, " +
                    $"banco: {conta2.Banco}, " +
                    $"agência: {conta2.Agencia} ");
                Console.WriteLine("Saldo atual: "+conta1.SaldoFormated);
            }
            catch (Exception e)
            {
                Console.Error.Write("Erro: ");
                Console.Error.WriteLine(e.Message);
            }

            Console.WriteLine("");
        }

        public void Depositar(string contaIdent, double valor)
        {
            Console.WriteLine("- Depositando dinheiro: ");
            try
            {
                Conta conta;
                if (!Contas.TryGetValue(contaIdent, out conta)) throw new Exception("Conta Inexistente");
                Banco.Depositar(conta, valor);
                Console.WriteLine(
                    $"Depositando R$ {valor} para " +
                    $"conta: {conta.NumeroConta}, " +
                    $"banco: {conta.Banco}, " +
                    $"agência: {conta.Agencia}");
                Console.WriteLine("Saldo atual: "+conta.SaldoFormated);
            }
            catch (Exception e)
            {
                Console.Error.Write("Erro: ");
                Console.Error.WriteLine(e.Message);
            }
            Console.WriteLine();
        }

        public void Sacar(string contaIdent, double valor)
        {
            Console.WriteLine("- Sacando dinheiro: ");
            try
            {
                Conta conta;
                if (!Contas.TryGetValue(contaIdent, out conta)) throw new Exception("Conta Inexistente");
                Banco.Sacar(conta, valor);
                Console.WriteLine(
                    $"Sacando R$ {valor} para " +
                    $"conta: {conta.NumeroConta}, " +
                    $"banco: {conta.Banco}, " +
                    $"agência: {conta.Agencia}");
                Console.WriteLine("Saldo atual: "+conta.SaldoFormated);
            }
            catch (Exception e)
            {
                Console.Error.Write("Erro: ");
                Console.Error.WriteLine(e.Message);
            }
            Console.WriteLine();
        }

        public void Extrato(string contaIdent)
        {
            Console.WriteLine("- Extrato: ");
            try
            {
                Conta conta;
                if (!Contas.TryGetValue(contaIdent, out conta)) throw new Exception("Conta Inexistente");
                Console.WriteLine($"conta: {conta.NumeroConta}, " +
                                  $"banco: {conta.Banco}, " +
                                  $"agência: {conta.Agencia}");
                Console.WriteLine("Saldo: "+conta.SaldoFormated);
            }
            catch (Exception e)
            {
                Console.Error.Write("Erro: ");
                Console.Error.WriteLine(e.Message);
            }
            Console.WriteLine();
        }
        public void Executar()
        {
            // Cadastrando Bancos
            Console.WriteLine("## Cadastrando Bancos");
            CadastrarBanco("Nubank", 0.05);
            CadastrarBanco("PicPay", 0.05);
            CadastrarBanco("Nubank", 0.05);
            CadastrarBanco("123123", -1);

            // Cadastrando Clientes
            Console.WriteLine("## Cadastrando Clientes");
            CadastrarCliente(
                "Alice Rocha Rodrigues",
                "91718662645",
                63,
                "(48) 7685-8971",
                "AliceRochaRodrigues@rhyta.com",
                1,
                "Nubank",
                11111,
                10000);

            CadastrarCliente(
                "Tiago Barros Pinto",
                "26854200024",
                80,
                "(31) 3159-2344",
                "TiagoBarrosPinto@armyspy.com",
                10,
                "PicPay",
                22222,
                10000);

            CadastrarCliente(
                "Caio Cunha Santos",
                "21765705029",
                -123,
                "(47) 3185-8143",
                "CaioCunhaSantos@armyspy.com",
                101,
                "PicPay",
                33333,
                10000);
            CadastrarCliente(
                "Caio Cunha Santos",
                "21765705029",
                100,
                "(47) 3185-8143",
                "CaioCunhaSantos@armyspy.com",
                101,
                "PicPaya",
                33333,
                10000);

            // Fazendo Depositos
            Console.WriteLine("## Depositos");
            Extrato("Nubank-1-11111");
            Depositar("Nubank-1-11111", 100);
            Depositar("Nubank-1-11111", 10000);
            Depositar("Nubank-1-11111", -15);
            
            // Fazendo Saques
            Console.WriteLine("## Saques");
            Extrato("Nubank-1-11111");
            Sacar("Nubank-1-11111", 4999);
            Sacar("Nubank-1-11111", 4999);
            Sacar("Nubank-1-11111", 50000);
            Sacar("Nubank-1-11111", -123);
            
            // Fazendo Transferencias
            Extrato("PicPay-10-22222");
            Extrato("Nubank-1-11111");
            Transferir("PicPay-10-22222","Nubank-1-11111",100);
            Transferir("Nubank-1-11111", "PicPay-10-22222",100);
            Transferir("Nubank-1-11111", "PicPay-10-22222",-100);
            Transferir("Nubank-1-11111", "PicPay-10-22222",10000);
            Transferir("PicPay-10-22222","Nubank-1-11111",10000);
        }
    }
}