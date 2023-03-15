namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
