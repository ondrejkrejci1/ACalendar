using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    /// <summary>
    /// Button to move calendar month forward or backward.
    /// Stores direction info (forward or backward) and shows given content.
    /// </summary>
    public class MoveMonthButton
    {
        /// <summary>
        /// The actual button UI element.
        /// </summary>
        public Button MoveMonthB {  get; private set; }

        private bool moveForward;

        /// <summary>
        /// True means button moves month forward, false means backward.
        /// </summary>
        public bool MoveForward {  get { return moveForward; } private set { moveForward = value; } }

        /// <summary>
        /// Constructor, sets if button moves forward or backward and the text/icon to show.
        /// </summary>
        /// <param name="moveForward">True for forward, false for backward</param>
        /// <param name="content">Text or symbol to display on button</param>
        public MoveMonthButton(bool moveForward, string content)
        {
            MoveForward = moveForward;

            MoveMonthB = new Button();
            MoveMonthB.Width = 60;
            MoveMonthB.Height = 250;
            MoveMonthB.Content = content;
            MoveMonthB.HorizontalContentAlignment = HorizontalAlignment.Center;
            MoveMonthB.VerticalContentAlignment = VerticalAlignment.Center;
            MoveMonthB.FontSize = 32;
            MoveMonthB.BorderThickness = new Thickness(0);

        }

        /// <summary>
        /// Static method to move calendar by given months, update its display.
        /// Returns new current date after move.
        /// </summary>
        /// <param name="monthsMove">Number of months to move (positive or negative)</param>
        /// <param name="calendar">Calendar instance to update</param>
        /// <param name="visibleTraining">Show training in calendar</param>
        /// <param name="visibleMeeting">Show meeting in calendar</param>
        /// <returns>New current date after moving months</returns>
        public static DateTime Move(int monthsMove,Calendar calendar, bool visibleTraining, bool visibleMeeting)
        {
            DateTime current = DateTime.Now.AddMonths(monthsMove);

            calendar.UpdateCalendar(current.Year, current.Month, visibleTraining, visibleMeeting);

            return current;
        }

    }
}
