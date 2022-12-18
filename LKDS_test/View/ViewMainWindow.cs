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
    public partial class ViewMainWindow : Form
    {
        private ControllerDataBaseManager __control_DB_manager;
        private ViewMainScreen __screen_main;
        private ViewCompany __screen_company;
        private ViewStaff __screen_staff;
        public ViewMainWindow()
        {
            InitializeComponent();
            __screen_main = new ViewMainScreen();
            __screen_main.window_parent = this;
            __screen_main.control_DB_manager = __control_DB_manager;
            __screen_main.MdiParent = this;
            __screen_main.FormBorderStyle= FormBorderStyle.None;
            __screen_main.StartPosition = FormStartPosition.CenterScreen;
            __screen_main.Show();
        }

        public void changeScreen(int screen_id, DataRow ?row, string mode)
        {
            switch(screen_id)
            {
                case 0:
                    if(row != null)
                    {
                        __screen_main.Hide();

                        __screen_company = new ViewCompany();
                        __screen_company.window_parent = this;
                        __screen_company.control_DB_manager = __screen_main.control_DB_manager;
                        __screen_company.work_mode = mode;
                        __screen_company.data_row = row;
                        __screen_company.MdiParent = this;
                        __screen_company.FormBorderStyle = FormBorderStyle.None;
                        __screen_company.StartPosition = FormStartPosition.CenterScreen;
                        __screen_company.Show();
                    }
                    break;
                case 1:
                    if(row != null)
                    {
                        __screen_main.Hide();

                        __screen_staff = new ViewStaff();
                        __screen_staff.window_parent = this;
                        __screen_staff.control_DB_manager = __screen_main.control_DB_manager;
                        __screen_staff.work_mode = mode;
                        __screen_staff.data_row = row;
                        __screen_staff.MdiParent = this;
                        __screen_staff.FormBorderStyle = FormBorderStyle.None;
                        __screen_staff.StartPosition = FormStartPosition.CenterScreen;
                        __screen_staff.Show();
                    }
                    break;
                case 2:
                    if(mode == "Screen_company")
                    {
                        __screen_main.control_DB_manager = __screen_company.control_DB_manager;
                        __screen_company.Hide();
                    }
                    else if(mode == "Screen_staff")
                    {
                        __screen_main.control_DB_manager = __screen_staff.control_DB_manager;
                        __screen_staff.Hide();
                    }
                    __screen_main.StartPosition = FormStartPosition.CenterScreen;
                    __screen_main.Show();
                   
                    break;
            }
        }
    }
}
