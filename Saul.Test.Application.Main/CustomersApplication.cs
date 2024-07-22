﻿using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface;
using Saul.Test.Domain.Entity;
using Saul.Test.Domain.Interface;
using Saul.Test.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saul.Test.Application.Main
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public CustomersApplication(ICustomersDomain customersDomain, IMapper mapper, ILoggerManager logger)
        {
            _customersDomain = customersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Insert(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = await _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Data saved";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //response.IsSuccess = false;
                //response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(CustomersDto customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDto);
                response.Data = await _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Data updated";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.Delete(customerId);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Data Deleted";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<CustomersDto>> Get(string customerId)
        {
            var response = new Response<CustomersDto>();
            try
            {
                var customer = await _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDto>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<CustomersDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CustomersDto>>();
            try
            {
                var customers = await _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful query";
                    _logger.LogInfo("Test LogInfo GetAll - Successful query...");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponsePagination<IEnumerable<CustomersDto>>> GetAllWithPagination(int pageNumber, int pageSize)
        {

            var response = new ResponsePagination<IEnumerable<CustomersDto>>();
            try
            {
                var customers = await _customersDomain.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalCount = await _customersDomain.Count();
                    response.TotalPages = (int)Math.Ceiling(response.TotalCount / (double)pageSize);

                    response.IsSuccess = true;
                    response.Message = "Successful query";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
