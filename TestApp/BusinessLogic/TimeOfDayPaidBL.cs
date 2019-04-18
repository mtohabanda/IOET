using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace BusinessLogic
{
  public  class TimeOfDayPaidBL
    {
        const bool IS_WEEKEND = true;
        
        public TimeOfDayPaidBL()
         {
         }

        
        public List<TimeOfDayPaid> FillListOfTimeOfDayPaid(){
            List<TimeOfDayPaid> lstTimeOfDayPaid = new List<TimeOfDayPaid>();

            TimeOfDayPaid timeOfDay1 = new TimeOfDayPaid("00:01", "09:00", 25, !IS_WEEKEND);
            TimeOfDayPaid timeOfDay2 = new TimeOfDayPaid("09:01", "18:00", 15, !IS_WEEKEND);
            TimeOfDayPaid timeOfDay3 = new TimeOfDayPaid("18:01", "00:00", 20, !IS_WEEKEND);

            TimeOfDayPaid timeOfDay4 = new TimeOfDayPaid("00:01", "09:00", 30, IS_WEEKEND);
            TimeOfDayPaid timeOfDay5 = new TimeOfDayPaid("09:01", "18:00", 20, IS_WEEKEND);
            TimeOfDayPaid timeOfDay6 = new TimeOfDayPaid("18:01", "23:59", 25, IS_WEEKEND);

            lstTimeOfDayPaid.Add(timeOfDay1);
            lstTimeOfDayPaid.Add(timeOfDay2);
            lstTimeOfDayPaid.Add(timeOfDay3);
            lstTimeOfDayPaid.Add(timeOfDay4);
            lstTimeOfDayPaid.Add(timeOfDay5);
            lstTimeOfDayPaid.Add(timeOfDay6);

            return lstTimeOfDayPaid;
        }
    }
}
