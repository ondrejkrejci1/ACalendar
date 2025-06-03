using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    /// <summary>
    /// This class create filter control with a radio button inside.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Container grid where button is placed.
        /// </summary>
        public Grid Container {  get; private set; }

        /// <summary>
        /// The radio button that user can check or uncheck.
        /// </summary>
        public RadioButton ButtonOperator { get; private set; }

        private bool isChecked = true;

        /// <summary>
        /// Constructor sets up container and radio button with given text and margin.
        /// Also adds click event that toggles check state manually.
        /// </summary>
        /// <param name="content">Text shown on radio button</param>
        /// <param name="margin">Margin for container grid</param>
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
