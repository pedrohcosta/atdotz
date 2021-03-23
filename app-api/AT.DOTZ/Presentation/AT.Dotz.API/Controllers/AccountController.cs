using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using AT.Dotz.API.ViewModels;
using AutoMapper;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AT.Dotz.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : MainController
    {
        private readonly InterfaceAccountApp _InterfaceAccountApp;
        private readonly IMapper _mapper;

        public AccountController(InterfaceAccountApp InterfaceAccountApp, IMapper mapper)
        {
            _InterfaceAccountApp = InterfaceAccountApp;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAccountViewModel oViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var account = _mapper.Map<Account>(oViewModel);
                    await _InterfaceAccountApp.AddAccount(account);
                    AddNotifies(account.Notitycoes);
                    return CustomResponse(account);
                }
                return CustomResponse(ModelState);
            } catch(Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("AccountByID")]
        public async Task<AccountViewModel> AccountByID(Guid Id)
        {
            try
            {
                return _mapper.Map<AccountViewModel>(await _InterfaceAccountApp.AccountById(Id));
            }
            catch (Exception ex)
            {
                return new AccountViewModel();
            }
        }

        [HttpGet("AccountByMail")]
        public async Task<AccountViewModel> AccountByMail(string Mail)
        {
            try
            {
                var o = await _InterfaceAccountApp.AccountByMail(Mail);
                return _mapper.Map<AccountViewModel>(o);
            }
            catch (Exception ex)
            {
                return new AccountViewModel();
            }
        }


        [HttpPost("Payment")]
        public async Task<IActionResult> Payment(PaymentViewModel oViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var payment = _mapper.Map<Payment>(oViewModel);
                    await _InterfaceAccountApp.Payment(payment);
                    AddNotifies(payment.Notitycoes);
                    return CustomResponse(payment);
                }
                return CustomResponse(ModelState);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("ExtractByAccountID")]
        public async Task<IList<AccountExtractViewModel>> ExtractByAccountID(Guid Id)
        {
            try
            {
                return _mapper.Map<List<AccountExtractViewModel>>(await _InterfaceAccountApp.GetExtractAccountId(Id));
            } catch(Exception ex)
            {
                return new List<AccountExtractViewModel>();
            }
        }

        [HttpGet("CardByAccountID")]
        public async Task<IList<AccountCardViewModel>> CardByAccountID(Guid Id)
        {
            try
            {
                return _mapper.Map<List<AccountCardViewModel>>(await _InterfaceAccountApp.GetCardByAccountId(Id));
            } catch (Exception ex)
            {
                return new List<AccountCardViewModel>();
            }
        }
    }
}
