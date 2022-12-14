#nullable disable

namespace BlazorServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StuController : ControllerBase
{
    private readonly IStudentService _stuService;

    public StuController(IStudentService stuService)
    {
        _stuService = stuService;
    }

    [HttpPost("add-student")]
    public IActionResult add([FromBody]ViewStu viewStu)
    {
        try
        {
            var rs = _stuService.Add(viewStu);
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpGet("get-student-by-id")]
    public async Task<List<ViewStudentMark>> Get([FromQuery]int? id)
    {
        try
        {
           var rs =await _stuService.Get(id);
            return rs;
        }
        catch (Exception )
        {
            throw;
        } 
    }

    [HttpGet("get-all")]
    public async Task<List<ViewStudentMark>> GetAll([FromQuery] int page1, [FromQuery] string name)
    {
        try
        {
            var page = new Paging() { Name = name, Page = page1};
            var rs =await _stuService.GetAll(page);
            return rs;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    [HttpGet("find-student-by-id")]
    public async Task<Students> FindStudnetByIdAsync([FromQuery]int? id)
    {
        try
        {
            var rs = await _stuService.FindStudnetByIdAsync(id);
            return rs;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    [HttpPut("sua-student")]
    public IActionResult UpdateStuent([FromBody]Students student)
    {
        try
        {
            var rs = _stuService.Update(student);
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpDelete("delete-student")]
    public IActionResult DeleteStuentByID([FromQuery]int id)
    {
        try
        {
            var rs = _stuService.Delete(id);
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }
}
