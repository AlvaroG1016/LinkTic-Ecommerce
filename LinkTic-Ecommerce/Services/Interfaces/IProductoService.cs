using LinkTic_Ecommerce.Models.DTO;

namespace LinkTic_Ecommerce.Services.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> GetAllProductos();
        Task<ProductoDTO> CreateProductoAsync(CrearProductoDTO crearProductoDTO);
    }
}
