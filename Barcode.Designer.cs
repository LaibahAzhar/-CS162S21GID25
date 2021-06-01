
namespace dashboard
{
    partial class Barcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Barcode));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.scanbtn = new System.Windows.Forms.Button();
            this.stopbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(45, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 360);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // scanbtn
            // 
            this.scanbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(175)))), ((int)(((byte)(5)))));
            this.scanbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scanbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.scanbtn.FlatAppearance.BorderSize = 0;
            this.scanbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scanbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scanbtn.ForeColor = System.Drawing.Color.Black;
            this.scanbtn.Image = ((System.Drawing.Image)(resources.GetObject("scanbtn.Image")));
            this.scanbtn.Location = new System.Drawing.Point(95, 388);
            this.scanbtn.Name = "scanbtn";
            this.scanbtn.Size = new System.Drawing.Size(120, 41);
            this.scanbtn.TabIndex = 32;
            this.scanbtn.Text = "Scan";
            this.scanbtn.UseVisualStyleBackColor = false;
            this.scanbtn.Click += new System.EventHandler(this.scanbtn_Click_1);
            // 
            // stopbtn
            // 
            this.stopbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(175)))), ((int)(((byte)(5)))));
            this.stopbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopbtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.stopbtn.FlatAppearance.BorderSize = 0;
            this.stopbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.stopbtn.ForeColor = System.Drawing.Color.Black;
            this.stopbtn.Image = ((System.Drawing.Image)(resources.GetObject("stopbtn.Image")));
            this.stopbtn.Location = new System.Drawing.Point(409, 388);
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(120, 41);
            this.stopbtn.TabIndex = 32;
            this.stopbtn.Text = "Stop";
            this.stopbtn.UseVisualStyleBackColor = false;
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click_1);
            // 
            // Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(175)))), ((int)(((byte)(5)))));
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.stopbtn);
            this.Controls.Add(this.scanbtn);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Barcode";
            this.Text = "Barcode";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button scanbtn;
        private System.Windows.Forms.Button stopbtn;
    }
}