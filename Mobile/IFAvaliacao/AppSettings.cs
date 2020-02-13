

using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Services.Response;
using IFAvaliacao.Utils;
using IFAvaliacao.Utils.Extensions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace IFAvaliacao
{
    public static class AppSettings
    {   
        public static string ApiUrl = "http://192.168.2.106:5000";                      

        public static Usuario Usuario
        {
            get => PreferencesHelpers.Get(nameof(Usuario), default(Usuario));
            set => PreferencesHelpers.Set(nameof(Usuario), value);
        }

        public static async Task<LoginResponse> GetSecurityUser(string key)
        {
            if (!key.HasValue()) return null;

            var value = await SecureStorage.GetAsync(key);

            return value.HasValue() ? JsonConvert.DeserializeObject<LoginResponse>(value) : null;
        }

        public static async Task SetSecurityUser(string key, LoginResponse securityUser)
        {
            await SecureStorage.SetAsync(key, JsonConvert.SerializeObject(securityUser));
        }
    }
}
