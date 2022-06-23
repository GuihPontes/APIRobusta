using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            context = _context;
        }


        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                                            .Where
                                            (
                                                x =>
                                                    x.Email.ToLower() == email.ToLower()
                                             )
                                            .AsNoTracking()
                                            .ToListAsync();
            return user.FirstOrDefault();

        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allUser = await _context.Users
                                                .Where
                                                (
                                                    x =>
                                                        x.Email.ToLower().Contains(email.ToLower())
                                                )
                                                .AsNoTracking()
                                                .ToListAsync();
            return allUser;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allUser = await _context.Users
                                                .Where
                                                (
                                                    x =>
                                                        x.Name.ToLower().Contains(name.ToLower())
                                                )
                                                .AsNoTracking()
                                                .ToListAsync();
            return allUser;
        }
    }
}
