namespace Task6_3
{
    public static class NullableExtentions
    {
        /// <summary>
        /// Возвращает true если данный объект равен null
        /// </summary>
        public static bool IsNull<T>(this T obj)
        {
            // выглядит как читерский способ, но вродь работает
            return (object)obj is null;
        }
    }
}
