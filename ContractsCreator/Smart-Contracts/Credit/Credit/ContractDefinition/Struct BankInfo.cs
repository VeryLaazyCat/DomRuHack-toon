using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Credit.Contracts.Credit.ContractDefinition
{
    public partial class Struct BankInfo : Struct BankInfoBase { }

    public class Struct BankInfoBase 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("uint256", "lastNumOfDocument", 2)]
        public virtual BigInteger LastNumOfDocument { get; set; }
        [Parameter("address", "bankAddress", 3)]
        public virtual string BankAddress { get; set; }
    }
}
