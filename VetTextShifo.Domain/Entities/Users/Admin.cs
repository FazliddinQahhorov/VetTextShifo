using VetTextShifo.Domain.Commons;

namespace VetTextShifo.Domain.Entities;

public class Admin : Auditable
{
   public string email { get; set; }    
   public string password { get; set; }
}
