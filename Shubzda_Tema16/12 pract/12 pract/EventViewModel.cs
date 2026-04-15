using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace _12_pract
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private readonly EventService _service = new();
        private readonly ChatService _chat = new();
        private readonly NotificationService _notify = new();

        public ObservableCollection<EventModel> Events { get; set; } = new();
        public ObservableCollection<string> ChatMessages { get; set; } = new();
        private string _chatInput;
        public string ChatInput
        {
            get => _chatInput;
            set
            {
                _chatInput = value;
                OnPropertyChanged(nameof(ChatInput));
            }
        }

        public RelayCommand SendChatCommand { get; }
        private EventModel _selectedEvent;
        public EventModel SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }
        private ParticipantModel _newParticipant = new();
        public ParticipantModel NewParticipant
        {
            get => _newParticipant;
            set
            {
                _newParticipant = value;
                OnPropertyChanged(nameof(NewParticipant));
            }
        }
        public RelayCommand CreateEventCommand { get; }
        public RelayCommand DeleteEventCommand { get; }
        public RelayCommand EditEventCommand { get; }
        public AsyncRelayCommand RegisterCommand { get; }
        public EventViewModel()
        {
            CreateEventCommand = new RelayCommand(_ => CreateEvent());
            DeleteEventCommand = new RelayCommand(_ => DeleteEvent(), _ => SelectedEvent != null);
            EditEventCommand = new RelayCommand(_ => EditEvent(), _ => SelectedEvent != null);
            RegisterCommand = new AsyncRelayCommand(RegisterAsync);

            SendChatCommand = new RelayCommand(async _ => await SendMessageAsync());
            _chat.StartListening(msg =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    ChatMessages.Add(msg);
                });
            });
            _notify.StartListening(() =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show("Расписание изменено в другой копии приложения!");
                });
            });

            _ = LoadAsync();
        }
        private async Task LoadAsync()
        {
            var list = await _service.LoadEventsAsync();
            foreach (var ev in list)
                Events.Add(ev);
        }

        private async Task SaveAsync()
        {
            await _service.SaveEventsAsync(Events);
        }
        private async void CreateEvent()
        {
            Events.Add(new EventModel
            {
                Name = "Новое мероприятие",
                Date = DateTime.Now
            });

            await SaveAsync();
            _notify.NotifyScheduleChanged();
        }
        private async void EditEvent()
        {
            if (SelectedEvent == null) return;

            SelectedEvent.Name += " (изменено)";
            OnPropertyChanged(nameof(Events));

            await SaveAsync();
            _notify.NotifyScheduleChanged();
        }
        private async void DeleteEvent()
        {
            if (SelectedEvent == null) return;

            Events.Remove(SelectedEvent);

            await SaveAsync();
            _notify.NotifyScheduleChanged();
        }
        private async Task RegisterAsync()
        {
            if (SelectedEvent == null)
            {
                MessageBox.Show("Выберите мероприятие!");
                return;
            }

            if (string.IsNullOrWhiteSpace(NewParticipant.FullName))
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }

            SelectedEvent.Participants.Add(NewParticipant);

            await _service.SendInvitationAsync(NewParticipant);

            MessageBox.Show("Приглашение отправлено!");

            NewParticipant = new ParticipantModel();
            OnPropertyChanged(nameof(NewParticipant));
            OnPropertyChanged(nameof(SelectedEvent));

            await SaveAsync();
            _notify.NotifyScheduleChanged();
        }
        private async Task SendMessageAsync()
        {
            if (string.IsNullOrWhiteSpace(ChatInput))
                return;

            string message = $"[{DateTime.Now:HH:mm}] {ChatInput}";
            await _chat.SendMessageAsync(message);

            ChatInput = "";
            OnPropertyChanged(nameof(ChatInput));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
