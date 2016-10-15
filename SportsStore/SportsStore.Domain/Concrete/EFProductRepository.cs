﻿using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
	public class EFProductRepository : IProductRepository
	{
		private EFDbContext context = new EFDbContext();

		public IQueryable<Product> Products
		{
			get
			{
				return context.Products;
			}
		}

		public void SaveProduct(Product product)
		{
			if (product.ProductID == 0)
			{
				context.Products.Add(product);
			}
			else
			{
				Product dbEntry = context.Products.Find(product.ProductID);
				if (dbEntry != null)
				{
					dbEntry.Name = product.Name;
					dbEntry.Description = product.Description;
					dbEntry.Price = product.Price;
					dbEntry.Category = product.Category;
					dbEntry.ImageData = product.ImageData;
					dbEntry.ImageMimeType = product.ImageMimeType;
				}
			}

			context.SaveChanges();
		}

		public Product DeleteProduct(int productId)
		{
			Product dbEntry = context.Products.Find(productId);
			if (dbEntry != null)
			{
				context.Products.Remove(dbEntry);
				context.SaveChanges();
			}

			return dbEntry;
		}
	}
}
