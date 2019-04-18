using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
   public class TimeOfDayPaid
    {

      public string StartHour{set; get;}
      public string EndHour{set ; get;}
      public double Amount{set;get;}
      public bool IsWeekEndDay { set; get; }
        
      public TimeOfDayPaid(string startHour, string endHour, double amount, bool isWeekEndDay) {
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.Amount = amount;
            this.IsWeekEndDay = isWeekEndDay;
        }
    }
}
