using System.ComponentModel.DataAnnotations;

namespace API.Requests.Product
{
    public record CreateProductRequest(
        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [StringLength(100, ErrorMessage = RequestValidationErrorCodes.MaxLength)]
        [Display(Name = "NAME")]
          string? Name,

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "UNIT_PRICE")]
          decimal? UnitPrice,

        [Required(ErrorMessage = RequestValidationErrorCodes.RequiredField)]
        [Display(Name = "STOCK_QUANTITY")]
          int? StockQuantity);
}