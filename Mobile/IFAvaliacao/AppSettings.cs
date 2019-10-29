

using IFAvaliacao.Domain.Entities;
using IFAvaliacao.Utils;

namespace IFAvaliacao
{
    public static class AppSettings
    {
        public static string Username = "admin";
        public static string Password = "admin";


        public static bool UsuarioLogado
        {
            get => PreferencesHelpers.Get(nameof(UsuarioLogado), false);
            set => PreferencesHelpers.Set(nameof(UsuarioLogado), value);
        }

        public static Usuario Usuario
        {
            get => PreferencesHelpers.Get(nameof(Usuario), default(Usuario));
            set => PreferencesHelpers.Set(nameof(Usuario), value);
        }
    }
}
