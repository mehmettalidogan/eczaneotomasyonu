using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.Business.Common
{
    /// <summary>
    /// İşlem sonucu için generic olmayan Result sınıfı
    /// </summary>
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public string ErrorMessage { get; protected set; } = string.Empty;
        public List<string> Errors { get; protected set; } = new List<string>();

        protected Result(bool isSuccess, string errorMessage = "", List<string>? errors = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Errors = errors ?? new List<string>();
        }

        /// <summary>
        /// Başarılı sonuç döndürür
        /// </summary>
        public static Result Success()
        {
            return new Result(true);
        }

        /// <summary>
        /// Başarısız sonuç döndürür (tek hata mesajı)
        /// </summary>
        /// <param name="errorMessage">Hata mesajı</param>
        public static Result Failure(string errorMessage)
        {
            return new Result(false, errorMessage);
        }

        /// <summary>
        /// Başarısız sonuç döndürür (çoklu hata mesajları)
        /// </summary>
        /// <param name="errors">Hata listesi</param>
        public static Result Failure(List<string> errors)
        {
            return new Result(false, string.Join("; ", errors), errors);
        }
    }

    /// <summary>
    /// İşlem sonucu için generic Result sınıfı
    /// </summary>
    /// <typeparam name="T">Döndürülecek veri tipi</typeparam>
    public class Result<T> : Result
    {
        public T Data { get; private set; }

        private Result(bool isSuccess, T data, string errorMessage = "", List<string>? errors = null)
            : base(isSuccess, errorMessage, errors)
        {
            Data = data;
        }

        /// <summary>
        /// Başarılı sonuç döndürür (veri ile)
        /// </summary>
        /// <param name="data">Döndürülecek veri</param>
        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data);
        }

        /// <summary>
        /// Başarısız sonuç döndürür (tek hata mesajı)
        /// </summary>
        /// <param name="errorMessage">Hata mesajı</param>
        public new static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, default!, errorMessage);
        }

        /// <summary>
        /// Başarısız sonuç döndürür (çoklu hata mesajları)
        /// </summary>
        /// <param name="errors">Hata listesi</param>
        public new static Result<T> Failure(List<string> errors)
        {
            return new Result<T>(false, default!, string.Join("; ", errors), errors);
        }
    }
}










