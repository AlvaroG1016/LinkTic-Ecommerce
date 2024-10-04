using AutoMapper;
using LinkTic_Ecommerce.Models.Domain;
using LinkTic_Ecommerce.Models.DTO;
using LinkTic_Ecommerce.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LinkTic_Ecommerce.Services.Implementations
{
    public class ProductoService : IProductoService
    {
        private readonly LinkticEcommerceContext _context;
        private readonly IMapper _mapper;

        public ProductoService(LinkticEcommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductoDTO>> GetAllProductos()
        {
            var listProductos = await _context.Productos.ToListAsync();
            var responseProductosDTO = listProductos.Select(p=>_mapper.Map<ProductoDTO>(p)).ToList();

            return responseProductosDTO;
        }

        public async Task<ProductoDTO> CreateProductoAsync(CrearProductoDTO crearProductoDTO)
        {
            var producto = _mapper.Map<Producto>(crearProductoDTO);
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();

            var responseProducto = _mapper.Map<ProductoDTO>(producto);

            return responseProducto;
        }
    }
}
