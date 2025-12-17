using System.Drawing.Printing;

namespace EczaneOtomasyon.Business.Interfaces
{
    public interface IReceiptPrinter
    {
        PharmacyInfo? PharmacyInfo { get; set; }
        void PreparePrescriptionReceipt(int prescriptionId);
        void Print();
        PrintDocument GetPrintDocument();
        string GenerateHtmlReceipt();
    }
}


