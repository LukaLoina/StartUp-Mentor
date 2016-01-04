using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using StartUpMentor.Service.Common;
using StartUpMentor.Repository.Common;
using StartUpMentor.Common.Filters;
using StartUpMentor.UI.Models;

using AnswerType = StartUpMentor.Model.Answer;

namespace StartUpMentor.UI.Controllers
{
	[Authorize]
	public class AnswerController : Controller
    {

		static int pageSize = 5;									
		protected IAnswerService AnswerService;
		protected IAnswerRepository AnswerRepository;
		#region constructor
		public AnswerController(IAnswerService service, IAnswerRepository repository)
		{
			AnswerService = service;
			AnswerRepository = repository;
		}
		#endregion

		#region methods
		// GET: Answer
		// Return a list of answers.
		// TODO: Filter answers by user to display only answers that user should see.
		// TODO: Check Generic filter to find out which searchString to use!
		public async Task<ActionResult> Index(Guid? id,uint? page)
        {
			if (id == null) return View();
			int currentpage = (page != null ? (int)page : 1);
			var answerList = await AnswerService.GetRangeAsync((Guid)id, new GenericFilter("", currentpage, pageSize));
			List<IndexAnswerViewModel> answerViewModelList = new List<IndexAnswerViewModel>();
			foreach(var answer in answerList)
			{
				answerViewModelList.Add(AutoMapper.Mapper.Map<IndexAnswerViewModel>(answer));
			}
			return View(answerViewModelList);
        }

		// GET: Answer/Details/5
		// Return information about answer.
		public async Task<ActionResult> Details(Guid? id)
		{
			if (id == null) return View();
			var answer = await AnswerRepository.GetAsync((Guid)id);
			var answerViewModel = AutoMapper.Mapper.Map<DetailsAnswerViewModel>(answer);
			return View(answerViewModel);
		}
																	   
		// GET: Answer/Create
		//Return View with form for creating Answer
		public ActionResult Create()
        {
            return View();
        }

		// POST: Answer/Create
		// Get answer from user and store it in database.
		// TODO: Combine Question object and information about user
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(CreateAnswerViewModel collection)
        {
            try
            {
				var answer = AutoMapper.Mapper.Map<AnswerType>(collection);
				await AnswerService.AddAsync(answer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
													  
        // GET: Answer/Edit/5
		// Return data used to fill form with existing data.
        public async Task<ActionResult> Edit(Guid? id)
        {
			if (id == null) return View();
			var answer = await AnswerRepository.GetAsync((Guid)id);
			var answerViewModel = AutoMapper.Mapper.Map<UpdateAnswerViewModel>(answer);
            return View(answerViewModel);
        }

        // POST: Answer/Edit/5
		// Edit info stored in database.
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Guid id, UpdateAnswerViewModel collection)
        {
            try
            {
				var answer = await AnswerRepository.GetAsync(id);
				var answerViewModel = collection;
				answer = AutoMapper.Mapper.Map(collection, answer);
				await AnswerService.UpdateAsync(answer);
				
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: Answer/Delete/5
		// Display delete Answer page to user.
		public async Task<ActionResult> Delete(Guid? id)
        {
			if (id == null) return View();
			var answerObject = await AnswerRepository.GetAsync((Guid)id);
			var answerViewModel = AutoMapper.Mapper.Map<DeleteAnswerViewModel>(answerObject);
            return View(answerObject);
        }

        // POST: Answer/Delete/5
		// Delete answer from database.
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(Guid id, DeleteAnswerViewModel collection)
        {
            try
            {
				await AnswerService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
		#endregion
	}
}
