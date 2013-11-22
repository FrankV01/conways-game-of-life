namespace Output
{
    partial class Form1
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
            this.pixel1 = new Output.UserControls.Pixel();
            this.pixel2 = new Output.UserControls.Pixel();
            this.SuspendLayout();
            // 
            // pixel1
            // 
            this.pixel1.BackColor = System.Drawing.Color.White;
            this.pixel1.Location = new System.Drawing.Point(29, 80);
            this.pixel1.Name = "pixel1";
            this.pixel1.Size = new System.Drawing.Size(10, 10);
            this.pixel1.State = false;
            this.pixel1.TabIndex = 0;
            // 
            // pixel2
            // 
            this.pixel2.BackColor = System.Drawing.Color.White;
            this.pixel2.Location = new System.Drawing.Point(46, 80);
            this.pixel2.Name = "pixel2";
            this.pixel2.Size = new System.Drawing.Size(10, 10);
            this.pixel2.State = false;
            this.pixel2.TabIndex = 1;
            this.pixel2.Click += new System.EventHandler(this.pixel2_OnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pixel2);
            this.Controls.Add(this.pixel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Pixel pixel1;
        private UserControls.Pixel pixel2;
    }
}

