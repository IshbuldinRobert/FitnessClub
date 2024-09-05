namespace FitnessClub.BL.Model
{
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Гендер.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthdate { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Гендер. </param>
        /// <param name="birthdate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name,
                    Gender gender,
                    DateTime birthdate,
                    double weight,
                    double height)
        {
            #region Проверка условий свойств класса
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть равен null", nameof(gender));
            }

            if (birthdate < DateTime.Parse("01.01.1900") || birthdate >= DateTime.Now)
            {
                throw new ArgumentException("Нечеловеческий возраст", nameof(birthdate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше либо равен нулю", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен нулю", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"Имя пользователя: {Name}\n" +
                $"Гендер: {Gender}\n" +
                $"Дата рождения: {Birthdate.ToString()}\n" +
                $"Вес: {Weight}\n" +
                $"Рост: {Height}";
        }
    }
}
