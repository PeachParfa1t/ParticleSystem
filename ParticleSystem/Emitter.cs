using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParticleSystem.Particle;

namespace ParticleSystem
{
    class Emitter
    {
        List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // <<< ТАК ВОТ

        public int MousePositionX;
        public int MousePositionY;
        public float GravitationX = 0;
        public float GravitationY = 0; // пусть гравитация будет силой один пиксель за такт, нам хватит

        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20;
        public int LifeMax = 100;

        public int ParticlesPerTick = 1; // добавил новое поле

        public Color ColorFrom = Color.Gray; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Gray); // конечный цвет частиц

        public Color FromColor { get; set; } // Начальный цвет
    public Color ToColor { get; set; }   // Конечный цвет
    public Color CurrentColor { get; set; } // Текущий цвет
    public bool IsColored { get; set; }   // Флаг, показывает, изменяется ли цвет

        /* добавил метод */
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = Color.Gray;  // Начальный цвет
            particle.ToColor = Color.Gray;    // Конечный цвет
            return particle;
        }



        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик

            foreach (var particle in particles)
            {
                if (particle.Life <= 0) // если частицы умерла
                {
                    if (particlesToCreate > 0)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {
                    //* теперь двигаю вначале */
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.Life -= 1;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        public void Render(Graphics g)
        {
            // это не трогаем
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            // рисую точки притяжения красными кружочками
            foreach (var point in impactPoints) // тут теперь  impactPoints
            {
                /* это больше не надо
                g.FillEllipse(
                    new SolidBrush(Color.Red),
                    point.X - 5,
                    point.Y - 5,
                    10,
                    10
                );
                */
                point.Render(g); // это добавили
            }
        }

        public int ParticlesCount = 500;
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction
                + (double)Particle.rand.Next(Spreading)
                - Spreading / 2;

            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public class TopEmitter : Emitter
        {
            public int Width; // длина экрана

            public virtual void ResetParticle(Particle particle)
            {
                particle.Life = Particle.rand.Next(LifeMin, LifeMax);
                particle.X = X;
                particle.Y = Y;

                var direction = Direction
                    + (double)Particle.rand.Next(Spreading)
                    - Spreading / 2;

                var speed = Particle.rand.Next(SpeedMin, SpeedMax);

                particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);

                // Сбрасываем цвет на серый всегда при сбросе
                if (particle is ParticleColorful colorfulParticle)
                {
                    colorfulParticle.FromColor = Color.Gray;
                    colorfulParticle.ToColor = Color.Gray;
                }
            }


        }

    }
}
