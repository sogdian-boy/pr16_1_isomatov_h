
namespace pr16_1_Isomatov_h
{
    partial class Form1
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
            this.word = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // word
            // 
            this.word.Location = new System.Drawing.Point(12, 12);
            this.word.Name = "word";
            this.word.PlaceholderText = "Искомое слово";
            this.word.Size = new System.Drawing.Size(100, 23);
            this.word.TabIndex = 0;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(119, 11);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 2;
            this.search.Text = "найти";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(13, 42);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(60, 15);
            this.result.TabIndex = 3;
            this.result.Text = "Результат";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.result);
            this.Controls.Add(this.search);
            this.Controls.Add(this.word);
            this.Name = "Form1";
            this.Text = "Поиск слова";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox word;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label result;
    }
}

