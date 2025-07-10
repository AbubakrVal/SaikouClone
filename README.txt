SaikouClone - .NET MAUI Anime/Manga App
======================================

This is a cross-platform anime/manga tracking and browsing app built with .NET MAUI.

Features:
---------
- Home page with user info, stats, and quick navigation buttons
- Anime and Manga pages with featured content
- Simple navigation bar at the bottom
- Sample data and placeholder images for demonstration

Project Structure:
-----------------
- Homepage/         - Home page XAML and code-behind
- Animepage/        - Anime page XAML and code-behind
- Mangapage/        - Manga page XAML and code-behind
- ViewModels/       - ViewModels for data binding
- Resources/Images/ - App images (ensure all are valid PNG/JPG files)
- Resources/Styles/ - App styles and color resources
- AppShell.xaml     - Shell navigation setup
- App.xaml          - App resources and startup

How to Build & Run:
-------------------
1. Ensure you have the .NET 9.0 SDK and MAUI workload installed.
2. Open the project in VS Code or Visual Studio.
3. Make sure all images in Resources/Images/ are valid PNG/JPG files.
4. Use the provided VS Code tasks or run:
   dotnet build -t:Run -f net9.0-android

Troubleshooting:
----------------
- If you see image errors, make sure all referenced images exist and are valid.
- If the app crashes on startup, try commenting out resource dictionaries in App.xaml to isolate style issues.
- For navigation errors, ensure all pages are registered in AppShell.xaml.cs and exist in the project.

Contributions:
--------------
Feel free to fork and improve this project!
