using System.Collections.Generic;
using System.Linq;

namespace EczaneOtomasyon.Business.Validation
{
    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;
        public List<string> Errors { get; set; } = new List<string>();

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public string GetErrorMessage()
        {
            return string.Join("\n", Errors);
        }
    }
}

