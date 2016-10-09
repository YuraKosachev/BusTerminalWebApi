using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace ConsoleApplication1
{
    class Program
    {
        private const string APP_PATH = "http://localhost:50670";
        private static string token;

        static void Main(string[] args)
        {
            //Console.WriteLine();
            //string userInfo1 = GetUserInfo("");
            //Console.WriteLine("Пользователь:");
            //Console.WriteLine(userInfo1);

            Console.WriteLine("Введите логин:");
            string userName = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();
            //Console.WriteLine("Введите Имя:");
            //string firstName = Console.ReadLine();
            //Console.WriteLine("Введите Фамилию:");
            //string lastName = Console.ReadLine();


            //var registerResult = Register(userName, password,DateTime.Now,firstName,lastName);

            //Console.WriteLine("Статусный код регистрации: {0}", registerResult);

            Dictionary<string, string> tokenDictionary = GetTokenDictionary(userName, password);
            token = tokenDictionary["access_token"];

            Console.WriteLine();
            Console.WriteLine("Access Token:");
            Console.WriteLine(token);

            Console.WriteLine();
            string userInfo = GetUserInfo(token);
            Console.WriteLine("Пользователь:");
            Console.WriteLine(userInfo);

            Console.WriteLine();
            string values = GetValues(token);
            Console.WriteLine("Values:");
            Console.WriteLine(values);

            Console.WriteLine("Модель автобуса:");
            string busModel = Console.ReadLine();

            Console.WriteLine("Количество мест");
            int busNOfSeats = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Описание");
            string busDescription = Console.ReadLine();

            BusCreate(busModel,busDescription, busNOfSeats, token);

            //Console.WriteLine();
            //string logOut = LogOut();
            //Console.WriteLine("Статус");
            //Console.WriteLine(logOut);

            Console.Read();
        }

        // регистрация
        static string Register(string email, string password,DateTime birthDate, string firstName,string lastName)
        {

            var registerModel = new
            {
                Email = email,
                Password = password,
                ConfirmPassword = password,
                UserBirthDate = birthDate,
                FirstName = firstName,
                LastName = lastName
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/Account/Register", registerModel).Result;
                return response.StatusCode.ToString();
            }
        }
        // получение токена
        static Dictionary<string, string> GetTokenDictionary(string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "grant_type", "password" ),
                    new KeyValuePair<string, string>( "username", userName ),
                    new KeyValuePair<string, string> ( "Password", password )
                };
            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsync(APP_PATH + "/Token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                // Десериализация полученного JSON-объекта
                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary;
            }
        }

        // создаем http-клиента с токеном
        static HttpClient CreateClient(string accessToken = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
            return client;
        }
        static string BusCreate(string busModel,string busDescription, int busNOfSeats,string token) {
           
        var bus = new
            {
                BusModel= busModel,
                BusDescription = busDescription,
                BusNumberOfSeats = busNOfSeats

        };
            using (var client = CreateClient(token))
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/api/Bus", bus).Result;
                return response.StatusCode.ToString();
            }
        }

        // получаем информацию о клиенте
        static string GetUserInfo(string token)
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/Account/UserInfo").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        //static string LogOut()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var response = client.PostAsJsonAsync(APP_PATH + "api/Account/Logout", new { }).Result;
        //        return response.StatusCode.ToString();
        //    }
        //}

        // обращаемся по маршруту api/values
        static string GetValues(string token)
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/values").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
