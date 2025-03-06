using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace AsmC5.Common.Request
{
    [ModelBinder(BinderType = typeof(FoodItemRequestParametersBinder))]
    public class FoodItemRequestParameters : RequestParameters
    {

        public ICollection<string>? Categories { get; set; } = new List<string>();
        public string? PriceRange { get; set; }

    }
    public class PriceRange
    {
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 100000000;
    }
    public class FoodItemRequestParametersBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var request = bindingContext.HttpContext.Request;
            var parameters = new FoodItemRequestParameters();

            // Lấy giá trị từ query string
            if (request.Query.TryGetValue("Categories", out var categories))
            {
                parameters.Categories = categories.ToString().Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
            }

          

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
}
