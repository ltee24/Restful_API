using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.VM
{
    public class CreateVillaNumberVM
    {
        public CreateVillaNumberVM()
        {
            VillaNumber = new VillaCreateNumberDTO();
        }
        public VillaCreateNumberDTO VillaNumber { get; set; }

        public IEnumerable<SelectListItem> VillaList { get; set; }
    }
}
