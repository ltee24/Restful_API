using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaNumberApi")]
    [ApiController]
    public class VillaNumberApiController:ControllerBase
    {
        protected APIResponse _response;
        private readonly IVillaNumberRepository _dbVillaNumber;
        private readonly IMapper _mapper;

        public VillaNumberApiController(IVillaNumberRepository dbvillaNumber,IMapper mapper)
        {
            _dbVillaNumber = dbvillaNumber;
            _mapper = mapper;
            this._response = new APIResponse();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumberList = await _dbVillaNumber.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumberList);
                _response.StatusCode = HttpStatusCode.OK;

            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        
        }

       

    }
}
