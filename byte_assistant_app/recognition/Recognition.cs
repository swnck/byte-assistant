using Microsoft.CognitiveServices.Speech;

namespace byte_assistant_app.openai;

public class Recognition
{
    private string subscriptionKey = "086b811d3a5e45f3a9259b17377a1e94";
    private string region = "germanywestcentral";
    
    private SpeechRecognizer recognizer;
    private string listenTo = "Ok Byte";
    public bool isListening;

    public async Task InitializeAsync()
    {
        var config = SpeechConfig.FromSubscription(subscriptionKey, region);
        recognizer = new SpeechRecognizer(config);

        recognizer.Recognized += (s, e) =>
        {
            Console.WriteLine(e.Result.Text);
            if (e.Result.Text.Equals(listenTo, StringComparison.OrdinalIgnoreCase))
            {
                isListening = true;
                Console.WriteLine("Listening...");
                // OpenAI wait a second
            }
        };

        await ListenAsync();
    }

    public async Task<RecognitionState> ListenAsync()
    {
        if (!isListening)
        {
            await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);
            return RecognitionState.PRE_RECORDING;
        }
        else
        {
            await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
            isListening = false;
            return RecognitionState.LISTENING;
        }
    }
}