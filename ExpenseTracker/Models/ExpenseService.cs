using ExpenseTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Models
{
    public class ExpenseService : IExpenseService
    {
        public AppDbContext _context { get; set; }
        public ExpenseService(AppDbContext trAppContext)
        {
            _context = trAppContext;

        }


        public List<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public List<Expense> GetByName(string trName)
        {
            var linq = from expenses in _context.Expenses select expenses;
            if (!string.IsNullOrWhiteSpace(trName))
            {
                linq = linq.Where(x => x.Name.ToUpper().Contains(trName.ToUpper()));
            }
            return linq.ToList();
        }

        public Expense Save(Expense trExpense)
        {
            _context.Expenses.Add(trExpense);
            _context.SaveChanges();
            return trExpense;
        }




        public Expense Update(Expense trExpense)
        {
            Expense ExpenseFromDb = _context.Expenses.First(x => x.Id == trExpense.Id);
            _context.Entry(ExpenseFromDb).CurrentValues.SetValues(trExpense);
            _context.SaveChanges();
            return trExpense;
        }

        public void Delete(Expense trExpense)
        {
            _context.Entry(trExpense).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

        }

        public Expense GetById(int Id)
        {
            var Expense = _context.Expenses.Find(Id);
            return Expense;
        }
    }
}
