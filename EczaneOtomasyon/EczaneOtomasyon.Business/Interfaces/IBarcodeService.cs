using System;
using EczaneOtomasyon.DataAccess;

namespace EczaneOtomasyon.Business.Interfaces
{
    public interface IBarcodeService
    {
        event EventHandler<BarcodeReadEventArgs>? BarcodeRead;
        void ProcessKeyPress(char key);
        Drug? FindDrugByBarcode(string barcode);
        bool ValidateBarcode(string barcode);
        BarcodeFormat GetBarcodeFormat(string barcode);
        bool ValidateEAN13(string barcode);
        void UpdateDrugBarcode(int drugId, string barcode);
        string GenerateBarcode(int drugId);
    }
}


