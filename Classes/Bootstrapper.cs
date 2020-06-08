using Autofac;

namespace BerlinClock.Classes
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ClockFormatter>().As<IClockFormatter>().SingleInstance();
            builder.RegisterType<ActiveLampCalculator>().As<IActiveLampCalculator>().SingleInstance();
            builder.Register(reader => new TextTimeReader(Consts.TimeFormat)).As<ITimeReader>();
            builder.RegisterType<TimeConverter>().As<ITimeConverter>().SingleInstance();
            builder.RegisterType<TimeProvider>().As<ITimeProvider>().SingleInstance();
            return builder.Build();

        }
    }
}
