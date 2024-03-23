using Humanizer;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Plugins;
using System.Linq;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.TextGeneration;


public class MyPlanner
{
    public void WriteLine(string text) => Console.WriteLine(text);

    public async Task RunAsync()
    {
        HttpClient client = new HttpClient(new MyHttpMessageHandler());

        var builder = Kernel.CreateBuilder();

        int number = 1;

        switch (number)
        {
            case 0:
                builder.AddAzureOpenAIChatCompletion(
                         "gpt4",                      // Azure OpenAI Deployment Name
                         "https://employee-profiler-openai-upvr4ogjxcmpo.openai.azure.com/openai", // Azure OpenAI Endpoint
                         Environment.GetEnvironmentVariable("AZURE_OPENAI_KEY") ?? "");      // Azure OpenAI Key
                break;

            case 1:
                // Alternative using OpenAI
                builder.AddOpenAIChatCompletion(
                         "gpt-3.5-turbo-0125",                  // OpenAI Model name
                         Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "");     // OpenAI API Key
                break;
            case 2:
                // Alternative using OpenAI
                builder.AddOpenAIChatCompletion(
                         "fake model",
                         "fake-api-key",
                         httpClient: client);
                break;
        }

        builder.Plugins.AddFromType<FilePlugin>();
        builder.Plugins.AddFromType<FolderPlugin>();
        Kernel kernel = builder.Build();

        // Get chat completion service
        var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

        // Create chat history
        ChatHistory history = new();

        // Start the conversation
        Console.Write("User > ");
        string? userInput;
        while ((userInput = Console.ReadLine()) != null)
        {
            // Get user input
            Console.Write("User > ");
            history.AddUserMessage(userInput!);

            // Enable auto function calling
            OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                Temperature = 0.5,
                MaxTokens = 1000,
            };

            // Get the response from the AI
            var result = chatCompletionService.GetStreamingChatMessageContentsAsync(
                                history,
                                executionSettings: openAIPromptExecutionSettings,
                                kernel: kernel);

            // Stream the results
            string fullMessage = "";
            var first = true;
            await foreach (var content in result)
            {
                if (content.Role.HasValue && first)
                {
                    Console.Write("\nAssistant > ");
                    first = false;
                }
                Console.Write(content.Content);
                fullMessage += content.Content;
            }
            Console.WriteLine();

            // Add the message from the agent to the chat history
            history.AddAssistantMessage(fullMessage);

            // Get user input again
            Console.Write("User > ");
        }
    }
}


public partial class Program
{
    public static void Main()
    {
        MyPlanner planner = new();
        planner.RunAsync().Wait();
    }
}
