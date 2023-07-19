namespace ToySimulator
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.RichTextBox();
            this.regA = new System.Windows.Forms.TextBox();
            this.regT = new System.Windows.Forms.TextBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MemBlockBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.monitorBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MemGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register A :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Register T :";
            // 
            // codeBox
            // 
            this.codeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeBox.Location = new System.Drawing.Point(2, 15);
            this.codeBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(499, 678);
            this.codeBox.TabIndex = 2;
            this.codeBox.Text = "";
            // 
            // regA
            // 
            this.regA.Location = new System.Drawing.Point(171, 45);
            this.regA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regA.Name = "regA";
            this.regA.Size = new System.Drawing.Size(128, 28);
            this.regA.TabIndex = 3;
            // 
            // regT
            // 
            this.regT.Location = new System.Drawing.Point(171, 89);
            this.regT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.regT.Name = "regT";
            this.regT.Size = new System.Drawing.Size(128, 28);
            this.regT.TabIndex = 4;
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(3, 32);
            this.runBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(106, 37);
            this.runBtn.TabIndex = 5;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.codeBox);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2, 15, 15, 15);
            this.splitContainer1.Size = new System.Drawing.Size(1420, 708);
            this.splitContainer1.SplitterDistance = 900;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.MemGridView);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(15, 0, 2, 15);
            this.splitContainer2.Size = new System.Drawing.Size(900, 708);
            this.splitContainer2.SplitterDistance = 190;
            this.splitContainer2.TabIndex = 8;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.MemBlockBox);
            this.splitContainer3.Panel1.Controls.Add(this.label4);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            this.splitContainer3.Panel1.Controls.Add(this.regT);
            this.splitContainer3.Panel1.Controls.Add(this.regA);
            this.splitContainer3.Panel1.Controls.Add(this.PC);
            this.splitContainer3.Panel1.Controls.Add(this.label3);
            this.splitContainer3.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(900, 190);
            this.splitContainer3.SplitterDistance = 310;
            this.splitContainer3.TabIndex = 8;
            // 
            // MemBlockBox
            // 
            this.MemBlockBox.Location = new System.Drawing.Point(171, 164);
            this.MemBlockBox.Name = "MemBlockBox";
            this.MemBlockBox.Size = new System.Drawing.Size(128, 28);
            this.MemBlockBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Registers :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label5.Location = new System.Drawing.Point(13, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Memory Block :";
            // 
            // PC
            // 
            this.PC.Location = new System.Drawing.Point(171, 127);
            this.PC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PC.Name = "PC";
            this.PC.Size = new System.Drawing.Size(128, 28);
            this.PC.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Program Counter :";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label6);
            this.splitContainer4.Panel1.Controls.Add(this.runBtn);
            this.splitContainer4.Panel1.Controls.Add(this.button2);
            this.splitContainer4.Panel1.Controls.Add(this.monitorBtn);
            this.splitContainer4.Panel1.Controls.Add(this.button1);
            this.splitContainer4.Size = new System.Drawing.Size(586, 190);
            this.splitContainer4.SplitterDistance = 110;
            this.splitContainer4.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Actions :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 112);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "Save to file";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // monitorBtn
            // 
            this.monitorBtn.Location = new System.Drawing.Point(3, 152);
            this.monitorBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.monitorBtn.Name = "monitorBtn";
            this.monitorBtn.Size = new System.Drawing.Size(106, 37);
            this.monitorBtn.TabIndex = 2;
            this.monitorBtn.Text = "Monitor";
            this.monitorBtn.UseVisualStyleBackColor = true;
            this.monitorBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Import file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MemGridView
            // 
            this.MemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemGridView.Location = new System.Drawing.Point(15, 0);
            this.MemGridView.Name = "MemGridView";
            this.MemGridView.RowHeadersWidth = 62;
            this.MemGridView.RowTemplate.Height = 28;
            this.MemGridView.Size = new System.Drawing.Size(883, 499);
            this.MemGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 708);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1442, 764);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MemGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox codeBox;
        private System.Windows.Forms.TextBox regA;
        private System.Windows.Forms.TextBox regT;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox PC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button monitorBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView MemGridView;
        private System.Windows.Forms.TextBox MemBlockBox;
    }
}

