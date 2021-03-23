using Entities.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT.Dotz.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private List<dynamic> _error;

        protected MainController()
        {
            _error = new List<dynamic>();
        }

        protected bool IsValid()
        {
            return !_error.Any();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _error
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) 
            {
                ErroModel(modelState);
            }
            return CustomResponse();
        }

        protected void ErroModel(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _error.Add(new {Message = errorMsg });
            }
        }

        protected void AddNotifies(List<Notifies> notifies)
        {
            foreach (var erro in notifies)
            {
                _error.Add(new {Message=erro.Message });
            }
        }

        protected void AddErro(string erro)
        {
            _error.Add(new { Message = erro });
        }
    }
}
