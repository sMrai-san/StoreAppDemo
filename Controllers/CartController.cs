using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StoreApp.Data.DatabaseModel;
using StoreApp.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Controllers
{
    public class CartController : Controller
    {
        StoreAppContext ctx = new StoreAppContext();

        /*********************************/
        /*SHOPPING CART*/
        /*********************************/

        public IActionResult Cart()
        {
            List<ShoppingCart> cart = new List<ShoppingCart>();

            if (HttpContext.Session.GetString("cart") != null)
            {
                cart = JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpContext.Session.GetString("cart"));
            }
            if (cart.Count() == 0)
            {
                ViewBag.CartEmptyMsg = "There is no items in your shopping cart";
            }

            return View(cart);
        }


        /*********************************/
        /*ADD TO CART*/
        /*********************************/
        public IActionResult AddToCart(int productId, int? addRemove)
        {
            List<ShoppingCart> shoppingCart = new List<ShoppingCart>();

            //Get the products to list if there is some
            if (HttpContext.Session.GetString("cart") != null)
            {
                var productsInBasket = JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpContext.Session.GetString("cart"));
                if (productsInBasket.Count > 0)
                {
                    foreach (var prod in productsInBasket)
                    { 
                        //if we have the item in cart
                        if (prod.Product.ProductId == productId)
                        {
                            //let's remove it from list...
                            shoppingCart.RemoveAll(prod => prod.Product.ProductId == productId);
                            //If we are passing addRemove value 1 (cart + 1)
                            if (addRemove == 1)
                            {
                                //...and add it to it again with different quantity
                                shoppingCart.Add(new ShoppingCart()
                                {
                                    Product = prod.Product,
                                    Quantity = prod.Quantity + 1
                                });
                            }
                            //If we are not passing addRemove to this 'function' we automatically + 1 to quantity (cart + 1)
                            else if (addRemove == null)
                            {
                                shoppingCart.Add(new ShoppingCart()
                                {
                                    Product = prod.Product,
                                    Quantity = prod.Quantity + 1
                                });
                            }
                            //If we are passing addRemove value 0 (cart - 1)
                            else if (addRemove == 0)
                            {
                                if (prod.Quantity - 1 == 0)
                                {
                                    RemoveFromCart(prod.Product.ProductId, true);
                                }
                                else
                                {
                                    shoppingCart.Add(new ShoppingCart()
                                    {
                                        Product = prod.Product,
                                        Quantity = prod.Quantity - 1
                                    });
                                }
                            }


                        }
                        //if we do not have the item in cart
                        else
                        {
                            //Need to add all the products back in to the List
                            shoppingCart.Add(prod);

                            //If we are about to add a product that already exists to the List
                            Products product = ctx.Products.Find(productId);
                            if (!shoppingCart.Exists(p => p.Product.ProductId == product.ProductId))
                            {
                                shoppingCart.Add(new ShoppingCart()
                                {
                                    Product = product,
                                    Quantity = 1
                                });
                            }
                        }
                    }

                }
                else
                {
                    Products product = ctx.Products.Find(productId);

                    shoppingCart.Add(new ShoppingCart()
                    {
                        Product = product,
                        Quantity = 1
                    });
                }

            }
            //If no Session present
            else
            {
                Products product = ctx.Products.Find(productId);

                shoppingCart.Add(new ShoppingCart()
                {
                    Product = product,
                    Quantity = 1
                });
            }

            //Counting the total sum of cart items
            decimal TotalSum = 0;
            foreach (var i in shoppingCart)
            {
                TotalSum = (TotalSum + i.Product.Price) * i.Quantity;
            }

            HttpContext.Session.SetString("total", TotalSum.ToString());
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(shoppingCart));

            //if we are in a cart...
            if(addRemove == 1)
            {
                return RedirectToAction("Cart","Cart");
            }
            else if (addRemove == 0)
            {
                return RedirectToAction("Cart", "Cart");
            }
            //...if we are somewhere else
            return RedirectToAction("Index", "Home");

        }

        /*********************************/
        /*REMOVE FROM CART*/
        /*********************************/
        public IActionResult RemoveFromCart(int productId, bool? fromCart)
        {
            List<ShoppingCart> shoppingCart = new List<ShoppingCart>();

            //Get the products to list if there is some
            if (HttpContext.Session.GetString("cart") != null)
            {
                var productsInBasket = JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpContext.Session.GetString("cart"));
                foreach (var prod in productsInBasket)
                {
                    if (prod.Product.ProductId == productId)
                    {
                        shoppingCart.Remove(prod);
                    }
                    else
                    {
                        shoppingCart.Add(prod);
                    }
                }
            }

            //Counting the total sum of cart items
            decimal TotalSum = 0;
            foreach (var i in shoppingCart)
            {
                TotalSum = (TotalSum + i.Product.Price) * i.Quantity;
            }

            HttpContext.Session.SetString("total", TotalSum.ToString());
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(shoppingCart));

            if (fromCart == true)
            {
                return RedirectToAction("Cart", "Cart");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
