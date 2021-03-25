﻿using System;
using System.Collections.Generic;


namespace Lucas.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                    ListarContas();
                    break;
                   case "2":
                    InserirConta();
                    break;
                   case "3":
                    Transferir();
                    break;
                   case "4":
                    Sacar();
                    break;  
                   case "5":
                    Depositar();
                    break;
                   case "6":
                    AdicionarCredito(); 
                    break;
                   case "7":
                    AplicarPoupanca(); 
                    break;   
                   case "8":
                    ResgatarPoupanca(); 
                    break;
                   case "9":
                    ConsultaSaldoPoupanca(); 
                    break;
                   default:
                    throw new ArgumentOutOfRangeException();
               }

               opcaoUsuario = ObterOpcaoUsuario();
           } 

           Console.WriteLine("Obrigado por utilizar nossos serviços.");
           Console.ReadLine();
        }
        private static string ObterOpcaoUsuario()
        {
                Console.WriteLine();
                Console.WriteLine("Lucas.Bank a seu dispor!");
                Console.WriteLine("Informe a opção desejada:");
                
                Console.WriteLine("1- Listar contas correntes");
                Console.WriteLine("2- Inserir nova conta");
                Console.WriteLine("3- Transferir");
                Console.WriteLine("4- Sacar");
                Console.WriteLine("5- Depositar");
                Console.WriteLine("6- Adicionar crédito para o cliente");
                Console.WriteLine("7- Aplicar na poupança");
                Console.WriteLine("8- Resgatar da poupança");
                Console.WriteLine("9- Consultar saldo da poupança");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;

        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o saldo da poupança inicial: ");
            double entradaSaldoPoupanca = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome,
                                        saldopoupanca: entradaSaldoPoupanca);

            listContas.Add(novaConta);

        }
        private static void ListarContas()
        {
            Console.WriteLine("CONTAS CORRENTES");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque); 
        }
        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito); 
        }
        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }
        private static void AdicionarCredito()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser adicionado: ");
            double novoCredito = double.Parse(Console.ReadLine());

            listContas[indiceConta].AdicionarCredito(novoCredito);
        }
        private static void AplicarPoupanca()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser aplicado: ");
            double valorAplicacao = double.Parse(Console.ReadLine());

            listContas[indiceConta].AplicarPoupanca(valorAplicacao);
        }
        private static void ResgatarPoupanca()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do resgate: ");
            double valorResgate = double.Parse(Console.ReadLine());

            listContas[indiceConta].ResgatarPoupanca(valorResgate);

        }
        private static void ConsultaSaldoPoupanca()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            listContas[indiceConta].ConsultaSaldoPoupanca();
        }
    }
}
