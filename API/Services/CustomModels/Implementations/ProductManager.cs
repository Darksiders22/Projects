using Data;
using Models;
using Services.Common;
using Services.CustomModels;
using Services.CustomModels.MapperSettings;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

public class ProductManager : BaseManager<ProductModel>
{
    public List<ProductModel> AllProducts
    {
        get
        {
            //var res = MapperConfigurator.Mapper.Map<List<ProductModel>>(this.context.Products.ToList());
            List<ProductModel> list = new List<ProductModel>();
            foreach (var product in context.Products.ToList())
            {
                ProductModel productManager = new ProductModel()
                {
                    Id = product.Id,
                    Name = product.ProductName,
                    Description = product.Description,
                    CurrentQuantity=product.CurrentQuantity
                };
                list.Add(productManager);
            }

            return list;
        }
    }
    public ProductManager() : base(new StoreDbContext())
    {

    }

    public override string Add(ProductModel model)
    {
        try
        {
            using (context)
            {
                Product product = MapperConfigurator.Mapper.Map<Product>(model);
                context.Products.Add(product);
                context.SaveChanges();
                return "";
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public override string Delete(ProductModel model)
    {
        try
        {
            using (context)
            {
                Product product = MapperConfigurator.Mapper.Map<Product>(model);
                context.Products.Remove(product);
                int res = context.SaveChanges();
                if (res == 1)
                {
                    return "";
                }
                return string.Format($"{Messages.DeleteFails} {model.Name}.");
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public object Delete(int id)
    {
        throw new NotImplementedException();
    }

    public override string Update(ProductModel model)
    {
        try
        {
            using (context)
            {
                Product product = MapperConfigurator.Mapper.Map<Product>(model);
                context.Products.Update(product);
                int res = context.SaveChanges();
                if (res == 1)
                {
                    return "";
                }
                return string.Format($"{Messages.UpdateFails} {model.Name}.");
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public override ProductModel Get(int id)
    {
        throw new NotImplementedException();
    }
}
