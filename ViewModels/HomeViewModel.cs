using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SaikouClone.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _welcomeMessage = "Welcome to Saikou";
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetField(ref _welcomeMessage, value);
        }

        public ObservableCollection<RecentUpdate> RecentUpdates { get; } = new();

        public HomeViewModel()
        {
            try
            {
                LoadRecentUpdates();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ViewModel initialization error: {ex}");
                WelcomeMessage = "Error loading content";
            }
        }

        private void LoadRecentUpdates()
        {
            RecentUpdates.Clear();

            // Sample recent updates data
            RecentUpdates.Add(new RecentUpdate
            {
                Title = "Jujutsu Kaisen",
                ImageUrl = "jujutsu_kaisen.jpg",
                EpisodeInfo = "Episode 23: The Shibuya Incident",
                TimeAgo = "2 hours ago"
            });

            RecentUpdates.Add(new RecentUpdate
            {
                Title = "Demon Slayer",
                ImageUrl = "demon_slayer.jpg",
                EpisodeInfo = "Episode 12: Hashira Training",
                TimeAgo = "5 hours ago"
            });

            RecentUpdates.Add(new RecentUpdate
            {
                Title = "Attack on Titan",
                ImageUrl = "aot.jpg",
                EpisodeInfo = "Episode 88: The Final Chapter",
                TimeAgo = "1 day ago"
            });

            RecentUpdates.Add(new RecentUpdate
            {
                Title = "Chainsaw Man",
                ImageUrl = "chainsaw_man.jpg",
                EpisodeInfo = "Episode 8: Gunfire",
                TimeAgo = "1 day ago"
            });

            RecentUpdates.Add(new RecentUpdate
            {
                Title = "Spy x Family",
                ImageUrl = "spy_x_family.jpg",
                EpisodeInfo = "Episode 15: The Friendship Scheme",
                TimeAgo = "2 days ago"
            });

            RecentUpdates.Add(new RecentUpdate
            {
                Title = "My Hero Academia",
                ImageUrl = "mha.jpg",
                EpisodeInfo = "Episode 132: Tartarus Escapees",
                TimeAgo = "3 days ago"
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class RecentUpdate
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string EpisodeInfo { get; set; } = string.Empty;
        public string TimeAgo { get; set; } = string.Empty;
    }
}