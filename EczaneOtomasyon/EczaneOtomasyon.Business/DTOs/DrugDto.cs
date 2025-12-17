namespace EczaneOtomasyon.Business.DTOs
{
    public class DrugDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ActiveSubstance { get; set; } = string.Empty;
        public string Form { get; set; } = string.Empty;
        public int? DosageMg { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string DisplayName => $"{Name} ({ActiveSubstance})";
        public string StockStatus => Stock <= 10 ? "Düşük Stok" : Stock == 0 ? "Stokta Yok" : "Normal";
    }
}

