using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParticleSystem.Particle;

namespace ParticleSystem
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать
        public abstract void ImpactParticle(Particle particle);

        // базовый класс для отрисовки точечки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;  // радиус радара (сила притяжения)
        public int CountInZone = 0;  // количество частиц в зоне

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);  // расстояние до частицы

            // Подсчет частиц в зоне
            if (r + particle.Radius < Power / 2)
            {
                CountInZone++;  // увеличиваем счетчик

                // Подсветка частицы зеленым цветом
                if (particle is ParticleColorful colorfulParticle)
                {
                    colorfulParticle.FromColor = Color.Green;
                    colorfulParticle.ToColor = Color.Green;
                }

                // Притяжение частицы
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }

        public override void Render(Graphics g)
        {
            // Сбрасываем счетчик перед перерисовкой
            CountInZone = 0;

            // Используем прозрачный цвет для заливки
            g.FillEllipse(
                new SolidBrush(Color.FromArgb(0, 255, 255, 255)), // прозрачный белый
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
            );

            // Рисуем обводку круга с цветом, например, красным
            g.DrawEllipse(
                new Pen(Color.Red, 2),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
            );

            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Текст с количеством частиц
            var text = $"Частиц: {CountInZone}";
            var font = new Font("Verdana", 10);

            // Рисуем текст в центре
            g.DrawString(
                text,
                font,
                Brushes.Black,
                X,
                Y,
                stringFormat
            );
        }
    }



    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100; // сила отторжения

        // а сюда по сути скопировали с минимальными правками то что было в UpdateState
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2; // тут минусики вместо плюсов
            particle.SpeedY -= gY * Power / r2; // и тут
        }
    }

    public class ColorPoint : IImpactPoint
    {
        public int Radius = 20;
        public Color Color;

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Radius)
            {
                if (particle is ParticleColorful colorfulParticle)
                {
                    // Временно перекрашиваем частицу в цвет, но сохраняем оригинальный серый цвет
                    colorfulParticle.FromColor = Color;
                    colorfulParticle.ToColor = Color;
                }
            }
        }


        public override void Render(Graphics g)
        {
            using (var pen = new Pen(Color, 2)) // рисуем только контур
            {
                g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }

    public class ParticleCounterPoint : IImpactPoint
    {
        public int Counter = 0;

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= 10) // радиус захвата, можно менять
            {
                Counter++;
                particle.Life = 0; // уничтожаем частицу
            }
        }

        public override void Render(Graphics g)
        {
            // Увеличенный размер точки-счетчика (радиус 30)
            int radius = 60;

            // Рисуем белый внутренний круг
            g.FillEllipse(Brushes.White, X - radius / 2, Y - radius / 2, radius, radius);

            // Рисуем красную обводку
            g.DrawEllipse(new Pen(Color.Red, 3), X - radius / 2, Y - radius / 2, radius, radius);

            // Рисуем текст с количеством уничтоженных частиц
            g.DrawString($"Счет: {Counter}", new Font("Verdana", 10), Brushes.Black, X + radius / 2 + 5, Y - 10);
        }


    }


}
