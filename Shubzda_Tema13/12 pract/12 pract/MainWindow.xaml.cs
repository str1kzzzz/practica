using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _12_pract
{
    public partial class MainWindow : Window
    {
        public List<EventItem> Events { get; set; } = new();

        public ICommand CreateEventCommand { get; }
        public ICommand EditEventCommand { get; }
        public ICommand DeleteEventCommand { get; }

        public MainWindow()
        {
            InitializeComponent();

            CreateEventCommand = new RelayCommand(_ => CreateEvent());
            EditEventCommand = new RelayCommand(_ => EditEvent(), _ => EventsGrid.SelectedItem != null);
            DeleteEventCommand = new RelayCommand(_ => DeleteEvent(), _ => EventsGrid.SelectedItem != null);

            DataContext = this;

            Events.Add(new EventItem { Name = "Конференция IT", Date = DateTime.Now });
            Events.Add(new EventItem { Name = "Форум образования", Date = DateTime.Now.AddDays(1) });

            EventsGrid.ItemsSource = Events;
        }

        private void CreateEvent()
        {
            Events.Add(new EventItem
            {
                Name = "Новое мероприятие",
                Date = DateTime.Now
            });
            EventsGrid.Items.Refresh();
        }

        private void EditEvent()
        {
            var selected = EventsGrid.SelectedItem as EventItem;
            if (selected == null) return;

            selected.Name += " (изменено)";
            EventsGrid.Items.Refresh();
        }

        private void DeleteEvent()
        {
            var selected = EventsGrid.SelectedItem as EventItem;
            if (selected == null) return;

            if (MessageBox.Show("Удалить мероприятие?", "Подтверждение", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                Events.Remove(selected);
                EventsGrid.Items.Refresh();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedEvent = EventsGrid.SelectedItem as EventItem;

            ParticipantsList.ItemsSource = selectedEvent?.Participants;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateEvent();
        }

        private void AddParticipant_Click(object sender, RoutedEventArgs e)
        {
            var selectedEvent = EventsGrid.SelectedItem as EventItem;

            if (selectedEvent == null)
            {
                MessageBox.Show("Выберите мероприятие!");
                return;
            }

            var participant = new Participant
            {
                FullName = NameBox.Text,
                Email = EmailBox.Text,
                Section = SectionBox.Text,
                EventName = selectedEvent.Name
            };

            selectedEvent.Participants.Add(participant);
            ParticipantsList.Items.Refresh();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Text == "ФИО" || tb.Text == "Email" || tb.Text == "Секция")
                tb.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var tb = sender as TextBox;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                if (tb == NameBox) tb.Text = "ФИО";
                if (tb == EmailBox) tb.Text = "Email";
                if (tb == SectionBox) tb.Text = "Секция";
            }
        }
    }
}
