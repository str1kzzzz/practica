using System;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_pract
{
    public class NotificationService
    {
        private const string MapName = "EventsScheduleMap";

        public void NotifyScheduleChanged()
        {
            using var mmf = MemoryMappedFile.CreateOrOpen(MapName, 256);
            using var accessor = mmf.CreateViewAccessor();

            byte[] bytes = Encoding.UTF8.GetBytes("changed");
            accessor.WriteArray(0, bytes, 0, bytes.Length);
        }

        public void StartListening(Action onChanged)
        {
            _ = Task.Run(() =>
            {
                while (true)
                {
                    using var mmf = MemoryMappedFile.CreateOrOpen(MapName, 256);
                    using var accessor = mmf.CreateViewAccessor();

                    byte[] buffer = new byte[256];
                    accessor.ReadArray(0, buffer, 0, buffer.Length);

                    string text = Encoding.UTF8.GetString(buffer).TrimEnd('\0');

                    if (text == "changed")
                        onChanged?.Invoke();

                    Thread.Sleep(1000);
                }
            });
        }
    }
}
