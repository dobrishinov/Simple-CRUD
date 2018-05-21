using System;
using System.Collections.Generic;

namespace SimpleCRUD.Data
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
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
            // TODO: Create DELETE code here

            return true;
        }

        public TrainingProduct Get(int productId)
        {
            List<TrainingProduct> list = new List<TrainingProduct>();
            TrainingProduct ret = new TrainingProduct();

            // TODO: Call your data access method here
            list = CreateMockData();

            ret = list.Find(p => p.ProductId == productId);

            return ret;
        }

        public bool Update(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if (ret)
            {
                // TODO: Create UPDATE code here
            }

            return ret;
        }

        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);

            if (ret)
            {
                // TODO: Create Insert Code here
            }

            return ret;
        }

        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            // TODO: Add data access method here
            ret = CreateMockData();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().
                StartsWith(entity.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }

            return ret;
        }

        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("6/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(32.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 2,
                ProductName = "Sed ut perspiciatis unde omnis iste",
                IntroductionDate = Convert.ToDateTime("3/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(22.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 3,
                ProductName = "Consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("3/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(35.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 4,
                ProductName = "Sit amet, consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("6/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(54.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 5,
                ProductName = "Dolor sit amet, consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("6/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(17.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 6,
                ProductName = "Ipsum dolor sit amet, consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("6/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(12.00)
            });

            return ret;
        }
    }
}
