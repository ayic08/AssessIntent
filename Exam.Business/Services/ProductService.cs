using Exam.Business.Interface;
using Exam.Data.DTO;
using Exam.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Exam.Business.Services
{
    public class ProductService : IProductService
    {
        readonly ExamProductDbContext _dbContext;
        readonly IConfiguration _configuration;
       // readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(ExamProductDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        #region Get
        public async Task<List<ProductDTO>> GetAllList()
        {
            return await _dbContext.Products.Where(x => x.IsEnabled)
                                                 .OrderBy(x => x.ProductName)
                                                 .Select(x => new ProductDTO(x))
                                                 .ToListAsync();
        }

        public async Task<List<ProductDTO>> GetList(int from, int to)
        {
            return await _dbContext.Products.Where(x => x.IsEnabled)
                                                 .OrderBy(x => x.ProductName)
                                                 .Select(x => new ProductDTO(x)).Skip(from).Take(to)
                                                 .ToListAsync();
        }

        public async Task<List<ProductDTO>> SearchAsync(string productName, int from, int to)
        {
            return await _dbContext.Products.Where(x => x.ProductName.Contains(productName) && x.IsEnabled)
                                                      .OrderBy(x => x.ProductName)
                                                      .Select(x => new ProductDTO(x)).Skip(from).Take(to)
                                                      .ToListAsync();
        }

        public async Task<List<ProductDTO>> SearchAllAsync(string productName)
        {
            return await _dbContext.Products.Where(x => x.ProductName.Contains(productName) && x.IsEnabled)
                                                      .Select(x => new ProductDTO(x))
                                                      .OrderBy(x => x.ProductName)
                                                      .ToListAsync();
        }

        public async Task<List<ProductDTO>> SortAsync(string sortWith, int from, int to)
        {
            if (sortWith == "#")
                return await _dbContext.Products.Where(x => !char.IsLetter(x.ProductName.FirstOrDefault()) && x.IsEnabled)
                                                          .OrderBy(x => x.ProductName)
                                                          .Select(x => new ProductDTO(x)).Skip(from).Take(to)
                                                          .ToListAsync();
            else
                return await _dbContext.Products.Where(x => x.ProductName.ToUpper().StartsWith(sortWith.ToUpper()) && x.IsEnabled)
                                                      .OrderBy(x => x.ProductName)
                                                      .Select(x => new ProductDTO(x)).Skip(from).Take(to)
                                                      .ToListAsync();
        }
        #endregion

        #region Action
        public async Task AddAsync(ProductDTO product)
        {
            //get username logged on
            //var currentUser = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            //var userId = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == currentUser);
            
            var user = 1;
            var filePath = "";

            if (product.File != null)
            {
                filePath = $"{_configuration["Upload:FolderPath"]}{product.File.FileName}";

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await product.File.CopyToAsync(stream);
                }
            }

            var addedProduct = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ImagePath = filePath,
                CreatedDate = DateTime.Now,
                CreatedBy = user,
                //CreatedBy = userId,
                IsEnabled = true,
            };

            await _dbContext.Products.AddAsync(addedProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDTO product)
        {
            //get username logged on
            //var currentUser = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            //var userId = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == currentUser);

            var user = 1;

            var getProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

            if (getProduct != null)
            {
                var filePath = product.ImagePath;
                if (product.File != null)
                {
                    filePath = $"{_configuration["Upload:FolderPath"]}{product.File.FileName}";

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await product.File.CopyToAsync(stream);
                    }
                }

                getProduct.ProductDescription = product.ProductDescription;
                getProduct.ImagePath = filePath;
                getProduct.UpdatedDate = DateTime.Now;
                getProduct.UpdatedBy = user;
                //getProduct.UpdatedBy = userId;
                getProduct.IsEnabled = true;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task EnableDisableAsync(int id)
        {
            //get username logged on
            //var currentUser = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            //var userId = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == currentUser);

            var user = 1;

            var getProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (getProduct != null)
            {
                getProduct.UpdatedDate = DateTime.Now;
                getProduct.UpdatedBy = user;
                //getProduct.UpdatedBy = userId;
                getProduct.IsEnabled = !getProduct.IsEnabled;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var getProduct = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (getProduct != null)
            {
                _dbContext.Products.Remove(getProduct);
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion

        #region Function
        static bool StartsNonAlphabetic(string input)
        {
            // Check if the string is not empty and the first character is not a letter
            return !string.IsNullOrEmpty(input) && !char.IsLetter(input[0]);
        }
        #endregion
    }
}
