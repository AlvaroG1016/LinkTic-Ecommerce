using LinkTic_Ecommerce.Models.DTO;

namespace LinkTic_Ecommerce.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoDTO> CreatePedidoAsync(CrearPedidoDTO crearPedidoDTO);
    }
}
