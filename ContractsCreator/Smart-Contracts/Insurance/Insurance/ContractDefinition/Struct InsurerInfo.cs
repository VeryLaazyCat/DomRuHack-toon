using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Insurance.Contracts.Insurance.ContractDefinition
{
    public partial class Struct InsurerInfo : Struct InsurerInfoBase { }

    public class Struct InsurerInfoBase 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("uint256", "lastNumOfDocument", 2)]
        public virtual BigInteger LastNumOfDocument { get; set; }
        [Parameter("address", "insurerAddress", 3)]
        public virtual string InsurerAddress { get; set; }
    }
}
