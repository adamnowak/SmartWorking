
namespace SmartWorking.Office.TabsGui.Shared.ViewModel
{
  public class DescriptionIndexted<T> : IDescriptionIndexted<T>
  {
    public T Id { get; set; }
    public string Description { get; set; }
  }

  public class DescriptionIndexted : DescriptionIndexted<int>, IDescriptionIndexted
  {
  }
}