namespace EditDefinition
{
    partial class DocumentsDurationPanel
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
            this._definitions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _definitions
            // 
            this._definitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this._definitions.FormattingEnabled = true;
            this._definitions.Items.AddRange(new object[] {
            "definition 1",
            "definition 2",
            "definition 3"});
            this._definitions.Location = new System.Drawing.Point(0, 0);
            this._definitions.Name = "_definitions";
            this._definitions.Size = new System.Drawing.Size(363, 107);
            this._definitions.TabIndex = 0;
            // 
            // DocumentsDurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._definitions);
            this.Name = "DocumentsDurationPanel";
            this.Size = new System.Drawing.Size(363, 107);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _definitions;
    }
}
