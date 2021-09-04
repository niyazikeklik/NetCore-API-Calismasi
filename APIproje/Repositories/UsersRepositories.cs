using APIproje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIproje.Repositories {
    public class UsersRepositories : IKullnicilar {
        private readonly UserContext _context;
        public UsersRepositories(UserContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Users>> Get() {
            return await _context.User.ToListAsync();
        }

        public async Task<Users> Get(int id) {
            return await _context.User.FindAsync(id);
        }
        public async Task<Users> Geteposta(string eposta) {
            return await _context.User.FindAsync(eposta);
        }
        public async Task Update(Users user) {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Users> Create(Users user) {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id) {
            var kullaniciyiSil = await _context.User.FindAsync(id);
            _context.User.Remove(kullaniciyiSil);
            await _context.SaveChangesAsync();
        }

    }
}
