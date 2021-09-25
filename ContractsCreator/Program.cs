using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Numerics;
using System.Threading.Tasks;
using SimpleStorage.Contracts.SimpleStorage.ContractDefinition;
using SimpleStorage.Contracts.SimpleStorage;
using Nethereum.JsonRpc.Client;
using System.Configuration;

namespace ContractsCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo().Wait();
        }

        static async Task Demo()
        {
            try
            {
                var config = ConfigurationManager.AppSettings;
                var url = "http://localhost:8545";
                var account = new Account(
                    key: new Nethereum.Signer.EthECKey(config["privateKey"]),
                    chainId: BigInteger.Parse(config["chainId"])
                );
                var web3 = new Web3(account, url);


                Console.WriteLine("Развёртывание контракта...");
                var deployment = new SimpleStorageDeployment();
                var receipt = await SimpleStorageService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new SimpleStorageService(web3, receipt.ContractAddress);
                Console.WriteLine($"Статус отправки контракта: {receipt.Status.Value}");
                Console.WriteLine($"Адрес контракта: {service.ContractHandler.ContractAddress}");
                Console.WriteLine();

                Console.WriteLine("Выполнение функции set()...");
                var receiptForSetFunctionCall = await service.SetRequestAndWaitForReceiptAsync(new SetFunction() { X = 42, Gas = 400000 });
                Console.WriteLine($"Результат функции: Tx хеш: {receiptForSetFunctionCall.TransactionHash}");
                Console.WriteLine($"Результат функции: Tx статус: {receiptForSetFunctionCall.Status.Value}");
                Console.WriteLine();

                Console.WriteLine("Обращение к функции get()...");
                var intValueFromGetFunctionCall = await service.GetQueryAsync();
                Console.WriteLine($"Значение int: {intValueFromGetFunctionCall} (ожидаемое значение: 42)");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Exception!");
            }

            Console.WriteLine("Конец");
            Console.ReadLine();
        }
    }
}
