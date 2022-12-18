using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKDS_test.Model
{
    public class ModelDataCompany
    {
        public int id { get; set; }
        public string organization { get; set; }
        public int cash_turnover { get; set; }
        public string direction_activity { get; set; }
        public int total_saff { get; set; }
        public string country { get; set; }

        public ModelDataCompany(int id, string organization, int cash_turnover,
                                string direction_activity, int total_staff, string country)
        { 
            this.id = id;
            this.organization = organization;
            this.cash_turnover= cash_turnover;
            this.direction_activity = direction_activity;
            this.total_saff= total_staff;
            this.country = country;
        }
    }
    public class ModelDataStaff
    {
        public int id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string patronymic { get; set; }
        public int id_organization { get; set; }
        public string profession { get; set; }
        public int salary { get; set; }
        public int company_utility_coef { get; set; }
        public string path_to_photography { get; set; }

        public ModelDataStaff(int id, string last_name, string first_name, string patronymic, 
                              int id_organization, string profession, int salary, int company_utility_coef,
                              string path_to_photography)
        {
            this.id = id;
            this.last_name = last_name;
            this.first_name = first_name;
            this.patronymic = patronymic;
            this.id_organization = id_organization;
            this.profession = profession;
            this.salary = salary;
            this.company_utility_coef = company_utility_coef;
            this.path_to_photography = path_to_photography;
        }
    }
    public class ModelComboBoxString
    {
        public int id { get; set; }
        public string content { get; set; }
        public ModelComboBoxString(int id, string content)
        {
            this.id = id;
            this.content = content;
        }
    }
}
