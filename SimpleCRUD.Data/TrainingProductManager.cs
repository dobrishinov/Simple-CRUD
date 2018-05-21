using System;
using System.Collections.Generic;

namespace SimpleCRUD.Data
{
    public class TrainingProductManager
    {
        public List<TrainingProducts> Get()
        {
            List<TrainingProducts> ret = new List<TrainingProducts>();

            // TODO: Add data access method here
            ret = CreateMockData();

            return ret;
        }

        private List<TrainingProducts> CreateMockData()
        {
            List<TrainingProducts> ret = new List<TrainingProducts>();

            ret.Add(new TrainingProducts()
            {
                ProductId = 1,
                ProductName = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("6/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(32.00)
            });

            ret.Add(new TrainingProducts()
            {
                ProductId = 2,
                ProductName = "Sed ut perspiciatis unde omnis iste",
                IntroductionDate = Convert.ToDateTime("3/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(22.00)
            });

            ret.Add(new TrainingProducts()
            {
                ProductId = 3,
                ProductName = "Consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("3/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(35.00)
            });

            ret.Add(new TrainingProducts()
            {
                ProductId = 4,
                ProductName = "Sit amet, consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("6/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(54.00)
            });

            ret.Add(new TrainingProducts()
            {
                ProductId = 5,
                ProductName = "Dolor sit amet, consectetur adipiscing elit",
                IntroductionDate = Convert.ToDateTime("6/6/2018"),
                Url = "https://google.com",
                Price = Convert.ToDecimal(17.00)
            });

            ret.Add(new TrainingProducts()
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
