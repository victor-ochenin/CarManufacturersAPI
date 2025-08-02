using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManufacturersAPI.Api
{
    public record StringMessage(string Message);
    public record ManufacturerMessage(int Id, string Name, string? Country);
    public record CarHeaderMessage(string Model, string Uri);
    public record CarMessage(
        int Id,
        string Model,
        int Year,
        decimal Price,
        string? Color,
        ManufacturerMessage manufacturer
    );
    public record CarFormMessage(
        string Model,
        int Year,
        decimal Price,
        string? Color,
        int ManufacturerId
    );
    public record ManufacturerFormMessage(
        string Name,
        string? Country
    );
} 