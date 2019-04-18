using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.IO;

namespace BusinessLogic
{
  public  class ProcessFileBL
    {
        private List<DailyHoursWork> lstDailyHoursWorked;
        private DailyWorkEmployeeBL dailyWorkScheduleBL;
        public List<string> lstResultProcess;

        public ProcessFileBL() {
            dailyWorkScheduleBL = new DailyWorkEmployeeBL();
            lstDailyHoursWorked = new List<DailyHoursWork>();
            lstResultProcess = new List<string>();
        }

        public void ReadFile(string path)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(path);
                int idEmployee = 0;

                foreach (string line in lines)
                {
                    lstDailyHoursWorked.Clear();
                    string[] listOfScheduleWorked = line.Split('=');
                    string nameEmployee = listOfScheduleWorked[0];
                    Employee employee = new Employee(idEmployee, nameEmployee);

                    FillListOfDailyHoursWorked(employee, listOfScheduleWorked[1]);
                    double totalAmountPay = dailyWorkScheduleBL.CalculateTotalAmountPay(lstDailyHoursWorked);
                    
                    lstResultProcess.Add("The amount to pay " + employee.Name + " is: " + totalAmountPay + " USD");

                    idEmployee++;
                }
            }
            catch (IOException e)
            {
                lstResultProcess.Add(e.Message.ToString());
            }
        }

        private void FillListOfDailyHoursWorked(Employee employee, string listOfScheduleWorked)
        {
            
            string[] dailyScheduleWorked = listOfScheduleWorked.Split(',');
            
            for (int index = 0; index < dailyScheduleWorked.Length; index++) {
                string day = dailyScheduleWorked[index].Substring(0, 2);
                string[] scheduleWorked = dailyScheduleWorked[index].Substring(2).Split('-');
                string startHour = scheduleWorked[0];
                string endHour = scheduleWorked[1];

                DailyHoursWork dailyHoursWorkedEmployee = new DailyHoursWork(employee, day, startHour, endHour, 0, IsWeekEnd(day));
                dailyHoursWorkedEmployee.AmountPay = dailyWorkScheduleBL.GetAmountPayTimeOfDay(dailyHoursWorkedEmployee);
                lstDailyHoursWorked.Add(dailyHoursWorkedEmployee);
            }            
        }

        
        private bool IsWeekEnd(string day)
        {
            const string SATURDAY = "SA";
            const string SUNDAY = "SU";
            const bool IS_WEEKEND = true;

            return (day.Equals(SATURDAY) || day.Equals(SUNDAY) ? IS_WEEKEND : !IS_WEEKEND);
        }       
    }
}
