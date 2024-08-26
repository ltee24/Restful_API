using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.VM
{
    public class UpdateVillaNumberVM
    {
        public UpdateVillaNumberVM()
        {
            VillaNumber = new VillaUpdateNumberDTO();
        }
        public VillaUpdateNumberDTO VillaNumber { get; set; }

        public IEnumerable<SelectListItem> VillaList { get; set; }
    }
}
