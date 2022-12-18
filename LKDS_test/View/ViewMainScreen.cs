using LKDS_test.View;
using LKDS_test.Controller;
using LKDS_test.Model;
using System.Windows.Forms;
using System.Data;

namespace LKDS_test
{
    public partial class ViewMainScreen : Form
    {
        private ControllerDataBaseManager? __control_DB_manager;
        private string __path_to_file_settings;
        private List<ModelComboBoxString>? __db_names;
        private List<List<ModelComboBoxString>>? __fields;
        private List<TabPage> __tab_pages;
        private List<DataGridView> __data_greed;
        private List<DataTable> __data_table;
        private List<ModelDataCompany> __data_model_company;
        private List<ModelDataStaff> __data_model_staff;
        private ViewMainWindow __window_parent;
        public ControllerDataBaseManager control_DB_manager { get { return __control_DB_manager; } set { __control_DB_manager = value; } }
        public ViewMainWindow window_parent { get { return __window_parent; } set { __window_parent = value; } }
        public ViewMainScreen()
        {
            InitializeComponent();
            
            __but_add.Enabled = false;
            __but_delete.Enabled = false;
            __but_redact.Enabled = false;
            __but_more.Enabled = false;
            __but_generate.Enabled = false;
            __but_search.Enabled = false;
        }

        private void __but_load_settings_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "Text file(*.txt)|*.txt|All files(*.*)|*.*";
            open_file_dialog.DefaultExt = "txt";
            open_file_dialog.AddExtension = true;
            open_file_dialog.Title = "Открыть файл с именем БД";
            open_file_dialog.InitialDirectory = "./../../../../../../";

            if(open_file_dialog.ShowDialog() == DialogResult.OK)
            {
                __l_name_settings_file.Text = open_file_dialog.SafeFileName;
                __path_to_file_settings = open_file_dialog.FileName;
                try
                {
                    control_DB_manager = new ControllerDataBaseManager(__path_to_file_settings);
                }
                catch(Exception ex)
                {
                    return;
                }
                
                __but_add.Enabled = true;
                __but_generate.Enabled = true;
                __but_search.Enabled = true;

                __db_names = control_DB_manager.getTableNames();
                
                if (__db_names != null)
                {
                    __fields = new List<List<ModelComboBoxString>>();
                    __tab_pages = new List<TabPage>();
                    __data_greed = new List<DataGridView>();
                    __data_table = new List<DataTable>();
                    for (int i = 0; i < __db_names.Count; i++)
                    {
                        __fields.Add(control_DB_manager.getFieldNames(__db_names[i].content));
                        __data_table.Add(new DataTable());
                        __data_greed.Add(new DataGridView());
                        __tab_pages.Add(new TabPage());
                        __tab_pages[i].Text = __db_names[i].content;
                        __tab_pages[i].TabIndex = i;
                    }
                    
                    __cb_table.DataSource = __db_names;
                    __cb_table.DisplayMember = "content";
                    __cb_table.ValueMember = "id";

                    __cb_fields.DataSource = __fields[0];
                    __cb_fields.DisplayMember = "content";
                    __cb_fields.ValueMember = "id";
                    
                    for(int i = 0; i < __data_table.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                __data_table[i].Columns.Add(__fields[i][0].content, typeof(int));
                                __data_table[i].Columns.Add(__fields[i][1].content, typeof(string));
                                __data_table[i].Columns.Add(__fields[i][2].content, typeof(int));
                                __data_table[i].Columns.Add(__fields[i][3].content, typeof(string));
                                __data_table[i].Columns.Add(__fields[i][4].content, typeof(int));
                                __data_table[i].Columns.Add(__fields[i][5].content, typeof(string));
                                break;
                            case 1:
                                __data_table[i].Columns.Add(__fields[i][0].content, typeof(int));
                                __data_table[i].Columns.Add(__fields[i][1].content, typeof(string));
                                __data_table[i].Columns.Add(__fields[i][2].content, typeof(string));
                                __data_table[i].Columns.Add(__fields[i][3].content, typeof(string));
                                __data_table[i].Columns.Add(__fields[i][4].content, typeof(int));
                                __data_table[i].Columns.Add(__fields[i][5].content, typeof(string));
                                __data_table[i].Columns.Add(__fields[i][6].content, typeof(int));
                                __data_table[i].Columns.Add(__fields[i][7].content, typeof(int));
                                __data_table[i].Columns.Add(__fields[i][8].content, typeof(string));
                                break;
                        }
                        __data_greed[i].DataSource = __data_table[i];
                        __data_greed[i].Width = __tab_control.Width-10;
                        __data_greed[i].Height = __tab_control.Height-30;
                        __data_greed[i].Location = new Point(0, 0);
                        __data_greed[i].AllowUserToAddRows = false;
                        __data_greed[i].AllowUserToDeleteRows = false;
                        __data_greed[i].ReadOnly = true;
                        __data_greed[i].SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        __data_greed[i].CellClick += new DataGridViewCellEventHandler(
                            (object sender, DataGridViewCellEventArgs e) => 
                            {
                                __but_delete.Enabled = true;
                                __but_redact.Enabled = true;
                                __but_more.Enabled = true;
                            }
                            );
                        
                    }

                    for (int i = 0; i < __tab_pages.Count; i++)
                    {
                        __tab_control.TabPages.Add(__tab_pages[i]);
                        __data_greed[i].Parent = __tab_pages[i];
                    }

                    tableUpdate(0);
                }
                
            }
        }
        
        private void __cb_table_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            for(; i < __db_names.Count; i++)
            {
                if(__cb_table.Text == __db_names[i].content)
                {
                    break;
                }
            }

            if(i < __db_names.Count) 
            {
                __cb_fields.DataSource = __fields[i];
                __cb_fields.DisplayMember = "content";
                __cb_fields.ValueMember = "id";
            }
        }

        private void __tab_control_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableUpdate(__tab_control.SelectedIndex);
        }

        private void __but_generate_Click(object sender, EventArgs e)
        {
            bool result = control_DB_manager.fillDataBase();
            string message;
            string caption = "Результат заполнения";
            if (result)
            {
                message = "База данных успешно заполнена";
            }
            else
            {
                message = "База данных не была заполнена так как уже имеет элементы внутри таблиц";
            }
            tableUpdate(__tab_control.SelectedIndex);
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        private void __but_search_Click(object sender, EventArgs e)
        {
            int column_id = (int)__cb_fields.SelectedValue;
            int table_id = (int)__cb_table.SelectedValue;

            for (int i = 0; i < __data_table[table_id].Rows.Count; i++)
            {
                if (__data_table[table_id].Rows[i][column_id].ToString().ToLower() == __tb_search_request.Text.ToLower())
                {
                    __tab_control.SelectTab(__tab_pages[table_id]);
                    __data_greed[table_id].CurrentCell = __data_greed[table_id][column_id, i];
                    __but_delete.Enabled = true;
                    __but_redact.Enabled = true;
                    __but_more.Enabled = true;
                    break;
                }
            }
        }

        private void tableUpdate(int table_id)
        {
            switch (table_id)
            {
                case 0:
                    __data_model_company = control_DB_manager.getCompanyList();
                    for (int i = 0, length = __data_table[0].Rows.Count; i < length; i++)
                    {
                        __data_table[0].Rows.Remove(__data_table[0].Rows[0]);

                    }
                    for (int i = 0; i < __data_model_company.Count; i++)
                    {
                        __data_table[0].Rows.Add(__data_model_company[i].id, __data_model_company[i].organization,
                                                 __data_model_company[i].cash_turnover, __data_model_company[i].direction_activity,
                                                 __data_model_company[i].total_saff, __data_model_company[i].country);
                    }
                    break;
                case 1:
                    __data_model_staff = control_DB_manager.getStaffList();
                    if (__data_table[1].Rows.Count > 0)
                    {
                        for (int i = 0, length = __data_table[1].Rows.Count; i < length; i++)
                        {
                            __data_table[1].Rows.Remove(__data_table[1].Rows[0]);

                        }
                    }
                    for (int i = 0; i < __data_model_staff.Count; i++)
                    {
                        __data_table[1].Rows.Add(__data_model_staff[i].id, __data_model_staff[i].last_name,
                                                 __data_model_staff[i].first_name, __data_model_staff[i].patronymic,
                                                 __data_model_staff[i].id_organization,
                                                 __data_model_staff[i].profession, __data_model_staff[i].salary,
                                                 __data_model_staff[i].company_utility_coef, __data_model_staff[i].path_to_photography);
                    }
                    break;
            }
        }
        private void __but_delete_Click(object sender, EventArgs e)
        {
            int table_id = (int)__tab_control.SelectedIndex;
            Point cell = __data_greed[table_id].CurrentCellAddress;
            string value = __data_greed[table_id][0,cell.Y].Value.ToString();
            control_DB_manager.deleteElement(table_id, value);
            tableUpdate(table_id);
        }

        private void __but_more_Click(object sender, EventArgs e)
        {
            int table_id = __tab_control.SelectedIndex;
            Point cell = __data_greed[table_id].CurrentCellAddress;
            DataRow row =  __data_table[table_id].Rows[cell.Y];
            window_parent.changeScreen(table_id, row, "More");
        }
        private void __but_add_Click(object sender, EventArgs e)
        {
            int table_id = __tab_control.SelectedIndex;
            Point cell = __data_greed[table_id].CurrentCellAddress;
            DataRow row = __data_table[table_id].Rows[cell.Y];
            window_parent.changeScreen(table_id, row, "Add");
        }
        private void __but_redact_Click(object sender, EventArgs e)
        {
            int table_id = __tab_control.SelectedIndex;
            Point cell = __data_greed[table_id].CurrentCellAddress;
            DataRow row = __data_table[table_id].Rows[cell.Y];
            window_parent.changeScreen(table_id, row, "Redact");
        }
    }
}