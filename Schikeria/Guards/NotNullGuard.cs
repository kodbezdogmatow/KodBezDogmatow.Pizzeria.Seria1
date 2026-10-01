namespace Schikeria.Guards
{
    public static class NotNullGuard
    {
        public static T Ensure<T>(T? value) where T : class
        {
            return value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
