using System.ComponentModel.DataAnnotations;

namespace API.Requests.Product
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [StringLength(100, ErrorMessage = RequestValidationErrorCodes.MaxLength)]
        [Display(Name = "NAME")]
        public string? Name { get; init; }

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "UNIT_PRICE")]
        public decimal? UnitPrice { get; init; }

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "STOCK_QUANTITY")]
        public int? StockQuantity { get; init; }
    }
}