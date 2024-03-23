using System.Runtime.CompilerServices;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.TextGeneration;


public sealed class MyTextGenerationService : ITextGenerationService
{
    private const string LLMResultText = @"...output from your custom model... Example:
AI is awesome because it can help us solve complex problems, enhance our creativity,
and improve our lives in many ways. AI can perform tasks that are too difficult,
tedious, or dangerous for humans, such as diagnosing diseases, detecting fraud, or
exploring space. AI can also augment our abilities and inspire us to create new forms
of art, music, or literature. AI can also improve our well-being and happiness by
providing personalized recommendations, entertainment, and assistance. AI is awesome.";

    public IReadOnlyDictionary<string, object?> Attributes => new Dictionary<string, object?>();

    public async IAsyncEnumerable<StreamingTextContent> GetStreamingTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        foreach (string word in LLMResultText.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            await Task.Delay(50, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            yield return new StreamingTextContent($"{word} ");
        }
    }

    public Task<IReadOnlyList<TextContent>> GetTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyList<TextContent>>(new List<TextContent>
            {
                new(LLMResultText)
            });
    }
}