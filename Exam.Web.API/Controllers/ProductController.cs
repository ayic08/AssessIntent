using Exam.Business.Interface;
using Exam.Data.DTO;
using Exam.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region Get
        [HttpGet("[action]")]
        public async Task<ActionResult<APIResponse<object>>> GetAllAsync()
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                var data = await _productService.GetAllList();

                if (data != null)
                {
                    apiResponse.Success = true;
                    apiResponse.Result = data;

                    response = Ok(apiResponse);
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Result = null;

                    response = BadRequest(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }

        [HttpGet("[action]/{from}/{to}")]
        public async Task<ActionResult<APIResponse<object>>> GetAsync(int from, int to)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                var data = await _productService.GetList(from, to);

                if (data != null)
                {
                    apiResponse.Success = true;
                    apiResponse.Result = data;

                    response = Ok(apiResponse);
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Result = null;

                    response = BadRequest(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }

        [HttpGet("[action]/{productName}")]
        public async Task<ActionResult<APIResponse<object>>> SearchAllAsync(string productName)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                var data = await _productService.SearchAllAsync(productName);

                if (data != null)
                {
                    apiResponse.Success = true;
                    apiResponse.Result = data;

                    response = Ok(apiResponse);
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Result = null;

                    response = BadRequest(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }

        [HttpGet("[action]/{productName}/{from}/{to}")]
        public async Task<ActionResult<APIResponse<object>>> SearchAsync(string productName, int from, int to)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                var data = await _productService.SearchAsync(productName, from, to);

                if (data != null)
                {
                    apiResponse.Success = true;
                    apiResponse.Result = data;

                    response = Ok(apiResponse);
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Result = null;

                    response = BadRequest(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }

        [HttpGet("[action]/{startWith}/{from}/{to}")]
        public async Task<ActionResult<APIResponse<object>>> SortAsync(string startWith, int from, int to)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                var data = await _productService.SortAsync(startWith, from, to);

                if (data != null)
                {
                    apiResponse.Success = true;
                    apiResponse.Result = data;

                    response = Ok(apiResponse);
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Result = null;

                    response = BadRequest(apiResponse);
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }
        #endregion

        #region Action
        [HttpPost("[action]")]
        public async Task<ActionResult<APIResponse<object>>> AddAsync([FromForm] ProductDTO product)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                await _productService.AddAsync(product);

                apiResponse.Success = true;

                response = Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<APIResponse<object>>> UpdateAsync([FromForm] ProductDTO product)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                await _productService.UpdateAsync(product);

                apiResponse.Success = true;

                response = Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<APIResponse<object>>> EnableDisableAsync(int id)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                await _productService.EnableDisableAsync(id);

                apiResponse.Success = true;

                response = Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<APIResponse<object>>> DeleteAsync(int id)
        {
            var apiResponse = new APIResponse<object>();
            var response = new ObjectResult(apiResponse);

            try
            {
                await _productService.DeleteAsync(id);

                apiResponse.Success = true;

                response = Ok(apiResponse);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Result = ex;
                response = StatusCode(StatusCodes.Status500InternalServerError, apiResponse);
            }
            return response;
        }
        #endregion
    }
}
