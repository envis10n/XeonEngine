using System;

namespace XeonCore.Util
{
    public static class Array
    {
        public static bool Every<T>(T[] arr, Predicate<T> predicate)
        {
            bool success = true;
            foreach (T val in arr)
            {
                if (!predicate(val))
                {
                    success = false;
                    break;
                }
            }
            return success;
        }
    }
}