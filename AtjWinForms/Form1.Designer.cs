namespace AtjWinForms
{
    partial class Atencjometer
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
            this.txtbNick1 = new System.Windows.Forms.TextBox();
            this.txtBNick2 = new System.Windows.Forms.TextBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.avMirek2 = new System.Windows.Forms.PictureBox();
            this.avMirek1 = new System.Windows.Forms.PictureBox();
            this.rtxtBTagi2 = new System.Windows.Forms.RichTextBox();
            this.rtxtBTagi1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCommonTags = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avMirek2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avMirek1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbNick1
            // 
            this.txtbNick1.Location = new System.Drawing.Point(28, 29);
            this.txtbNick1.Name = "txtbNick1";
            this.txtbNick1.Size = new System.Drawing.Size(150, 20);
            this.txtbNick1.TabIndex = 0;
            // 
            // txtBNick2
            // 
            this.txtBNick2.Location = new System.Drawing.Point(335, 29);
            this.txtBNick2.Name = "txtBNick2";
            this.txtBNick2.Size = new System.Drawing.Size(146, 20);
            this.txtBNick2.TabIndex = 1;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(220, 29);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Porownaj";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // avMirek2
            // 
            this.avMirek2.Location = new System.Drawing.Point(335, 297);
            this.avMirek2.Name = "avMirek2";
            this.avMirek2.Size = new System.Drawing.Size(150, 150);
            this.avMirek2.TabIndex = 5;
            this.avMirek2.TabStop = false;
            // 
            // avMirek1
            // 
            this.avMirek1.Location = new System.Drawing.Point(28, 297);
            this.avMirek1.Name = "avMirek1";
            this.avMirek1.Size = new System.Drawing.Size(150, 150);
            this.avMirek1.TabIndex = 6;
            this.avMirek1.TabStop = false;
            // 
            // rtxtBTagi2
            // 
            this.rtxtBTagi2.Location = new System.Drawing.Point(335, 55);
            this.rtxtBTagi2.Name = "rtxtBTagi2";
            this.rtxtBTagi2.ReadOnly = true;
            this.rtxtBTagi2.Size = new System.Drawing.Size(150, 225);
            this.rtxtBTagi2.TabIndex = 8;
            this.rtxtBTagi2.Text = "";
            // 
            // rtxtBTagi1
            // 
            this.rtxtBTagi1.Location = new System.Drawing.Point(28, 55);
            this.rtxtBTagi1.Name = "rtxtBTagi1";
            this.rtxtBTagi1.ReadOnly = true;
            this.rtxtBTagi1.Size = new System.Drawing.Size(150, 225);
            this.rtxtBTagi1.TabIndex = 9;
            this.rtxtBTagi1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wspólne tagi:";
            // 
            // lblCommonTags
            // 
            this.lblCommonTags.AutoSize = true;
            this.lblCommonTags.Location = new System.Drawing.Point(246, 146);
            this.lblCommonTags.Name = "lblCommonTags";
            this.lblCommonTags.Size = new System.Drawing.Size(13, 13);
            this.lblCommonTags.TabIndex = 11;
            this.lblCommonTags.Text = "0";
            // 
            // Atencjometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 471);
            this.Controls.Add(this.lblCommonTags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxtBTagi1);
            this.Controls.Add(this.rtxtBTagi2);
            this.Controls.Add(this.avMirek1);
            this.Controls.Add(this.avMirek2);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.txtBNick2);
            this.Controls.Add(this.txtbNick1);
            this.MinimumSize = new System.Drawing.Size(555, 510);
            this.Name = "Atencjometer";
            this.Text = "Atencjometer";
            ((System.ComponentModel.ISupportInitialize)(this.avMirek2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avMirek1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbNick1;
        private System.Windows.Forms.TextBox txtBNick2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.PictureBox avMirek2;
        private System.Windows.Forms.PictureBox avMirek1;
        private System.Windows.Forms.RichTextBox rtxtBTagi2;
        private System.Windows.Forms.RichTextBox rtxtBTagi1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCommonTags;
    }
}

