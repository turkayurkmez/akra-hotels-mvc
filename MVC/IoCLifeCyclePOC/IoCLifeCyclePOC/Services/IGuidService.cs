namespace IoCLifeCyclePOC.Services
{
    public interface IGuidService
    {
        Guid Id { get; }
    }

    public interface ISingleton : IGuidService { }

    public interface ITransient : IGuidService { }

    public interface IScoped: IGuidService { }

    public class Singleton : ISingleton
    {
       
        public Guid Id { get; }

        public Singleton()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Scoped : IScoped
    {
        public Guid Id { get; }
        public Scoped()
        {
            Id = Guid.NewGuid();
        }
    }

    public class Transient : ITransient
    {
        public Guid Id { get; }

        public Transient()
        {
            Id = Guid.NewGuid();
            
        }

    }

    public class AllInOne
    {
        public ISingleton Singleton { get; set; }
        public IScoped Scoped { get; set; }
        public ITransient Transient { get; set; }

        public AllInOne(ISingleton singleton, IScoped scoped, ITransient transient)
        {
            Singleton = singleton;
            Scoped = scoped;
            Transient = transient;
        }
    }
}
