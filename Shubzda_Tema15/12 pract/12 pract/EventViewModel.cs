using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace _12_pract
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private readonly EventService _service = new();

        public ObservableCollection<EventModel> Events { get; set; } = new();

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

            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            var list = await _service.LoadEventsAsync();
            foreach (var ev in list)
                Events.Add(ev);
        }

        private void CreateEvent()
        {
            Events.Add(new EventModel
            {
                Name = "Новое мероприятие",
                Date = System.DateTime.Now
            });
        }

        private void EditEvent()
        {
            if (SelectedEvent == null) return;
            SelectedEvent.Name += " (изменено)";
            OnPropertyChanged(nameof(Events));
        }

        private void DeleteEvent()
        {
            if (SelectedEvent == null) return;
            Events.Remove(SelectedEvent);
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
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
