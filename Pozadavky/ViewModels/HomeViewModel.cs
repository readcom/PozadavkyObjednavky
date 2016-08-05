using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using Pozadavky.Data;
using Pozadavky.DTO;
using Pozadavky.Services;

namespace Pozadavky.ViewModels
{
	public class HomeViewModel : AppViewModel
    {

     public GridViewDataSet<ItemsDTO> ItemsListGridView { get; set; } = new GridViewDataSet<ItemsDTO>()
        {
            PageSize = 20,
            SortExpression = nameof(Item.Datum),
            SortDescending = true
        };

        public bool CurrentUserOnly { get; set; } = true;
	    public bool NewItemVisibility { get; set; } = false;
	    public string ItemPopis { get; set; } = "";

        public void DeleteItem(int id)
        {
            ItemsServices.DeleteItem(id);
        }

        public void NewItemEdit()
        {
            NewItemVisibility = true;            
        }

	    public void NewItemAdd()
	    {
	        ItemsDTO item = new ItemsDTO() {CelkovyPopis = ItemPopis};
            ItemsServices.InsertItem(item);
            NewItemVisibility = false;
        }

        public void ChangeCurrentUser(){}

        public override Task PreRender()
        {
            if (CurrentUserOnly)
            {
                ItemsServices.FillGridViewItems(ItemsListGridView, ActiveUser);
               
            }
            else
            {
                ItemsServices.FillGridViewItems(ItemsListGridView);

            }
            return base.PreRender();
        }
    }
}

