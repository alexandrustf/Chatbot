using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Google.Cloud.Speech.V1;

namespace SpeechToText
{
    public class SpeechToTextConverter
    {
        public string ConvertSpeechToText(string path)
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "..\\..\\..\\..\\SpeechToText\\Speech-206301277cf5.json");
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "en",
            }, RecognitionAudio.FromFile(path));
            string text = "";
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    text += alternative.Transcript;
                }
            }
            return text;
        }

        public string ConvertSpeechToText(byte[] bytes)
        {
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "C:\\Users\\Alex Stefan\\source\\repos\\Chatbot\\SpeechToText\\Speech-206301277cf5.json");
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                LanguageCode = "en",
            }, RecognitionAudio.FromBytes(bytes));
            string text = "";
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    text += alternative.Transcript;
                }
            }
            return text;
        }
    }
}
