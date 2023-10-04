using infrastructure.DataModels;
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
    [Route("/api/boxes")]
    public IEnumerable<Box> GetAllBoxes()
    {
        return _service.GetAllBoxes();
    }
    

    [HttpPost]
    [Route("/api/NewBox")]
    public Box PostBox([FromBody]Box box)
    {
        return _service.CreateBox(box.Name, box.DateOfCreation, box.Category);

    }

    [HttpPut]
    [Route("/api/UpdateBox/{boxId}")]
    public Box UpdateBox([FromBody] Box box, [FromRoute] int boxId)
    {
        return _service.UpdateBox(box.Id,box.Name, box.DateOfCreation, box.Category);
    }

    [HttpDelete]
    [Route("/api/DeleteBox/{bookId}")]
    public IActionResult  DeleteBook([FromRoute] int bookId)
    {
        _service.DeleteBox(bookId);
        return NoContent();
    }


}
