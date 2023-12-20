using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OrionPos.Core.ResponseObjects;

namespace OrionPos.UI.Helpers.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult ReturnView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.ValidationError)
            {
                controller.ModelState.Clear();
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return controller.View(response.Data);
        }

        public static IActionResult ReturnView<T>(this Controller controller, IResponse<T> response, INotyfService notifyService)
        {
            controller.ModelState.Clear();
            if (response.ResponseType == ResponseType.Success)
                notifyService.Success(response.Message);
            else
                notifyService.Error(response.Message);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    notifyService.Warning(error.ErrorMessage);
                }
            }
            return controller.View(response.Data);
        }



        public static IActionResult RedirectToAction<T>(this Controller controller, IResponse<T> response, INotyfService notifyService, string actionName, string controllerName = "", string areaName = "")
        {
            controller.ModelState.Clear();
            if (response.ResponseType == ResponseType.Success && !string.IsNullOrEmpty(response.Message))
            {
                notifyService.Success(response.Message);
            }
            else
                if (!string.IsNullOrEmpty(response.Message))
                notifyService.Error(response.Message);

            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    notifyService.Warning(error.ErrorMessage);
                }
            }
            return controller.RedirectToAction(actionName, controllerName, new { Area = areaName });

        }
    
    
        public static IActionResult ReturnJson<T>(this Controller controller, IResponse<T> response, INotyfService notifyService)
        {
            controller.ModelState.Clear();
            if (response.ResponseType == ResponseType.Success)
                notifyService.Success(response.Message);
            else
                notifyService.Error(response.Message);
            return controller.Json(response);
        }

    }
}
