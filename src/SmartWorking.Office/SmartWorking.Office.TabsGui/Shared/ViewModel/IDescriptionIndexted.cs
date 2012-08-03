namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public interface IDescriptionIndexted<T>
  {
    T Id { get; }
    string Description { get; }
  }

  public interface IDescriptionIndexted : IDescriptionIndexted<int>
  {

  }
}