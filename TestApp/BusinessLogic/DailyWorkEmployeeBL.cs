using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
namespace BusinessLogic
{
  public  class DailyWorkEmployeeBL
    {
        private List<TimeOfDayPaid> lstTimeOfDayPaid;

        public DailyWorkEmployeeBL(){
            TimeOfDayPaidBL timeOfDayPaid = new TimeOfDayPaidBL();
            lstTimeOfDayPaid = timeOfDayPaid.FillListOfTimeOfDayPaid();
        }

        public double GetAmountPayTimeOfDay(DailyHoursWork workDaily) {
            return lstTimeOfDayPaid.Where(x => DateTime.Parse(workDaily.StartHour) >= DateTime.Parse(x.StartHour) &&
                                               DateTime.Parse(workDaily.EndHour) <= DateTime.Parse(x.EndHour) &&
                                               workDaily.IsWeekEnd == x.IsWeekEndDay
                                          ).Select(x => x.Amount).SingleOrDefault();
        }


        public double CalculateTotalAmountPay(List<DailyHoursWork> lstDailyWorkEmployee) {
            double totalAmountPay = 0;

            foreach (DailyHoursWork workDaily in lstDailyWorkEmployee)
            {
                TimeSpan numberOfHoursWorked = (DateTime.Parse(workDaily.EndHour).Subtract(DateTime.Parse(workDaily.StartHour)));
                totalAmountPay += (int)numberOfHoursWorked.TotalHours * GetAmountPayTimeOfDay(workDaily);
            }
            return totalAmountPay;
        }     
  }    
}
