using FitnessClub.BL.Controller;

namespace FitnessClub.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложения Fitness Club");
            Console.WriteLine("1. Зарегистрироваться\n" +
                              "2. Войти");
            int choise = int.Parse(Console.ReadLine());

            switch (choise)
            {
                case 1:
                    FirstChoise();
                    break;
                case 2:
                    SecondChoise();
                    break;
            }
        }

        private static void FirstChoise()
        {
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthdate = DateTime.Parse(Console.ReadLine()); //TODO: Переписать.

            Console.WriteLine("Введите вес");
            var weight = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            var height = Double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();
        }

        private static void SecondChoise()
        {
            UserController userController = new UserController();
            Console.WriteLine(userController.User);
        }
    }
}