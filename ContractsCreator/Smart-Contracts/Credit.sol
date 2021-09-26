// "SPDX-License-Identifier: UNLICENSED"
pragma solidity 0.8.7;

import "./Entities.sol";

contract Credit is Borrower, Bank, Insurer {
    enum CreditStatus { Processed, Complite }

    CreditStatus public _status;
    int private _creditSum;
    
    constructor() {
        _status = CreditStatus.Processed;
        _creditSum = 0;
    }

    // Modificators

    modifier onlyBank() {
        require(msg.sender == _bankAddress, "Only Bank can change this information.");
        _;
    }

    // ---
    // Events

    event CreditSumChanged(address indexed whoChange, int indexed newSum);
    event DepositOnAccount(address indexed from, address indexed where, int depositSum);
    event ActualCreditSum(int indexed creditSum);

    // ---
    // Functions

    function SetCreditSum(int creditSum) public onlyBank() {
        emit CreditSumChanged(_bankAddress, creditSum);
        _creditSum = creditSum;
    }

    function Deposit(int depositSum) public {
        emit DepositOnAccount(msg.sender, _bankAddress, depositSum);
        _creditSum -= depositSum;
        emit ActualCreditSum(_creditSum);
    }

    // ---
}