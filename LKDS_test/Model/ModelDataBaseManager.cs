using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LKDS_test.Model
{
    public class ModelDataBaseManager
    {
        private string __settings_connect_to_DB;
        private string __name_DB = "";
        private SqlConnection __connection;
        private SqlCommand __command;
        private ModelLoggingClass __log_stream;
        private string __organization_table_name = "Organization_table";
        private string __staff_table_name = "Staff_table";
        public string staff_table_name 
        { 
            get
            {
                return __staff_table_name;
            } 
        }
        public string organization_table_name
        {
            get
            {
                return __organization_table_name;
            }
        }
        public ModelDataBaseManager(string data_source,string name_DB, ref ModelLoggingClass log_stream)
        {
            __log_stream = log_stream;
            __name_DB = name_DB;
            __settings_connect_to_DB = $"Data source={data_source};Integrated security=true;database=master";
            __connection = new SqlConnection(__settings_connect_to_DB);
            __command = new SqlCommand();

            openConnectToDataBase();
        }

        public void openConnectToDataBase() {
            string command_text;
            bool read_result;
            SqlDataReader data_reader;

            if (__connection.State == System.Data.ConnectionState.Closed)
            {
                __connection.Open();
            }

            command_text = $"SELECT name FROM master.dbo.sysdatabases WHERE name='{__name_DB}'";
            __command.Connection = __connection;
            __command.CommandText = command_text;
                
            data_reader = __command.ExecuteReader();
            read_result = data_reader.Read();
            data_reader.Close();

            if (!read_result)
            {
                __log_stream.Log("ModelDataBaseManager", "openConnectToDataBase", "-", "База данных не найдена, создаётся новая");
                command_text = $"CREATE DATABASE {__name_DB}";
                __command.CommandText = command_text;
                __command.ExecuteNonQuery();
            }
                
            __connection.ChangeDatabase(__name_DB); 
        }
        public void closeConnectToDataBase()
        {

            if (__connection.State == System.Data.ConnectionState.Open)
            {
                __connection.Close();
            }
        }

        public SqlDataReader queryDataBase(string query)
        {
            __command.CommandText = query;
            return __command.ExecuteReader();
        }
        public void createStandartTable()
        {
            SqlDataReader reader;
            bool read_result;
            string command_text;
            Random rand = new Random();

            command_text = "SELECT * FROM INFORMATION_SCHEMA.TABLES " +
                                  $"WHERE TABLE_NAME = '{organization_table_name}'";
            reader = queryDataBase(command_text);
            read_result = reader.Read();
            reader.Close();

            if (!read_result)
            {
                __log_stream.Log("ModelDataBaseManager", "fillDataBase", "-", $"Таблица '{organization_table_name}' не найдена, создаётся новая");
                command_text = $"CREATE TABLE {organization_table_name}(" +
                                "id int IDENTITY (1,1) NOT NULL," +
                                "Organization varchar(50) NOT NULL," +
                                "Cash_turnover int NOT NULL," +
                                "Direction_activity varchar(50) NOT NULL," +
                                "Total_staff int NOT NULL," +
                                "Country varchar(50) NOT NULL," +
                                "PRIMARY KEY (id));";
                queryDataBase(command_text).Close();
            }

            command_text = "SELECT * FROM INFORMATION_SCHEMA.TABLES " +
                                  $"WHERE TABLE_NAME = '{staff_table_name}'";

            reader = queryDataBase(command_text);
            read_result = reader.Read();
            reader.Close();

            if (!read_result)
            {
                __log_stream.Log("ModelDataBaseManager", "fillDataBase", "-", $"Таблица '{staff_table_name}' не найдена, создаётся новая");
                command_text = $"CREATE TABLE {staff_table_name}(" +
                               "id int IDENTITY (1,1) NOT NULL," +
                               "Last_name varchar(50) NOT NULL," +
                               "First_name varchar(50) NOT NULL," +
                               "Patronymic varchar(50)," +
                               "id_organization int NOT NULL," +
                               "Profession varchar(50) NOT NULL," +
                               "Salary int NOT NULL," +
                               "Company_utility_coef int NOT NULL," +
                               "Path_to_photography varchar(80)," +
                               "PRIMARY KEY (id));";
                queryDataBase(command_text).Close();
            }
        }
        public void fillDataBase()
        {
            int max_staff = 100;
            string[] organization = { "Volbek", "Ornim Inc.",
                                      "Bublic", "Loriul",
                                      "Morning", "CarCar",
                                      "AppleBin", "Gorash",
                                      "Voda Ltd.", "Earth"
                                    };
            string[] direction_activity = {"IT", "Construction",
                                           "Mining", "Taxi"  
                                          };
            string[] country = {"Russia", "USA",
                             "Germany", "Moldova"
                            };

            string[] last_name = {  "Браун", "Вильямс", "Тэйлор", "Смит", "Джонс",
                                    "Чеботоревский", "Мирошниченко", "Каргин", "Толочко", "Палий",
                                    "Мюллер", "Вебер", "Беккер", "Шнайдер", "Вольф",
                                    "Хасан", "Перес", "Руис", "Диас", "Торрес",
                                    "Сато", "Ямагути", "Абэ", "Гото", "Накаяма"
                                 };
            string[] first_name = { "Киара","Джуди","Макс","Иван","Владислав",
                                    "Никита","Кирито","София","Генрих","Ульберт",
                                    "Изольда","Эмили","Урсула","Аделя","Гульшат",
                                    "Инкар","Анар","Арсен","Карим","Альфонсо",
                                    "Мигель","Каталина","Бланка","Даниеэль","Паула"
                                   };
            string[] patronymic = { "Никитич/на", "Александрович/на", "Владимирович/на", "Бахтиянович/на", "Олегович/на",
                                     "Николаевич/на", "Аракбаевич/на", "Аржанович/на", "Каримович/на", "Денисович/на",
                                     "Романович/на", "Артёмович/на", "Максимович/на", "Данилович/на", "Глебович/на",
                                     "Георгиевич/на", "Станиславович/на", "Арсенович/на", "Юрьевич/на", "Гулназарович/на"
                                   };
            string[] profession = { "Программист", "Бухгалтер", "Экономист/ка", "Специалист/ка", "Менеджер",
                                    "Юрист", "Секретарь", "Убарщик/ца", "Стажёр", "Маркетолог"
                                  };
            string[] photo_path = { "./../../../source/staff_image/image_1.jpg",
                                    "./../../../source/staff_image/image_2.jpg",
                                    "./../../../source/staff_image/image_3.png",
                                    "./../../../source/staff_image/image_4.png",
                                    "./../../../source/staff_image/image_5.png",
                                    "./../../../source/staff_image/image_6.jpg",
                                    "./../../../source/staff_image/image_7.jpg",
                                    "./../../../source/staff_image/image_8.jpg",
                                    "./../../../source/staff_image/image_9.png",
                                    "./../../../source/staff_image/image_10.png"};

            SqlDataReader reader;
            bool read_result;
            string command_text;
            Random rand = new Random();

            

            for(int i = 0; i < organization.Length; i++)
            {
                command_text = $"INSERT INTO dbo.{organization_table_name} " +
                               $"(Organization, Cash_turnover, Direction_activity, Total_staff, Country) " +
                               $"VALUES ('{organization[i]}', " +
                                        $"{rand.Next(500000, 50000001)}, " +
                                        $"'{direction_activity[rand.Next(direction_activity.Length)]}', " +
                                        $"{max_staff}, " +
                                        $"'{country[rand.Next(country.Length)]}');";
                reader = queryDataBase(command_text);
                reader.Read();
                reader.Close();

                command_text = $"INSERT INTO dbo.{staff_table_name} " +
                               $"(Last_name, First_name, Patronymic," +
                               $" id_organization, Profession, Salary," +
                               $" Company_utility_coef, Path_to_photography) VALUES ";
                for (int j = 0; j < max_staff; j++)
                {
                    command_text += $"('{last_name[rand.Next(last_name.Length)]}'," +
                                    $" '{first_name[rand.Next(first_name.Length)]}'," +
                                    $" '{patronymic[rand.Next(patronymic.Length)]}'," +
                                    $" {i+1}," +
                                    $" '{profession[rand.Next(profession.Length)]}'," +
                                    $" {rand.Next(700,10501)}," +
                                    $" {rand.Next(10)}," +
                                    $" '{photo_path[rand.Next(photo_path.Length)]}'" +
                                    $")";
                    if(j == max_staff - 1)
                    {
                        command_text += ';';
                    }
                    else
                    {
                        command_text += ',';
                    }
                }

                reader = queryDataBase(command_text);
                reader.Read();
                reader.Close();
            }
        }
    }
}
