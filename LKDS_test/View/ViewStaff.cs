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
    public partial class ViewStaff : Form
    {
        private const int __BACK_TO_MAIN_SCREEN = 2;
        private const int __ID_TABLE_STAFF = 1;
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
                __data_row[1] = __tb_last_name.Text;
                __data_row[2] = __tb_name.Text;
                __data_row[3] = __tb_patronymic.Text;
                __data_row[4] = __tb_id_organization.Text;
                __data_row[5] = __tb_profession.Text;
                __data_row[6] = __tb_salary.Text;
                __data_row[7] = __tb_company_utility_coef.Text;
                __data_row[8] = __pb_images.ImageLocation;

                return __data_row;
            }
            set
            {
                __data_row = value;
                if (work_mode != "Add")
                {
                    __tb_last_name.Text = __data_row[1].ToString();
                    __tb_name.Text = __data_row[2].ToString();
                    __tb_patronymic.Text = __data_row[3].ToString();
                    __tb_id_organization.Text = __data_row[4].ToString();
                    __tb_profession.Text = __data_row[5].ToString();
                    __tb_salary.Text = __data_row[6].ToString();
                    __tb_company_utility_coef.Text = __data_row[7].ToString();
                    __pb_images.ImageLocation = __data_row[8].ToString();

                    
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
                if (value == "More")
                {
                    __tb_last_name.ReadOnly = true;
                    __tb_name.ReadOnly = true;
                    __tb_patronymic.ReadOnly = true;
                    __tb_id_organization.ReadOnly = true;
                    __tb_profession.ReadOnly = true;
                    __tb_salary.ReadOnly = true;
                    __tb_company_utility_coef.ReadOnly = true;
                    __but_add_pics.Enabled = false;
                }
                else if (value == "Redact" || value == "Add")
                {
                    __tb_last_name.ReadOnly = false;
                    __tb_name.ReadOnly = false;
                    __tb_patronymic.ReadOnly = false;
                    __tb_id_organization.ReadOnly = false;
                    __tb_profession.ReadOnly = false;
                    __tb_salary.ReadOnly = false;
                    __tb_company_utility_coef.ReadOnly = false;

                    __but_add_pics.Enabled = true;
                    __but_action.Text = "Готово";
                }
            }
        }
        public ViewStaff()
        {
            InitializeComponent();
            __pb_images.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void __but_back_Click(object sender, EventArgs e)
        {
            window_parent.changeScreen(__BACK_TO_MAIN_SCREEN, null, "Screen_staff");
        }

        private void __but_action_Click(object sender, EventArgs e)
        {
            if (__but_action.Text == "Редактировать")
            {
                __but_action.Text = "Готово";
                work_mode = "Redact";
            }
            else if (__but_action.Text == "Готово")
            {
                bool result = __control_DB_manager.updateElement(__ID_TABLE_STAFF, data_row);
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
                MessageBox.Show(message,caption,MessageBoxButtons.OK);
                work_mode = "More";
                __but_action.Text = "Редактировать";
            }
            else if (__but_action.Text == "Добавить")
            {
                bool result = __control_DB_manager.addElement(__ID_TABLE_STAFF, data_row);
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
                if(res == DialogResult.OK)
                {
                    window_parent.changeScreen(__BACK_TO_MAIN_SCREEN, null, "Screen_staff");
                }
            }
        }

        private void __but_add_pics_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "Picture file(*.png, *.jpg)|*.png;*.jpg|All files(*.*)|*.*";
            open_file_dialog.Title = "Добавить изображение";
            open_file_dialog.InitialDirectory = "./../../../../../../";

            if (open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                __pb_images.ImageLocation = open_file_dialog.FileName;
            }
        }
    }
}
