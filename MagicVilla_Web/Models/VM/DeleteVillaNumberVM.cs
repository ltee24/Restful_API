using MagicVilla_Web.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.VM
{
    public class DeleteVillaNumberVM
    {
        public DeleteVillaNumberVM()
        {
            VillaNumber = new VillaNumberDTO();
        }
        public VillaNumberDTO VillaNumber { get; set; }

        public IEnumerable<SelectListItem> VillaList { get; set; }
    }
}
