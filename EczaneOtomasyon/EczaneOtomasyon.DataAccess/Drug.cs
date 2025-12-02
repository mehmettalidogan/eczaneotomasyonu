namespace EczaneOtomasyon.DataAccess
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ActiveSubstance { get; set; } = string.Empty;
        public string Form { get; set; } = string.Empty;
        public int DosageMg { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}

