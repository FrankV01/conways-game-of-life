namespace FrankVillasenor.Life.Output
{
    partial class Main
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCellList = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grid1 = new FrankVillasenor.Life.Output.UserControls.Grid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCellList);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(696, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 615);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cbCellList
            // 
            this.cbCellList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCellList.FormattingEnabled = true;
            this.cbCellList.Location = new System.Drawing.Point(6, 19);
            this.cbCellList.Name = "cbCellList";
            this.cbCellList.Size = new System.Drawing.Size(221, 21);
            this.cbCellList.TabIndex = 2;
            this.cbCellList.SelectedIndexChanged += new System.EventHandler(this.cbCellList_SelectedIndexChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 75);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(221, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.stop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 46);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(221, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.start_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.Location = new System.Drawing.Point(12, 12);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(677, 616);
            this.grid1.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 633);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid1);
            this.Name = "Main";
            this.Text = "Frank Villasesnor\'s Game of Life";
            this.Load += new System.EventHandler(this.OnLoad);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox cbCellList;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

