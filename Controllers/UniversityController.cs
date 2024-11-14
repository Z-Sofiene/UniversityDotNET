using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;
using School.Models.Repositories;

namespace School.Controllers
{
    [Authorize]
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository UniversityRepository;
        private readonly IWebHostEnvironment HostingEnvironment;

        public UniversityController(IUniversityRepository universityRepository, IWebHostEnvironment hostingEnvironment)
        {
            UniversityRepository = universityRepository;
            HostingEnvironment = hostingEnvironment;
        }

        // GET: University
        [AllowAnonymous]
        public ActionResult Index()
        {
            var universities = UniversityRepository.GetAll();
            return View(universities);
        }

        // GET: University/Details/{id}
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var university = UniversityRepository.GetById(id);
            if (university == null)
            {
                return NotFound();
            }

            var studentCount = UniversityRepository.StudentCount(id);
            var studentAgeAverage = UniversityRepository.StudentAgeAverage(id);

            var viewModel = new UniversityDetailsViewModel
            {
                University = university,
                StudentCount = studentCount,
                StudentAgeAverage = studentAgeAverage
            };

            return View(viewModel);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(University university)
        {
            try
            {
                UniversityRepository.Add(university);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }



        public ActionResult Edit(int id)
        {
            var university = UniversityRepository.GetById(id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(University university)
        {

            try
            {
                UniversityRepository.Edit(university);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }


        public ActionResult Delete(int id)
        {
            var university = UniversityRepository.GetById(id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var university = UniversityRepository.GetById(id);
            UniversityRepository.Delete(university);
            return RedirectToAction(nameof(Index));
        }

    }
}
