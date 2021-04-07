using Capitech.Client.Absence;
using Capitech.Client.Catalogue;
using Capitech.Client.Common;
using Capitech.Client.Employee;
using Capitech.Client.OperationalPlan;
using Capitech.Client.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capitech
{
    public class CapitechClient
    {
        public CapitechClient(CapitechOptions options)
        {
            Options = options;
            var handler = new CapitechApiRequestHandler(options);
            Absence = new AbsenceClient(handler);
            Catalogue = new CatalogueClient(handler);
            Employee = new EmployeeClient(handler);
            OperationalPlan = new OperationalPlanClient(handler);
            Time = new TimeClient(handler);
        }

        protected CapitechOptions Options { get; }

        public AbsenceClient Absence { get; }

        public CatalogueClient Catalogue { get; }

        public EmployeeClient Employee { get; set; }

        public OperationalPlanClient OperationalPlan { get; set; }

        public TimeClient Time { get; set; }
    }
}
