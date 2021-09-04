using APIproje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIproje.Repositories {
    public interface IKullnicilar {
        Task<Users> Geteposta(string eposta);
        Task<IEnumerable<Users>> Get();
        Task<Users> Get(int id);
        Task<Users> Create(Users user);
        Task Update(Users user);
        Task Delete(int id);
    }
}
