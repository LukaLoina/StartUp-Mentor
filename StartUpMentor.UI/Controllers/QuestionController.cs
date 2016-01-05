using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StartUpMentor.Service.Common;
using StartUpMentor.Repository.Common;
using System.Threading.Tasks;
using StartUpMentor.UI.Models;
using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;

namespace StartUpMentor.UI.Controllers
{
	[Authorize]
	public class QuestionController : Controller
    {
		static int pageSize = 5;
		protected IQuestionService QuestionService;
		protected IQuestionRepository QuestionRepository;
		#region constructor
		public QuestionController(IQuestionService service, IQuestionRepository repository)
		{
			QuestionService = service;
			QuestionRepository = repository;
		}
		#endregion
		#region methods
		// GET: Question
		// Get page with list of Questions
		// TODO: Filter questions by user to display only questions that user should see.
		// TODO: Check Generic filter to find out which searchString to use!
		public async Task<ActionResult>Index(Guid? id, uint? page)
        {
			if (id == null) return View();
			int currentpage = (page != null ? (int)page:1);
			var questionList = await QuestionService.GetRangeAsync((Guid)id, new GenericFilter("", currentpage, pageSize));
			List<IndexQuestionViewModel> questionViewModelList = new List<IndexQuestionViewModel>();
			foreach(var question in questionList)
			{
				questionViewModelList.Add(AutoMapper.Mapper.Map<IndexQuestionViewModel>(question));
            }

			return View(questionViewModelList);
        }

        // GET: Question/Details/5
		// Display details about question
        public async Task<ActionResult> Details(Guid? id)
        {
			if (id == null) return View();
			var question = await QuestionRepository.GetAsync((Guid)id);
			var questionViewModel = AutoMapper.Mapper.Map<DetailsQuestionViewModel>(question);
            return View(questionViewModel);
        }

		// GET: Question/Create
		// Return View with form for creating Question.
		public ActionResult Create()
        {
            return View();
		}

		// POST: Question/Create
		// Get question from user and store it in database.
		// TODO: Combine Question object and information about user
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(CreateQuestionViewModel collection)
        {
            try
            {
				var question = AutoMapper.Mapper.Map<IQuestion>(collection);
				await QuestionService.AddAsync(question);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
		// Get Question from database and let user edit it.
        public async Task<ActionResult> Edit(Guid? id)
        {
			if (id == null) return View();
			var question = await QuestionRepository.GetAsync((Guid)id);
			var questionViewModel = AutoMapper.Mapper.Map<UpdateQuestionViewModel>(question);
            return View(questionViewModel);
        }

        // POST: Question/Edit/5
		// Get edited Question from user and store it in database.
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Guid id, UpdateQuestionViewModel collection)
        {
            try
            {
				var question = await QuestionRepository.GetAsync(id);
				question = AutoMapper.Mapper.Map(collection, question);
				await QuestionService.UpdateAsync(question);

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
		// Display delete Question page to user.
        public async Task<ActionResult> Delete(Guid? id)
        {
			if (id == null) return View();
			var question = await QuestionRepository.GetAsync((Guid)id);
			var questionViewModel = AutoMapper.Mapper.Map<DeleteQuestionViewModel>(question);
            return View(questionViewModel);
        }

        // POST: Question/Delete/5
		// Remove Question from database.
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(Guid id, FormCollection collection)
        {
            try
            {
				await QuestionService.DeleteAsync(id);
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
