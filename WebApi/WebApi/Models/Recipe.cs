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
    [Table("Recipe")]
    public class Recipe
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

        public bool PaidIn { get; set; }

        public Recipe() { }
        private static DataContext db = new DataContext();

        public static List<Recipe> List()
        {
            try
            {
                return db.Recipes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex + MsgApi.API001));
            }
        }
        public Recipe Save()
        {
            try
            {
                db.Recipes.Add(this);
                db.SaveChanges();
                return this;
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex + MsgApi.API001));
            }
        }
        public Recipe Update(Recipe recipe)
        {
            try
            {
                var context = db.Recipes.Find(this.Id);
                if (context != null)
                {
                    context.Description = recipe.Description;
                    context.Date = recipe.Date;
                    context.PaidIn = recipe.PaidIn;
                    context.Value = recipe.Value;
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
        public Recipe Remove(Recipe recipe)
        {
            var context = db.Recipes.Find(recipe.Id);
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
