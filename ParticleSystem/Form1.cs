using static ParticleSystem.Emitter;
using static ParticleSystem.Particle;

namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        // ���������� ������, ���� ������
        List<Particle> particles = new List<Particle>();
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // ��� ������ ����� ��������
        List<ParticleCounterPoint> counters = new List<ParticleCounterPoint>();


        GravityPoint point1; // ������� ���� ��� ������ �����

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // ������� �������
            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);  // ��������� ������� � ������ ���������

            // ������� ���������
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
                Power = 100  // ��������� ������
            };

            // ��������� �������� � ������ ����� ����������� ��������
            emitter.impactPoints.Add(point1);

            // ���������� ���������� ������� �������� ����
            picDisplay.MouseWheel += picDisplay_MouseWheel;
        }


        // �� � ��������� ���� �������, ��� ������ ������������ ���������
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // ��� ������ ��������� �������

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                emitter.Render(g); // � ��� ������ �������� ����� �������
            }

            picDisplay.Invalidate();
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // ���������� �������� � ������� ����
            point1.X = e.X;
            point1.Y = e.Y;
        }

        private void tbDirection_Scroll_1(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"�����������: {tbDirection.Value}�"; // ������� ����� ��������
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
            label2.Text = $"������ ���������: {tbGraviton.Value}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = trackBar1.Value;
            emitter.Spreading = trackBar1.Value;
            label3.Text = $"�������������: {trackBar1.Value}�";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMin = trackBar2.Value;
            emitter.SpeedMax = trackBar2.Value;
            label4.Text = $"��������: {trackBar2.Value}";
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = trackBar3.Value;
            label5.Text = $"������ �� ���: {trackBar3.Value}";
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            // ������� ������� � ������������� (��������, 16 = 60 FPS)
            float timerFrequency = timer1.Interval / 1000f; // ��������� � �������

            // ��������� ����������� � ������������ ����� ����� � �����
            emitter.LifeMin = (int)(trackBar4.Value / timerFrequency);
            emitter.LifeMax = (int)(trackBar4.Value / timerFrequency);

            label6.Text = $"����� ������: {trackBar4.Value} ���";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                AddColorPoints(); // ��������� ������� �����
            }
            else
            {
                // ������� ��� ������� �����, ���� ������� ��������
                foreach (var colorPoint in emitter.impactPoints.OfType<ColorPoint>().ToList())
                {
                    emitter.impactPoints.Remove(colorPoint);
                }
            }
        }

        private void AddColorPoints()
        {
            int centerY = picDisplay.Height / 2 + 50; // ���������� Y ���� ���� ��������
            int radius = 20; // ������ �����
            int spacing = 50; // ���������� ����� �������
            Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Purple };

            for (int i = 0; i < colors.Length; i++)
            {
                var colorPoint = new ColorPoint
                {
                    X = picDisplay.Width / 2 - (colors.Length / 2 * spacing) + i * spacing,
                    Y = centerY,
                    Radius = radius,
                    Color = colors[i]
                };
                emitter.impactPoints.Add(colorPoint);
            }

            // �������������� ��������
            picDisplay.Invalidate();
        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                AddRandomCounter();
            }
            else
            {
                // ������� ��� �������� ��� ���������� ��������
                foreach (var counter in counters)
                {
                    emitter.impactPoints.Remove(counter);
                }
                counters.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                AddRandomCounter();
            }
        }

        // ����� ��� �������� �������� � ��������� �������
        private void AddRandomCounter()
        {
            var random = new Random();
            var counter = new ParticleCounterPoint
            {
                X = random.Next(0, picDisplay.Width),
                Y = random.Next(0, picDisplay.Height)
            };
            counters.Add(counter);
            emitter.impactPoints.Add(counter);
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            // ������ �������� (�����) ����� ����� �����������
            foreach (var point in emitter.impactPoints)
            {
                if (point is GravityPoint gravityPoint)
                {
                    // ������ ������ � ����������� �� ����������� ���������
                    gravityPoint.Power += e.Delta > 0 ? 10 : -10;
                    gravityPoint.Power = Math.Max(20, Math.Min(500, gravityPoint.Power));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random(); // ��������� ��������� �����

            // ���������� ��� ����� ����������� � ������
            foreach (var point in emitter.impactPoints.OfType<ColorPoint>())
            {
                // ���������� ��������� ����
                var randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                // ����������� ����� ���� �����
                point.Color = randomColor;
            }

            // �������������� ��������, ����� ��������� ������������
            picDisplay.Invalidate();
        }

    }
}
