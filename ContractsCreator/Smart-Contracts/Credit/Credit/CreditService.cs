using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Credit.Contracts.Credit.ContractDefinition;

namespace Credit.Contracts.Credit
{
    public partial class CreditService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CreditDeployment creditDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CreditDeployment>().SendRequestAndWaitForReceiptAsync(creditDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CreditDeployment creditDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CreditDeployment>().SendRequestAsync(creditDeployment);
        }

        public static async Task<CreditService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CreditDeployment creditDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, creditDeployment, cancellationTokenSource);
            return new CreditService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CreditService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DepositRequestAsync(DepositFunction depositFunction)
        {
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(DepositFunction depositFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<string> DepositRequestAsync(BigInteger depositSum)
        {
            var depositFunction = new DepositFunction();
                depositFunction.DepositSum = depositSum;
            
             return ContractHandler.SendRequestAsync(depositFunction);
        }

        public Task<TransactionReceipt> DepositRequestAndWaitForReceiptAsync(BigInteger depositSum, CancellationTokenSource cancellationToken = null)
        {
            var depositFunction = new DepositFunction();
                depositFunction.DepositSum = depositSum;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositFunction, cancellationToken);
        }

        public Task<BigInteger> GetCreditSumQueryAsync(GetCreditSumFunction getCreditSumFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCreditSumFunction, BigInteger>(getCreditSumFunction, blockParameter);
        }

        
        public Task<BigInteger> GetCreditSumQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCreditSumFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetCreditSumRequestAsync(SetCreditSumFunction setCreditSumFunction)
        {
             return ContractHandler.SendRequestAsync(setCreditSumFunction);
        }

        public Task<TransactionReceipt> SetCreditSumRequestAndWaitForReceiptAsync(SetCreditSumFunction setCreditSumFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCreditSumFunction, cancellationToken);
        }

        public Task<string> SetCreditSumRequestAsync(BigInteger newCreditSum)
        {
            var setCreditSumFunction = new SetCreditSumFunction();
                setCreditSumFunction.NewCreditSum = newCreditSum;
            
             return ContractHandler.SendRequestAsync(setCreditSumFunction);
        }

        public Task<TransactionReceipt> SetCreditSumRequestAndWaitForReceiptAsync(BigInteger newCreditSum, CancellationTokenSource cancellationToken = null)
        {
            var setCreditSumFunction = new SetCreditSumFunction();
                setCreditSumFunction.NewCreditSum = newCreditSum;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCreditSumFunction, cancellationToken);
        }

        public Task<byte> StatusQueryAsync(StatusFunction statusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StatusFunction, byte>(statusFunction, blockParameter);
        }

        
        public Task<byte> StatusQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StatusFunction, byte>(null, blockParameter);
        }
    }
}
