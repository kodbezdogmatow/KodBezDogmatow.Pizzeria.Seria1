namespace Schikeria.Guards
{
    public static class CastGuard
    {
        public static T CastOrThrow<T>(object value)
            where T : class
        {
            var result = value as T;

            if (result == null)
            {
                throw new InvalidCastException($"Rzutowanie na '{typeof(T).Name}' niepowiodlo sie.");
            }

            return result;
        }
    }
}
