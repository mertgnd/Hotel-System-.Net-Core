using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _roomService.TGetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(RoomAddDto request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var values = _mapper.Map<Room>(request);
            var result = await _roomService.TAdd(values);

            if(result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_mapper.Map<RoomAddDto>(result));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoom(RoomUpdateDto request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var values = _mapper.Map<Room>(request);
            var result = await _roomService.TUpdate(values);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<RoomUpdateDto>(result));
        }
    }
}
