using ASAPSystemsAssignment.BL.DTOs;
using ASAPSystemsAssignment.BL.Iservice;
using ASAPSystemsAssignment.DAL.Model;
using ASAPSystemsAssignment.DAL.UOW;
using AutoMapper;

namespace ASAPSystemsAssignment.BL.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddProduct(ProductAddDto model)
        {
            var obj=_mapper.Map<Product>(model);
            await _unitOfWork.Products.Add(obj);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditProduct(ProductDto model)
        {
            var obj = _mapper.Map<Product>(model);
            await _unitOfWork.Products.Edit(obj);
            await _unitOfWork.SaveAsync();
        }

        public Task<List<Product>> GetAllProducts()
        {
            return _unitOfWork.Products.GetAll();
        }

        public Task<Product> GetProductById(int id)
        {
            return _unitOfWork.Products.Get(id);
        }

        public async Task RemoveProduct(int id)
        {
            var model=await _unitOfWork.Products.Get(id); 
            await _unitOfWork.Products.Remove(model);
            await _unitOfWork.SaveAsync();
            
        }
    }
}
