using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace CustomHttpHeaders
{
    public static class WebHeaders
    {
        public static void SetHeaders(this HttpWebRequest request, Dictionary<string, string> headers)
        {
            FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders",
                BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(request, new CustomWebHeaderCollection(headers));
        }

        public static void SetHeaders(this HttpWebRequest request, List<CustomHeader> headers)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (CustomHeader header in headers)
            {
                keyValuePairs.Add(header.Name, header.Value);
            }

            SetHeaders(request, keyValuePairs);
        }

        public static CustomHeader GetHeaderValue(this HttpWebRequest request, string header)
        {
            return new CustomHeader(header, request.Headers[header].ToString());
        }

        public static List<CustomHeader> GetHeaderValues(this HttpWebRequest request)
        {
            List<CustomHeader> customHeaders = new List<CustomHeader>();

            foreach (string header in request.Headers.AllKeys)
            {
                customHeaders.Add(new CustomHeader(header, request.Headers[header].ToString()));
            }

            return customHeaders;
        }

        public static CustomHeader GetHeaderValue(this HttpWebResponse response, string header)
        {
            return new CustomHeader(header, response.Headers[header].ToString());
        }

        public static List<CustomHeader> GetHeaderValues(this HttpWebResponse response)
        {
            List<CustomHeader> customHeaders = new List<CustomHeader>();

            foreach (string header in response.Headers.AllKeys)
            {
                customHeaders.Add(new CustomHeader(header, response.Headers[header].ToString()));
            }

            return customHeaders;
        }
    }
}