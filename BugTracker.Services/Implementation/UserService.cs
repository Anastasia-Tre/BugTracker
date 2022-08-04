using System.Collections.Generic;
using AutoMapper;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation
{
    internal class UserService<TKey> : IUserService<TKey>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<TKey> _unitOfWork;

        public UserService(IUnitOfWork<TKey> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public User<TKey> GetUserById(TKey id)
        {
            return _mapper.Map<User<TKey>>(
                _unitOfWork.BugRepository.GetById(id));
        }

        public IEnumerable<User<TKey>> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<User<TKey>>>(
                _unitOfWork.BugRepository.GetAll());
        }
    }
}
