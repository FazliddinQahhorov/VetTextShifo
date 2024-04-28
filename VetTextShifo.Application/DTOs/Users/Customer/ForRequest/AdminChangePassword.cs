namespace VetTextShifo.Application.DTOs.Users.Customer.ForRequest
{
    public class AdminChangePassword
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
