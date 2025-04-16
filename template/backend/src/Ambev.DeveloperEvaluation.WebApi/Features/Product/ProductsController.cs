using Ambev.DeveloperEvaluation.Application.Product.Create;
using Ambev.DeveloperEvaluation.Application.Product.Delete;
using Ambev.DeveloperEvaluation.Application.Product.Get;
using Ambev.DeveloperEvaluation.Application.Product.Update;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.Create;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.Get;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.Update;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, IMapper mapper, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Cria um novo produto
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de produto: {@Request}", request);

        var command = _mapper.Map<CreateProductCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<CreateProductResponse>(result);

        _logger.LogInformation("Produto criado com sucesso. ID: {Id}", response.Id);

        return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = response
        });
    }

    /// <summary>
    /// Obtém os detalhes de um produto pelo ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Consultando produto pelo ID: {Id}", id);

        var result = await _mediator.Send(new GetProductCommand { Id = id }, cancellationToken);
        if (result == null)
        {
            _logger.LogWarning("Produto não encontrado. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Product not found" });
        }

        var response = _mapper.Map<GetProductResponse>(result);

        _logger.LogInformation("Produto recuperado com sucesso: {@Response}", response);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Product retrieved successfully",
            Data = response
        });
    }

    /// <summary>
    /// Atualiza os dados de um produto existente
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Atualizando produto ID {Id}: {@Request}", id, request);

        var command = _mapper.Map<UpdateProductCommand>(request);
        command.Id = id;

        var success = await _mediator.Send(command, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Produto não encontrado para atualização. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Product not found" });
        }

        _logger.LogInformation("Produto atualizado com sucesso. ID: {Id}", id);

        return Ok(new ApiResponse { Success = true, Message = "Product updated successfully" });
    }

    /// <summary>
    /// Exclui um produto pelo ID
    /// </summary>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remove um produto", Description = "Remove um produto existente pelo seu ID.")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Solicitada exclusão do produto ID: {Id}", id);

        var success = await _mediator.Send(new DeleteProductCommand { Id = id }, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Produto não encontrado para exclusão. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Product not found" });
        }

        _logger.LogInformation("Produto excluído com sucesso. ID: {Id}", id);

        return Ok(new ApiResponse { Success = true, Message = "Product deleted successfully" });
    }
}
