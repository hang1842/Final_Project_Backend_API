using Backend_API.Models;

namespace Backend.Dtos
{
    public class RegisterMerchantRequest
    {


        public string MerName { get; set; } = default!;
        public string email { get; set; } = default!;
        public string password { get; set; } = default!;
        public float? Balance { get; set; }

        public RegisterMerchantRequest(merchants mer)
        {
            MerName = mer.MchName;
            email = mer.MchEmail;
            password=mer.MchPassword;
            Balance = mer.MchBalance;
        }
    }
}
