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

namespace Credit.Contracts.Credit.ContractDefinition
{


    public partial class CreditDeployment : CreditDeploymentBase
    {
        public CreditDeployment() : base(BYTECODE) { }
        public CreditDeployment(string byteCode) : base(byteCode) { }
    }

    public class CreditDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506040516105d53803806105d583398101604081905261002f91610147565b6009805460ff191690558051805161004f91600391602090910190610092565b506040810151600480546001600160a01b0319166001600160a01b039092169190911790556020810151610084906001610297565b60075550600060085561030e565b82805461009e906102bd565b90600052602060002090601f0160209004810192826100c05760008555610106565b82601f106100d957805160ff1916838001178555610106565b82800160010185558215610106579182015b828111156101065782518255916020019190600101906100eb565b50610112929150610116565b5090565b5b808211156101125760008155600101610117565b80516001600160a01b038116811461014257600080fd5b919050565b6000602080838503121561015a57600080fd5b82516001600160401b038082111561017157600080fd5b908401906060828703121561018557600080fd5b61018d61023f565b82518281111561019c57600080fd5b8301601f810188136101ad57600080fd5b8051838111156101bf576101bf6102f8565b6101d1601f8201601f19168701610267565b935080845288868284010111156101e757600080fd5b60005b818110156102055782810187015185820188015286016101ea565b818111156102165760008783870101525b50505081815283830151848201526102306040840161012b565b60408201529695505050505050565b604051606081016001600160401b0381118282101715610261576102616102f8565b60405290565b604051601f8201601f191681016001600160401b038111828210171561028f5761028f6102f8565b604052919050565b600082198211156102b857634e487b7160e01b600052601160045260246000fd5b500190565b600181811c908216806102d157607f821691505b602082108114156102f257634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052604160045260246000fd5b6102b88061031d6000396000f3fe608060405234801561001057600080fd5b506004361061004c5760003560e01c80630fb3844c146100515780634d6ce1e5146100745780637addcca414610095578063b327a1e0146100aa575b600080fd5b60095461005e9060ff1681565b60405161006b9190610235565b60405180910390f35b61008761008236600461021c565b6100b2565b60405190815260200161006b565b6100a86100a336600461021c565b61016e565b005b600854610087565b60085460009081908311156100da576008546100ce908461025d565b600060085590506100f2565b82600860008282546100ec919061025d565b90915550505b60045460408051858152602081018490526001600160a01b039092169133917f7268bfdde2c9c0bd30fe023ece6d785774da75386fb3c1ce3c692b628c29e0c3910160405180910390a36008546040517f4d46906cd245974f625979eaba40bd70ff903363b33757946f496971ee8037e790600090a292915050565b6004546001600160a01b031633146101db5760405162461bcd60e51b815260206004820152602660248201527f4f6e6c792042616e6b2063616e206368616e6765207468697320696e666f726d60448201526530ba34b7b71760d11b606482015260840160405180910390fd5b6008546004546040518392916001600160a01b0316907fb6c0cacd5e14fa177486b7dbe6e916c3c198b9d57bd2c31c9c153e8b92c2f05590600090a4600855565b60006020828403121561022e57600080fd5b5035919050565b602081016002831061025757634e487b7160e01b600052602160045260246000fd5b91905290565b60008282101561027d57634e487b7160e01b600052601160045260246000fd5b50039056fea264697066735822122016ed4fd40814bb123f0ad0feb6ca029fa600d5861be69634bdcbad5b3903185164736f6c63430008070033";
        public CreditDeploymentBase() : base(BYTECODE) { }
        public CreditDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("tuple", "representative", 1)]
        public virtual Struct BankInfo Representative { get; set; }
    }

    public partial class DepositFunction : DepositFunctionBase { }

    [Function("Deposit", "uint256")]
    public class DepositFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "depositSum", 1)]
        public virtual BigInteger DepositSum { get; set; }
    }

    public partial class GetCreditSumFunction : GetCreditSumFunctionBase { }

    [Function("GetCreditSum", "uint256")]
    public class GetCreditSumFunctionBase : FunctionMessage
    {

    }

    public partial class SetCreditSumFunction : SetCreditSumFunctionBase { }

    [Function("SetCreditSum")]
    public class SetCreditSumFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newCreditSum", 1)]
        public virtual BigInteger NewCreditSum { get; set; }
    }

    public partial class StatusFunction : StatusFunctionBase { }

    [Function("_status", "uint8")]
    public class StatusFunctionBase : FunctionMessage
    {

    }

    public partial class ActualCreditSumEventDTO : ActualCreditSumEventDTOBase { }

    [Event("ActualCreditSum")]
    public class ActualCreditSumEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "creditSum", 1, true )]
        public virtual BigInteger CreditSum { get; set; }
    }

    public partial class CreditSumChangedEventDTO : CreditSumChangedEventDTOBase { }

    [Event("CreditSumChanged")]
    public class CreditSumChangedEventDTOBase : IEventDTO
    {
        [Parameter("address", "whoChange", 1, true )]
        public virtual string WhoChange { get; set; }
        [Parameter("uint256", "oldSum", 2, true )]
        public virtual BigInteger OldSum { get; set; }
        [Parameter("uint256", "newSum", 3, true )]
        public virtual BigInteger NewSum { get; set; }
    }

    public partial class DepositOnAccountEventDTO : DepositOnAccountEventDTOBase { }

    [Event("DepositOnAccount")]
    public class DepositOnAccountEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "where", 2, true )]
        public virtual string Where { get; set; }
        [Parameter("uint256", "depositSum", 3, false )]
        public virtual BigInteger DepositSum { get; set; }
        [Parameter("uint256", "remainder", 4, false )]
        public virtual BigInteger Remainder { get; set; }
    }



    public partial class GetCreditSumOutputDTO : GetCreditSumOutputDTOBase { }

    [FunctionOutput]
    public class GetCreditSumOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class StatusOutputDTO : StatusOutputDTOBase { }

    [FunctionOutput]
    public class StatusOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }
}
