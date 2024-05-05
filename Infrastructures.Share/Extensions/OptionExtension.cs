using Optional;

namespace Infrastructures.Share.Extensions
{
    public static class OptionExtension
    {
        /// <summary>
        /// If value is null return None, else return Some
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option<T, string> ToOptionNotNull<T>(this T value)
        {
            if (value == null) return Option.None<T, string>("Not Found");
            return Option.Some<T, string>(value);
        }


        /// <summary>
        /// allway return Some
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Option<T, string> ToOption<T>(this T value)
        {
            return Option.Some<T, string>(value);
        }
        public static Task<Option<T, string>> ToTaskNoneOption<T>(this string value)
        {
            return Task.FromResult(Option.None<T, string>(value));
        }
        public static Option<T, string> ToNoneOption<T>(this string value)
        {
            return Option.None<T, string>(value);
        }
        public static Option<T> ToOptionWithNoError<T>(this T value)
        {
            if (value != null)
                return Option.Some<T>(value);
            return Option.None<T>();
        }
        public static Option<bool, string> ToOption(this bool value, string message = null)
        {
            return value ? Option.Some<bool, string>(value) : Option.None<bool, string>(message);
        }
        public static Option<bool, string> ToOptionPermission(this bool value)
        {
            return value ? Option.Some<bool, string>(value) : Option.None<bool, string>("No Permission");
        }
    }
}
