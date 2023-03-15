using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _IExpenseService;
        public ExpenseController(IExpenseService trAppDbContext)
        {
            _IExpenseService = trAppDbContext;
        }
        public IActionResult Index()
        {
            List<Expense> trResult = _IExpenseService.GetAll();
            return View(trResult);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Expense trExpense)
        {
            return View(_IExpenseService.Save(trExpense));
        }


      
        public IActionResult Update(int Id)
        {
            var E = _IExpenseService.GetById(Id);
            return View(E);
        }

        [HttpPost]
        public IActionResult Update(Expense trExpense)
        {
            return View(_IExpenseService.Update(trExpense));

        }

        public IActionResult Delete(int Id)
        {
            var E = _IExpenseService.GetById(Id);
            return View(E);
        }



        [HttpPost]
        public IActionResult Delete(Expense trExpense)
        {
            _IExpenseService.Delete(trExpense);
            return RedirectToAction("Index");
            
        }
    }
}
