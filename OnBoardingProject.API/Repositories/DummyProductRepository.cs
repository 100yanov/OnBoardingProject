using OnBoardingProject.API.Infrastructure.Exceptions;
using OnBoardingProject.Common.Models;
using System.Text.Json;

namespace OnBoardingProject.API.Repositories
{
    public class DummyProductRepository : IRepository<ProductModel>
    {
        private List<ProductModel> products;
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Products.json");

        public DummyProductRepository(IConfiguration Configuration)
        {
            this.products = ReadFromFile();
        }

        public Guid Add(ProductModel entity)
        {
            var Id = Guid.NewGuid();
            entity.Id = Id;
            products.Add(entity);
            return Id;
        }

        public void Delete(Guid id)
        {
            var peoduct = GetById(id);
            products.Remove(peoduct);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return products.AsEnumerable();
        }

        public ProductModel GetById(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            return product is not null ? product : throw new NotFoundException();
        }

        public void Update(ProductModel entity)
        {
            var product = GetById(entity.Id) ?? throw new NotFoundException();

            product.Title = entity.Title;
            product.Description = entity.Description;
            product.ImageSource = entity.ImageSource;
            product.Category = entity.Category;
        }

        public void SaveChanges()
        {
            this.WriteToFile(products);
        }

        private List<ProductModel> ReadFromFile()
        {
            string json = File.ReadAllText(filePath);

            var products = JsonSerializer.Deserialize<IEnumerable<ProductModel>>(json);

            return products.ToList();
        }

        public void WriteToFile(List<ProductModel> products)
        {
            string json = JsonSerializer.Serialize(products);

            File.WriteAllText(filePath, json);
        }
    }
}
