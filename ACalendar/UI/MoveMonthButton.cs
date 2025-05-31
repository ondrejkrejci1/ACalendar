using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    public class MoveMonthButton
    {
        public Button MoveMonthB {  get; private set; }

        private bool moveForward;
        public bool MoveForward {  get { return moveForward; } private set { moveForward = value; } }
        

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

        }

        public static DateTime Move(int monthsMove,Calendar calendar)
        {
            DateTime current = DateTime.Now.AddMonths(monthsMove);
            calendar.UpdateCalendar(current.Year, current.Month);

            return current;
        }





    }
}
