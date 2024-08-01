﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Transversal.Common;

namespace Saul.Test.Services.WebAPI.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountsApplication _discountsApplication;
        private readonly ILoggerManager _logger;

        public DiscountsController(IDiscountsApplication discountsApplication, ILoggerManager logger)
        {
            _discountsApplication = discountsApplication;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _discountsApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _discountsApplication.Get(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] DiscountDto discountDto)
        {
            if (discountDto == null)
                return BadRequest();

            var response = await _discountsApplication.Insert(discountDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DiscountDto discountDto)
        {
            var discountDtoExists = await _discountsApplication.Get(id);
            if (discountDtoExists.Data is null)
                return NotFound(discountDtoExists);

            if (discountDto is null)
                return BadRequest();

            var response = await _discountsApplication.Update(discountDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var response = await _discountsApplication.Delete(int.Parse(id));
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }


    }
}