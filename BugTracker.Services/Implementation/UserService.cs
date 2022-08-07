using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;

namespace BugTracker.Services.Implementation
{
    public class UserService : IUserService<int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;

        public UserService(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User<int>> GetUserById(int id)
        {
            var user = await _unitOfWork.BugRepository.GetById(id);
            return  _mapper.Map<User<int>>(user);
        }

        public IEnumerable<User<int>> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<User<int>>>(
                _unitOfWork.BugRepository.GetAll());
        }
    }
}
