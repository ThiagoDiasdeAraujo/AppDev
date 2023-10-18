using Microsoft.AspNetCore.Mvc;
using Opdracht_MusicApp.Models;

namespace Opdracht_MusicApp.Controllers
{
	public class AlbumController : Controller
	{
		private AlbumRepository _albumRepository = new AlbumRepository();
		private List<Album> _albums;

		public IActionResult Index()
		{
			_albums = _albumRepository.GetAll();
			return View(_albums);
		}

		public IActionResult Details(int id)
		{
			_albums = _albumRepository.GetAll();
			Album album = _albums.Single(x => x.Id == id);
			return View(album);
		}
	}
}
