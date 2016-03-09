#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

#endregion

namespace PayU_Core.Extensions
{
    internal static class StringBuilderExtensions
    {
        internal static void BeginBody(this StringBuilder sb, string key, string value)
        {
            sb.Append(key + "=" + HttpUtility.UrlEncode(value));
        }

        internal static void BeginBody(this StringBuilder sb, params KeyValuePair<string, string>[] keysAndValues)
        {
            sb.BeginBody(keysAndValues[0].Key, keysAndValues[0].Value);

            List<KeyValuePair<string, string>> list = keysAndValues.ToList();
            list.RemoveAt(0);

            foreach (KeyValuePair<string, string> kvp in list)
            {
                sb.AppendToBody(kvp.Key, kvp.Value);
            }
        }

        internal static void AppendToBody(this StringBuilder sb, string key, string value)
        {
            sb.Append("&" + key + "=" + HttpUtility.UrlEncode(value));
        }

        internal static void AppendToBody(this StringBuilder sb, params KeyValuePair<string, string>[] keysAndValues)
        {
            foreach (KeyValuePair<string, string> kvp in keysAndValues)
            {
                sb.AppendToBody(kvp.Key, kvp.Value);
            }
        }

        internal static void AppendToControlString(this StringBuilder sb, string text)
        {
            sb.Append(Encoding.UTF8.GetByteCount(text) + text);
        }

        internal static void AppendToControlString(this StringBuilder sb, params string[] textArray)
        {
            foreach (string text in textArray)
            {
                sb.AppendToControlString(text);
            }
        }

        internal static int IndexOf(this StringBuilder sb, string value)
        {
            return IndexOf(sb, value, 0, false);
        }

        internal static int IndexOf(this StringBuilder sb, string value, int startIndex, bool ignoreCase)
        {
            int index;
            int length = value.Length;
            int maxSearchLength = (sb.Length - length) + 1;

            if (ignoreCase)
            {
                for (int i = startIndex; i < maxSearchLength; ++i)
                {
                    if (Char.ToLower(sb[i]) == Char.ToLower(value[0]))
                    {
                        index = 1;
                        while ((index < length) && (Char.ToLower(sb[i + index]) == Char.ToLower(value[index])))
                        {
                            ++index;
                        }

                        if (index == length)
                        {
                            return i;
                        }
                    }
                }

                return -1;
            }

            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (sb[i] == value[0])
                {
                    index = 1;
                    while ((index < length) && (sb[i + index] == value[index]))
                    {
                        ++index;
                    }

                    if (index == length)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}