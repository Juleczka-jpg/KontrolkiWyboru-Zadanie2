using System.Collections.ObjectModel;

namespace MauiApp7
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<string> Specializations { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Specializations = new ObservableCollection<string>
            {
                "Internista",
                "Kardiolog",
                "Dermatolog",
                "Okulista"
            };

            MinDate = DateTime.Today.AddDays(1);
            MaxDate = DateTime.Today.AddDays(30);

            BindingContext = this;
        }
*******************************************************************
nazwa funkcji: OnReserveClicked
opis funkcji: Funkcja rezewuje wizytę po kliknięciu w przycisk. Sprawdza, czy wybrano specjalizację i wyświetla odpowiedni alert.
parametry: sender – obiekt wywołujący zdarzenie, e – argumenty zdarzenia
zwracany typ i opis: brak(void) – funkcja wyświetla alert z błędem lub potwierdzeniem
autor: Julia Nowakowska
*******************************************************************

        private async void OnReserveClicked(object sender, EventArgs e)
        {
            if (SpecializationPicker.SelectedItem == null)
            {
                await DisplayAlert("Błąd", "Wybierz specjalizację.", "OK");
                return;
            }

            var specialization = SpecializationPicker.SelectedItem.ToString();
            var date = VisitDatePicker.Date.ToShortDateString();
            var time = VisitTimePicker.Time.ToString(@"hh\:mm");

            await DisplayAlert("Potwierdzenie",
                $"Zarezerwowano wizytę u: {specialization}\nData: {date}\nGodzina: {time}",
                "OK");
        }

    }
}
