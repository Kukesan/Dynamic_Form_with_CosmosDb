﻿using Dynamic_Form_with_CosmosDb.Models;
using Dynamic_Form_with_CosmosDb.Service;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Dynamic_Form_with_CosmosDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCreatedFormController : ControllerBase
    {
        public readonly IEmployeeCreatedFormService _employeeCreatedFormService;

        public EmployeeCreatedFormController(IEmployeeCreatedFormService employeeCreatedFormService)
        {
            _employeeCreatedFormService = employeeCreatedFormService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlQuery = "SELECT * FROM c";
            var result = await _employeeCreatedFormService.Get(sqlQuery);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _employeeCreatedFormService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeCreatedForm employeeCreatedForm)
        {
            employeeCreatedForm.Id = Guid.NewGuid().ToString();
            var result = await _employeeCreatedFormService.Add(employeeCreatedForm);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeCreatedForm employeeCreatedForm)
        {
            var result = await _employeeCreatedFormService.Update(employeeCreatedForm);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, string partition)
        {
            await _employeeCreatedFormService.Delete(id, partition);
            return Ok();
        }
    }
}
