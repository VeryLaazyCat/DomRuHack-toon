using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using SimpleStorage.Contracts.SimpleStorage;
using SimpleStorage.Contracts.SimpleStorage.ContractDefinition;
using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary> Тестовый контракт</summary>
    [ApiController]
    [Route("[controller]")]
    public class IntegerContractController : ControllerBase
    {
        private readonly ILogger<IntegerContractController> _logger;
        private readonly ContractsContext _context;
        private readonly IConfiguration _config;

        public IntegerContractController(ILogger<IntegerContractController> logger,
                                         ContractsContext contractsContext,
                                         IConfiguration configuration)
        {
            _logger = logger;
            _context = contractsContext;
            _config = configuration;
        }

        /// <summary> Получить адреса всех записанных смарт-контрактов</summary>
        [HttpGet]
        public ActionResult GetAll()
        {
            var addreses = _context.ContractInfos.Select(c => c.Address).ToArray();
            return new JsonResult(addreses);
        }

        /// <summary> Получить результат контракта по его адресу</summary>
        [HttpGet("{address}")]
        public async Task<ActionResult> Get(string address)
        {
            Web3 web3 = GetWeb3Wrapper();
            var service = new SimpleStorageService(web3, address);

            Debug.WriteLine("Обращение к функции get()...");
            var intValueFromGetFunctionCall = await service.GetQueryAsync();
            Debug.WriteLine($"Значение int: {intValueFromGetFunctionCall} (ожидаемое значение: 42)");
            Debug.WriteLine("");

            _context.ContractInfos.First(c => c.Address == address);
            return new JsonResult(new { Info = "Контракт найден" });
        }

        /// <summary> Создать смарт контракт</summary>
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            string address = "";
            try
            {
                Web3 web3 = GetWeb3Wrapper();

                Debug.WriteLine("Развёртывание контракта...");
                var deployment = new SimpleStorageDeployment();
                var receipt = await SimpleStorageService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new SimpleStorageService(web3, receipt.ContractAddress);
                Debug.WriteLine($"Статус отправки контракта: {receipt.Status.Value}");

                _context.ContractInfos.Add(new ContractInfo() { Address = service.ContractHandler.ContractAddress });
                _context.SaveChanges();
            }
            catch
            {

            }

            return new JsonResult(new { Info = "Смарт контракт успешно занесён в блокчейн, адрес контракта: " + address });
        }

        /// <summary> Добавить число к результату</summary>
        [HttpPatch("address")]
        public async Task<ActionResult> Update(string address, int i)
        {
            Web3 web3 = GetWeb3Wrapper();
            var service = new SimpleStorageService(web3, address);

            Debug.WriteLine("Выполнение функции set()...");
            var receiptForSetFunctionCall = await service.SetRequestAndWaitForReceiptAsync(new SetFunction() { X = i, Gas = 400000 });
            Debug.WriteLine($"Результат функции: Tx хеш: {receiptForSetFunctionCall.TransactionHash}");
            Debug.WriteLine($"Результат функции: Tx статус: {receiptForSetFunctionCall.Status.Value}");
            Debug.WriteLine("");

            return new JsonResult(new { Info = "Успешно обновлено" });
        }

        private Web3 GetWeb3Wrapper()
        {
            var url = "http://localhost:8545";
            var account = new Account(
                key: new Nethereum.Signer.EthECKey(_config["privateKey"]),
                chainId: BigInteger.Parse(_config["chainId"])
            );
            var web3 = new Web3(account, url);
            return web3;
        }
    }
}
