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

namespace Insurance.Contracts.Insurance.ContractDefinition
{


    public partial class InsuranceDeployment : InsuranceDeploymentBase
    {
        public InsuranceDeployment() : base(BYTECODE) { }
        public InsuranceDeployment(string byteCode) : base(byteCode) { }
    }

    public class InsuranceDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506040516105ee3803806105ee83398101604081905261002f91610136565b600b805461ffff191690558051805161005091600591602090910190610081565b506040810151600680546001600160a01b0319166001600160a01b03909216919091179055602001516007556102d7565b82805461008d90610286565b90600052602060002090601f0160209004810192826100af57600085556100f5565b82601f106100c857805160ff19168380011785556100f5565b828001600101855582156100f5579182015b828111156100f55782518255916020019190600101906100da565b50610101929150610105565b5090565b5b808211156101015760008155600101610106565b80516001600160a01b038116811461013157600080fd5b919050565b6000602080838503121561014957600080fd5b82516001600160401b038082111561016057600080fd5b908401906060828703121561017457600080fd5b61017c61022e565b82518281111561018b57600080fd5b8301601f8101881361019c57600080fd5b8051838111156101ae576101ae6102c1565b6101c0601f8201601f19168701610256565b935080845288868284010111156101d657600080fd5b60005b818110156101f45782810187015185820188015286016101d9565b818111156102055760008783870101525b505050818152838301518482015261021f6040840161011a565b60408201529695505050505050565b604051606081016001600160401b0381118282101715610250576102506102c1565b60405290565b604051601f8201601f191681016001600160401b038111828210171561027e5761027e6102c1565b604052919050565b600181811c9082168061029a57607f821691505b602082108114156102bb57634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052604160045260246000fd5b610308806102e66000396000f3fe608060405234801561001057600080fd5b50600436106100575760003560e01c806301cbf8fa1461005c5780630fb3844c146100715780632d582a211461009457806370063e801461009c578063a6dcb9b0146100af575b600080fd5b61006f61006a366004610242565b6100d1565b005b600b5461007e9060ff1681565b60405161008b919061025b565b60405180910390f35b61006f61012f565b61006f6100aa366004610242565b610191565b600b546100c190610100900460ff1681565b604051901515815260200161008b565b600060646100e083606e6102a5565b6100ea9190610283565b60095460408051918252602082018390529192507f8dc3ca543a94a3c9e408610776dc54bf750f01e5d289892d00fa8cdeb6685701910160405180910390a160095550565b6000606460085460095461014391906102a5565b61014d9190610283565b600a5460408051918252602082018390529192507f9b14a9e89b8cbc67c30893cb410e22df159d678783812160d264d798feacd861910160405180910390a1600a55565b6006546001600160a01b031633146102015760405162461bcd60e51b815260206004820152602960248201527f4f6e6c7920496e73757265722063616e206368616e6765207468697320696e6660448201526837b936b0ba34b7b71760b91b606482015260840160405180910390fd5b60085460408051918252602082018390527fd328f919590003febee2013b9ca8ef0b3ce0138855e9ed4d84eebb081ab00d6f910160405180910390a1600855565b60006020828403121561025457600080fd5b5035919050565b602081016002831061027d57634e487b7160e01b600052602160045260246000fd5b91905290565b6000826102a057634e487b7160e01b600052601260045260246000fd5b500490565b60008160001904831182151516156102cd57634e487b7160e01b600052601160045260246000fd5b50029056fea2646970667358221220f1842f4a8c397a027212db32d035325396859aa545544bd0ab54fe34f8ee756a64736f6c63430008070033";
        public InsuranceDeploymentBase() : base(BYTECODE) { }
        public InsuranceDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("tuple", "representative", 1)]
        public virtual Struct InsurerInfo Representative { get; set; }
    }

    public partial class SetInsuranceSumFunction : SetInsuranceSumFunctionBase { }

    [Function("SetInsuranceSum")]
    public class SetInsuranceSumFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "creditSum", 1)]
        public virtual BigInteger CreditSum { get; set; }
    }

    public partial class SetPaymentSumFunction : SetPaymentSumFunctionBase { }

    [Function("SetPaymentSum")]
    public class SetPaymentSumFunctionBase : FunctionMessage
    {

    }

    public partial class SetTariffFunction : SetTariffFunctionBase { }

    [Function("SetTariff")]
    public class SetTariffFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newTariff", 1)]
        public virtual BigInteger NewTariff { get; set; }
    }

    public partial class PaidStatusFunction : PaidStatusFunctionBase { }

    [Function("_paidStatus", "bool")]
    public class PaidStatusFunctionBase : FunctionMessage
    {

    }

    public partial class StatusFunction : StatusFunctionBase { }

    [Function("_status", "uint8")]
    public class StatusFunctionBase : FunctionMessage
    {

    }

    public partial class InsuranceSumChangeEventDTO : InsuranceSumChangeEventDTOBase { }

    [Event("InsuranceSumChange")]
    public class InsuranceSumChangeEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "oldSum", 1, false )]
        public virtual BigInteger OldSum { get; set; }
        [Parameter("uint256", "newSum", 2, false )]
        public virtual BigInteger NewSum { get; set; }
    }

    public partial class PaymentSumChangeEventDTO : PaymentSumChangeEventDTOBase { }

    [Event("PaymentSumChange")]
    public class PaymentSumChangeEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "oldSum", 1, false )]
        public virtual BigInteger OldSum { get; set; }
        [Parameter("uint256", "newSum", 2, false )]
        public virtual BigInteger NewSum { get; set; }
    }

    public partial class TariffChangeEventDTO : TariffChangeEventDTOBase { }

    [Event("TariffChange")]
    public class TariffChangeEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "oldTariff", 1, false )]
        public virtual BigInteger OldTariff { get; set; }
        [Parameter("uint256", "newTariff", 2, false )]
        public virtual BigInteger NewTariff { get; set; }
    }







    public partial class PaidStatusOutputDTO : PaidStatusOutputDTOBase { }

    [FunctionOutput]
    public class PaidStatusOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class StatusOutputDTO : StatusOutputDTOBase { }

    [FunctionOutput]
    public class StatusOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }
}
