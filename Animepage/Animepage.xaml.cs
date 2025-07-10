using Microsoft.Maui.Controls;
using System;

namespace SaikouClone
{
    public partial class Animepage : ContentPage
    {
        public Animepage()
        {
            try
            {
                InitializeComponent();
                SetupEventHandlers();
            }
            catch (Exception ex)
            {
                HandleInitializationError(ex);
            }
        }

        private void SetupEventHandlers()
        {
            if (this.FindByName("AnimeButton") is Button animeButton)
                animeButton.Clicked += OnNavButtonClicked;
            
            if (this.FindByName("HomeButton") is Button homeButton)
                homeButton.Clicked += OnNavButtonClicked;
            
            if (this.FindByName("MangaButton") is Button mangaButton)
                mangaButton.Clicked += OnNavButtonClicked;
        }

        private async void OnNavButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button button)
                {
                    ResetButtonColors();
                    button.TextColor = Color.FromHex("#FF5722");
                    
                    if (button.Text == "Home" && !(Navigation.NavigationStack.LastOrDefault() is SaikouClone.Homepage.Homepage))
                        await Navigation.PushAsync(new SaikouClone.Homepage.Homepage());
                    else if (button.Text == "Manga" && !(Navigation.NavigationStack.LastOrDefault() is Mangapage))
                        await Navigation.PushAsync(new Mangapage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void ResetButtonColors()
        {
            if (this.FindByName("AnimeButton") is Button animeButton)
                animeButton.TextColor = Color.FromHex("#8A8A8F");
            
            if (this.FindByName("HomeButton") is Button homeButton)
                homeButton.TextColor = Color.FromHex("#8A8A8F");
            
            if (this.FindByName("MangaButton") is Button mangaButton)
                mangaButton.TextColor = Color.FromHex("#8A8A8F");
        }

        private void HandleInitializationError(Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(() => 
            {
                this.Content = new ErrorPageContent(ex.Message, () => 
                {
                    Application.Current.MainPage = new Animepage();
                });
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.FindByName("AnimeButton") is Button animeButton)
            {
                ResetButtonColors();
                animeButton.TextColor = Color.FromHex("#FF5722");
            }
        }
    }
}