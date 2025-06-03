using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    /// <summary>
    /// This class creates a warning button with warning symbol.
    /// It can be shown or hidden by HideButton method.
    /// </summary>
    public class Warning
    {
        /// <summary>
        /// Button which shows warning icon.
        /// </summary>
        public Button WarningButton {  get; private set; }

        /// <summary>
        /// Constructor initialize the warning button with fixed size and style.
        /// </summary>
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
            WarningButton.BorderThickness = new Thickness(0);

        }

        /// <summary>
        /// Show or hide the warning button depends on the boolean parameter.
        /// If true, button will be hidden, else it will be visible.
        /// </summary>
        /// <param name="hide">Set true for hide button, false to show</param>
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
