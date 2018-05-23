using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCRUD.Data
{
    public class TrainingProductManager
    {
        private readonly ProductDbContext Db;

        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
            this.Db = new ProductDbContext();
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lower case."));
                }
            }

            return (ValidationErrors.Count == 0);
        }

        public bool Delete(TrainingProduct entity)
        {
            var DbItem = Db.TrainingProduct;
            DbItem.Remove(DbItem.Find(entity.Id));

            Db.SaveChanges();

            return true;
        }

        public TrainingProduct Get(int productId)
        {
            var DbItem = Db.TrainingProduct.Find(productId);

            return DbItem;
        }

        public bool Update(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if (ret)
            {
                var DbItem = Db.TrainingProduct.Find(entity.Id);

                DbItem.Id = entity.Id;
                DbItem.ProductName = entity.ProductName;
                DbItem.IntroductionDate = entity.IntroductionDate;
                DbItem.Url = entity.Url;
                DbItem.Price = entity.Price;

                try
                {
                    Db.SaveChanges();
                }
                catch (Exception)
                {

                    return ret;
                }
            }

            return ret;
        }

        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);

            if (ret)
            {
                Db.TrainingProduct.Add(entity);
                try
                {
                    Db.SaveChanges();
                }
                catch (Exception)
                {

                    return ret;
                }
            }

            return ret;
        }

        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> products = new List<TrainingProduct>();
            var DbItems = Db.TrainingProduct;

            // TODO: Refactor Searching...
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                var search = DbItems.Where(p => p.ProductName.Contains(entity.ProductName));

                foreach (var product in search)
                {
                    products.Add(new TrainingProduct()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        IntroductionDate = product.IntroductionDate,
                        Url = product.Url,
                        Price = product.Price
                    });
                }

                return products;
            }

            foreach (var product in DbItems)
            {
                products.Add(new TrainingProduct()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    IntroductionDate = product.IntroductionDate,
                    Url = product.Url,
                    Price = product.Price
                });
            }

            return products;
        }
    }
}
