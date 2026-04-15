using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace _12_pract
{
    public class ChatService
    {
        private const string PipeName = "EventsChatPipe";

        public async Task SendMessageAsync(string message)
        {
            using var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out);
            await client.ConnectAsync();

            using var writer = new StreamWriter(client) { AutoFlush = true };
            await writer.WriteLineAsync(message);
        }

        public void StartListening(Action<string> onMessage)
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    using var server = new NamedPipeServerStream(PipeName, PipeDirection.In);
                    await server.WaitForConnectionAsync();

                    using var reader = new StreamReader(server);
                    string msg = await reader.ReadLineAsync();

                    if (!string.IsNullOrEmpty(msg))
                        onMessage?.Invoke(msg);
                }
            });
        }
    }
}
