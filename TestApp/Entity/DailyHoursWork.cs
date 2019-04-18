using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
  public  class DailyHoursWork
    {
       public Employee WEmployee { set; get; }
       public string Day { set; get; }
       public bool IsWeekEnd { set; get; }
       public string StartHour { set; get; }
       public string EndHour { set; get; }
       public double AmountPay { set; get; }

       public DailyHoursWork(Employee employee, string day, string startHour, string endHour, double amount, bool isWeekEnd) {
            this.WEmployee = employee;
            this.Day = day;
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.AmountPay = amount;
            this.IsWeekEnd = isWeekEnd;
        }
    }
}
