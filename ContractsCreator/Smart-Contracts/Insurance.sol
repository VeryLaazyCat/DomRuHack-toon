// "SPDX-License-Identifier: UNLICENSED"
pragma solidity 0.8.7;

import "./Entities.sol";

struct InsurerInfo {
    string name;
    uint lastNumOfDocument;
    address insurerAddress;
}

contract Insurance is Borrower, Bank, Insurer {
    enum InsuranceStatus { Processed, Complite }

    uint private _docNumber;
    uint private _tariff; // % (Example: 110%)
    uint private _insuranceSum;
    uint private _paymentSum;
    

    InsuranceStatus public _status;
    bool public _paidStatus;

    constructor(InsurerInfo memory representative) {
        _status = InsuranceStatus.Processed;
        _paidStatus = false;

        _insurerName = representative.name;
        _insurerAddress = representative.insurerAddress;

        _docNumber = representative.lastNumOfDocument;
    }

    // Modificators

    modifier onlyInsurer() {
        require(msg.sender == _insurerAddress, "Only Insurer can change this information.");
        _;
    }

    // -!Modificators-
    // Events

    event TariffChange(uint oldTariff, uint newTariff);
    event InsuranceSumChange(uint oldSum, uint newSum);
    event PaymentSumChange(uint oldSum, uint newSum);

    // -!Events-
    // Functions

    function SetTariff(uint newTariff) public onlyInsurer() {
        emit TariffChange(_tariff, newTariff);
        _tariff = newTariff;
    }
    
    function SetInsuranceSum(uint creditSum) public {
        uint newSum = creditSum * 110 / 100;
        emit InsuranceSumChange(_insuranceSum, newSum);
        _insuranceSum = newSum;
    }

    function SetPaymentSum() public {
        uint newSum = _insuranceSum * _tariff / 100;
        emit PaymentSumChange(_paymentSum, newSum);
        _paymentSum = newSum;
    }

    // -!Functions-
}