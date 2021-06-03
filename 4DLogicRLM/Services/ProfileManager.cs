using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace _4DLogicRLM.Services
{
    
    public class ProfileManager 
    {
        private readonly HttpRequest _httpRequest;

        public ProfileManager(HttpRequest httpRequest)
        {
            _httpRequest = httpRequest;
        }
        //private readonly IActionDescriptorCollectionProvider _actionDescriptionColletionProvider;
        //private readonly IHtmlHelper _htmlHelper;
        //public ProfileManager(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IHtmlHelper htmlHelper)
        //{
        //    _actionDescriptionColletionProvider = actionDescriptorCollectionProvider;
        //    _htmlHelper = htmlHelper;
        //}
        
        public string ControllerName()
        {
            var httpRequestFeature = _httpRequest.HttpContext.Features.Get<IHttpRequestFeature>();
            return httpRequestFeature.RawTarget;
        }
        
    }
    
}
