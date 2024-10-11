namespace EditDefinition
{
    partial class TimePeriodPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._begin = new System.Windows.Forms.DateTimePicker();
            this._end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this._beginPlus1 = new System.Windows.Forms.Button();
            this._endPlus1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Von";
            // 
            // _begin
            // 
            this._begin.CustomFormat = "dd.MM.yyyy hh:mm";
            this._begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._begin.Location = new System.Drawing.Point(36, 3);
            this._begin.Name = "_begin";
            this._begin.Size = new System.Drawing.Size(125, 20);
            this._begin.TabIndex = 1;
            // 
            // _end
            // 
            this._end.CustomFormat = "dd.MM.yyyy hh:mm";
            this._end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._end.Location = new System.Drawing.Point(306, 4);
            this._end.Name = "_end";
            this._end.Size = new System.Drawing.Size(125, 20);
            this._end.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bis";
            // 
            // _beginPlus1
            // 
            this._beginPlus1.Location = new System.Drawing.Point(167, 1);
            this._beginPlus1.Name = "_beginPlus1";
            this._beginPlus1.Size = new System.Drawing.Size(30, 23);
            this._beginPlus1.TabIndex = 4;
            this._beginPlus1.Text = "+1";
            this._beginPlus1.UseVisualStyleBackColor = true;
            // 
            // _endPlus1
            // 
            this._endPlus1.Location = new System.Drawing.Point(437, 2);
            this._endPlus1.Name = "_endPlus1";
            this._endPlus1.Size = new System.Drawing.Size(30, 23);
            this._endPlus1.TabIndex = 5;
            this._endPlus1.Text = "+1";
            this._endPlus1.UseVisualStyleBackColor = true;
            // 
            // TimePeriodPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._endPlus1);
            this.Controls.Add(this._beginPlus1);
            this.Controls.Add(this._end);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._begin);
            this.Controls.Add(this.label1);
            this.Name = "TimePeriodPanel";
            this.Size = new System.Drawing.Size(499, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _begin;
        private System.Windows.Forms.DateTimePicker _end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _beginPlus1;
        private System.Windows.Forms.Button _endPlus1;
    }
}
