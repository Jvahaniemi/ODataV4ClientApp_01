using System;

namespace ODataV4ClientApp
{
    class Program
    {
        // Get an entire entity set.
        static void ListAllProducts(Default.Container container)
        {
            foreach (var p in container.Products)
            {
                Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
            }
        }

        static void AddProduct(Default.Container container, ODataV4Endpoint.Models.Product product)
        {
            container.AddToProducts(product);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }

        static void DeleteAllProducts(Default.Container container)
        {
            foreach (var p in container.Products)
            {
                container.DeleteObject(p);
                var serviceResponse = container.SaveChanges();
                foreach (var operationResponse in serviceResponse)
                {
                    Console.WriteLine("Response: {0}", operationResponse.StatusCode);
                }
            }
            
        }

        static void Main(string[] args)
        {
            // TODO: Replace with your local URI.
            string serviceUri = "http://localhost:63584/";
            var container = new Default.Container(new Uri(serviceUri));

            var product1 = new ODataV4Endpoint.Models.Product()
            {
                Name = "Yo-yo",
                Category = "Toys",
                Price = 4.95M
            };

            var product2 = new ODataV4Endpoint.Models.Product()
            {
                Name = "Leather belt",
                Category = "Belts",
                Price = 7.55M
            };

            var product3 = new ODataV4Endpoint.Models.Product()
            {
                Name = "Car",
                Category = "Toys",
                Price = 10.05M
            };

            AddProduct(container, product1);
            AddProduct(container, product2);
            AddProduct(container, product3);
            ListAllProducts(container);
            
            DeleteAllProducts(container);
            
        }
    }
}
