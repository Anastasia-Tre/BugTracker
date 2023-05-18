using System.Collections.Generic;
using AutoMapper;
using Bugify.Domain.AggregatesModel.UserAggregate;
using Bugify.Domain.SeedWork;

namespace BugTracker.Services.Services;

public class UserService : IUserService<int>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork<int> _unitOfWork;

    public UserService(IUnitOfWork<int> unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async System.Threading.Tasks.Task<User<int>> GetUserById(int id)
    {
        var user = await _unitOfWork.UserRepository.GetById(id);
        return _mapper.Map<User<int>>(user);
    }

    public async System.Threading.Tasks.Task<IEnumerable<User<int>>>
        GetAllUsers()
    {
        var users = await _unitOfWork.UserRepository.GetAllUsers();
        return _mapper.Map<IEnumerable<User<int>>>(users);
    }

    public async System.Threading.Tasks.Task<User<int>>
        CreateUser(User<int> user)
    {
        var mappedUser = _mapper.Map<UserEntity<int>>(user);
        await _unitOfWork.UserRepository.Create(mappedUser);
        await _unitOfWork.Save();
        return user;
    }

    public async System.Threading.Tasks.Task<User<int>> UpdateUser(
        User<int> user)
    {
        var mappedUser = _mapper.Map<UserEntity<int>>(user);
        _unitOfWork.UserRepository.Update(mappedUser);
        await _unitOfWork.Save();
        return user;
    }

    public async System.Threading.Tasks.Task<User<int>> DeleteUser(
        User<int> user)
    {
        var mappedUser = _mapper.Map<UserEntity<int>>(user);
        _unitOfWork.UserRepository.Delete(mappedUser);
        await _unitOfWork.Save();
        return user;
    }
}
