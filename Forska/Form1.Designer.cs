namespace Forska
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Modeling = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Modeling
            // 
            this.Modeling.BackColor = System.Drawing.Color.ForestGreen;
            this.Modeling.Location = new System.Drawing.Point(59, 374);
            this.Modeling.Name = "Modeling";
            this.Modeling.Size = new System.Drawing.Size(110, 63);
            this.Modeling.TabIndex = 0;
            this.Modeling.Text = "Моделирование";
            this.Modeling.UseVisualStyleBackColor = false;
            this.Modeling.Click += new System.EventHandler(this.Modeling_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Tomato;
            this.Exit.Location = new System.Drawing.Point(454, 374);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(108, 63);
            this.Exit.TabIndex = 1;
            this.Exit.Text = "Выход";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(638, 479);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Modeling);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forska";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Modeling;
        private System.Windows.Forms.Button Exit;
    }
}

