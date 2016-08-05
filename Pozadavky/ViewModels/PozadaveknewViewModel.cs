using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using Pozadavky.DTO;
using System.Threading.Tasks;
using Pozadavky.Services;

namespace Pozadavky.ViewModels
{
	public class PozadaveknewViewModel : AppViewModel
	{
        public int ItemId
        {
            get { return Convert.ToInt32(Context.Parameters["Id"]); }

        }

        public string Mena { get; set; }
        public List<string> MenaList { get; set; } = new List<string> { "CZK", "EUR", "USD" };

        public void Prepocitat()
        {
            PozadavekData.CelkovaCena = PozadavekData.CenaZaJednotku * PozadavekData.Mnozstvi;
        }

        public PozadavekDTO PozadavekData { get; set; } = new PozadavekDTO();

        public List<DodavateleDTO> Dodavatele { get; set; }

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                PozadavekData.ItemId = ItemId;
                PozadavekData.DatumObjednani = DateTime.Now;
                PozadavekData.TerminDodani = DateTime.Now;

                var service = new DodavateleService();
                Dodavatele = service.GetDodavateleOrderedByName();
            }

            return base.PreRender();
        }

        public void SaveNewPozadavek()
        {
            PozadavkyServices.PozadavekInsert(PozadavekData);

            Context.RedirectToRoute("PozadavkyList", ItemId);

        }

    }
}

