using LKDS_test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LKDS_test.Controller
{
    public class ControllerDataBaseManager
    {
        private string __default_path_logging = "./../../../../log.txt";
        private ModelLoggingClass __logging_class;

        private const int __max_length_DB_name = 128;
        private ModelDataBaseManager __DB_manager;
        public ControllerDataBaseManager(string path_to_settings_file)
        {
            __logging_class = new ModelLoggingClass(__default_path_logging);
            StreamReader fin = new StreamReader(path_to_settings_file,Encoding.UTF8);
            string? server_name = fin.ReadLine();
            string? db_name = fin.ReadLine();
            if (server_name != null && db_name != null)
            {
                if(db_name.Length <= __max_length_DB_name)
                {
                    __DB_manager = new ModelDataBaseManager(server_name, db_name, ref __logging_class);
                    __DB_manager.createStandartTable();
                }
                else
                {
                    throw new Exception("Имя базы данных больше допустимого (128 символов)");
                }
               
            }
            else
            {
                __logging_class.Log("fin", "ReadLine", "null", "Файл не содержит имени базы данных");
                throw new Exception("Файл не содержит имени сервера или имени базы данных");
            }
        }

        public List<ModelComboBoxString> getTableNames()
        {
            List<ModelComboBoxString> result = new List<ModelComboBoxString>();
            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
            SqlDataReader query_result = __DB_manager.queryDataBase(query);

            
            for(int i = 0; query_result.Read();i++)
            {
                result.Add(new ModelComboBoxString(i, query_result.GetString(0)));
            }
            query_result.Close();
            if (query_result == null )
            {
                __logging_class.Log("ControllerDBManager", "getTableNames", "not result", "База данных не содержит таблиц");
            }

            return result;  
        }

        public List<ModelComboBoxString>? getFieldNames(string table_name)
        {
            List<ModelComboBoxString>? result = new List<ModelComboBoxString>();
            string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS" +
                          $" WHERE TABLE_NAME = '{table_name}'";
            SqlDataReader query_result = __DB_manager.queryDataBase(query);


            for (int i = 0; query_result.Read(); i++)
            {
                result.Add(new ModelComboBoxString(i, query_result.GetString(0)));
            }
            query_result.Close();
            if (query_result == null)
            {
                __logging_class.Log("ControllerDBManager", "getFieldNames", "not result", "Таблица не содержит колонок");
            }

            return result;
        }
    
        public bool fillDataBase()
        {
            string query = $"SELECT TOP (10) id FROM {__DB_manager.organization_table_name}";
            SqlDataReader reader = __DB_manager.queryDataBase(query);
            bool reader_result = reader.Read();
            reader.Close();
            if (!reader_result)
            {
                __DB_manager.fillDataBase();
                __logging_class.Log("ControlDBManager","fillDataBase","Succeful","База данных успешно заполнена");
            }
            else
            {
                __logging_class.Log("ControlDBManager", "fillDataBase", "Warning", "База данных не была заполнена, так как она не пустая");
            }
            return !reader_result;
        }
    
        public List<ModelDataCompany> getCompanyList()
        {
            List<ModelDataCompany> result = new List<ModelDataCompany>();
            string query = $"SELECT * FROM {__DB_manager.organization_table_name}";
            SqlDataReader query_result = __DB_manager.queryDataBase(query);

            for(;query_result.Read();)
            {
                result.Add(new ModelDataCompany(query_result.GetInt32(0), query_result.GetString(1),
                                                query_result.GetInt32(2), query_result.GetString(3),
                                                query_result.GetInt32(4), query_result.GetString(5)));
            }
            query_result.Close();

            return result;
        }

        public List<ModelDataStaff> getStaffList()
        {
            List<ModelDataStaff> result = new List<ModelDataStaff>();
            string query = $"SELECT * FROM {__DB_manager.staff_table_name}";
            SqlDataReader query_result = __DB_manager.queryDataBase(query);

            for (;query_result.Read();)
            {
                result.Add(new ModelDataStaff(query_result.GetInt32(0), query_result.GetString(1),
                                              query_result.GetString(2), query_result.GetString(3),
                                              query_result.GetInt32(4), query_result.GetString(5),
                                              query_result.GetInt32(6), query_result.GetInt32(7),
                                              query_result.GetString(8)));
            }
            query_result.Close();

            return result;
        }

        public bool deleteElement(int id_table, string value)
        {
            string[] temp_table = { __DB_manager.organization_table_name, __DB_manager.staff_table_name };
            string query = $"DELETE FROM {temp_table[id_table]} WHERE id = {value}";
            try
            {
                __DB_manager.queryDataBase(query).Close();
                __logging_class.Log("ControlDBManager", "deleteElemet", "succeful", $"Элемент: {value}, из таблицы: {temp_table[id_table]} успешно удалён");
            }
            catch(Exception ex)
            {
                __logging_class.Log("ControlDBManager", "deleteElemet", "Error", $"Элемент: {value}, из таблицы: {temp_table[id_table]} не был удалён");
                return false;
            }
            return true;
            
        }
        public bool updateElement(int id_table, DataRow row)
        {
            string query;
            switch (id_table)
            {
                case 0:
                    query = $"UPDATE {__DB_manager.organization_table_name} SET " +
                            $"Organization = '{row[1]}', " +
                            $"Cash_turnover = {row[2]}, " +
                            $"Direction_activity = '{row[3]}', " +
                            $"Total_staff = {row[4]}, " +
                            $"Country = '{row[5]}' WHERE id = {row[0]}";
                    try
                    {
                        __DB_manager.queryDataBase(query).Close();
                        __logging_class.Log("ControlDBManager", "updateElement", "Succeful",
                                            $"Элемент: {row[0]}, из таблицы: {__DB_manager.organization_table_name}, успешно обновлён");
                    }
                    catch(Exception e)
                    {
                        __logging_class.Log("ControlDBManager", "updateElement", "Error",
                                            $"Элемент: {row[0]}, из таблицы: {__DB_manager.organization_table_name}, не был обновлён");
                        return false;
                    }
                    break;
                case 1:
                    query = $"UPDATE {__DB_manager.staff_table_name} SET " +
                            $"Last_name = '{row[1]}', " +
                            $"First_name = '{row[2]}', " +
                            $"Patronymic = '{row[3]}', " +
                            $"id_organization = {row[4]}, " +
                            $"Profession = '{row[5]}', " +
                            $"Salary = {row[6]}, " +
                            $"Company_utility_coef = {row[7]}, " +
                            $"Path_to_photography = '{row[8]}' WHERE id = {row[0]}";
                    try
                    {
                        __DB_manager.queryDataBase(query).Close();
                        __logging_class.Log("ControlDBManager", "updateElement", "Succeful",
                                            $"Элемент: {row[0]}, из таблицы: {__DB_manager.staff_table_name}, успешно обновлён");
                    }
                    catch (Exception e)
                    {
                        __logging_class.Log("ControlDBManager", "updateElement", "Error",
                                            $"Элемент: {row[0]}, из таблицы: {__DB_manager.staff_table_name}, не был обновлён");
                        return false;
                    }
                    break;
            }
            return true;
        }
        public bool addElement(int id_table, DataRow row)
        {
            string query;
            switch (id_table)
            {
                case 0:
                    query = $"INSERT INTO {__DB_manager.organization_table_name} " +
                            $"(Organization, Cash_turnover, Direction_activity, Total_staff, Country) " +
                            $"VALUES ('{row[1]}',{row[2]},'{row[3]}',{row[4]},'{row[5]}')";
                    try
                    {
                        __DB_manager.queryDataBase(query).Close();
                        __logging_class.Log("ControlDBManager", "updateElement", "Succeful",
                                            $"Элемент успешно добавлен, в таблицу {__DB_manager.organization_table_name}");
                    }
                    catch (Exception e)
                    {
                        __logging_class.Log("ControlDBManager", "updateElement", "Error",
                                            $"Элемент не был добавлен в таблицу {__DB_manager.organization_table_name}");
                        return false;
                    }
                    break;
                case 1:
                    query = $"INSERT INTO {__DB_manager.staff_table_name} " +
                            $"(Last_name, First_name, Patronymic, id_organization, Profession, Salary, " +
                            $"Company_utility_coef, Path_to_photography) " +
                            $"VALUES ('{row[1]}', '{row[2]}', '{row[3]}', {row[4]}, '{row[5]}', {row[6]}, {row[7]}, '{row[8]}')";
                    try
                    {
                        __DB_manager.queryDataBase(query).Close();
                        __logging_class.Log("ControlDBManager", "updateElement", "Succeful",
                                            $"Элемент успешно добавлен, в таблицу {__DB_manager.staff_table_name}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        __logging_class.Log("ControlDBManager", "updateElement", "Error",
                                            $"Элемент не был добавлен в таблицу {__DB_manager.staff_table_name}");
                        return false;
                    }
                    break;
            }
            return true;
        }
    }
}
