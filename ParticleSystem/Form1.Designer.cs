namespace ParticleSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            lblDirection = new Label();
            tbGraviton = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            trackBar1 = new TrackBar();
            label3 = new Label();
            trackBar2 = new TrackBar();
            label4 = new Label();
            label5 = new Label();
            trackBar3 = new TrackBar();
            trackBar4 = new TrackBar();
            label6 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(-10, -4);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(1179, 435);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(12, 505);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(162, 56);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll_1;
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDirection.Location = new Point(25, 479);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(125, 25);
            lblDirection.TabIndex = 2;
            lblDirection.Text = "Направление:";
            // 
            // tbGraviton
            // 
            tbGraviton.Location = new Point(198, 505);
            tbGraviton.Maximum = 100;
            tbGraviton.Name = "tbGraviton";
            tbGraviton.Size = new Size(162, 56);
            tbGraviton.TabIndex = 3;
            tbGraviton.Scroll += tbGraviton_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(469, 434);
            label1.Name = "label1";
            label1.Size = new Size(165, 41);
            label1.TabIndex = 5;
            label1.Text = "Настройки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(198, 479);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 6;
            label2.Text = "Размер гравитона: ";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(387, 505);
            trackBar1.Maximum = 360;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(162, 56);
            trackBar1.TabIndex = 7;
            trackBar1.Value = 1;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(387, 479);
            label3.Name = "label3";
            label3.Size = new Size(144, 25);
            label3.TabIndex = 8;
            label3.Text = "Распределение: ";
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(571, 505);
            trackBar2.Maximum = 100;
            trackBar2.Minimum = 1;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(144, 56);
            trackBar2.TabIndex = 9;
            trackBar2.Value = 1;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(571, 479);
            label4.Name = "label4";
            label4.Size = new Size(98, 25);
            label4.TabIndex = 10;
            label4.Text = "Скорость: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(734, 479);
            label5.Name = "label5";
            label5.Size = new Size(126, 25);
            label5.TabIndex = 11;
            label5.Text = "Частиц за тик:";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(734, 505);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(144, 56);
            trackBar3.TabIndex = 12;
            trackBar3.Scroll += trackBar3_Scroll;
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(884, 505);
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(144, 56);
            trackBar4.TabIndex = 13;
            trackBar4.Scroll += trackBar4_Scroll;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(884, 477);
            label6.Name = "label6";
            label6.Size = new Size(244, 25);
            label6.TabIndex = 14;
            label6.Text = "Продолжительность жизни: ";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(25, 567);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(248, 24);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Точки перекрашивания частиц";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(296, 567);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(181, 24);
            checkBox2.TabIndex = 16;
            checkBox2.Text = "Точка-счетчик частиц";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(334, 597);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 17;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(60, 597);
            button2.Name = "button2";
            button2.Size = new Size(166, 29);
            button2.TabIndex = 18;
            button2.Text = "Поменять цвет";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 660);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label6);
            Controls.Add(trackBar4);
            Controls.Add(trackBar3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(trackBar2);
            Controls.Add(label3);
            Controls.Add(trackBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbGraviton);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGraviton;
        private Label label1;
        private Label label2;
        private TrackBar trackBar1;
        private Label label3;
        private TrackBar trackBar2;
        private Label label4;
        private Label label5;
        private TrackBar trackBar3;
        private TrackBar trackBar4;
        private Label label6;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button button1;
        private Button button2;
    }
}
