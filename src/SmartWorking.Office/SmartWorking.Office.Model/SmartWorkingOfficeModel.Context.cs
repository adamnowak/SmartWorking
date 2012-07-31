//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;
using SmartWorking.Office.Entities;

namespace SmartWorking.Office.Entities
{
    public partial class SmartWorkingEntities : ObjectContext
    {
        public const string ConnectionString = "name=SmartWorkingEntities";
        public const string ContainerName = "SmartWorkingEntities";
    
        #region Constructors
    
        public SmartWorkingEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
        }
    
        public SmartWorkingEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
        }
    
        public SmartWorkingEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = false;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Contractor> Contractors
        {
            get { return _contractors  ?? (_contractors = CreateObjectSet<Contractor>("Contractors")); }
        }
        private ObjectSet<Contractor> _contractors;
    
        public ObjectSet<Material> Materials
        {
            get { return _materials  ?? (_materials = CreateObjectSet<Material>("Materials")); }
        }
        private ObjectSet<Material> _materials;
    
        public ObjectSet<MaterialStock> MaterialStocks
        {
            get { return _materialStocks  ?? (_materialStocks = CreateObjectSet<MaterialStock>("MaterialStocks")); }
        }
        private ObjectSet<MaterialStock> _materialStocks;
    
        public ObjectSet<RecipeComponent> RecipeComponents
        {
            get { return _recipeComponents  ?? (_recipeComponents = CreateObjectSet<RecipeComponent>("RecipeComponents")); }
        }
        private ObjectSet<RecipeComponent> _recipeComponents;
    
        public ObjectSet<Recipe> Recipes
        {
            get { return _recipes  ?? (_recipes = CreateObjectSet<Recipe>("Recipes")); }
        }
        private ObjectSet<Recipe> _recipes;
    
        public ObjectSet<Car> Cars
        {
            get { return _cars  ?? (_cars = CreateObjectSet<Car>("Cars")); }
        }
        private ObjectSet<Car> _cars;
    
        public ObjectSet<Driver> Drivers
        {
            get { return _drivers  ?? (_drivers = CreateObjectSet<Driver>("Drivers")); }
        }
        private ObjectSet<Driver> _drivers;
    
        public ObjectSet<Building> Buildings
        {
            get { return _buildings  ?? (_buildings = CreateObjectSet<Building>("Buildings")); }
        }
        private ObjectSet<Building> _buildings;
    
        public ObjectSet<ClientBuilding> ClientBuildings
        {
            get { return _clientBuildings  ?? (_clientBuildings = CreateObjectSet<ClientBuilding>("ClientBuildings")); }
        }
        private ObjectSet<ClientBuilding> _clientBuildings;
    
        public ObjectSet<Client> Clients
        {
            get { return _clients  ?? (_clients = CreateObjectSet<Client>("Clients")); }
        }
        private ObjectSet<Client> _clients;
    
        public ObjectSet<Order> Orders
        {
            get { return _orders  ?? (_orders = CreateObjectSet<Order>("Orders")); }
        }
        private ObjectSet<Order> _orders;
    
        public ObjectSet<DeliveryNote> DeliveryNotes
        {
            get { return _deliveryNotes  ?? (_deliveryNotes = CreateObjectSet<DeliveryNote>("DeliveryNotes")); }
        }
        private ObjectSet<DeliveryNote> _deliveryNotes;

        #endregion
    }
}
