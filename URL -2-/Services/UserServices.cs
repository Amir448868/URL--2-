using AcortURL.Data;
using AcortURL.Entities;
using AcortURL.Models;
using AcortURL.Models.Dtos;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AcortURL
{
    public class UserServices
    {
        private UrlsShortenerContext _context;
        public UserServices(UrlsShortenerContext context)
        {
            _context = context;
        }
      

        public User? ValidateUser(AuthenticationRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Username == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }
        
        public List<UserDto> GetAll()
        {
            return _context.Users.Select(u => new UserDto()
            {
                Id = u.Id,
                
                UserName = u.Username
            }).ToList();
        }

        public User? GetById(int userId)
        {
            return _context.Users.Include(u => u.Username).FirstOrDefault(u => u.Id == userId);
        }


        public void Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                Password = dto.Password,
                Username = dto.UserName,
               
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        //El update funciona de la siguiente manera:
        /*
         * Primero traemos la entidad de la base de datos.
         * Cuando traemos la entidad entity framework trackea las propiedades del objeto
         * Cuando modificamos algo el estado de la entidad pasa a "Modified"
         * Una vez hacemos _context.SaveChanges() esto va a ver que la entidad fue modificada y guarda los cambios en la base de datos.
         */
        public void Update(CreateAndUpdateUserDto dto, int userId)
        {
            User userToUpdate = _context.Users.First(u => u.Id == userId);
            userToUpdate.Password = dto.Password;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == id));
            _context.SaveChanges();
        }


        public bool CheckIfUserExists(int userId)
        {
            User? user = _context.Users.FirstOrDefault(user => user.Id == userId);
            return user != null;
        }
    }
}
