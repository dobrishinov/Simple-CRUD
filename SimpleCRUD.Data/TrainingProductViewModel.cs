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
            Init();

            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
        }

        public string EventCommand { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        public bool IsDetailAreaVisible { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        private void Init()
        {
            EventCommand = "List";
            ListMode();
        }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "save":
                    break;

                case "cancel":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    AddMode();
                    break;

                default:
                    break;
            }
        }

        private void ListMode()
        {
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsDetailAreaVisible = false;
        }

        private void AddMode()
        {
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;
            IsDetailAreaVisible = true;
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);
        }
    }
}
