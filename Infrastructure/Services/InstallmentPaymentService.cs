using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using System.Text;

namespace Infrastructure.Services
{
    public class InstallmentPaymentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public InstallmentPaymentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Response<double>> GetTotalAmountOfPayment(OrderDto order)
        {     
            try
            {
                var mapped = _mapper.Map<Order>(order);
                switch (order.ProductCategory)
                {
                    case ProductCategory.Smartphone:
                        switch (order.InstallmentRange)
                        {
                            case InstallmentRange.Twelve:
                                mapped.Percent = 3;
                                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
                                break;
                            case InstallmentRange.Eighteen:
                                mapped.Percent = 6;
                                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
                                break;
                            case InstallmentRange.TwentyFour:
                                mapped.Percent = 9;
                                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
                                break;
                            default:
                                mapped.ProductAmount = order.ProductPrice;
                                break;
                        }
                        break;
                
                    case ProductCategory.Computer:
                        switch (order.InstallmentRange)
                        {
                            case InstallmentRange.Eighteen:
                                mapped.Percent = 4;
                                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
                                break;
                            case InstallmentRange.TwentyFour:
                                mapped.Percent = 8;
                                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
                                break;
                            default:
                                mapped.ProductAmount = order.ProductPrice;
                                break;
                        }
                        break;
                    case ProductCategory.TV:
                        switch (order.InstallmentRange)
                        {
                            case InstallmentRange.TwentyFour:
                                mapped.Percent = 5;
                                mapped.ProductAmount = (order.ProductPrice * mapped.Percent) / 100 + order.ProductPrice;
                                break;
                            default:
                                mapped.ProductAmount = order.ProductPrice;
                                break;
                        }
                        break;
                }

                mapped.StartDate = DateTime.UtcNow;

                await _context.Orders.AddAsync(mapped);
                await _context.SaveChangesAsync();
                return new Response<double>(mapped.ProductAmount);

            }
            catch (System.Exception ex)
            {
                return new Response<double>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

//     public string SendSMSMessage(string api ,string username,string phone, string messages)
//     {

//         string result;
//         string apiKey = api;
//         string numbers = phone; // in a comma seperated list
//         string message = messages;
//         string send = username;
//         String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&amp;amp;numbers=" + numbers + "&amp;amp;message=" + message + "&amp;amp;sender=" + send;
//         StreamWriter myWriter = null;

//         HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

//         objRequest.Method = "POST";

//         objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);

//         objRequest.ContentType = "application/x-www-form-urlencoded";

//         try

//         {

//             myWriter = new StreamWriter(objRequest.GetRequestStream());

//             myWriter.Write(url);

//         }

//         catch (Exception ex)

//         {

//             //return e.Message;

//             return $"the error is {ex.Message}";

//         }

//         finally
//         {

//             myWriter.Close();

//         }

//         HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

//         using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))

//         {

//             result = sr.ReadToEnd();

//             // Close and clean up the StreamReader

//             sr.Close();

//         }

//         //return result;

//         return result;
//     }

// }}
