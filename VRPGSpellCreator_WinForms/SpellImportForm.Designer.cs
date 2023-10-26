namespace VRPGSpellCreator_WinForms
{
    partial class SpellImportForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_importSqlInsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(833, 27);
            this.textBox1.TabIndex = 0;
            // 
            // button_importSqlInsert
            // 
            this.button_importSqlInsert.Location = new System.Drawing.Point(360, 78);
            this.button_importSqlInsert.Name = "button_importSqlInsert";
            this.button_importSqlInsert.Size = new System.Drawing.Size(137, 36);
            this.button_importSqlInsert.TabIndex = 1;
            this.button_importSqlInsert.Text = "Import";
            this.button_importSqlInsert.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter SQL insert from DB Browser:";
            // 
            // SpellImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 126);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_importSqlInsert);
            this.Controls.Add(this.textBox1);
            this.Name = "SpellImportForm";
            this.Text = "SpellImportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button button_importSqlInsert;
        private Label label1;
    }
}