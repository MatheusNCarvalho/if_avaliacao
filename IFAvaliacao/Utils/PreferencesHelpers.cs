using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using Xamarin.Essentials;

namespace IFAvaliacao.Utils
{
    public class PreferencesHelpers
    {
        public static T Get<T>(string key, T @default)
        {
            var serialized = Preferences.Get(key, string.Empty);

            var result = @default;

            try
            {
                result = JsonConvert.DeserializeObject<T>(serialized);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error deserializing settings value: {e}");
            }
            return result;
        }

        public static void Set<T>(string key, T obj)
        {
            try
            {
                var settings = GetSerializerSettings();
                var serialized = JsonConvert.SerializeObject(obj, settings);
                Preferences.Set(key, serialized);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error serializing settings value: {e}");
            }
        }

        public static void Clear(string key)
        {
            try
            {
                Preferences.Clear(key);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error clearning settings value: {e}");
            }
        }

        static JsonSerializerSettings GetSerializerSettings() => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
