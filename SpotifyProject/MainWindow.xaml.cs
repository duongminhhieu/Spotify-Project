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

namespace SpotifyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                SetFontWeight(stackPanel, FontWeights.UltraBold);
            }
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                SetFontWeight(stackPanel, FontWeights.Normal);
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Xử lý sự kiện click ở đây
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                var stackPanelName = stackPanel.Name;

                // Thực hiện các hành động tương ứng với sự kiện click (ví dụ: hiển thị nội dung, chuyển trang, ...)
                switch (stackPanelName)
                {
                    case "homePanel":
                        MessageBox.Show("Home clicked!");
                        break;
                    case "searchPanel":
                        MessageBox.Show("Search clicked!");
                        break;
                    case "musicPanel":
                        mainFrame.Navigate(new Uri("Views/MusicPage.xaml", UriKind.Relative));
                        break;
                    case "videoPanel":
                        MessageBox.Show("Video clicked!");
                        break;
                    case "settingPanel":
                        MessageBox.Show("Setting clicked!");
                        break;
        
                }
            }
        }

        private void SetFontWeight(StackPanel stackPanel, FontWeight fontWeight)
        {
            var textBlock = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();
            var icon = stackPanel.Children.OfType<FontAwesome.WPF.FontAwesome>().FirstOrDefault();

            if (textBlock != null && icon != null)
            {
                textBlock.FontWeight = fontWeight;
                icon.FontWeight = fontWeight;
            }
        }

       
    }
}
