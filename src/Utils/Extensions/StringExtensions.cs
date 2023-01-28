using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Extensions
{
    public static class StringExtensions
    {
        public static string GetHash( this string source )
        {
            using ( HashAlgorithm algorithm = SHA256.Create() )
            {
                var bytes = algorithm.ComputeHash( Encoding.UTF8.GetBytes( source ) );
                StringBuilder builder = new StringBuilder();
                foreach ( byte b in bytes )
                {
                    builder.Append( b.ToString( "X2" ) );
                }
                return builder.ToString();
            }
        }
    }
}
