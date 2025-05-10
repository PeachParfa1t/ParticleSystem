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
        List<ParticleCounterPoint> counters = new List<ParticleCounterPoint>();


        GravityPoint point1; // добавил поле под первую точку

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // Создаем эмиттер
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

            emitters.Add(this.emitter);  // добавляем эмиттер в список эмиттеров

            // Создаем гравитоны
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
                Power = 100  // начальный радиус
            };

            // Добавляем гравитон в список точек воздействия эмиттера
            emitter.impactPoints.Add(point1);

            // Подключаем обработчик события колесика мыши
            picDisplay.MouseWheel += picDisplay_MouseWheel;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                AddColorPoints(); // Добавляем цветные точки
            }
            else
            {
                // Удаляем все цветные точки, если чекбокс выключен
                foreach (var colorPoint in emitter.impactPoints.OfType<ColorPoint>().ToList())
                {
                    emitter.impactPoints.Remove(colorPoint);
                }
            }
        }

        private void AddColorPoints()
        {
            int centerY = picDisplay.Height / 2 + 50; // координата Y чуть ниже середины
            int radius = 20; // радиус круга
            int spacing = 50; // расстояние между кругами
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

            // Перерисовываем картинку
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
                // Удаляем все счетчики при выключении чекбокса
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

        // Метод для создания счетчика в случайной позиции
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
            // Найдем гравитон (радар) среди точек воздействия
            foreach (var point in emitter.impactPoints)
            {
                if (point is GravityPoint gravityPoint)
                {
                    // Меняем радиус в зависимости от направления прокрутки
                    gravityPoint.Power += e.Delta > 0 ? 10 : -10;
                    gravityPoint.Power = Math.Max(20, Math.Min(500, gravityPoint.Power));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random(); // Генератор случайных чисел

            // Перебираем все точки воздействия в списке
            foreach (var point in emitter.impactPoints.OfType<ColorPoint>())
            {
                // Генерируем случайный цвет
                var randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                // Присваиваем новый цвет точке
                point.Color = randomColor;
            }

            // Перерисовываем картинку, чтобы изменения отобразились
            picDisplay.Invalidate();
        }

    }
}
