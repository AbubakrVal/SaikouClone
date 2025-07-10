using Microsoft.Maui.Controls;

namespace SaikouClone
{
    public class ErrorPageContent : StackLayout
    {
        public ErrorPageContent(string errorMessage, Action retryAction)
        {
            VerticalOptions = LayoutOptions.Center;
            HorizontalOptions = LayoutOptions.Center;
            Padding = 20;
            BackgroundColor = Color.FromArgb("#0F1115");
            Spacing = 10;

            Children.Add(new Label 
            { 
                Text = "Loading Error",
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                TextColor = Colors.Red,
                HorizontalOptions = LayoutOptions.Center
            });

            Children.Add(new Label 
            { 
                Text = errorMessage,
                FontSize = 14,
                TextColor = Colors.White,
                MaxLines = 5,
                LineBreakMode = LineBreakMode.WordWrap
            });

            Children.Add(new Button
            {
                Text = "Retry",
                BackgroundColor = Color.FromArgb("#FF5722"),
                TextColor = Colors.White,
                Margin = new Thickness(0, 20),
                Command = new Command(retryAction)
            });
        }
    }
}