using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        //// tableau immuable au singleton
        private List<CartLine> _cartLines = new();
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            //Controle de la quantité
            var cartLine = _cartLines.FirstOrDefault(l => l.Product.Id == product.Id);
            if (cartLine != null)
            {
                if(cartLine.Quantity+quantity> product.Stock)
                {
                    return;
                }
                cartLine.Quantity += quantity;
                Debug.WriteLine($"Produit déjà présent : {product.Name}, Quantité : {cartLine.Quantity}");
                return;
            }
            CartLine newCartline = new()
            {
                Product = product,
                Quantity = quantity
            };
            _cartLines.Add(newCartline);

            Debug.WriteLine("___________________________________");
            Debug.WriteLine($"Produit ajouté : {product.Name}, Quantité : {quantity}");
            Debug.WriteLine($"Il y a {_cartLines.Count} éléments dans la liste.");
            Debug.WriteLine("___________________________________");
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            double total = _cartLines.Sum(obj => obj.Product.Price * obj.Quantity);
            return total;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            bool Pondérer = true;
            double totalValeur;
            double totalQuantité;
            if (Pondérer)
            {
                totalValeur = _cartLines.Sum(obj => obj.Product.Price * obj.Quantity);
                totalQuantité = _cartLines.Sum(obj => obj.Quantity);
            }
            else
            { 
            totalValeur = _cartLines.Sum(obj => obj.Product.Price);
            totalQuantité = _cartLines.Count();
        }
                return totalValeur / totalQuantité;
            ;

        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
