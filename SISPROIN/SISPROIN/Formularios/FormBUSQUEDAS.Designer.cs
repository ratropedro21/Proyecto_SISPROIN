namespace SISPROIN.Formularios
{
    partial class FormBUSQUEDAS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXT_Text = new System.Windows.Forms.MaskedTextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // TXT_Text
            // 
            this.TXT_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_Text.Culture = new System.Globalization.CultureInfo("es-AR");
            this.TXT_Text.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.TXT_Text.Location = new System.Drawing.Point(8, 27);
            this.TXT_Text.Name = "TXT_Text";
            this.TXT_Text.PromptChar = ' ';
            this.TXT_Text.Size = new System.Drawing.Size(227, 25);
            this.TXT_Text.TabIndex = 100;
            this.TXT_Text.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.TXT_Text.Visible = false;
            this.TXT_Text.TextChanged += new System.EventHandler(this.TXT_Text_TextChanged);
            this.TXT_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXT_Text_KeyDown);
            this.TXT_Text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_Text_KeyPress);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radioButton2.Location = new System.Drawing.Point(455, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(101, 21);
            this.radioButton2.TabIndex = 99;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.radioButton1.Location = new System.Drawing.Point(455, 14);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(101, 21);
            this.radioButton1.TabIndex = 98;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // listView
            // 
            this.listView.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.listView.AllowColumnReorder = true;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.Location = new System.Drawing.Point(6, 68);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(692, 364);
            this.listView.TabIndex = 97;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // FormBUSQUEDAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 437);
            this.Controls.Add(this.TXT_Text);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.listView);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormBUSQUEDAS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBUSQUEDAS";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBUSQUEDAS_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox TXT_Text;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ListView listView;
    }
}