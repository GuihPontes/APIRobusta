using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Romove(long id);
        Task<UserDTO> Get(long id);
        Task<List<UserDTO>> Get();

        Task<List<UserDTO>> SearchByName(string nome);
        Task<List<UserDTO>> SearchByEmail(string email);
        Task<UserDTO> GetByEmail(string email);

    }
}
