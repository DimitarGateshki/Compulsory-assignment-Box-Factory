using api.Filters;
using infrastructure.DataModels;
using infrastructure.TranferModels;
using Microsoft.AspNetCore.Mvc;
using service;


namespace api.Controllers;

[ApiController]
public class BoxController : ControllerBase
{
    private readonly Service _service;

    public BoxController(Service service)
    {
        _service = service;
    }

    
    [HttpGet]
    [ValidateModel]
    [Route("/api/boxes")]
    public ResponseDto GetAllBoxes()
    {

        return new ResponseDto()
        {
            MessageToClient = "Here are all the books!",
            ResponseData = _service.GetAllBoxes(),
        };
        
        
    }

    [HttpGet]
    [ValidateModel]
    [Route("/api/box/{boxId}")]
    public ResponseDto GetBox([FromRoute] int boxId)
    {
        return new ResponseDto()
        {
            MessageToClient = "Here is the wanted box!",
            ResponseData = _service.GetBox(boxId)
        };
    }

    [HttpGet]
    [Route("/api/searchBox")]
    public IEnumerable<SearchBoxItem> Get([FromQuery] BoxSearchRequestDto dto)
    {
        return _service.SearchBoxItems(dto.SearchTerm, dto.PageSize);
    }
    

    [HttpPost]
    [ValidateModel]
    [Route("/api/NewBox")]
    public ResponseDto PostBox([FromBody] CreateBoxRequestDto dto)
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully created a box!",
            ResponseData = _service.CreateBox(dto.BoxName, dto.DateOfCreation, dto.BoxCategory),
        };

    }

    [HttpPut]
    [ValidateModel]
    [Route("/api/UpdateBox/{boxId}")]
    public ResponseDto UpdateBox([FromBody] UpdateBoxRequestDto dto, [FromRoute] int boxId)
    {
        return new ResponseDto
        {
            MessageToClient = "Successfully updated the box: " + dto.BoxName + "!",
            ResponseData = _service.UpdateBox(dto.BoxID, dto.BoxName, dto.DateOfCreation, dto.BoxCategory),
        };
    }

    [HttpDelete]
    [ValidateModel]
    [Route("/api/DeleteBox/{boxId}")] 
    public ResponseDto  DeleteBook([FromRoute] int bookId)
    {
        _service.DeleteBox(bookId);
        return new ResponseDto()
        {
            MessageToClient = "Successfully deleted the box",
        };

    }
}


