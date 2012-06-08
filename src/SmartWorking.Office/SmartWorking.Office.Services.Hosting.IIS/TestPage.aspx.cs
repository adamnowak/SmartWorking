using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartWorking.Office.Entities;
using SmartWorking.Office.Services.Hosting.Local;

namespace SmartWorking.Office.Services.Hosting.IIS
{
  public partial class TestPage : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      CarsService cars = new CarsService();
      List<Car> result = cars.GetCars(string.Empty);
    }
  }
}