using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using DynamicMVC.DynamicEntityMetadataLibrary.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Strategies.DynamicMethodInvoker
{
    public class EmptyDynamicMethodInvoker : IDynamicMethodInvoker
    {
        public EmptyDynamicMethodInvoker()
        {
            PersistModel = true;
            ReturnSucessfulRedirect = true;
        }

        void IDynamicMethodInvoker.InvokePostSaveOperation(Func<object, object[], object> invokeMethodFunction, dynamic id, FormCollection formCollection, dynamic model,
            ref string returnUrl, IDictionary<string, object> tempData, IDictionary<string, object> viewData)
        {
            throw new NotImplementedException();
        }

        public bool PersistModel { get; set; }
        public bool ReturnSucessfulRedirect { get; set; }

        public string DynamicMethodInvokerName()
        {
            return this.GetType().Name;
        }

        void IDynamicMethodInvoker.InvokeMethodPreSaveOperation(Func<object, object[], object> invokeMethodFunction, dynamic id, FormCollection formCollection, dynamic model, ref string returnUrl, IDictionary<string, object> tempData, IDictionary<string, object> viewData)
        {
            invokeMethodFunction(model, null);
        }

        public void InvokePostSaveOperation(Func<object, object[], object> invokeMethodFunction, dynamic id, NameValueCollection formCollection, dynamic model,ref string returnUrl, IDictionary<string, object> tempData, IDictionary<string, object> viewData)
        {
            
        }
    }
}