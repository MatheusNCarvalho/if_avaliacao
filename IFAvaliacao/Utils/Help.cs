using Plugin.Connectivity;

namespace IFAvaliacao.Utils
{
    public static class Help
    {
        public static bool IsConnected => CrossConnectivity.Current.IsConnected;

    }
}
