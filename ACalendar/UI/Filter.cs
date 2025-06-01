using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACalendar.UI
{
    public class Filter
    {
        public RadioButton ButtonOperator { get; private set; }

        private bool isChecked = true;

        public Filter(string content, Thickness margin) 
        {
            ButtonOperator = new RadioButton();
            ButtonOperator.Height = 20;
            ButtonOperator.Content = content;
            ButtonOperator.FontSize = 16;
            ButtonOperator.HorizontalContentAlignment = HorizontalAlignment.Center;
            ButtonOperator.VerticalContentAlignment = VerticalAlignment.Center;
            ButtonOperator.VerticalAlignment = VerticalAlignment.Bottom;
            ButtonOperator.HorizontalAlignment = HorizontalAlignment.Left;
            ButtonOperator.Margin = margin;
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


            
        }

    }
}
