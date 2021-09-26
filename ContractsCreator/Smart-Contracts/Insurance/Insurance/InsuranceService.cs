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
using Insurance.Contracts.Insurance.ContractDefinition;

namespace Insurance.Contracts.Insurance
{
    public partial class InsuranceService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, InsuranceDeployment insuranceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<InsuranceDeployment>().SendRequestAndWaitForReceiptAsync(insuranceDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, InsuranceDeployment insuranceDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<InsuranceDeployment>().SendRequestAsync(insuranceDeployment);
        }

        public static async Task<InsuranceService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, InsuranceDeployment insuranceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, insuranceDeployment, cancellationTokenSource);
            return new InsuranceService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public InsuranceService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> SetInsuranceSumRequestAsync(SetInsuranceSumFunction setInsuranceSumFunction)
        {
             return ContractHandler.SendRequestAsync(setInsuranceSumFunction);
        }

        public Task<TransactionReceipt> SetInsuranceSumRequestAndWaitForReceiptAsync(SetInsuranceSumFunction setInsuranceSumFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInsuranceSumFunction, cancellationToken);
        }

        public Task<string> SetInsuranceSumRequestAsync(BigInteger creditSum)
        {
            var setInsuranceSumFunction = new SetInsuranceSumFunction();
                setInsuranceSumFunction.CreditSum = creditSum;
            
             return ContractHandler.SendRequestAsync(setInsuranceSumFunction);
        }

        public Task<TransactionReceipt> SetInsuranceSumRequestAndWaitForReceiptAsync(BigInteger creditSum, CancellationTokenSource cancellationToken = null)
        {
            var setInsuranceSumFunction = new SetInsuranceSumFunction();
                setInsuranceSumFunction.CreditSum = creditSum;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setInsuranceSumFunction, cancellationToken);
        }

        public Task<string> SetPaymentSumRequestAsync(SetPaymentSumFunction setPaymentSumFunction)
        {
             return ContractHandler.SendRequestAsync(setPaymentSumFunction);
        }

        public Task<string> SetPaymentSumRequestAsync()
        {
             return ContractHandler.SendRequestAsync<SetPaymentSumFunction>();
        }

        public Task<TransactionReceipt> SetPaymentSumRequestAndWaitForReceiptAsync(SetPaymentSumFunction setPaymentSumFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPaymentSumFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SetPaymentSumRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<SetPaymentSumFunction>(null, cancellationToken);
        }

        public Task<string> SetTariffRequestAsync(SetTariffFunction setTariffFunction)
        {
             return ContractHandler.SendRequestAsync(setTariffFunction);
        }

        public Task<TransactionReceipt> SetTariffRequestAndWaitForReceiptAsync(SetTariffFunction setTariffFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTariffFunction, cancellationToken);
        }

        public Task<string> SetTariffRequestAsync(BigInteger newTariff)
        {
            var setTariffFunction = new SetTariffFunction();
                setTariffFunction.NewTariff = newTariff;
            
             return ContractHandler.SendRequestAsync(setTariffFunction);
        }

        public Task<TransactionReceipt> SetTariffRequestAndWaitForReceiptAsync(BigInteger newTariff, CancellationTokenSource cancellationToken = null)
        {
            var setTariffFunction = new SetTariffFunction();
                setTariffFunction.NewTariff = newTariff;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTariffFunction, cancellationToken);
        }

        public Task<bool> PaidStatusQueryAsync(PaidStatusFunction paidStatusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PaidStatusFunction, bool>(paidStatusFunction, blockParameter);
        }

        
        public Task<bool> PaidStatusQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PaidStatusFunction, bool>(null, blockParameter);
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
