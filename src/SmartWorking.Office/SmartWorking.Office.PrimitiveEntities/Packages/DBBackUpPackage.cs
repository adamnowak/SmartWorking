using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SmartWorking.Office.PrimitiveEntities.Packages
{
  public class DBBackUpPackage
  {
    private ICollection<BuildingPrimitive> _buildingList;
    public ICollection<BuildingPrimitive> BuildingList
    {
      get
      {
        if (_buildingList == null)
        {
          _buildingList = new ObservableCollection<BuildingPrimitive>();
        }
        return _buildingList;
      }
      set { _buildingList = value; }
    }

    private ICollection<CarPrimitive> _carList;
    public ICollection<CarPrimitive> CarList
    {
      get
      {
        if (_carList == null)
        {
          _carList = new ObservableCollection<CarPrimitive>();
        }
        return _carList;
      }
      set { _carList = value; }
    }

    

    private ICollection<ClientBuildingPrimitive> _clientClientBuildingList;
    public ICollection<ClientBuildingPrimitive> ClientBuildingList
    {
      get
      {
        if (_clientClientBuildingList == null)
        {
          _clientClientBuildingList = new ObservableCollection<ClientBuildingPrimitive>();
        }
        return _clientClientBuildingList;
      }
      set { _clientClientBuildingList = value; }
    }

    private ICollection<ClientPrimitive> _clientList;
    public ICollection<ClientPrimitive> ClientList
    {
      get
      {
        if (_clientList == null)
        {
          _clientList = new ObservableCollection<ClientPrimitive>();
        }
        return _clientList;
      }
      set { _clientList = value; }
    }

    private ICollection<ContractorPrimitive> _contractorList;
    public ICollection<ContractorPrimitive> ContractorList
    {
      get
      {
        if (_contractorList == null)
        {
          _contractorList = new ObservableCollection<ContractorPrimitive>();
        }
        return _contractorList;
      }
      set { _contractorList = value; }
    }

    private ICollection<DeliveryNotePrimitive> _deliveryNoteList;
    public ICollection<DeliveryNotePrimitive> DeliveryNoteList
    {
      get
      {
        if (_deliveryNoteList == null)
        {
          _deliveryNoteList = new ObservableCollection<DeliveryNotePrimitive>();
        }
        return _deliveryNoteList;
      }
      set { _deliveryNoteList = value; }
    }

    private ICollection<DriverPrimitive> _driverList;
    public ICollection<DriverPrimitive> DriverList
    {
      get
      {
        if (_driverList == null)
        {
          _driverList = new ObservableCollection<DriverPrimitive>();
        }
        return _driverList;
      }
      set { _driverList = value; }
    }

    private ICollection<MaterialPrimitive> _materialList;
    public ICollection<MaterialPrimitive> MaterialList
    {
      get
      {
        if (_materialList == null)
        {
          _materialList = new ObservableCollection<MaterialPrimitive>();
        }
        return _materialList;
      }
      set { _materialList = value; }
    }

    private ICollection<MaterialStockPrimitive> _materialStockList;
    public ICollection<MaterialStockPrimitive> MaterialStockList
    {
      get
      {
        if (_materialStockList == null)
        {
          _materialStockList = new ObservableCollection<MaterialStockPrimitive>();
        }
        return _materialStockList;
      }
      set { _materialStockList = value; }
    }

    private ICollection<OrderPrimitive> _orderList;
    public ICollection<OrderPrimitive> OrderList
    {
      get
      {
        if (_orderList == null)
        {
          _orderList = new ObservableCollection<OrderPrimitive>();
        }
        return _orderList;
      }
      set { _orderList = value; }
    }

    private ICollection<RecipeComponentPrimitive> _recipeComponentList;
    public ICollection<RecipeComponentPrimitive> RecipeComponentList
    {
      get
      {
        if (_recipeComponentList == null)
        {
          _recipeComponentList = new ObservableCollection<RecipeComponentPrimitive>();
        }
        return _recipeComponentList;
      }
      set { _recipeComponentList = value; }
    }

    private ICollection<RecipePrimitive> _recipeList;
    public ICollection<RecipePrimitive> RecipeList
    {
      get
      {
        if (_recipeList == null)
        {
          _recipeList = new ObservableCollection<RecipePrimitive>();
        }
        return _recipeList;
      }
      set { _recipeList = value; }
    }
  }
}
