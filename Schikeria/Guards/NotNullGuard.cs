namespace Schikeria.Guards
{
    public static class NotNullGuard
    {
        public static T Against<T>(T? value) where T : class
        {
            return value ?? throw new ArgumentNullException(nameof(value));
        }

        public static T Against<T>(T? value) where T : struct
        {
            return value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
