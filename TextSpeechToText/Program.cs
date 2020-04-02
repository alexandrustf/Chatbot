using System;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Google.Cloud.Storage.V1;
using NAudio.Wave;
using Newtonsoft.Json;
using NLayer.NAudioSupport;
using SpeechToText;

namespace TextSpeechToText
{
    public class Program
    {
        // The name of the local audio file to transcribe
        public static string DEMO_FILE = "C:\\Users\\Alex Stefan\\source\\repos\\Chatbot\\SpeechToText\\audio.raw";
        public static void Main(string[] args)
        {
            var bytes = File.ReadAllBytes(DEMO_FILE);
            var cceva = JsonConvert.SerializeObject(bytes);
            Console.WriteLine(cceva);
            string result = System.Text.Encoding.UTF8.GetString(bytes);
            Console.WriteLine(result);
            // Console.WriteLine(new SpeechToTextConverter().ConvertSpeechToText(bytes));
        }
    }
}
