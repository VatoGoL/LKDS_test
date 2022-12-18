using LKDS_test.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKDS_test.View
{
    public partial class ViewCompany : Form
    {
        private const int __BACK_TO_MAIN_SCREEN = 2;
        private const int __ID_TABLE_COMPANY = 0;
        private ControllerDataBaseManager __control_DB_manager;
        private ViewMainWindow __window_parent;
        private DataRow __data_row;
        private string __work_mode;
        public ControllerDataBaseManager control_DB_manager { get { return __control_DB_manager; } set { __control_DB_manager = value; } }
        public ViewMainWindow window_parent { get { return __window_parent; } set { __window_parent = value; } }
        public DataRow data_row 
        { 
            get 
            {
                __data_row[1] = __tb_company_name.Text;
                __data_row[2] = __tb_cash_turnover.Text;
                __data_row[3] = __tb_direction_activity.Text;
                __data_row[4] = __tb_total_staff.Text;
                __data_row[5] = __tb_country.Text;
                return __data_row;
            } 
            set 
            {
                __data_row = value; 
                if(work_mode != "Add")
                {
                    __tb_company_name.Text = __data_row[1].ToString();
                    __tb_cash_turnover.Text = __data_row[2].ToString();
                    __tb_direction_activity.Text = __data_row[3].ToString();
                    __tb_total_staff.Text = __data_row[4].ToString();
                    __tb_country.Text = __data_row[5].ToString();
                }
                else
                {
                    __but_action.Text = "Добавить";
                }
            } 
        }
        public string work_mode 
        { 
            get { return __work_mode; } 
            set 
            { 
                __work_mode = value; 
                if(value == "More")
                {
                    __tb_company_name.ReadOnly = true;
                    __tb_direction_activity.ReadOnly = true;
                    __tb_total_staff.ReadOnly = true;
                    __tb_cash_turnover.ReadOnly = true;
                    __tb_country.ReadOnly = true;
                }
                else if( value == "Redact" || value == "Add")
                {
                    __tb_company_name.ReadOnly = false;
                    __tb_direction_activity.ReadOnly = false ;
                    __tb_total_staff.ReadOnly = false;
                    __tb_cash_turnover.ReadOnly = false;
                    __tb_country.ReadOnly = false;
                    __but_action.Text = "Готово";
                }
            } 
        }
        public ViewCompany()
        {
            InitializeComponent();
        }

        private void __but_back_Click(object sender, EventArgs e)
        {
            window_parent.changeScreen(__BACK_TO_MAIN_SCREEN, null, "Screen_company");
        }

        private void __but_action_Click(object sender, EventArgs e)
        {
            if(__but_action.Text == "Редактировать")
            {
                __but_action.Text = "Готово";
                work_mode = "Redact";
            }
            else if(__but_action.Text == "Готово")
            {
                bool result = __control_DB_manager.updateElement(__ID_TABLE_COMPANY,data_row);
                string message;
                string caption = "Результат обновления";
                if (result)
                {
                    message = "Элемент успешно обновлён";
                }
                else
                {
                    message = "Элемент не получилось обновить";
                }
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
                work_mode = "More";
                __but_action.Text = "Редактировать";
            }
            else if(__but_action.Text == "Добавить")
            {
                bool result = __control_DB_manager.addElement(__ID_TABLE_COMPANY,data_row);
                string message;
                string caption = "Результат добавления";
                if (result)
                {
                    message = "Элемент успешно добавлен";
                }
                else
                {
                    message = "Элемент не получилось добавить в таблицу";
                }
                var res = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    window_parent.changeScreen(__BACK_TO_MAIN_SCREEN, null, "Screen_staff");
                }
            }
        }
    }
}
