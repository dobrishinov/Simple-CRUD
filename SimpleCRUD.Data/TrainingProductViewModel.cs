using SimpleCRUD.Common;
using System;
using System.Collections.Generic;

namespace SimpleCRUD.Data
{
    public class TrainingProductViewModel : ViewModelBase
    {
        public TrainingProductViewModel() : base()
        {
        }

        public TrainingProduct Entity { get; set; }
        public List<TrainingProduct> Products { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        protected override void Init()
        {
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();

            base.Init();
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
                    Save();
                    if (IsValid)
                    {
                        Get();
                    }
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "cancel":
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                default:
                    break;
            }
        }

        protected override void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;

            base.Save();
        }

        protected override void Add()
        {
            IsValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "https://";
            Entity.Price = 0;

            base.Add();
        }

        protected override void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Entity = mgr.Get(Convert.ToInt32(EventArgument));

            base.Edit();
        }

        protected override void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = new TrainingProduct();
            Entity.ProductId = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();

            base.Delete();
        }

        protected override void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }

        protected override void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();

            Products = mgr.Get(SearchEntity);
        }
    }
}
