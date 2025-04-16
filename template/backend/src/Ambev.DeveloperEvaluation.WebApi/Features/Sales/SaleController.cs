using Ambev.DeveloperEvaluation.Application.Sales.Create;
using Ambev.DeveloperEvaluation.Application.Sales.Delete;
using Ambev.DeveloperEvaluation.Application.Sales.Dtos;
using Ambev.DeveloperEvaluation.Application.Sales.Get;
using Ambev.DeveloperEvaluation.Application.Sales.Update;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Create;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Update;
using AutoMapper;
using FluentValidation; // ✅ Correção para exceções de validação
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/[controller]")]
public class SaleController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<SaleController> _logger;

    public SaleController(IMediator mediator, IMapper mapper, ILogger<SaleController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de venda: {@Request}", request);

        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou ao criar venda: {@Errors}", validationResult.Errors);
            throw new ValidationException(validationResult.Errors);
        }

        var command = _mapper.Map<CreateSaleCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<CreateSaleResponse>(result);

        _logger.LogInformation("Venda criada com sucesso. Id: {SaleId}", response.SaleId);

        return CreatedAtAction(nameof(GetSale), new { id = response.SaleId }, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = response
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Consultando venda por ID: {Id}", id);

        var result = await _mediator.Send(new GetSaleCommand { Id = id }, cancellationToken);

        if (result == null)
        {
            _logger.LogWarning("Venda não encontrada para o ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Sale not found" });
        }

        _logger.LogInformation("Venda recuperada com sucesso: {@Result}", result);

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(result)
        });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSale([FromRoute] Guid id, [FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Atualizando venda ID {Id}: {@Request}", id, request);

        var validator = new UpdateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validação falhou ao atualizar venda ID {Id}: {@Errors}", id, validationResult.Errors);
            throw new ValidationException(validationResult.Errors);
        }

        var command = _mapper.Map<UpdateSaleCommand>(request);
        command.Id = id;

        var success = await _mediator.Send(command, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Venda não encontrada para atualização. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Sale not found" });
        }

        _logger.LogInformation("Venda ID {Id} atualizada com sucesso", id);

        return Ok(new ApiResponse { Success = true, Message = "Sale updated successfully" });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Solicitada exclusão de venda. ID: {Id}", id);

        var success = await _mediator.Send(new DeleteSaleCommand { Id = id }, cancellationToken);

        if (!success)
        {
            _logger.LogWarning("Venda não encontrada para exclusão. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Sale not found" });
        }

        _logger.LogInformation("Venda ID {Id} excluída com sucesso", id);

        return Ok(new ApiResponse { Success = true, Message = "Sale deleted successfully" });
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<SaleDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSales(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recuperando todas as vendas");

        var query = new GetAllSalesQuery();
        var result = await _mediator.Send(query, cancellationToken);

        _logger.LogInformation("Total de vendas recuperadas: {Count}", result?.Count ?? 0);

        return Ok(result);
    }
}
