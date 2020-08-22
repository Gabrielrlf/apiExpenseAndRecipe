using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Resource;


namespace WebApi.Models
{
    [Table("Expense")]

    public class Expense
    {
        [Key]
        public int Id { get; set; }
     
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public string Description { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public decimal Value { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]

        public bool PaidOut { get; set; }

        public Expense() { }
        private static DataContext db = new DataContext();
     
        public static List<Expense> List()
        {
            try
            {
                return db.Expenses.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Expense Save()
        {
            try
            {
                db.Expenses.Add(this);
                db.SaveChanges();
                return this;
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex + MsgApi.API001));
            }
        }

        public Expense Update(Expense expense)
        {
            try
            {
                var context = db.Expenses.Find(this.Id);
                if (context != null)
                {
                    context.Description = expense.Description;
                    context.Date = expense.Date;
                    context.PaidOut = expense.PaidOut;
                    context.Value = expense.Value;
                }
                else
                {
                    throw new Exception(MsgApi.API001);
                }

                db.SaveChanges();
                return this;
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex + MsgApi.API001));
            }
        }

        public Expense Remove(Expense expense)
        {
            var context = db.Expenses.Find(expense.Id);
            if (context != null)
            {
                db.Remove(context);
            }
            else
                throw new Exception(MsgApi.API001);

            db.SaveChanges();
            return this;
        }
    }
}
