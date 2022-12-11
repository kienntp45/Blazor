namespace BlazorServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost("add-subject")]
    public IActionResult AddSubject(ViewSub viewSub)
    {
        try
        {
            var rs = _subjectService.Add(viewSub);
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpGet("get-subject-by-id")]
    public IActionResult GetSubjectByID(int id)
    {
        try
        {
            var rs = _subjectService.Get(id);
            return Ok(rs);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet("get-all-subject")]
    public IActionResult GetAll()
    {
        try
        {
            var rs = _subjectService.GetAll();
            return Ok(rs);
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpPut("update-subject")]
    public IActionResult UpdateSubject(Subjects sub)
    {
        try
        {
            var rs = _subjectService.Update(sub);
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());
        }
    }

    [HttpDelete("delete-subject")]
    public IActionResult delete(int id)
    {
        try
        {
            var rs = _subjectService.Delete(id);
            return Ok(rs);
        }
        catch (Exception e)
        {
            return BadRequest(e.ToString());    
        }
    }
}
