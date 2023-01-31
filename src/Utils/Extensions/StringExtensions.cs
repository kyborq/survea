using System.Security.Cryptography;
using System.Text;

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
