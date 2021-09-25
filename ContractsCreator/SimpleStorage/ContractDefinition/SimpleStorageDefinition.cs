using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace ContractsCreator.SimpleStorage.ContractDefinition
{


    public partial class SimpleStorageDeployment : SimpleStorageDeploymentBase
    {
        public SimpleStorageDeployment() : base(BYTECODE) { }
        public SimpleStorageDeployment(string byteCode) : base(byteCode) { }
    }

    public class SimpleStorageDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052348015600f57600080fd5b5060ac8061001e6000396000f3fe6080604052348015600f57600080fd5b506004361060325760003560e01c806360fe47b11460375780636d4ce63c146049575b600080fd5b60476042366004605e565b600055565b005b60005460405190815260200160405180910390f35b600060208284031215606f57600080fd5b503591905056fea2646970667358221220a27f290bab1ff0a46c8e3bb1db31fde228df8ccb549b138c226e8b5ea64b801764736f6c63430008070033";
        public SimpleStorageDeploymentBase() : base(BYTECODE) { }
        public SimpleStorageDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetFunction : GetFunctionBase { }

    [Function("get", "uint256")]
    public class GetFunctionBase : FunctionMessage
    {

    }

    public partial class SetFunction : SetFunctionBase { }

    [Function("set")]
    public class SetFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
    }

    public partial class GetOutputDTO : GetOutputDTOBase { }

    [FunctionOutput]
    public class GetOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
