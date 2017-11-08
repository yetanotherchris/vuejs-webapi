using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace restbasic.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		private static List<Item> _items;

		static ValuesController()
		{
			_items = new List<Item>()
			{
				new Item() { Id = 1, Name = "Kitkat", Price = 0.79},
				new Item() { Id = 2, Name = "Snickers", Price = 1.19},
				new Item() { Id = 3, Name = "Mars x10", Price = 10.19},
				new Item() { Id = 4, Name = "Twix", Price = 4.19}
			};
		}

		// GET api/values
		[HttpGet]
		public IEnumerable<Item> Get()
		{
			return _items;
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public Item Get(int id)
		{
			return _items.FirstOrDefault(x => x.Id == id);
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody]Item value)
		{
			_items.Add(value);
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]Item value)
		{
			var existingItem = _items.FirstOrDefault(x => x.Id == value.Id);
			if (existingItem != null)
				existingItem = value;
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var existingItem = _items.FirstOrDefault(x => x.Id == id);
			if (existingItem != null)
				_items.Remove(existingItem);
		}
	}

	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}