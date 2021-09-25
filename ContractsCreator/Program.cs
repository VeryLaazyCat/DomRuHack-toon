using ContractsCreator.SimpleStorage;
using ContractsCreator.SimpleStorage.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Numerics;
using System.Threading.Tasks;

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
                var url = "http://localhost:8545";
                var account = new Account(
                    key: new Nethereum.Signer.EthECKey("0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7"),
                    chainId: new BigInteger(444444444500)
                );

                var web3 = new Web3(account, url);

                Console.WriteLine("Deploying...");
                var deployment = new SimpleStorageDeployment();
                var receipt = await SimpleStorageService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new SimpleStorageService(web3, receipt.ContractAddress);
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");
                Console.WriteLine("");

                Console.WriteLine("Sending a transaction to the function set()...");
                var receiptForSetFunctionCall = await service.SetRequestAndWaitForReceiptAsync(
                    new SetFunction() { X = 42, Gas = 400000 });
                Console.WriteLine($"Finished storing an int: Tx Hash: {receiptForSetFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an int: Tx Status: {receiptForSetFunctionCall.Status.Value}");
                Console.WriteLine("");

                Console.WriteLine("Calling the function get()...");
                var intValueFromGetFunctionCall = await service.GetQueryAsync();
                Console.WriteLine($"Int value: {intValueFromGetFunctionCall} (expecting value 42)");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
