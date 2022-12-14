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
    public IActionResult add(ViewStu viewStu)
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
    public IActionResult Get(int? id)
    {
        try
        {
           var rs = _stuService.Get(id);
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        } 
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        try
        {
            var rs = _stuService.GetAll();
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpPut("sua-student")]
    public IActionResult UpdateStuent(Students student)
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
    public IActionResult DeleteStuentByID(int id)
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
