using AsmC5.Common.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace AsmC5.Common.Request
{
    [ModelBinder(BinderType = typeof(ComboRequestParametersBinder))]
    public class ComboRequestParameters : RequestParameters
    {
      
        public string? PriceRange { get; set; }
    }

}
public class PriceRange
{
    public int Min { get; set; } = 0;
    public int Max { get; set; } = 100000000;
}
public class ComboRequestParametersBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var request = bindingContext.HttpContext.Request;
        var parameters = new ComboRequestParameters();

        // Lấy giá trị từ query string
      



        // Xử lý PriceRange (min-max)
        if (request.Query.TryGetValue("PriceRange", out var priceRangeString))
        {
            var rangeParts = priceRangeString.ToString().Split('-');
            if (rangeParts.Length == 2 && int.TryParse(rangeParts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int min) && int.TryParse(rangeParts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int max))
            {
                parameters.PriceRange = $"{min}-{max}";
            }
        }

        bindingContext.Result = ModelBindingResult.Success(parameters);
        return Task.CompletedTask;
    }
}
