﻿using System;
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
        public Expense Save()
        {
            try
            {
                if (this.Description != Description)
                {
                    db.Expenses.Update(this);
                }
                else
                {
                    db.Expenses.Add(this);
                }
                db.SaveChanges();
                return this;
            }
            catch (Exception ex)
            {
                throw  new Exception(Convert.ToString(ex + MsgApi.API001));
            }
        }

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
    }
}
