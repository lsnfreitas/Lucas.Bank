using System;

namespace Lucas.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        private double SaldoPoupanca { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, double saldopoupanca)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.SaldoPoupanca = saldopoupanca;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta corrente de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta corrente de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public void AdicionarCredito(double novoCredito)
        {
            this.Credito += novoCredito;

            Console.WriteLine("Crédito atual da conta de {0} é {1}", this.Nome, this.Credito);
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Credito: " + this.Credito + " | ";
            return retorno;
        }
        public void DepositarPoupanca(double valorDepositoP)
        {
            this.SaldoPoupanca += valorDepositoP;

            Console.WriteLine("Saldo atual da conta poupança de {0} é {1}", this.Nome, this.SaldoPoupanca);
        }
        public void AplicarPoupanca(double valorAplicacao)
        {
            if (this.Sacar(valorAplicacao))
            {
                DepositarPoupanca(valorAplicacao);
            }
        }
        public bool SacarPoupanca(double valorSaqueP)
        {
            //Validação de saldo suficiente
            if (valorSaqueP > this.SaldoPoupanca)
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.SaldoPoupanca -= valorSaqueP;

            Console.WriteLine("Saldo atual da conta poupança de {0} é {1}", this.Nome, this.SaldoPoupanca);

            return true;
        }
        public void ResgatarPoupanca(double valorResgate)
        {
            if (this.SacarPoupanca(valorResgate))
            {
                Depositar(valorResgate);
            }
        }
        public void ConsultaSaldoPoupanca()
        {
            Console.WriteLine("O saldo da conta poupança de {0} é {1}", this.Nome, this.SaldoPoupanca);
        }
    }
}