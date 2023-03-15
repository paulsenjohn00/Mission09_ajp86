using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static ShopAroundTheCorner.Models.ShoppingCart;

namespace ShopAroundTheCorner.Models
{
	public class Purchase
	{
		[Key]
		[BindNever]
		public int purchaseId { get; set; }

		[BindNever]
		public ICollection<ShoppingCartLineItem> Lines { get; set; }

		[Required(ErrorMessage = "Please enter a name")]
		public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the shipping address")]
		public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a zipcode")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
    }
}

