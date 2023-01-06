using Microsoft.AspNetCore.Mvc;

namespace KaizenCaseStudy2.Controllers;

[ApiController]
[Route("[controller]")]
public class CodeController : ControllerBase
{
    private readonly CodeService _codeService;

    public CodeController(CodeService codeService)
    {
        _codeService = codeService;
    }

    [HttpPost]
    [Route("create")]
    public ActionResult<List<string>> CreateCode(int codeAmount)
    {
        var response = new List<string>();

        for (var i = 0; i < codeAmount; i++)
        {
            // Generate a unique code
            response.Add(_codeService.GenerateUniqueCode());
        }

        return response;
    }

    [HttpGet]
    [Route("validate")]
    public ActionResult<string> ValidateCode(string code)
    {
        // Validate the code
        return CodeService.ValidateCode(code) ? "valid" : "invalid";
    }

    [HttpGet]
    [Route("validate/list")]
    public ActionResult<Dictionary<string, string>> ValidateCodes([FromQuery] List<string> codes)
    {
        var response = new Dictionary<string, string>();

        foreach (var code in codes)
        {
            // Validate the code
            response.Add(code, CodeService.ValidateCode(code) ? "valid" : "invalid");
        }

        return response;
    }
}