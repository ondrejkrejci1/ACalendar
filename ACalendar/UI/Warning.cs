using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    public class Warning
    {
        public Button WarningButton {  get; private set; }

        public Warning()
        {
            WarningButton = new Button();
            WarningButton.Width = 50;
            WarningButton.Height = 50;
            WarningButton.VerticalAlignment = VerticalAlignment.Center;
            WarningButton.HorizontalAlignment = HorizontalAlignment.Center;
            WarningButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            WarningButton.VerticalContentAlignment = VerticalAlignment.Center;
            WarningButton.Content = "⚠︎";
            WarningButton.FontSize = 26;

        }

        public void HideButton(bool hide)
        {
            if (hide)
            {
                WarningButton.Visibility = Visibility.Hidden;
            } else
            {
                WarningButton.Visibility = Visibility.Visible;
            }
        }
    }
}
