﻿using Backend_API.Models;

namespace Backend_API.Dtos
{
    public class RegisterMerchantRequest
    {


        public string MerName { get; set; } = default!;
        public string email { get; set; } = default!;
        public string password { get; set; } = default!;
        public float? Balance { get; set; }

        public RegisterMerchantRequest(Merchants mer)
        {
            MerName = mer.MchName;
            email = mer.MchEmail;
            password=mer.MchPassword;
            Balance = mer.MchBalance;
        }
    }
}
