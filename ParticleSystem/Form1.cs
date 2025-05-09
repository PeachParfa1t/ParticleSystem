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


        GravityPoint point1; // ������� ���� ��� ������ �����

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // ������ ������� � ���������� ��� � ���� emitter
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

            emitters.Add(this.emitter);
            // �� ���� �� �������

            // ����������� ��������� � �����
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };


            // ����������� ���� � ��������
            emitter.impactPoints.Add(point1);

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
    }
}
