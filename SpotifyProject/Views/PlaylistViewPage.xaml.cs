using SpotifyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotifyProject.Views
{
    /// <summary>
    /// Interaction logic for PlaylistViewPage.xaml
    /// </summary>
    public partial class PlaylistViewPage : Page
    {
        private Playlist Playlist;
        public PlaylistViewPage(Playlist playlist)
        {
            InitializeComponent();
            this.Playlist = playlist;
            this.DataContext = playlist;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            // Get the NavigationService of the Frame
            NavigationService navigationService = NavigationService.GetNavigationService(this);

            // Check if it's possible to go back
            if (navigationService.CanGoBack)
            {
                // Go back to the previous page
                navigationService.GoBack();
            }
        }

        private void PlayMusicBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OptionBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SubMenuPopup.IsOpen = true;
        }

     
    }
}
