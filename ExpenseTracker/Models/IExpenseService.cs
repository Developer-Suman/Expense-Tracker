namespace ExpenseTracker.Models
{
    public interface IExpenseService
    {
        void Delete(Expense trExpense);
        List<Expense> GetAll();
        Expense GetById(int id);
        List<Expense> GetByName(string trName);
        Expense Save(Expense trExpense);
        Expense Update(Expense trExpense);
    }
}