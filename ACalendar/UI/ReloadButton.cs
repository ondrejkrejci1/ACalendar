using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    /// <summary>
    /// Simple class for create reload button with refresh icon.
    /// Button is styled with fixed size and position.
    /// </summary>
    public class ReloadButton
    {
        /// <summary>
        /// The actual button control.
        /// </summary>
        public Button Button { get; private set; }

        /// <summary>
        /// Constructor sets up the button with icon, size and layout.
        /// </summary>
        public ReloadButton()
        {
            Button = new Button();
            Button.Height = 50;
            Button.Width = 70;
            Button.HorizontalAlignment = HorizontalAlignment.Left;
            Button.VerticalAlignment = VerticalAlignment.Bottom;
            Button.Margin = new Thickness(5,0,0,5);
            Button.BorderThickness = new Thickness(0);
            Button.Content = "🔄";
            Button.FontSize = 30;

        }


    }
}
