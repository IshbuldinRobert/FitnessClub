using FitnessClub.BL.Model;
using System.Text.Json;

namespace FitnessClub.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Сщздание нового пользователя.
        /// </summary>
        /// <param name="userName"> Имя. </param>
        /// <param name="genderName"> Гендер. </param>
        /// <param name="birthdate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> рост. </param>
        public UserController(string userName, string genderName, DateTime birthdate, double weight, double height)
        {
            // TODO: Проверка

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthdate, weight, height);
        }

        public UserController()
        {
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (JsonSerializer.Deserialize<User>(fs) is User user)
                {
                    User = user;
                }

                // TODO: Если пользователя не прочитали
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                byte[] bytes = JsonSerializer.SerializeToUtf8Bytes(User);
                fs.Write(bytes);
            }
        }
    }
}
