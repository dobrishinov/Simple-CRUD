using System;

namespace SimpleCRUD.Data
{
    public class TrainingProducts
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime IntroductionDate { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
    }
}
