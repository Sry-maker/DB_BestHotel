﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BackEnd.Models;
using BackEnd;


namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {



        [HttpPost]
        [ApiResponseFilterAttribute]

        public List<Order> Post( string query = "*",out int total)
        {
            DataAccess.CreateConn();
            var OrderList = DataAccess.DisplayOrderInfo(query);
            total= OrderList.Count();
            DataAccess.CloseConn();
            return OrderList;
        }
      
    }
}
