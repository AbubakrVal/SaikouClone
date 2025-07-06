namespace SaikouClone
{
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"INIT ERROR: {ex}");
                
                MainThread.BeginInvokeOnMainThread(() => 
                {
                    this.Content = new Label { Text = $"Error: {ex.Message}" };
                });
            }
        }
    }
}