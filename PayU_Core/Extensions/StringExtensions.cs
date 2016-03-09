#region

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

#endregion

namespace PayU_Core.Extensions
{
    internal static class StringExtension
    {
        internal static bool IsArrayKey(this string key)
        {
            return key.EndsWith("[]");
        }

        internal static string[] GetArrayFromValue(this string value)
        {
            return value.Split(',');
        }

        internal static object FromBase64String(this string base64String)
        {
            byte[] arrBytes = Convert.FromBase64String(base64String);
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var objText = (string)binForm.Deserialize(memStream);

                return JsonConvert.DeserializeObject(objText);
            }
        }
    }
}