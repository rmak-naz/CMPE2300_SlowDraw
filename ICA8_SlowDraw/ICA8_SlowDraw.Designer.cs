namespace ICA8_SlowDraw
{
    partial class ICA8_SlowDraw
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
            this.LB_DrawData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_DrawData
            // 
            this.LB_DrawData.AutoSize = true;
            this.LB_DrawData.Location = new System.Drawing.Point(147, 9);
            this.LB_DrawData.Name = "LB_DrawData";
            this.LB_DrawData.Size = new System.Drawing.Size(190, 13);
            this.LB_DrawData.TabIndex = 0;
            this.LB_DrawData.Text = "segs in queue, estimated time to draw :";
            // 
            // ICA8_SlowDraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 47);
            this.Controls.Add(this.LB_DrawData);
            this.Name = "ICA8_SlowDraw";
            this.Text = "Slow Draw";
            this.Load += new System.EventHandler(this.ICA8_SlowDraw_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_DrawData;
    }
}

