// <copyright file="ValidateModelStateAttribute.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Filters
{
    using System;
    using System.Web.Mvc;

    /// <inheritdoc/>
    public class ValidateModelStateAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ValidateModelStateAttribute"/>.
        /// </summary>
        public ValidateModelStateAttribute()
        {
        }

        /// <inheritdoc/>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        /// <inheritdoc/>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var viewData = context.Controller.ViewData;
            var routeData = context.RouteData;

            var areaName = routeData.DataTokens["area"] ?? string.Empty;
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format($" area:{areaName} controller:{controllerName} action:{actionName}");

            logger.Debug($"Executing Action : {message}");

            if (!viewData.ModelState.IsValid)
            {
                context.Result = new ViewResult
                {
                    ViewData = viewData,
                    TempData = context.Controller.TempData,
                };
            }

            base.OnActionExecuting(context);
        }

        /// <inheritdoc/>
        public void OnException(ExceptionContext context)
        {
            logger.Debug($"Exception levée : {context.Exception.Message}");
            logger.Debug($"Exception levée : {context.Exception}");
            NLog.LogManager.Shutdown();
        }
    }
}