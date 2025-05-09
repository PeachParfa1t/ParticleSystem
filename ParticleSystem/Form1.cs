using static ParticleSystem.Emitter;
using static ParticleSystem.Particle;

namespace ParticleSystem
{
    public partial class Form1 : Form
    {
        // собственно список, пока пустой
        List<Particle> particles = new List<Particle>();
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // тут убрали явное создание


        GravityPoint point1; // добавил поле под первую точку

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
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
            // до сюда НЕ ТРОГАЕМ

            // привязываем гравитоны к полям
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };


            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);

        }

        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }

            picDisplay.Invalidate();
        }
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Перемещаем гравитон к позиции мыши
            point1.X = e.X;
            point1.Y = e.Y;
        }

        private void tbDirection_Scroll_1(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"Направление: {tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
            label2.Text = $"Размер гравитона: {tbGraviton.Value}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = trackBar1.Value;
            emitter.Spreading = trackBar1.Value;
            label3.Text = $"Распределение: {trackBar1.Value}°";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMin = trackBar2.Value;
            emitter.SpeedMax = trackBar2.Value;
            label4.Text = $"Скорость: {trackBar2.Value}";
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = trackBar3.Value;
            label5.Text = $"Частиц за тик: {trackBar3.Value}";
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            // Частота таймера в миллисекундах (например, 16 = 60 FPS)
            float timerFrequency = timer1.Interval / 1000f; // Переводим в секунды

            // Вычисляем минимальное и максимальное время жизни в тиках
            emitter.LifeMin = (int)(trackBar4.Value / timerFrequency);
            emitter.LifeMax = (int)(trackBar4.Value / timerFrequency);

            label6.Text = $"Жизнь частиц: {trackBar4.Value} сек";
        }
    }
}
