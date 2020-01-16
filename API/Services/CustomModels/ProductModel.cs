namespace Services.CustomModels
{
    using Models.Interfaces;

    public class ProductModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        

        public int CurrentQuantity { get; set; }
    }
}