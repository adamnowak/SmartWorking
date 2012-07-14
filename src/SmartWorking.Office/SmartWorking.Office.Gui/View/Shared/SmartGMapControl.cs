using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace SmartWorking.Office.Gui.View.Shared
{
  public class SmartGMapControl : GMapControl, INotifyPropertyChanged
  {
    public override void Dispose()
    {
      base.Dispose();
    }
    private ICommand _refreshMapCommand;

    private static GMapProvider _mapProvider;

    public GMapProvider GetMapProvider
    {
      get
      {

        if (MapProvider == null || MapProvider == GMapProviders.EmptyProvider)
        {
          lock (this)
          {
            _mapProvider = GMapProviders.GoogleMap;
          }
        }
        return _mapProvider;
      }
    }

    public SmartGMapControl()
    {
      
      this.Loaded += new RoutedEventHandler(SmartGMapControl_Loaded);


      // map events
      OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);
      OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
      OnTileLoadStart += MainMap_OnTileLoadStart;

      MinZoom = 1;
      MaxZoom = int.MaxValue;
      Zoom = 4;

      //GMapMarker it = new GMapMarker(Position);
      //{
      //  it.ZIndex = 55;
      //  it.Shape = new CustomMarkerRed(this, it, "Welcome to Lithuania! ;}");
      //}
      //Markers.Add(it);
    }


    /// <summary>
    /// The <see cref="RouteDistance" /> property's name.
    /// </summary>
    public const string RouteDistancePropertyName = "RouteDistance";

    private double _routeDistance;

    /// <summary>
    /// Gets the RouteDistance property.
    /// TODO Update documentation:
    /// Changes to that property's value raise the PropertyChanged event. 
    /// This property's value is broadcasted by the Messenger's default instance when it changes.
    /// </summary>
    public double RouteDistance
    {
      get
      {
        return _routeDistance;
      }

      set
      {
        if (_routeDistance == value)
        {
          return;
        }

        _routeDistance = value;

        // Update bindings, no broadcast
        RaisePropertyChanged(RouteDistancePropertyName);
      }
    }

    private void MainMap_OnCurrentPositionChanged(PointLatLng point)
    {
      
    }


    // tile louading starts
    void MainMap_OnTileLoadStart()
    {
      

      
    }

    // tile loading stops
    void MainMap_OnTileLoadComplete(long elapsedMilliseconds)
    {
      
      
    }

    public ICommand RefreshMapCommand
    {
      get
      {
        //if (_refreshMapCommand == null)
        //  _refreshMapCommand = new RelayCommand(RefreshMap);
        return _refreshMapCommand;
      }
    }

    private void RefreshMap()
    {
      //RectLatLng? rectLatLng=GetRectOfAllMarkers(null);
      //if (rectLatLng.HasValue)
      //{
      //  SetZoomToFitRect(rectLatLng.Value);
      //}
      //Zoom = Zoom + 0.1;
      ZoomAndCenterMarkers(null);
      ReloadMap();

    }

    void SmartGMapControl_Loaded(object sender, RoutedEventArgs e)
    {
      RefreshMap();
    }

    /// <summary>
    /// The <see cref="BuildingDescription" /> dependency property's name.
    /// </summary>
    public const string BuildingDescriptionPropertyName = "BuildingDescription";

    /// <summary>
    /// Gets or sets the value of the <see cref="BuildingDescription" />
    /// property. This is a dependency property.
    /// </summary>
    public string  BuildingDescription
    {
      get
      {
        return (string)GetValue(BuildingDescriptionProperty);
      }
      set
      {
        SetValue(BuildingDescriptionProperty, value);
      }
    }

    /// <summary>
    /// Identifies the <see cref="BuildingDescription" /> dependency property.
    /// </summary>
    public static readonly DependencyProperty BuildingDescriptionProperty = DependencyProperty.Register(
        BuildingDescriptionPropertyName,
        typeof(string),
        typeof(SmartGMapControl),
        new PropertyMetadata(string.Empty, OnBuildingDescriptionPropertyChanged));

    

    private static void OnBuildingDescriptionPropertyChanged(DependencyObject source,
      DependencyPropertyChangedEventArgs e)
    {
      SmartGMapControl smartGMapControl = source as SmartGMapControl;
      if (smartGMapControl != null)
      {
        if (smartGMapControl.MapProvider == null || smartGMapControl.MapProvider == GMapProviders.EmptyProvider)
        {
          smartGMapControl.MapProvider = smartGMapControl.GetMapProvider;//.OpenStreetMap;
          smartGMapControl.Manager.Mode = AccessMode.ServerAndCache;
          smartGMapControl.Position = new PointLatLng(51.3458053, 19.3458053);
        }
        if (smartGMapControl.MapProvider != null && smartGMapControl.MapProvider != GMapProviders.EmptyProvider)
        {
            GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;

            PointLatLng? city = GMapProviders.GoogleMap.GetPoint(e.NewValue.ToString(), out status);
            if(city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            {
              RoutingProvider rp = smartGMapControl.MapProvider as RoutingProvider;
              if (rp == null)
              {
                rp = GMapProviders.GoogleMap; // use google if provider does not implement routing
              }

              PointLatLng start = new PointLatLng(51.3458053, 19.3458053);
              PointLatLng end = city.Value;
              MapRoute route = rp.GetRoute(start, end, false, false, (int)smartGMapControl.Zoom);
              if (route != null)
              {
                smartGMapControl.RouteDistance = route.Distance;
                GMapMarker m1 = new GMapMarker(start);
                m1.Shape = new CustomMarkerRed(smartGMapControl, m1, "Start: " + route.Name);
                m1.ZIndex = 10;
                
                GMapMarker m2 = new GMapMarker(end);
                m2.Shape = new CustomMarkerRed(smartGMapControl, m2, "End: " + start.ToString());
                m2.ZIndex = 10;

                GMapMarker mRoute = new GMapMarker(start);
                {
                  mRoute.Route.AddRange(route.Points);
                  mRoute.RegenerateRouteShape(smartGMapControl);

                  mRoute.ZIndex = 10;
                }

                smartGMapControl.Markers.Clear();
                smartGMapControl.Markers.Add(m1);
                smartGMapControl.Markers.Add(m2);
                smartGMapControl.Markers.Add(mRoute);

                //RectLatLng? rectLatLng = smartGMapControl.GetRectOfAllMarkers(null);
                //if (rectLatLng.HasValue)
                //{
                //  smartGMapControl.Position = new PointLatLng(rectLatLng.Value.Lat + rectLatLng.Value.HeightLat / 2,
                //                                              rectLatLng.Value.Lng + rectLatLng.Value.WidthLng / 2);
                //}
                //smartGMapControl.ZoomAndCenterMarkers(null);
                
              }

              //List<PointLatLng> rt = new List<PointLatLng>(); // is a List<PointLatLng>
              //rt.Add(new PointLatLng(51.3458053, 19.3458053));
              //rt.Add(city.Value);
              //MapRoute routes = new MapRoute(rt, "MyRoute");
              
              //if (routes != null)
              //{
              //  //GMapRoute r = new GMapRoute(routes.Points, routes.Name);
              //  //r.Stroke.Color = Color.Red;
              //  //routes.Routes.Add(r);

              //  GMapMarker it1 = new GMapMarker((PointLatLng)routes.From.Value);
              //  it1.Shape = new CustomMarkerRed(smartGMapControl, it1, "from");
              // // m1.ToolTipText = "From";
              //  GMapMarker it2 = new GMapMarker((PointLatLng)routes.To.Value);
              //  it2.Shape = new CustomMarkerRed(smartGMapControl, it2, "to");
              ////  m2.ToolTipText = "To";

              //  smartGMapControl.Markers.Add(it1);
              //  smartGMapControl.Markers.Add(it2);

              //  GMapRoute r = new GMapRoute(route.Points, "test");
              //  smartGMapControl.ZoomAndCenterMarkers(null);
              //}



              //GMapMarker it = new GMapMarker(city.Value);
              //{
              //  it.ZIndex = 55;
              //  it.Shape = new CustomMarkerRed(smartGMapControl, it, "Welcome to Lithuania! ;}");
              //}
              //smartGMapControl.Markers.Add(it);
              //smartGMapControl.ReloadMap();
            }
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void RaisePropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
