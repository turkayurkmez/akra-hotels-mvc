using System.Text.Json;

namespace miniEShop.MVC.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string sessionKey, T registeredObject) 
        {
            var jsonString = JsonSerializer.Serialize(registeredObject);
            session.SetString(sessionKey, jsonString);
        }

        public static T? GetJson<T> (this ISession session, string sessionKey) where T:class,new()
        {
            string serializedJson = session.GetString(sessionKey);
            if (!string.IsNullOrEmpty(serializedJson))
            {
                return JsonSerializer.Deserialize<T>(serializedJson);
            }
            //Bir class'dan türeyen nesnenin varsayılan değeri null olduğuna göre
            //Biz de T tipini  where T:class biçiminde kısıtladığımıza göre:
            return new T();
        }
    }
}
