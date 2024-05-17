using Dynamic_Form_with_CosmosDb.Models;
using Dynamic_Form_with_CosmosDb.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dynamic_Form_with_CosmosDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFillFormController : ControllerBase
    {
        public readonly IEmployeeCreatedFormService _employeeCreatedFormService;
        public readonly IUserFillFormService _userFillFormService;

        public UserFillFormController(IEmployeeCreatedFormService employeeCreatedFormService, IUserFillFormService userFillFormService) {
            _employeeCreatedFormService = employeeCreatedFormService;
            _userFillFormService = userFillFormService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserFormById(string id)
        {
            UserFillForm userFillForm = new UserFillForm();

            var result = await _employeeCreatedFormService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            userFillForm.AddMetadata("id", result.Id);
            userFillForm.AddMetadata("title", result.Title);
            userFillForm.AddMetadata("description", result.Description);
            userFillForm.AddMetadata("firstName", null);
            userFillForm.AddMetadata("lastName", null);
            userFillForm.AddMetadata("email", null);

            if (result.Phone.IsHide == false)
            {
                userFillForm.AddMetadata("phone", null);
            }
            if (result.Nationality.IsHide == false)
            {
                userFillForm.AddMetadata("nationality", null);
            }
            if (result.CurrentResidence.IsHide == false)
            {
                userFillForm.AddMetadata("currentResidence", null);
            }
            if (result.IdNumber.IsHide == false)
            {
                userFillForm.AddMetadata("idNumber", null);
            }
            if (result.DateOfBirth.IsHide == false)
            {
                userFillForm.AddMetadata("dateOfBirth", null);
            }
            if (result.Gender.IsHide == false)
            {
                userFillForm.AddMetadata("gender", null);
            }

            return Ok(userFillForm.GetAllMetadata());
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserFillForm userFillForm)
        {
            userFillForm.Id = Guid.NewGuid().ToString();
            var result = await _userFillFormService.Add(userFillForm);

            return Ok(result);
        }
    }
}
