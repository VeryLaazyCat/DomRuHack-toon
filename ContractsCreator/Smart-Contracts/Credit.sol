// "SPDX-License-Identifier: UNLICENSED"
pragma solidity 0.8.7;

import "./Entities.sol";

struct BankInfo {
    string name;
    uint lastNumOfDocument;
    address bankAddress;
}

contract Credit is Borrower, Bank, Insurer {
    enum CreditStatus { Processed, Complite }

    CreditStatus public _status;
    uint private _docNumber;
    int private _creditSum;
    
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

    // ---
    // Events

    event CreditSumChanged(address indexed whoChange, int indexed oldSum, int indexed newSum);
    event DepositOnAccount(address indexed from, address indexed where, int depositSum);
    event ActualCreditSum(int indexed creditSum);

    // ---
    // Functions

    function SetCreditSum(int newCreditSum) public onlyBank() {
        emit CreditSumChanged(_bankAddress, _creditSum, newCreditSum);
        _creditSum = newCreditSum;
    }

    function Deposit(int depositSum) public {
        emit DepositOnAccount(msg.sender, _bankAddress, depositSum);
        _creditSum -= depositSum;
        emit ActualCreditSum(_creditSum);
    }

    function GetCreditSum() external view returns (int) {
        return _creditSum;
    }

    // ---
}