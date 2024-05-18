using AutoMapper;
using Interviewer.Application.Extensions;
using System.Linq.Expressions;
using VetTextShifo.Application.Confugrations;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.Exceptions;
using VetTextShifo.Application.Extansions;
using VetTextShifo.Application.Interfaces;
using VetTextShifo.Data.Interfaces;
using VetTextShifo.Domain.Entities;

namespace VetTextShifo.Application.Services;

public class AdminService : IAdminService
{
    private readonly IGenericRepository<Admin> _repository;

    private readonly IMapper _mapper;
    public AdminService(IGenericRepository<Admin> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<bool> ChangePasswordAsync(AdminChangePassword userPasswordChange, CancellationToken cancellationToken)
    {
        var admin = await _repository.GetAsync(p => p.email == userPasswordChange.Email);
        if (admin == null)
        {
            throw new CustomException(400, "User not found");
        }
        if(admin.password != userPasswordChange.OldPassword.Encrypt())
        {
            throw new CustomException(400, "Password incorrect");
        }
        admin.password = userPasswordChange.NewPassword.Encrypt();
        _repository.UpdateAsync(admin);
        _repository.SaveChangesAsync(cancellationToken);
        return true;
        
    }

    public async Task<AdminRespons> CreatAsync(AdminRequest userCreation, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAsync(p => p.email == userCreation.Email);
        if (user is not null)
        {
            throw new CustomException(400, "User already exsist");
        }
        if(userCreation.Password != userCreation.ConfirmPassword)
        {
            throw new CustomException(404, "Bad request on the password!");
        }
        userCreation.Password = userCreation.Password.Encrypt();
        var respons = await _repository.CreateAsync(_mapper.Map<Admin>(userCreation));
        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<AdminRespons>(respons);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _repository.GetAsync(p => p.id == id);
        if (user is null)
        {
            throw new CustomException(404, "User not found");
        }

        await _repository.DeleteAsync(p => p.id == id);
        await _repository.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IEnumerable<AdminRespons>> GetAllAsync(PaginationParams @params)
    {
        var admins = _repository.GetAll()
                           .ToPagedListAdmin(@params);
        return _mapper.Map<IEnumerable<AdminRespons>>(admins);
    }

    public async Task<AdminRespons> GetAsync(Expression<Func<Admin, bool>> expression)
    {
        var admin = await _repository.GetAsync(expression);
        return  _mapper.Map<AdminRespons>(admin);
    }

}
