using System.ComponentModel.DataAnnotations;

namespace Pri.Vue.Store.Api.Core.Models.Results
{
    public class ServiceResultModel<T> where T : class
    {
        public IList<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
