namespace Mobilephone.DataProduct
{
    partial class formSearchOrder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSentDatatoIN = new System.Windows.Forms.Button();
            this.txtCodeOrder = new System.Windows.Forms.TextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvSearchOrder = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnSentDatatoIN);
            this.panel1.Controls.Add(this.txtCodeOrder);
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Phetsarath OT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 100);
            this.panel1.TabIndex = 0;
            // 
            // btnSentDatatoIN
            // 
            this.btnSentDatatoIN.BackColor = System.Drawing.Color.Silver;
            this.btnSentDatatoIN.ForeColor = System.Drawing.Color.Black;
            this.btnSentDatatoIN.Location = new System.Drawing.Point(462, 26);
            this.btnSentDatatoIN.Name = "btnSentDatatoIN";
            this.btnSentDatatoIN.Size = new System.Drawing.Size(127, 40);
            this.btnSentDatatoIN.TabIndex = 2;
            this.btnSentDatatoIN.Text = "Sent Data";
            this.btnSentDatatoIN.UseVisualStyleBackColor = false;
            // 
            // txtCodeOrder
            // 
            this.txtCodeOrder.Location = new System.Drawing.Point(250, 32);
            this.txtCodeOrder.Name = "txtCodeOrder";
            this.txtCodeOrder.Size = new System.Drawing.Size(192, 31);
            this.txtCodeOrder.TabIndex = 1;
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.Color.Red;
            this.lbMessage.Location = new System.Drawing.Point(623, 32);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(40, 23);
            this.lbMessage.TabIndex = 0;
            this.lbMessage.Text = "msg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Searching for Code  Ordered :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvSearchOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1066, 519);
            this.panel2.TabIndex = 1;
            // 
            // dgvSearchOrder
            // 
            this.dgvSearchOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearchOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvSearchOrder.Name = "dgvSearchOrder";
            this.dgvSearchOrder.Size = new System.Drawing.Size(1066, 519);
            this.dgvSearchOrder.TabIndex = 0;
            // 
            // formSearchOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 619);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "formSearchOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formSearchOrder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSentDatatoIN;
        private System.Windows.Forms.TextBox txtCodeOrder;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvSearchOrder;
    }
}