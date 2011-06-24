using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Epiworx.WebMvc.Controllers
{
    [Authorize]
    public class ChartController : Controller
    {
        public ActionResult BarChart(string valuesX, string valuesY)
        {
            var theme =
                @"<Chart BorderWidth=""0"">
                    <ChartAreas>
                        <ChartArea Name=""Default"">
                            <AxisY LineColor=""64, 64, 64, 64"">
                                <MajorGrid Interval=""10"" LineColor=""64, 64, 64, 64"" />
                            </AxisY>
                            <AxisX LineColor=""64, 64, 64, 64"">
                                <MajorGrid LineColor=""64, 64, 64, 64"" />
                            </AxisX>
                        </ChartArea> 
                    </ChartAreas>
                  </Chart>";

            var chart = new Chart(width: 300, height: 200, theme: theme)
                   .AddSeries(
                       xValue: valuesX.Split(','),
                       yValues: valuesY.Split(','))
                   .Write();

            return null;
        }
    }
}
