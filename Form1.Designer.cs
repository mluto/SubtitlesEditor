namespace SubtitlesEditor
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
            Load_btn = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            Processing_btn = new Button();
            Save_btn = new Button();
            SuspendLayout();
            // 
            // Load_btn
            // 
            Load_btn.Location = new Point(89, 85);
            Load_btn.Name = "Load_btn";
            Load_btn.Size = new Size(75, 23);
            Load_btn.TabIndex = 0;
            Load_btn.Text = "Load file";
            Load_btn.UseVisualStyleBackColor = true;
            Load_btn.Click += LoadButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(212, 129);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(126, 23);
            textBox1.TabIndex = 1;
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.Leave += textBox1_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 105);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 2;
            label1.Text = "subtitles time offset [s]";
            // 
            // Processing_btn
            // 
            Processing_btn.Enabled = false;
            Processing_btn.Location = new Point(89, 128);
            Processing_btn.Name = "Processing_btn";
            Processing_btn.Size = new Size(75, 23);
            Processing_btn.TabIndex = 3;
            Processing_btn.Text = "Processing";
            Processing_btn.UseVisualStyleBackColor = true;
            Processing_btn.Click += Processing_btn_Click;
            // 
            // Save_btn
            // 
            Save_btn.Enabled = false;
            Save_btn.Location = new Point(89, 172);
            Save_btn.Name = "Save_btn";
            Save_btn.Size = new Size(75, 23);
            Save_btn.TabIndex = 4;
            Save_btn.Text = "Save files";
            Save_btn.UseVisualStyleBackColor = true;
            Save_btn.Click += Save_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Save_btn);
            Controls.Add(Processing_btn);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(Load_btn);
            Name = "Form1";
            Text = "Super Subtitles Editor";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Load_btn;
        private TextBox textBox1;
        private Label label1;
        private Button Processing_btn;
        private Button Save_btn;
    }
}