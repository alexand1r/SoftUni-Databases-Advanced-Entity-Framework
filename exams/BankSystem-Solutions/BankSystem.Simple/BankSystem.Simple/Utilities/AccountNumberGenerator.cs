﻿namespace BankSystem.Simple.Utilities
{
    using System;

    public static class AccountNumberGenerator
    {
        public static string GenerateAccountNumber()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10).ToUpper();
        }
    }
}
