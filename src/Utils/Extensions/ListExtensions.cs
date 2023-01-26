using System.Collections.Generic;

namespace Utils.Extensions
{
    public static class ListExtensions
    {
        public static string ToSqlRequestArray<T>( this List<T> source )
        {
            string result = string.Empty;
            bool firstSymbol = true;
            foreach ( T element in source )
            {
                if ( !firstSymbol )
                {
                    result += ", ";
                    firstSymbol = false;
                }
                result += element.ToString();
            }
            return result;
        }
    }
}
