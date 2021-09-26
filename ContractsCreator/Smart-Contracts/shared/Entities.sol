// "SPDX-License-Identifier: UNLICENSED"
pragma solidity 0.8.7;

contract Borrower {
    string internal _borrowerName;  // "Ivan"
    string internal _borrowerPasport;  // "7010123456"
    address internal _borrowerAddress;
}

contract Bank {
    string internal _bankName;  // "DomRF"
    address internal _bankAddress;
}

contract Insurer {
    string internal _insurerName;  // "Ugoria"
    address internal _insurerAddress;
}