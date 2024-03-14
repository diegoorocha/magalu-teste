using AspNetCoreHero.ToastNotification.Abstractions;
using DSR_MAGALU_BUSINESS.Resources;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace DSR_MAGALU_WEB.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        protected void LimparErrosModelStateInvalido(params string[] keys)
        {
            foreach (var key in keys)
                ModelState.Remove(key);
        }
    }
}