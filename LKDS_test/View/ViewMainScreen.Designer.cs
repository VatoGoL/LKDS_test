namespace LKDS_test
{
    partial class ViewMainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.@__l_name_settings_file = new System.Windows.Forms.Label();
            this.@__but_load_settings_file = new System.Windows.Forms.Button();
            this.@__but_more = new System.Windows.Forms.Button();
            this.@__but_add = new System.Windows.Forms.Button();
            this.@__but_redact = new System.Windows.Forms.Button();
            this.@__but_delete = new System.Windows.Forms.Button();
            this.@__horizontal_line = new System.Windows.Forms.Label();
            this.@__cb_table = new System.Windows.Forms.ComboBox();
            this.@__cb_fields = new System.Windows.Forms.ComboBox();
            this.@__tb_search_request = new System.Windows.Forms.TextBox();
            this.@__but_search = new System.Windows.Forms.Button();
            this.@__but_generate = new System.Windows.Forms.Button();
            this.@__tab_control = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // __l_name_settings_file
            // 
            this.@__l_name_settings_file.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.@__l_name_settings_file.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.@__l_name_settings_file.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__l_name_settings_file.Location = new System.Drawing.Point(424, 21);
            this.@__l_name_settings_file.Name = "__l_name_settings_file";
            this.@__l_name_settings_file.Size = new System.Drawing.Size(348, 40);
            this.@__l_name_settings_file.TabIndex = 1;
            this.@__l_name_settings_file.Text = "Добавьте файл с именем БД";
            this.@__l_name_settings_file.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // __but_load_settings_file
            // 
            this.@__but_load_settings_file.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__but_load_settings_file.Location = new System.Drawing.Point(518, 86);
            this.@__but_load_settings_file.Name = "__but_load_settings_file";
            this.@__but_load_settings_file.Size = new System.Drawing.Size(165, 40);
            this.@__but_load_settings_file.TabIndex = 2;
            this.@__but_load_settings_file.Text = "Загрузить";
            this.@__but_load_settings_file.UseVisualStyleBackColor = true;
            this.@__but_load_settings_file.Click += new System.EventHandler(this.@__but_load_settings_file_Click);
            // 
            // __but_more
            // 
            this.@__but_more.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__but_more.Location = new System.Drawing.Point(424, 222);
            this.@__but_more.Name = "__but_more";
            this.@__but_more.Size = new System.Drawing.Size(165, 40);
            this.@__but_more.TabIndex = 3;
            this.@__but_more.Text = "Подробнее";
            this.@__but_more.UseVisualStyleBackColor = true;
            this.@__but_more.Click += new System.EventHandler(this.@__but_more_Click);
            // 
            // __but_add
            // 
            this.@__but_add.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__but_add.Location = new System.Drawing.Point(607, 222);
            this.@__but_add.Name = "__but_add";
            this.@__but_add.Size = new System.Drawing.Size(165, 40);
            this.@__but_add.TabIndex = 4;
            this.@__but_add.Text = "Добавить";
            this.@__but_add.UseVisualStyleBackColor = true;
            this.@__but_add.Click += new System.EventHandler(this.@__but_add_Click);
            // 
            // __but_redact
            // 
            this.@__but_redact.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__but_redact.Location = new System.Drawing.Point(424, 280);
            this.@__but_redact.Name = "__but_redact";
            this.@__but_redact.Size = new System.Drawing.Size(165, 40);
            this.@__but_redact.TabIndex = 5;
            this.@__but_redact.Text = "Редактировать";
            this.@__but_redact.UseVisualStyleBackColor = true;
            this.@__but_redact.Click += new System.EventHandler(this.@__but_redact_Click);
            // 
            // __but_delete
            // 
            this.@__but_delete.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__but_delete.Location = new System.Drawing.Point(607, 280);
            this.@__but_delete.Name = "__but_delete";
            this.@__but_delete.Size = new System.Drawing.Size(165, 40);
            this.@__but_delete.TabIndex = 6;
            this.@__but_delete.Text = "Удалить";
            this.@__but_delete.UseVisualStyleBackColor = true;
            this.@__but_delete.Click += new System.EventHandler(this.@__but_delete_Click);
            // 
            // __horizontal_line
            // 
            this.@__horizontal_line.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.@__horizontal_line.Location = new System.Drawing.Point(424, 349);
            this.@__horizontal_line.Name = "__horizontal_line";
            this.@__horizontal_line.Size = new System.Drawing.Size(348, 2);
            this.@__horizontal_line.TabIndex = 7;
            this.@__horizontal_line.UseMnemonic = false;
            // 
            // __cb_table
            // 
            this.@__cb_table.FormattingEnabled = true;
            this.@__cb_table.Location = new System.Drawing.Point(424, 381);
            this.@__cb_table.Name = "__cb_table";
            this.@__cb_table.Size = new System.Drawing.Size(163, 23);
            this.@__cb_table.TabIndex = 8;
            this.@__cb_table.TextChanged += new System.EventHandler(this.@__cb_table_TextChanged);
            // 
            // __cb_fields
            // 
            this.@__cb_fields.FormattingEnabled = true;
            this.@__cb_fields.Location = new System.Drawing.Point(609, 381);
            this.@__cb_fields.Name = "__cb_fields";
            this.@__cb_fields.Size = new System.Drawing.Size(163, 23);
            this.@__cb_fields.TabIndex = 9;
            // 
            // __tb_search_request
            // 
            this.@__tb_search_request.Location = new System.Drawing.Point(424, 416);
            this.@__tb_search_request.Name = "__tb_search_request";
            this.@__tb_search_request.Size = new System.Drawing.Size(348, 23);
            this.@__tb_search_request.TabIndex = 10;
            // 
            // __but_search
            // 
            this.@__but_search.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__but_search.Location = new System.Drawing.Point(518, 483);
            this.@__but_search.Name = "__but_search";
            this.@__but_search.Size = new System.Drawing.Size(165, 40);
            this.@__but_search.TabIndex = 11;
            this.@__but_search.Text = "Найти";
            this.@__but_search.UseVisualStyleBackColor = true;
            this.@__but_search.Click += new System.EventHandler(this.@__but_search_Click);
            // 
            // __but_generate
            // 
            this.@__but_generate.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.@__but_generate.Location = new System.Drawing.Point(483, 160);
            this.@__but_generate.Name = "__but_generate";
            this.@__but_generate.Size = new System.Drawing.Size(230, 40);
            this.@__but_generate.TabIndex = 12;
            this.@__but_generate.Text = "Сгенерировать БД";
            this.@__but_generate.UseVisualStyleBackColor = true;
            this.@__but_generate.Click += new System.EventHandler(this.@__but_generate_Click);
            // 
            // __tab_control
            // 
            this.@__tab_control.Location = new System.Drawing.Point(10, 15);
            this.@__tab_control.Name = "__tab_control";
            this.@__tab_control.SelectedIndex = 0;
            this.@__tab_control.Size = new System.Drawing.Size(389, 534);
            this.@__tab_control.TabIndex = 13;
            this.@__tab_control.SelectedIndexChanged += new System.EventHandler(this.@__tab_control_SelectedIndexChanged);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.@__tab_control);
            this.Controls.Add(this.@__but_generate);
            this.Controls.Add(this.@__but_search);
            this.Controls.Add(this.@__tb_search_request);
            this.Controls.Add(this.@__cb_fields);
            this.Controls.Add(this.@__cb_table);
            this.Controls.Add(this.@__horizontal_line);
            this.Controls.Add(this.@__but_delete);
            this.Controls.Add(this.@__but_redact);
            this.Controls.Add(this.@__but_add);
            this.Controls.Add(this.@__but_more);
            this.Controls.Add(this.@__but_load_settings_file);
            this.Controls.Add(this.@__l_name_settings_file);
            this.Name = "MainScreen";
            this.Text = "DBManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label __l_name_settings_file;
        private Button __but_load_settings_file;
        private Button __but_more;
        private Button __but_add;
        private Button __but_redact;
        private Button __but_delete;
        private Label __horizontal_line;
        private ComboBox __cb_table;
        private ComboBox __cb_fields;
        private TextBox __tb_search_request;
        private Button __but_search;
        private Button __but_generate;
        private TabControl __tab_control;
    }
}