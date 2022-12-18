using System;
using System.IO;
using System.Text;
using LKDS_test.Model;
using LKDS_test.View;

namespace LKDS_test
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new ViewMainWindow());

            /*string default_path_settings = "./../../../../config.txt";
            string default_path_logging = "./../../../../log.txt";
            
            StreamWriter log_writer= new StreamWriter(default_path_logging,true);

            ModelLoggingClass logging_class = new ModelLoggingClass(ref log_writer);

            if (!File.Exists(default_path_settings) )
            {
                logging_class.Log("File","Exists","error","Файл с название БД не существует");
                logging_class.Close();
                return;
            }
            

            int max_length_DB_name = 128;
            StreamReader fin = new StreamReader(default_path_settings, Encoding.UTF8);

            string ?db_name = fin.ReadLine();
            if (db_name != null && db_name.Length <= max_length_DB_name)
            {
                ModelDataBaseManager mdb = new ModelDataBaseManager(db_name);
            }
            else
            {
                logging_class.Log("fin", "ReadLine", "null", "Файл не содержит имени Базы данных");
                logging_class.Close();
            }
            */
        }
    }
}