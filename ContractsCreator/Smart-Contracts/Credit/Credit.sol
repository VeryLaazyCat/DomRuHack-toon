// "SPDX-License-Identifier: UNLICENSED"
pragma solidity 0.8.7;

import "../shared/Entities.sol";

struct BankInfo {
    string name;
    uint lastNumOfDocument;
    address bankAddress;
}

contract Credit is Borrower, Bank, Insurer {
    enum CreditStatus { Processed, Complite }

    uint private _docNumber;
    uint private _creditSum;

    CreditStatus public _status;
    
    constructor(BankInfo memory representative) {
        _status = CreditStatus.Processed;

        _bankName = representative.name;
        _bankAddress = representative.bankAddress;

        _docNumber = representative.lastNumOfDocument + 1;
        _creditSum = 0;
    }

    // Modificators

    modifier onlyBank() {
        require(msg.sender == _bankAddress, "Only Bank can change this information.");
        _;
    }

    // -!Modificators-
    // Events

    event CreditSumChanged(address indexed whoChange, uint indexed oldSum, uint indexed newSum);
    event DepositOnAccount(address indexed from, address indexed where, uint depositSum, uint remainder);
    event ActualCreditSum(uint indexed creditSum);

    // -!Events-
    // Functions

    function SetCreditSum(uint newCreditSum) public onlyBank() {
        emit CreditSumChanged(_bankAddress, _creditSum, newCreditSum);
        _creditSum = newCreditSum;
    }

    function Deposit(uint depositSum) public returns (uint) {
        uint remainder = 0;
        if (depositSum > _creditSum) {
            remainder = depositSum - _creditSum;
            _creditSum = 0;
        } else {
            _creditSum -= depositSum;
        }
        emit DepositOnAccount(msg.sender, _bankAddress, depositSum, remainder);
        emit ActualCreditSum(_creditSum);
        return (remainder);
    }

    function GetCreditSum() external view returns (uint) {
        return _creditSum;
    }

    // -!Functions-
}