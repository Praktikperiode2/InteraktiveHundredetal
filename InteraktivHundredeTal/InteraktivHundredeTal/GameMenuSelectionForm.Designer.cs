
namespace InteraktivHundredeTal
{
  partial class GameMenuSelectionForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InteraktivHundredetal_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(59, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Skriv dit navn:";
            // 
            // InteraktivHundredetal_btn
            // 
            this.InteraktivHundredetal_btn.Location = new System.Drawing.Point(59, 55);
            this.InteraktivHundredetal_btn.Name = "InteraktivHundredetal_btn";
            this.InteraktivHundredetal_btn.Size = new System.Drawing.Size(244, 32);
            this.InteraktivHundredetal_btn.TabIndex = 2;
            this.InteraktivHundredetal_btn.Text = "Interaktiv Hundredetal";
            this.InteraktivHundredetal_btn.UseVisualStyleBackColor = true;
            this.InteraktivHundredetal_btn.Click += new System.EventHandler(this.InteraktivHundredetal_btn_Click);
            // 
            // GameMenuSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 288);
            this.Controls.Add(this.InteraktivHundredetal_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "GameMenuSelectionForm";
            this.Text = "Interaktive Hundredtal";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InteraktivHundredetal_btn;
    }
}