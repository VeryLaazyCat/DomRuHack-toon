// "SPDX-License-Identifier: UNLICENSED"
pragma solidity 0.8.7;

contract Credit {
    enum CreditStatus { Processed, Complite }

    struct Borrower {
        string sellerName;  // "Ivan"
        string pasport;  // "7010123456"
        address borrowerAddress;
    }
    
    struct Insurer {
        string insurerName;  // "ООО Ugoria"
        address insurerAddress;
    }
    
    struct Bank {
        string bankName;  // "DomRF"
        address bankAddress;
    }

    Borrower private _borrower;
    uint private _creditSum;

    CreditStatus public _status;
    Insurer public _insurer;
    Bank public _bank;

    constructor(address bankAddress) {
        _status = CreditStatus.Processed;
        _bank.bankAddress = bankAddress;
    }

    // Modificators

    modifier onlyBank() {
        require(msg.sender == _bank.bankAddress, "Only Bank can change this information.");
        _;
    }

    modifier onlyInsurer() {
        require(msg.sender == _insurer.insurerAddress, "Only Insurer can change this information.");
        _;
    }

    modifier onlyCompany() {
        require(isUserCompany(msg.sender), "Only Companies can change this information.");
        _;
    }

    // functions

    function isUserCompany(address sender) private view returns(bool) {
        if ((sender == _bank.bankAddress) || (sender == _insurer.insurerAddress)) {
            return true;
        } else {
            return false;
        }
    }

    function SetBorrowerInformation (string memory name, string memory pasport, address borAd) public onlyBank() {
        _borrower.sellerName = name;
        _borrower.pasport = pasport;
        _borrower.borrowerAddress = borAd;
    }

    function SetInsurerInformation (string memory name, address insurerAddress) public onlyBank() {
        _insurer.insurerName = name;
        _insurer.insurerAddress = insurerAddress;
    }

    function GetBorrowerInformation () public view onlyCompany() returns(Borrower memory) {
        return _borrower;
    }

    
}