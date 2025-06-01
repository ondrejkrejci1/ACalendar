using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACalendar.UI
{
    public class Filter
    {
        public Grid Container {  get; private set; }
        public RadioButton ButtonOperator { get; private set; }

        private bool isChecked = true;

        public Filter(string content, Thickness margin) 
        {
            Container = new Grid();
            Container.Height = 20;
            Container.Width = 100;
            Container.Margin = margin;
            Container.HorizontalAlignment = HorizontalAlignment.Left;
            Container.VerticalAlignment = VerticalAlignment.Bottom;

            ButtonOperator = new RadioButton();
            
            ButtonOperator.Content = content;
            ButtonOperator.FontSize = 16;
            ButtonOperator.HorizontalContentAlignment = HorizontalAlignment.Center;
            ButtonOperator.VerticalContentAlignment = VerticalAlignment.Center;
            ButtonOperator.VerticalAlignment = VerticalAlignment.Bottom;
            ButtonOperator.HorizontalAlignment = HorizontalAlignment.Left;
            ButtonOperator.IsChecked = true;
            ButtonOperator.Click += (s, e) => 
            {
                if(isChecked)
                {
                    ButtonOperator.IsChecked = false;
                    isChecked = false;
                } else
                {
                    ButtonOperator.IsChecked = true;
                    isChecked = true;
                }

            };

            Container.Children.Add(ButtonOperator);
            
        }

    }
}
