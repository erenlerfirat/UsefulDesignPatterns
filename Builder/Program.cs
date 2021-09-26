using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var newCustomerBuilder = new NewCustomerProductBuilder();
            director.GenerateProduct(newCustomerBuilder);
            var model = newCustomerBuilder.GetModel();
            Console.WriteLine("Product Name : {0}  and Product discounted price : {1} Product price{2}", 
                model.ProductName,model.DiscountedPrice,model.UnitPrice);
            //Output =  Product Name : Latte  and Product discounted price : 1,9125 Product price2,25


        }
    }
    class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }
    class OldCustomerProdcutBuilder : ProductBuilder
    {
        public override void ApplyDiscount()
        {
            throw new NotImplementedException();
        }

        public override ProductViewModel GetModel()
        {
            throw new NotImplementedException();
        }

        public override void GetProductData()
        {
            ProductViewModel productView = new ProductViewModel();
            productView.Id = 1;
            productView.ProductName = "Cappuchino";
            productView.UnitPrice = (decimal)2.75;
            productView.CategoryName = "Coffee";
        }
    }
    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel productView = new ProductViewModel();

        public override void ApplyDiscount()
        {
           productView.DiscountedPrice=productView.UnitPrice * (decimal) 0.85;
            productView.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return productView;
        }

        public override void GetProductData()
        {
            productView.Id = 1;
            productView.ProductName = "Latte";
            productView.UnitPrice = (decimal)2.25;
            productView.CategoryName = "Coffee";
        }
    }
    class ProductDirector
    {
        public void GenerateProduct (ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
