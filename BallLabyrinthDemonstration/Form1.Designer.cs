// Form1.Designer.cs
namespace BallLabyrinthDemonstration
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
            this.components = new System.ComponentModel.Container();
            this.canvas = new System.Windows.Forms.Panel();
            this.cbSolverType = new System.Windows.Forms.ComboBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.lblStepInfo = new System.Windows.Forms.Label();
            this.lblPathDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // canvas
            //
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(12, 12); // Example position, adjust as needed
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(350, 350); // Example size for 7x7 grid, adjust as needed
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint); // Hook up Paint event
            //
            // cbSolverType
            //
            this.cbSolverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSolverType.FormattingEnabled = true;
            this.cbSolverType.Location = new System.Drawing.Point(380, 12); // Example position
            this.cbSolverType.Name = "cbSolverType";
            this.cbSolverType.Size = new System.Drawing.Size(250, 21); // Example size
            this.cbSolverType.TabIndex = 1;
            this.cbSolverType.SelectedIndexChanged += new System.EventHandler(this.cbSolverType_SelectedIndexChanged); // Hook up event
            //
            // btnPrev
            //
            this.btnPrev.Location = new System.Drawing.Point(380, 40); // Example position
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23); // Example size
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click); // Hook up Click event
            //
            // btnNext
            //
            this.btnNext.Location = new System.Drawing.Point(461, 40); // Example position
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23); // Example size
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click); // Hook up Click event
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(380, 70); // Example position
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status:";
            //
            // lblCurrentPosition
            //
            this.lblCurrentPosition.AutoSize = true;
            this.lblCurrentPosition.Location = new System.Drawing.Point(380, 90); // Example position
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(84, 13);
            this.lblCurrentPosition.TabIndex = 5;
            this.lblCurrentPosition.Text = "Current Position:";
            //
            // lblStepInfo
            //
            this.lblStepInfo.AutoSize = true;
            this.lblStepInfo.Location = new System.Drawing.Point(380, 110); // Example position
            this.lblStepInfo.Name = "lblStepInfo";
            this.lblStepInfo.Size = new System.Drawing.Size(33, 13);
            this.lblStepInfo.TabIndex = 6;
            this.lblStepInfo.Text = "Step:";
            //
            // lblPathDisplay
            //
            this.lblPathDisplay.AutoSize = true;
            this.lblPathDisplay.Location = new System.Drawing.Point(380, 130); // Example position
            this.lblPathDisplay.Name = "lblPathDisplay";
            this.lblPathDisplay.Size = new System.Drawing.Size(33, 13);
            this.lblPathDisplay.TabIndex = 7;
            this.lblPathDisplay.Text = "Path:";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 381); // Example size, adjust as needed
            this.Controls.Add(this.lblPathDisplay);
            this.Controls.Add(this.lblStepInfo);
            this.Controls.Add(this.lblCurrentPosition);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.cbSolverType);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Ball Labyrinth Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.ComboBox cbSolverType;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Label lblStepInfo;
        private System.Windows.Forms.Label lblPathDisplay;
    }
}
