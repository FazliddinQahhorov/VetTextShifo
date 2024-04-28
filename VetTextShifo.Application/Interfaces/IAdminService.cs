using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Domain.Entities;

namespace VetTextShifo.Application.Interfaces;

public interface IAdminService
{
    public Task<AdminRespons> CreatAsync(AdminRequest userCreation, CancellationToken cancellationToken);
    public Task<bool> ChangePasswordAsync(AdminChangePassword userPasswordChange, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    public Task<AdminRespons> GetAsync(Expression<Func<Admin, bool>> expression);
    public Task<IEnumerable<AdminRespons>> GetAllAsync(PaginationParams @params);
}
