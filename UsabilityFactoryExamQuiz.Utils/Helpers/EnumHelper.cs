using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UsabilityFactoryExamQuiz.Utils.Helpers
{
    /// <summary>
    /// Расширение для стандартного энумератора
    /// </summary>
    public static class EnumHelper
    {
        public static int GetLength<E>()
        {
            return Enum.GetNames(typeof(E)).Length;
        }

        public static List<string> GetValues<E>()
        {
            return (from object value in Enum.GetValues(typeof(E)) select value.ToString()).ToList();
        }

        public static List<string> GetNames<E>()
        {
            return Enum.GetNames(typeof(E)).ToList();
        }

        public static E GetEnumByValue<E>(int value)
        {
            return (E)Enum.ToObject(typeof(E), value);
        }

        public static List<E> GetItems<E>()
        {
            return Enum.GetNames(typeof(E)).Select(name => (E)Enum.Parse(typeof(E), name.ToString(CultureInfo.InvariantCulture))).ToList();
        }

        public static List<T> GetAllExcept<T>(T exceptItem)
        {
            var type = typeof(T);
            if (type.IsEnum)
            {
                return Enum.GetValues(typeof(T))
                            .Cast<T>()
                            .Where(t => !t.Equals(exceptItem)).ToList();
            }

            return null;

        }
                
        public static List<T> GetAllExcept<T>(IEnumerable<T> exceptItem)
        {
            var type = typeof(T);
            if (type.IsEnum)
            {
                return Enum.GetValues(typeof(T))
                            .Cast<T>()
                            .Where(t => !exceptItem.Contains(t)).ToList();
            }

            return null;

        }

        public static IEnumerable<string> GetAllNamesExcept<T>(IEnumerable<T> exceptItem)
        {
            var type = typeof(T);
            if (type.IsEnum)
            {
                return Enum.GetValues(typeof(T))
                            .Cast<T>()
                            .Where(t => !exceptItem.Contains(t))
                            .ToList()
                            .Select(m => m.ToString());
            }

            return null;
        }
    }
}
