using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    public class ReloadButton
    {
        public Button Button { get; private set; }

        public ReloadButton()
        {
            Button = new Button();
            Button.Height = 50;
            Button.Width = 70;
            Button.HorizontalAlignment = HorizontalAlignment.Left;
            Button.VerticalAlignment = VerticalAlignment.Bottom;
            Button.Margin = new Thickness(5,0,0,5);
            Button.Content = "🔄";
            Button.FontSize = 30;

        }


    }
}
