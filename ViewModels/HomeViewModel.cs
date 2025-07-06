namespace SaikouClone.ViewModels
{
    public class HomeViewModel
    {
        public List<string> Categories { get; } = new List<string>
        {
            "Featured", "Trending", "Popular", "New Releases"
        };
    }
}