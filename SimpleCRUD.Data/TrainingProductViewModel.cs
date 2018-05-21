using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRUD.Data
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            Products = new List<TrainingProducts>();
        }

        public List<TrainingProducts> Products { get; set; }

        public void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get();
        }
    }
}
