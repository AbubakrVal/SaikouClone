using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SaikouClone.ViewModels;

namespace SaikouClone.Homepage
{
    public partial class Homepage : ContentPage
    {
        private readonly Color _activeColor = Color.FromArgb("#FF5722");
        private readonly Color _inactiveColor = Color.FromArgb("#8A8A8F");
        
        public Homepage()
        {
            try
            {
                InitializeComponent();
                BindingContext = new HomeViewModel();
            }
            catch (Exception ex)
            {
                Content = new Label
                {
                    Text = $"Homepage Error: {ex.Message}",
                    TextColor = Colors.Red,
                    FontSize = 18,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ResetNavigationButtons();
            SetActiveButton(HomeButton);
        }

        private async void BrowseAnimeClicked(object sender, EventArgs e)
        {
            await NavigateToPage("//AnimePage", AnimeButton);
        }

        private async void BrowseMangaClicked(object sender, EventArgs e)
        {
            await NavigateToPage("//MangaPage", MangaButton);
        }

        private async void OnNavButtonClicked(object sender, EventArgs e)
        {
            if (sender is not Button button) return;
            
            var route = button switch
            {
                _ when button == AnimeButton => "//AnimePage",
                _ when button == MangaButton => "//MangaPage",
                _ => "//HomePage"
            };

            await NavigateToPage(route, button);
        }

        private async Task NavigateToPage(string route, Button activeButton)
        {
            try
            {
                ResetNavigationButtons();
                SetActiveButton(activeButton);
                
                if (Shell.Current.CurrentState.Location.ToString() != route)
                {
                    await Shell.Current.GoToAsync(route);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }

        private void ResetNavigationButtons()
        {
            var buttons = new[] { AnimeButton, HomeButton, MangaButton };
            foreach (var button in buttons)
            {
                button.TextColor = _inactiveColor;
                button.FontAttributes = FontAttributes.None;
            }
        }

        private void SetActiveButton(Button button)
        {
            button.TextColor = _activeColor;
            button.FontAttributes = FontAttributes.Bold;
        }

        private void HandleInitializationError(Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(() => 
            {
                Content = new StackLayout
                {
                    BackgroundColor = Color.FromArgb("#0F1115"),
                    Children = {
                        new Label 
                        { 
                            Text = "Failed to load application",
                            FontSize = 18,
                            TextColor = Colors.White,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        new Label 
                        { 
                            Text = ex.Message,
                            FontSize = 14,
                            TextColor = Colors.Orange,
                            HorizontalOptions = LayoutOptions.Center,
                            Margin = new Thickness(0, 10)
                        },
                        new Button
                        {
                            Text = "Retry",
                            Command = new Command(() => 
                            {
                                Application.Current.MainPage = new SaikouClone.Homepage.Homepage();
                            }),
                            HorizontalOptions = LayoutOptions.Center,
                            Margin = new Thickness(0, 20),
                            WidthRequest = 100
                        }
                    },
                    VerticalOptions = LayoutOptions.Center
                };
            });
        }
    }
}