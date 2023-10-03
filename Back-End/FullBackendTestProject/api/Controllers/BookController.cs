using infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using service;


namespace api.Controllers;

[ApiController]
public class BookController : ControllerBase
{
    private readonly Service _service;

    public BookController(Service service)
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
    [Route("/api/newBox")]
    public Box PostBox([FromBody]Box box)
    {
        return _service.CreateBox(box.Name, box.DateOfCreation, box.Category);

    }

    [HttpPut]
    [Route("/api/book/{bookId}")]
    public Box UpdateBook([FromBody] Box box, [FromRoute] int bookId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("/api/book/{bookId}")]
    public object DeleteBook([FromRoute] int bookId)
    {
        throw new NotImplementedException();
    }


}
