using System.ComponentModel.DataAnnotations;

namespace Cannabis.Api.Dtos;

public class CustomerBasketDto
{
    [Required]
    public string Id { get; set; }  

    public List<BasketItemDto> Items { get; set; }
}
