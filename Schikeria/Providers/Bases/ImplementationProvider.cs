namespace Schikeria.Providers.Bases
{
    public abstract class ImplementationProvider
    {
        protected List<T> GetImplementations<T>()
        {
            if (!typeof(T).IsInterface)
                throw new ArgumentException($"{typeof(T).Name} must be an interface.");

            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => x is { IsClass: true, IsAbstract: false }
                            && typeof(T).IsAssignableFrom(x))
                .Select(t => (T)Activator.CreateInstance(t)!)
                .ToList();
        }
    }
}
