using System;
using System.Windows.Forms;
using EczaneOtomasyon.Business.Logging;

namespace EczaneOtomasyon.UI.ErrorHandling
{
    public class GlobalExceptionHandler
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void Handle(Exception exception, string context = "")
        {
            var message = string.IsNullOrEmpty(context) 
                ? $"Hata: {exception.Message}" 
                : $"{context} - Hata: {exception.Message}";

            _logger.LogError(message, exception);

            var userMessage = GetUserFriendlyMessage(exception);
            MessageBox.Show(userMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void HandleWithCustomMessage(Exception exception, string userMessage, string context = "")
        {
            _logger.LogError($"{context} - {userMessage}", exception);
            MessageBox.Show(userMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string GetUserFriendlyMessage(Exception exception)
        {
            return exception switch
            {
                UnauthorizedAccessException => "Bu işlemi gerçekleştirmek için yetkiniz yok.",
                System.IO.FileNotFoundException => "Gerekli dosya bulunamadı.",
                InvalidOperationException => "İşlem şu anda gerçekleştirilemiyor.",
                ArgumentException => "Geçersiz parametre.",
                _ => $"Bir hata oluştu: {exception.Message}\n\nDetaylar log dosyasına kaydedildi."
            };
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

