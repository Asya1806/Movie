//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
//using Kanema.Models;
//using System.Text.Json;


//namespace Kanema.Models.Cart
//{
//    public class CartModelBinder : IModelBinder
//    {
//        private const string sessionKey = "Cart";

//        //public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
//        //{
//        //    throw new NotImplementedException();
//        //}
//        private IHttpContextAccessor _httpContextAccessor;


//        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
//        {
//            Cart cart = null;
//            // Получить объект Cart из сеанса
//            if (controllerContext.HttpContext.Session != null)
//            {
//                cart = (Cart)controllerContext.HttpContext.Session.Get<Cart>(sessionKey) ?? new Cart();//.GetString(sessionKey);
//            }

//            // Создать объект Cart если он не обнаружен в сеансе
//            if (cart == null)
//            {
//                cart = new Cart();
//                if (controllerContext.HttpContext.Session != null)
//                {
//                    controllerContext.HttpContext.Session.GetString(sessionKey) = cart;
//                }
//            }

//            // Возвратить объект Cart
//            return cart;

//        }

//        public Task BindModelAsync(ModelBindingContext bindingContext)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
