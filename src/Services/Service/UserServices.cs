using AutoMapper;
using Core;
using Domain.Entities;
using Infra.Interfaces;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Services.Service
{
    public class UserServices : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);
            if (userExists != null)
                throw new DomainException("Email já cadastrado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreate = await _userRepository.Create(user);
            return _mapper.Map<UserDTO>(userCreate);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> Get()
        {
            var allUser = await _userRepository.Get();
            return _mapper.Map<List<UserDTO>>(allUser);
            
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);

        }

        public async Task Romove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var user = await _userRepository.SearchByEmail(email);
            return _mapper.Map<List<UserDTO>>(email);

        }

        public async Task<List<UserDTO>> SearchByName(string nome)
        {
            var user = await _userRepository.SearchByName(nome);
            return _mapper.Map<List<UserDTO>>(nome);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null)
                throw new DomainException("Id informado não se encontra em nossa base de dados ");


            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpadate = await _userRepository.Upadate(user);

            return _mapper.Map<UserDTO>(userUpadate);

        }
    }
}
