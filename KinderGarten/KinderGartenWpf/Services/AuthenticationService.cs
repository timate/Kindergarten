using KinderGartenWpf.Models;
using KinderGartenWpf.Models.Objects;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KinderGartenWpf.Services
{
    public class AuthenticationService
    {

        #region  Свойства

        private readonly IPasswordHasher hasher = new PasswordHasher();
        private readonly KinderGartenDbContext Db;

        #endregion

        #region Конструктор

        public AuthenticationService(KinderGartenDbContext db)
        {
            Db = db;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Авторизация. Возвращает авторизованного педагога
        /// </summary>
        /// <param name="Login">Логин</param>
        /// <param name="Password">Пароль</param>
        /// <returns></returns>
        public async Task<Employee> Auth(string Login, string Password)
        {
            var user = await Db.Users.FirstOrDefaultAsync(x => x.Login == Login);
            if (user != null && hasher.VerifyHashedPassword(user.PasswordHash, Password) == PasswordVerificationResult.Success)
                return await Db.Employees
                               .Include(x => x.Person)
                               .Include(x => x.Document)
                               .Include(x => x.Role)
                               .FirstOrDefaultAsync(x => x.User == user);
            return null;
        }

        /// <summary>
        /// Регистрация. Регистрирует и возвращает нового пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public User Reg(string login, string password)
        {
            var user = new User
            {
                Login = login,
                PasswordHash = hasher.HashPassword(password)
            };
            return user;
        }

        /// <summary>
        /// Изменение пароля, возвращает булевый тип, true - успешно
        /// </summary>
        /// <param name="UserId">Id пользователя</param>
        /// <param name="Password">Старый пароль</param>
        /// <param name="newPassword">Новый пароль</param>
        /// <returns></returns>
        public async Task<bool> UpdatePassword(int UserId, string Password, string newPassword)
        {
            var user = await Db.Users.FirstOrDefaultAsync(x => x.Id == UserId);

            if (hasher.HashPassword(Password) == user.PasswordHash)
            {
                user.PasswordHash = hasher.HashPassword(newPassword);
                await Db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        #endregion
    }
}
