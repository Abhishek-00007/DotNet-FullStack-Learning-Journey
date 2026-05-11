using RazorPagesApp.Models;

namespace RazorPagesApp.Data
{
    public static class ItemStore
    {
        public static List<Item> Items = new()
        {
            new Item { Name = "Laptop" },
            new Item { Name = "Mouse" }
        };
    }
}