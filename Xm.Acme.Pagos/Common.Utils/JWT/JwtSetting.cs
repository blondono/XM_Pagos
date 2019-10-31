using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.JWT
{
    [ExcludeFromCodeCoverage]
    public sealed class JwtSetting
    {
        public string SecretKey { get; set; }

        public string Issuer { get; set; }
    }
}
