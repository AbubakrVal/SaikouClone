namespace SaikouClone
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            try
            {
                return new Window(new AppShell());
            }
            catch (Exception ex)
            {
                return new Window(new ContentPage
                {
                    Content = new Label
                    {
                        Text = $"Startup Error: {ex.Message}",
                        TextColor = Colors.Red,
                        FontSize = 18,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    }
                });
            }
        }
    }
}