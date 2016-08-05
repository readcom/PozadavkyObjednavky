using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls;
using System.Threading.Tasks;
using Pozadavky.Data;
using Pozadavky.Services;
using Pozadavky.DTO;

namespace Pozadavky.ViewModels
{
    public class ManagerViewModel : AppViewModel
    {

        public int? ItemId
        {
            get { return Convert.ToInt32(Context.Parameters["Id"]); }
        }

        public string ItemPopis { get; set; } = "";

        public List<PozadavekDTO> SeznamPozadavku { get; set; }

        public PozadavekDTO PozadavekData { get; set; } = new PozadavekDTO();

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public GridViewDataSet<PozadavekDTO> SeznamPozadavkuGV { get; set; } = new GridViewDataSet<PozadavekDTO>()
        {
            PageSize = 10,
            SortExpression = nameof(PozadavekDTO.Datum),
            SortDescending = true
        };

        public bool CurrentUserOnly { get; set; } = true;
        public bool NothingFound { get; set; } = true;
        public bool EditItemName { get; set; } = false;

        public void DeletePozadavek(int id)
        {
            PozadavkyServices.DeletePozadavek(id);
        }

        public void EditPozadavekName()
        {
            EditItemName = true;
        }

        public void NewPozadavek()
        {
           Context.RedirectToRoute("PozadavekNew", ItemId);
        }


        public void EditItemPopis(int id = 0)
        {
            if (id == 0) ItemsServices.EditItemPopis(ItemPopis, ItemId.Value);
            else ItemsServices.EditItemPopis(ItemPopis, id);
            EditItemName = false;
        }

        public void ChangeCurrentUser()
        {
            SeznamPozadavku = CurrentUserOnly ? PozadavkyServices.GetPozadavkyByName(ActiveUser) 
                :PozadavkyServices.GetPozadavkyByName();
        }

        public override Task PreRender()
        {
            if (CurrentUserOnly)
            {
                //PozadavkyServices.FillGridViewPozadavkyByUser(SeznamPozadavkuGV, ActiveUser);
                ItemPopis = ItemsServices.GetItemPopisById(ItemId.Value);
                PozadavkyServices.FillGridViewPozadavkyByUserAndItemId(SeznamPozadavkuGV, ItemId, ActiveUser);                
                //SeznamPozadavku = PozadavkyServices.GetPozadavkyByName(ActiveUser);
            }
            else
            {
                PozadavkyServices.FillGridViewPozadavkyByUser(SeznamPozadavkuGV);
                //PozadavkyServices.FillGridViewPozadavkyByUserAndItemId(SeznamPozadavkuGV, ItemId);
                //SeznamPozadavku = PozadavkyServices.GetPozadavkyByName();
            }

            NothingFound = SeznamPozadavkuGV.TotalItemsCount == 0;

            return base.PreRender();
        }

    }


}




    


