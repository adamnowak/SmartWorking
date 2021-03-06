﻿using System.Collections.ObjectModel;

namespace SmartWorking.Office.Gui.ViewModel.Cars
{
  public interface IDescriptionIndexted
  {
    int Id { get; }
    string Description { get; }
  }

  public class CarType : IDescriptionIndexted
  {
    public int Id { get; set; }
    public string Description { get; set; }
  }


  public class CarTypes  
  {
    private CarTypes()
    {
      Items = new ObservableCollection<CarType>();
    }

    private static CarTypes _instance;

    public static CarTypes Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CarTypes();
          _instance.LoadItems();
        }
        return _instance;
      }
    }

    public ObservableCollection<CarType> Items { get; private set; }

    private void LoadItems()
    {
      Items.Add(new CarType { Id = 1, Description = "Betonomieszarka" });
      Items.Add(new CarType { Id = 2, Description = "Pompogruszka" });
      Items.Add(new CarType { Id = 3, Description = "Wywrotka" });
      Items.Add(new CarType { Id = 4, Description = "Inny" });
    }
  }
}