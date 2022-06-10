// <copyright file="LoggerActionFilter.cs" company="Inetum">
// Copyright (c) Inetum. All rights reserved.
// </copyright>

namespace Webzine.WebApplication.Filters
{
    using System.Diagnostics;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// .
    /// </summary>
    public class LoggerActionFilter : ActionFilterAttribute
    {
        /// <inheritdoc/>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.Log("OnActionExecuted", filterContext.RouteData);
        }

        /// <inheritdoc/>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.Log("OnActionExecuting", filterContext.RouteData);
        }

        /// <inheritdoc/>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            this.Log("OnResultExecuted", filterContext.RouteData);
        }

        /// <inheritdoc/>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            this.Log("OnResultExecuting ", filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var areaName = routeData.DataTokens["area"] ?? string.Empty;
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0}- area:{3} controller:{1} action:{2}", methodName, controllerName, actionName, areaName);
            Debug.WriteLine(message);
        }
    }
}