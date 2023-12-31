﻿using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
	public class ClubController : Controller
	{

		private readonly ApplicationDbContext _context;

		public ClubController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var clubs = _context.Clubs.ToList();
			return View(clubs);
		}
	}

}
