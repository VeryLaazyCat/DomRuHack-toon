﻿// "SPDX-License-Identifier: UNLICENSED"
pragma solidity 0.8.7;

contract ContractWithParameters {
    uint storedData;
    constructor (uint data) {

    }

    function set(uint x) public {
        storedData = x;
    }

    function get() public view returns (uint) {
        return storedData;
    }
}