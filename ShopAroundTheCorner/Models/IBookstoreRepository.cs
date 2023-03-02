using System;
using System.Linq;

namespace ShopAroundTheCorner.Models
{
	public interface IBookstoreRepository
	{
		IQueryable<Books> Books { get; }
	}
}

