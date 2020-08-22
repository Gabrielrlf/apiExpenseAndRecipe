﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using WebApi.Models;
using System.IO;
using System.Web.Http.Results;
using WebApi.Data;
using System.Web.Http.ModelBinding;
using WebApi.Resource;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/home")]
    public class HomeController : ControllerBase
    {
        [Route("saveExpense")]
        [HttpPost]
        public Expense SaveExpense([FromBody] Expense expense)
        {
            try
            {
                return expense.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("listExpense")]
        [HttpPost]
        public List<Expense> ListExpense()
        {
            try
            {
                return Expense.List();
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

       
        [Route("BalanceExpense")]
        [HttpPost]
        public decimal BalanceExpense()
        {
            try
            {
                var listExpense = Expense.List();
                List<decimal> listExpenseValue = new List<decimal>();
                object totalValue = 0;

                foreach (var list in listExpense)
                {
                    totalValue = list.Value + Convert.ToDecimal(totalValue);
                }

                return Convert.ToDecimal(totalValue);
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("updateExpense/{id}")]
        [HttpPost]
        public Expense updateExpense(int id,[FromBody] Expense expense)
        {
            try
            {
                expense.Id = id;
                return expense.Update(expense);
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("RemoveExpense")]
        [HttpPost]
        public Expense RemoveExpense([FromBody] Expense expense)
        {
            try
            {
                return expense.Remove(expense);
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("RemoveRecipe")]
        [HttpPost]
        public Recipe RemoveRecipe([FromBody] Recipe recipe)
        {
            try
            {
                return recipe.Remove(recipe);
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("saveRecipe")]
        [HttpPost]
        public Recipe SaveRecipe([FromBody] Recipe recipe)
        {
            try
            {
                return recipe.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("updateRecipe/{id}")]
        [HttpPost]
        public Recipe UpdateRecipe(int id,[FromBody] Recipe recipe)
        {
            try
            {
                recipe.Id = id;
                return recipe.Update(recipe);
            }
            catch (Exception ex)
            {
               throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("listRecipe")]
        [HttpPost]
        public List<Recipe> ListRecipe()
        {
            try
            {
                return Recipe.List();
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }

        [Route("BalanceRecipe")]
        [HttpPost]
        public decimal BalanceRecipe()
        {
            try
            {
                var listExpense = Recipe.List();
                List<decimal> listExpenseValue = new List<decimal>();
                object totalValue = 0;

                foreach (var list in listExpense)
                {
                    totalValue = list.Value + Convert.ToDecimal(totalValue);
                }

                return Convert.ToDecimal(totalValue);
            }
            catch (Exception ex)
            {
                throw new Exception(Convert.ToString(ex) + MsgApi.API001);
            }
        }
    }
}
