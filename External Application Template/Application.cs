using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace BasicPlugInTest
{
    public class Application : IExternalApplication
    {
        Result IExternalApplication.OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        Result IExternalApplication.OnStartup(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public RibbonPanel RibbonPanel(UIControlledApplication a)
        {
            string tab = "Test";
            RibbonPanel ribbonPanel = null;

            try
            {
                a.CreateRibbonPanel(tab);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            try
            {
                a.CreateRibbonPanel(tab, "Whatever");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            List<RibbonPanel> panels = a.GetRibbonPanels(tab);
            foreach (RibbonPanel p in panels.Where(p => p.Name == "Whatever"))
            {
                ribbonPanel = p;
            }

            return ribbonPanel;
        }
    }
}
