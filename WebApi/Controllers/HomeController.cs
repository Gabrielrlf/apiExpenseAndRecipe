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
                throw ex;

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
                throw ex;
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
                throw ex;
            }
        }
        [Route("updateExpense")]
        [HttpPost]
        public Expense updateExpense([FromBody] Expense expense)
        {
            try
            {
                return expense.Save();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
