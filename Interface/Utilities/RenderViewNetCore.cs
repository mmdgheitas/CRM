using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Interface.Utilities
{
    public interface IRazorViewToStringRenderer
    {
        Task<string> RenderViewToStringAsync(string viewName, object model,dynamic viewbage = null);
        Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model);
    }

    public class RazorViewToStringRenderer : IRazorViewToStringRenderer
    {
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IServiceProvider _serviceProvider;

        public RazorViewToStringRenderer(IRazorViewEngine razorViewEngine,
                                 ITempDataProvider tempDataProvider,
                                 IHttpContextAccessor contextAccessor,
                                 IServiceProvider serviceProvider)
        {
            _viewEngine = razorViewEngine;
            _tempDataProvider = tempDataProvider;
            _contextAccessor = contextAccessor;
            _serviceProvider = serviceProvider;
        }

        public async Task<string> RenderViewToStringAsync(string viewName, object model,dynamic viewBage = null)
        {
            var actionContext = new ActionContext(_contextAccessor.HttpContext, _contextAccessor.HttpContext.GetRouteData(), new ActionDescriptor());

            await using var sw = new StringWriter();
            var viewResult = FindView(actionContext, viewName);

            if (viewResult == null)
            {
                throw new ArgumentNullException($"{viewName} does not match any available view");
            }

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };
            if (viewBage != null) {
                //foreach (var item in viewBage)
                //{
                //    viewDictionary.Add(item.Key, item.Value);
                //}
            }
            var viewContext = new ViewContext(
                actionContext,
                viewResult,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.RenderAsync(viewContext);
            return sw.ToString();
        }

        public async Task<string> RenderPartialToStringAsync<TModel>(string partialName, TModel model)
        {
            var actionContext = GetActionContext();
            var partial = FindView(actionContext, partialName);

            using (var output = new StringWriter())
            {
                var viewContext = new ViewContext(
                    actionContext,
                    partial,
                    new ViewDataDictionary<TModel>(
                        metadataProvider: new EmptyModelMetadataProvider(),
                        modelState: new ModelStateDictionary())
                    {
                        Model = model
                    },
                    new TempDataDictionary(
                        actionContext.HttpContext,
                        _tempDataProvider),
                    output,
                    new HtmlHelperOptions()
                );

                await partial.RenderAsync(viewContext);

                return output.ToString();
            }
        }


        private IView FindView(ActionContext actionContext, string viewName)
        {
            var getViewResult = _viewEngine.GetView(executingFilePath: null, viewPath: viewName, isMainPage: true);
            if (getViewResult.Success)
            {
                return getViewResult.View;
            }

            var findViewResult = _viewEngine.FindView(actionContext, viewName, isMainPage: true);
            if (findViewResult.Success)
            {
                return findViewResult.View;
            }

            var searchedLocations = getViewResult.SearchedLocations.Concat(findViewResult.SearchedLocations);
            var errorMessage = string.Join(
                Environment.NewLine,
                new[] { $"Unable to find view '{viewName}'. The following locations were searched:" }.Concat(searchedLocations));

            throw new InvalidOperationException(errorMessage);
        }
        private ActionContext GetActionContext()
        {
            //var httpContext = new DefaultHttpContext
            //{
            //    RequestServices = _serviceProvider
            //};

            //return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

           return  new ActionContext(_contextAccessor.HttpContext, _contextAccessor.HttpContext.GetRouteData(), new ActionDescriptor());

        }
    }
}
