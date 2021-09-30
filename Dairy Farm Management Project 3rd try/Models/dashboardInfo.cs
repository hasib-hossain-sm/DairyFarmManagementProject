using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dairy_Farm_Management_Project_3rd_try.Models
{
    public class dashboardInfo
    {
        public int numCowsAlive { get; set; }
        public int numDuetobeVaccinated { get; set; }
        public int averageMilkProductionRate { get; set; }
        public int totalMilkToday { get; set; }
        public int totalCows { get; set; }
        public List<dueVaccination> dueTobeVaccinatedlist { get; set; }
    }
}