using System.Net.Http.Headers;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Domain.Wrapper;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class OrderServiceController : ControllerBase
    {
        private readonly InstallmentPaymentService _InstallmentPaymentService;
        public OrderServiceController(InstallmentPaymentService installmentPaymentService)
        {

            _InstallmentPaymentService = installmentPaymentService;

        }
        [HttpPost("GetTotalAmountOfPayment")]
        public async Task<Response<double>> GetTotalAmountOfPayment([FromForm] OrderDto order)
        {

            if (ModelState.IsValid)
            {
                return await _InstallmentPaymentService.GetTotalAmountOfPayment(order);
            }
            else
            {

                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return new Response<double>(System.Net.HttpStatusCode.BadGateway, errors);
            }

        }
        // [HttpPost("SendSMS")]
        // public string SendSMSMessage(string api , string username, string phone,string messages)
        // {
        //     return _InstallmentPaymentService.SendSMSMessage(api,username,phone,messages);
        // }
    }
}
