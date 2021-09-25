using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary> Тестовый контракт</summary>
    [ApiController]
    [Route("[controller]")]
    public class IntegerContractController : ControllerBase
    {
        private readonly ILogger<IntegerContractController> _logger;

        public IntegerContractController(ILogger<IntegerContractController> logger)
        {
            _logger = logger;
        }

        /// <summary> Получить адреса всех записанных смарт-контрактов</summary>
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(new { dsfgdsf = "dsf" });
        }

        /// <summary> Получить результат контракта по его адресу</summary>
        [HttpGet("{address}")]
        public ActionResult Get(string address)
        {
            return new JsonResult(new { dsfgdsf = "dsf" });
        }

        /// <summary> Создать смарт контракт</summary>
        [HttpPost]
        public ActionResult Post()
        {
            return new JsonResult(new { dsfgdsf = "dsf" });
        }

        /// <summary> Добавить число к результату</summary>
        [HttpPatch]
        public ActionResult Update()
        {
            return new JsonResult(new { dsfgdsf = "dsf" });
        }
    }
}
