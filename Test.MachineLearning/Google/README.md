### Text To Speech
```C#
if (PlatformID.Win32NT == Environment.OSVersion.Platform)
{
  var tts = new TextToSpeech(Resources.GOOGLESERVICE);

  using (var ms = new MemoryStream())
  {
    tts.VoiceSelection.LanguageCode = Google.Cloud.Speech.V1.LanguageCodes.Korean.SouthKorea;
    tts.VoiceSelection.SsmlGender = (Google.Cloud.TextToSpeech.V1.SsmlVoiceGender)(inventory.Value.Name.Length % 2 + 1);

    using (var sp = new SoundPlayer(await tts.SynthesizeSpeechAsync(ms, inventory.Value.Name)))
    {
      sp.PlaySync();
    }
  }
}
```
