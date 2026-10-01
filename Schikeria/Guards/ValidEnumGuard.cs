namespace Schikeria.Guards
{
    public static class ValidEnumGuard
    {
        public static void Against<T>(T value)
            where T : Enum
        {
            if (Enum.GetName(typeof(T), 0) != "None")
            {
                throw new ArgumentException("Wartosc domyslna None musi zostac zdefiniowana.");
            }

            if (EqualityComparer<T>.Default.Equals(value, default))
            {
                throw new ArgumentException("Wartosc zostala nie zainicjalizowana.");
            }
        }
    }
}
