namespace GuiTest
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbGo = new System.Windows.Forms.Button();
            this.tbErrors = new System.Windows.Forms.RichTextBox();
            this.tbAsm = new System.Windows.Forms.RichTextBox();
            this.tbSource = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходный код";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ассемблер";
            // 
            // pbGo
            // 
            this.pbGo.Location = new System.Drawing.Point(734, 544);
            this.pbGo.Name = "pbGo";
            this.pbGo.Size = new System.Drawing.Size(75, 23);
            this.pbGo.TabIndex = 2;
            this.pbGo.Text = "|>";
            this.pbGo.UseVisualStyleBackColor = true;
            this.pbGo.Click += new System.EventHandler(this.pbGo_Click);
            // 
            // tbErrors
            // 
            this.tbErrors.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbErrors.Location = new System.Drawing.Point(12, 382);
            this.tbErrors.Name = "tbErrors";
            this.tbErrors.ReadOnly = true;
            this.tbErrors.Size = new System.Drawing.Size(797, 156);
            this.tbErrors.TabIndex = 4;
            this.tbErrors.Text = "";
            // 
            // tbAsm
            // 
            this.tbAsm.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbAsm.Location = new System.Drawing.Point(410, 68);
            this.tbAsm.Name = "tbAsm";
            this.tbAsm.ReadOnly = true;
            this.tbAsm.Size = new System.Drawing.Size(399, 308);
            this.tbAsm.TabIndex = 5;
            this.tbAsm.Text = "";
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(12, 68);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(392, 308);
            this.tbSource.TabIndex = 6;
            this.tbSource.Text = "Var a,b;\nBegin\nEnd\n";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 571);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.tbAsm);
            this.Controls.Add(this.tbErrors);
            this.Controls.Add(this.pbGo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MetaL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button pbGo;
        private System.Windows.Forms.RichTextBox tbErrors;
        private System.Windows.Forms.RichTextBox tbAsm;
        private System.Windows.Forms.RichTextBox tbSource;
    }
}

