using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using Pozadavky.Data;
using Pozadavky.Services;
using DotVVM.Framework.Hosting;

namespace Pozadavky.ViewModels
{

    public class AppViewModel : DotvvmViewModelBase
	{

        public string ActiveUser { get; set; } = UserServices.GetActiveUser();
                      
        public void Temp() { }

        //public ItemInfoData EditedItem { get; set; } = new ItemInfoData();

        public string DemandAlertText { get; set; }

        public virtual string ActivePage => Context.Route.RouteName;

        //public void ShowDemandPopup(int? demandId)
        //{
        //    if (demandId == null)
        //    {
        //        EditedItem = new ItemInfoData() { }; //UserRole = UserRole.User };
        //    }
        //    else
        //    {
        //       // EditedItem = UserService.GetUserInfo(demandId.Value);
        //    }
        //    Context.ResourceManager.AddStartupScript("$('#myModal').modal();"); 
        //    //Context.ResourceManager.AddStartupScript("$('div[data-id=user-detail]').modal('show');");
        //}

        public void SaveDemand()
        {
            try
            {
                //UserService.CreateOrUpdateUserInfo(EditedItem);
                Context.ResourceManager.AddStartupScript("$('div[data-id=user-detail]').modal('hide');");
            }
            catch (Exception ex)
            {
                DemandAlertText = ex.Message;
            }
        }

        public string Text { get; set; }

        public void Redirect()
        {
            Context.RedirectToRoute("PozadavkyList");

            //try
            //{
            //    Context.RedirectToRoute("PozadavkyList");
            //}
            //catch (DotvvmInterruptRequestExecutionException e)
            //{

            //    throw;
            //}

        }

    }
}




//// vytvoření nového produktu
//var product = new Product();
//product.Title = "Můj nový produkt";
//product.Price = 1699;
//entities.AddToProducts(product);
//entities.SaveChanges();
 
//// úprava existujícího
//var product = entities.Products.Single(p => p.ProductID == 1); // vytáhnout si libovolným způsobem produkt nebo více produktů z databáze
//product.Title = "Jiný název";
//entities.SaveChanges();
 
//// smazání
//var product = entities.Products.Single(p => p.ProductID == 1); // vytáhnout si libovolným způsobem produkt nebo více produktů z databáze
//entities.DeleteObject(product);
//entities.SaveChanges();

    	
//.Where(p => p.CreatedDate<DateTime.Now).OrderBy(p => p.PayedDate)