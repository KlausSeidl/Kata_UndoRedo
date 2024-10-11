namespace EditDefinition
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
            this.documentsDurationPanel1 = new EditDefinition.DocumentsDurationPanel();
            this.timePeriodPanel1 = new EditDefinition.TimePeriodPanel();
            this._addDefinition = new System.Windows.Forms.Button();
            this._deleteDefinition = new System.Windows.Forms.Button();
            this._addToChangeSeries = new System.Windows.Forms.Button();
            this._definitionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._undo = new System.Windows.Forms.Button();
            this._redo = new System.Windows.Forms.Button();
            this._clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // documentsDurationPanel1
            // 
            this.documentsDurationPanel1.Location = new System.Drawing.Point(13, 71);
            this.documentsDurationPanel1.Name = "documentsDurationPanel1";
            this.documentsDurationPanel1.Size = new System.Drawing.Size(451, 119);
            this.documentsDurationPanel1.TabIndex = 0;
            // 
            // timePeriodPanel1
            // 
            this.timePeriodPanel1.Location = new System.Drawing.Point(13, 214);
            this.timePeriodPanel1.Name = "timePeriodPanel1";
            this.timePeriodPanel1.Size = new System.Drawing.Size(499, 27);
            this.timePeriodPanel1.TabIndex = 1;
            // 
            // _addDefinition
            // 
            this._addDefinition.Location = new System.Drawing.Point(625, 33);
            this._addDefinition.Name = "_addDefinition";
            this._addDefinition.Size = new System.Drawing.Size(133, 23);
            this._addDefinition.TabIndex = 2;
            this._addDefinition.Text = "Neue Definition";
            this._addDefinition.UseVisualStyleBackColor = true;
            // 
            // _deleteDefinition
            // 
            this._deleteDefinition.Location = new System.Drawing.Point(625, 62);
            this._deleteDefinition.Name = "_deleteDefinition";
            this._deleteDefinition.Size = new System.Drawing.Size(133, 23);
            this._deleteDefinition.TabIndex = 3;
            this._deleteDefinition.Text = "Definition entfernen";
            this._deleteDefinition.UseVisualStyleBackColor = true;
            // 
            // _addToChangeSeries
            // 
            this._addToChangeSeries.Location = new System.Drawing.Point(625, 91);
            this._addToChangeSeries.Name = "_addToChangeSeries";
            this._addToChangeSeries.Size = new System.Drawing.Size(133, 23);
            this._addToChangeSeries.TabIndex = 4;
            this._addToChangeSeries.Text = "Änderung planen";
            this._addToChangeSeries.UseVisualStyleBackColor = true;
            // 
            // _definitionName
            // 
            this._definitionName.Location = new System.Drawing.Point(54, 30);
            this._definitionName.Name = "_definitionName";
            this._definitionName.Size = new System.Drawing.Size(100, 20);
            this._definitionName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name";
            // 
            // _undo
            // 
            this._undo.Location = new System.Drawing.Point(625, 166);
            this._undo.Name = "_undo";
            this._undo.Size = new System.Drawing.Size(75, 23);
            this._undo.TabIndex = 7;
            this._undo.Text = "Undo";
            this._undo.UseVisualStyleBackColor = true;
            // 
            // _redo
            // 
            this._redo.Location = new System.Drawing.Point(625, 195);
            this._redo.Name = "_redo";
            this._redo.Size = new System.Drawing.Size(75, 23);
            this._redo.TabIndex = 8;
            this._redo.Text = "Redo";
            this._redo.UseVisualStyleBackColor = true;
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(625, 224);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(75, 23);
            this._clear.TabIndex = 9;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._clear);
            this.Controls.Add(this._redo);
            this.Controls.Add(this._undo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._definitionName);
            this.Controls.Add(this._addToChangeSeries);
            this.Controls.Add(this._deleteDefinition);
            this.Controls.Add(this._addDefinition);
            this.Controls.Add(this.timePeriodPanel1);
            this.Controls.Add(this.documentsDurationPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DocumentsDurationPanel documentsDurationPanel1;
        private TimePeriodPanel timePeriodPanel1;
        private System.Windows.Forms.Button _addDefinition;
        private System.Windows.Forms.Button _deleteDefinition;
        private System.Windows.Forms.Button _addToChangeSeries;
        private System.Windows.Forms.TextBox _definitionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _undo;
        private System.Windows.Forms.Button _redo;
        private System.Windows.Forms.Button _clear;
    }
}

