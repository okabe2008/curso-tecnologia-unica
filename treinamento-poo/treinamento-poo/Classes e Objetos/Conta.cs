namespace treinamento_poo.Classes_e_Objetos
{
    public class Conta
    {
        private double _saldo;

        public Conta(int agencia, Banco banco, int numeroConta, double saldo)
        {
            Banco = banco;
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = saldo;
        }

        public int Agencia { get; set; }
        public Banco Banco { get; set; }
        public int NumeroConta { get; set; }

        public double Saldo
        {
            get => _saldo;
            set => _saldo = value;
        }

        public string SaldoFormated => string.Format("R$ {0}",_saldo);

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}", Banco, Agencia, NumeroConta);
        }
    }
}