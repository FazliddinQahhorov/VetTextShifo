using VetTextShifo.Domain.Entities;

namespace VetTextShifo.Application.Interfaces;

public interface IAuthService
{
    Task<string> GenerateToken(Admin user);
}
