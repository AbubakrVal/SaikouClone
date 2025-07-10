using SaikouClone;


namespace SaikouClone
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            try
            {
                InitializeComponent();
                RegisterRoutes();
                SetupTabBar();
            }
            catch (Exception ex)
            {
                // Handle initialization errors
                Console.WriteLine($"Shell initialization error: {ex}");
            }
        }

        private void RegisterRoutes()
        {
            // Main pages
            Routing.RegisterRoute("AnimePage", typeof(Animepage));
            Routing.RegisterRoute("HomePage", typeof(SaikouClone.Homepage.Homepage));
            Routing.RegisterRoute("MangaPage", typeof(Mangapage));

            // Detail pages (if needed)
            // Routing.RegisterRoute("AnimeDetailPage", typeof(AnimeDetailPage));
        }

        private void SetupTabBar()
        {
            // Ensure tab bar is properly configured
            CurrentItem = FindByName("HomeTab") as Tab;
        }
    }
}