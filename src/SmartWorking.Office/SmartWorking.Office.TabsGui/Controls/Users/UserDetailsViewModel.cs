using System;
using System.Security.Cryptography;
using System.Text;
using SmartWorking.Office.PrimitiveEntities;
using SmartWorking.Office.PrimitiveEntities.Packages;
using SmartWorking.Office.Services.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel;
using SmartWorking.Office.TabsGui.Shared.ViewModel.Interfaces;
using SmartWorking.Office.TabsGui.Shared.ViewModel.ModalDialogs;

namespace SmartWorking.Office.TabsGui.Controls.Users
{
  /// <summary>
  /// Car details view model implementation.
  /// </summary>
  public class UserDetailsViewModel : EditableControlViewModelBase<UserAndRolesPackage>
  {
    public UserDetailsViewModel(IMainViewModel mainViewModel, IModalDialogProvider modalDialogProvider, IServiceFactory serviceFactory)
      : base(mainViewModel, modalDialogProvider, serviceFactory)
    {
      UserInRolesListViewModel = new RoleListViewModel(MainViewModel, null, ModalDialogProvider, ServiceFactory);
    }

    public RoleListViewModel UserInRolesListViewModel { get; private set; }

    protected override void OnItemChanged(UserAndRolesPackage oldItem)
    {
      base.OnItemChanged(oldItem);
      if (Item != null)
      {
        UserInRolesListViewModel.Items.LoadItems(Item.Roles);
      }
      else
      {
        UserInRolesListViewModel.Items.LoadItems(null);
      }
    }

    /// <summary>
    /// Gets the name of editing control.
    /// </summary>
    public override string Name
    {
      get { return "UserDetails"; }
    }

    protected override void EditItemCommandExecute()
    {
      Item = Item.GetPackageCopy();
      base.EditItemCommandExecute();
    }

    protected override bool OnSavingItem()
    {
      if (base.OnSavingItem())
      {
        if (Item.PasswordConfirm != Item.User.Password)
        {
          Item.PasswordConfirm = string.Empty;
          Item.User.Password = string.Empty;
          throw new Exception("Hasła muszą być identyczne!");
        }
        using (IUsersService service = ServiceFactory.GetUsersService())
        {
          service.CreateOrUpdateUserAndRolesPackage(Item);
        }
        return true;
      }
      return false;
    }


    private string GetMD5HashData(string data)
    {
      //create new instance of md5
      MD5 md5 = MD5.Create();

      //convert the input text to array of bytes
      byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

      //create new instance of StringBuilder to save hashed data
      StringBuilder returnValue = new StringBuilder();

      //loop for each byte and add it to StringBuilder
      for (int i = 0; i < hashData.Length; i++)
      {
        returnValue.Append(hashData[i].ToString());
      }

      // return hexadecimal string
      return returnValue.ToString();

    }



    /// <summary>
    /// Called when [item changed].
    /// </summary>
    /// <param name="oldItem">The old item.</param>
    //protected override void OnItemChanged(CarAndDriverPackage oldItem)
    //{
    //  if (Contractors.Items != null && Item != null && Item.Deliverer != null)
    //  {
    //    Contractors.SelectedItem = Contractors.Items.Where(x => x.Id == Item.Driver.Id).FirstOrDefault();
    //    Item.Deliverer = Contractors.SelectedItem;
    //  }
    //  else
    //  {
    //    Contractors.SelectedItem = null;
    //  }

    //}
  }
}