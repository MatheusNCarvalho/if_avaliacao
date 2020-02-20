

using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Extensions;
using IFAvaliacao.Services.Response;
using IFAvaliacao.Utils;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace IFAvaliacao
{
    public static class AppSettings
    {
        public static string ApiUrl = "http://192.168.2.103:5000";

        public static Usuario Usuario
        {
            get => PreferencesHelpers.Get(nameof(Usuario), default(Usuario));
            set => PreferencesHelpers.Set(nameof(Usuario), value);
        }

        public static bool PrimeiraInicializacao
        {
            get
            {
                var result = PreferencesHelpers.Get(nameof(PrimeiraInicializacao), default(bool?));
                return result ?? true;
            }
            set => PreferencesHelpers.Set(nameof(PrimeiraInicializacao), value);
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

        public static async Task UpdateSecurityUser(string key, LoginResponse securityUserUpdate)
        {
            var security = await GetSecurityUser(key);

            if (security == null) return;

            RemoveSecurityUser(key);

            securityUserUpdate.User.Password = security.User.Password;
            await SetSecurityUser(key, securityUserUpdate);
        }

        public static void RemoverUsuarioLogado()
        {
            Preferences.Remove(nameof(Usuario));
        }


        public static void RemoveSecurityUser(string key)
        {
            SecureStorage.Remove(key);
        }
    }
}
