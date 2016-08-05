using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using DotVVM.Framework.ViewModel;
using Pozadavky.DTO;
using Pozadavky.Services;

namespace Pozadavky.ViewModels
{
	public class PozadavekViewModel : AppViewModel
	{
	    public PozadavekDTO PozadavekData { get; set; }

        public List<DodavateleDTO> Dodavatele { get; set; }

        public int SelectedDodavatelId { get; set; }

	    public int ParrentItemId { get; set; }

	    public int ItemId { get; set; }

        public string Mena { get; set; }
        public List<string> MenaList { get; set; } = new List<string> { "CZK", "EUR", "USD" };

        public int? PozadavekId
        {
            get { return Convert.ToInt32(Context.Parameters["Id"]); }

        }

        public void Prepocitat()
        {
            PozadavekData.CelkovaCena = PozadavekData.CenaZaJednotku * PozadavekData.Mnozstvi;
        }


        public override Task PreRender()
	    {
	        if (!Context.IsPostBack)
	        {
                PozadavekData = PozadavkyServices.GetPozadavekById(PozadavekId.Value);

                ParrentItemId = PozadavekData.ItemId;

                var service = new DodavateleService();
                Dodavatele = service.GetDodavateleOrderedByName();
            }

            return base.PreRender();
	    }

	    public void Save()
	    {
            PozadavkyServices.SavePozadavek(PozadavekData);
	        
            Context.RedirectToRoute("PozadavkyList", new { Id = ParrentItemId });

        }





    }
}

