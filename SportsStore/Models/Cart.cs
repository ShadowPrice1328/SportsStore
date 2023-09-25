namespace SportsStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines {get; set;} = new();
        public virtual void AddItem(Product product, int quantity)
        {
            // Looking for the same Product in cart with its ID
            CartLine? line = Lines
                .Where(l => l.Product.ProductId == product.ProductId)
                .FirstOrDefault();
            
            // If none - adds product
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            // Already in cart - increases the number
            else line.Quantity += quantity;
        }
        public virtual void RemoveLine (Product product)
        {
            Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }
        public decimal ComputeTotalValue() =>
            Lines.Sum(l => l.Product.Price * l.Quantity);

        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineId {get; set;}
        public Product Product {get; set;} = new();
        public int Quantity {get; set;}
    }
}