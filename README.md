# Chatbot Planner Application

This repository contains a C# console application that demonstrates the integration of a chatbot using Microsoft Semantic Kernel and (Azure) OpenAI's GPT models. The application is designed to provide a conversational interface where users can input text and receive responses from the AI.

## Features

- Integration with (Azure) OpenAI's GPT models for natural language processing.
- Support for multiple OpenAI models, including GPT-4 and GPT-3.5.
- Customizable settings for AI prompt execution, such as temperature and max tokens.
- **Plugin support for file and folder management within the chatbot environment.**
- A chat history mechanism to maintain the context of the conversation.
- Streaming of AI responses to provide a dynamic conversational experience.

## Configuration

The application can be configured to use different OpenAI models by setting the `number` variable. The configuration includes:

- Case 0: Azure OpenAI with GPT-4 model.
- Case 1: OpenAI with GPT-3.5-turbo model.
- Case 2: A placeholder for a fake model and API key, intended for  local testing.

## Prerequisites

- .NET 8.0 or higher.
- Valid OpenAI API keys for the models you intend to use.
- If local testing, you need to host your Language Model yourself. Visit [Langchain](https://python.langchain.com/docs/guides/local_llms) or the [Open-Interpreter](https://docs.openinterpreter.com/guides/running-locally) project to setup.

## Usage

1. Clone the repository to your local machine.
2. Replace the placeholders in the code with your actual OpenAI API keys or create environment variables.
3. Build and run the application using your preferred .NET CLI tools or IDE.
4. Interact with the chatbot through the console by typing messages and receiving responses.

## Important Notes

- Ensure that you have the correct API keys set in your environment variables or replace the placeholders in the code with your actual keys.
- The `MyHttpMessageHandler` class is referenced but not defined in the provided code. You will need to implement this class or use the default `HttpClientHandler`.
    It is used, in case you want to add your local LM server as API.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
