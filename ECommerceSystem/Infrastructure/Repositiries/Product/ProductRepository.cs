using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using System.Threading.Tasks;
using Application.DTO_s;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositiries.Product
{
    public class ProductRepository : GenaricRepository<Domain.Models.Product, int>, IProductRepository

    {
        private readonly productDb Dbcontext;
        public ProductRepository(productDb dbcontext) : base(dbcontext)
        {
            Dbcontext = dbcontext;
        }

    }
}
