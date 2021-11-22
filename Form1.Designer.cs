namespace HW4_MandelbrotZoom
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
            this.lblIterations = new System.Windows.Forms.Label();
            this.lblHowToZoom = new System.Windows.Forms.Label();
            this.tboxMaxIter = new System.Windows.Forms.TextBox();
            this.bttnDraw = new System.Windows.Forms.Button();
            this.bttnReset = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Location = new System.Drawing.Point(11, 16);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(53, 13);
            this.lblIterations.TabIndex = 0;
            this.lblIterations.Text = "Iterations:";
            // 
            // lblHowToZoom
            // 
            this.lblHowToZoom.Location = new System.Drawing.Point(11, 185);
            this.lblHowToZoom.Name = "lblHowToZoom";
            this.lblHowToZoom.Size = new System.Drawing.Size(150, 55);
            this.lblHowToZoom.TabIndex = 1;
            this.lblHowToZoom.Text = "Click and drag on the image to draw a box, and the program will zoom in on that b" +
    "ox.";
            this.lblHowToZoom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tboxMaxIter
            // 
            this.tboxMaxIter.Location = new System.Drawing.Point(71, 13);
            this.tboxMaxIter.Name = "tboxMaxIter";
            this.tboxMaxIter.Size = new System.Drawing.Size(80, 20);
            this.tboxMaxIter.TabIndex = 2;
            this.tboxMaxIter.Text = "1024";
            // 
            // bttnDraw
            // 
            this.bttnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bttnDraw.Location = new System.Drawing.Point(24, 65);
            this.bttnDraw.Name = "bttnDraw";
            this.bttnDraw.Size = new System.Drawing.Size(120, 35);
            this.bttnDraw.TabIndex = 3;
            this.bttnDraw.Text = "Draw";
            this.bttnDraw.UseVisualStyleBackColor = true;
            this.bttnDraw.Click += new System.EventHandler(this.BttnDraw_Click);
            // 
            // bttnReset
            // 
            this.bttnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bttnReset.Location = new System.Drawing.Point(24, 120);
            this.bttnReset.Name = "bttnReset";
            this.bttnReset.Size = new System.Drawing.Size(120, 35);
            this.bttnReset.TabIndex = 4;
            this.bttnReset.Text = "Reset";
            this.bttnReset.UseVisualStyleBackColor = true;
            this.bttnReset.Click += new System.EventHandler(this.BttnReset_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCanvas.Location = new System.Drawing.Point(169, 13);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(600, 600);
            this.picCanvas.TabIndex = 5;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PicCanvas_Paint);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicCanvas_MouseMove);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicCanvas_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 626);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.bttnReset);
            this.Controls.Add(this.bttnDraw);
            this.Controls.Add(this.tboxMaxIter);
            this.Controls.Add(this.lblHowToZoom);
            this.Controls.Add(this.lblIterations);
            this.Name = "Form1";
            this.Text = "Mandelbrot Set";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.Label lblHowToZoom;
        private System.Windows.Forms.TextBox tboxMaxIter;
        private System.Windows.Forms.Button bttnDraw;
        private System.Windows.Forms.Button bttnReset;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}

