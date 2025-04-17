using Ambev.DeveloperEvaluation.Application.Customers.Create;
using Ambev.DeveloperEvaluation.Application.Customers.Delete;
using Ambev.DeveloperEvaluation.Application.Customers.Get;
using Ambev.DeveloperEvaluation.Application.Customers.Update;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.Create;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.Get;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.Update;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(IMediator mediator, IMapper mapper, ILogger<CustomersController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Cria um novo cliente
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCustomerResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de cliente: {@Request}", request);

        // Mapeia para o comando de aplicação
        var command = _mapper.Map<CreateCustomerCommand>(request);

        // Validação automática via ValidationBehavior (deve estar registrado no pipeline)
        var result = await _mediator.Send(command, cancellationToken);

        // Mapeia resultado para a resposta
        var response = _mapper.Map<CreateCustomerResponse>(result);

        _logger.LogInformation("Cliente criado com sucesso. ID: {Id}", response.Id);

        return CreatedAtAction(nameof(GetCustomer), new { id = response.Id }, new ApiResponseWithData<CreateCustomerResponse>
        {
            Success = true,
            Message = "Customer created successfully",
            Data = response
        });
    }


    /// <summary>
    /// Busca um cliente pelo ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCustomerResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomer(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Consultando cliente ID: {Id}", id);

        var result = await _mediator.Send(new GetCustomerCommand { Id = id }, cancellationToken);
        if (result == null)
        {
            _logger.LogWarning("Cliente não encontrado. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Customer not found" });
        }

        var response = _mapper.Map<GetCustomerResponse>(result);

        _logger.LogInformation("Cliente recuperado com sucesso: {@Response}", response);

        return Ok(new ApiResponseWithData<GetCustomerResponse>
        {
            Success = true,
            Message = "Customer retrieved successfully",
            Data = response
        });
    }

    /// <summary>
    /// Atualiza um cliente existente
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Atualizando cliente ID: {Id} com dados: {@Request}", id, request);

        var command = _mapper.Map<UpdateCustomerCommand>(request);
        command.Id = id;

        var success = await _mediator.Send(command, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Cliente não encontrado para atualização. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Customer not found" });
        }

        _logger.LogInformation("Cliente atualizado com sucesso. ID: {Id}", id);

        return Ok(new ApiResponse { Success = true, Message = "Customer updated successfully" });
    }

    /// <summary>
    /// Remove um cliente pelo ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCustomer(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Solicitada exclusão do cliente ID: {Id}", id);

        var success = await _mediator.Send(new DeleteCustomerCommand { Id = id }, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Cliente não encontrado para exclusão. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Customer not found" });
        }

        _logger.LogInformation("Cliente excluído com sucesso. ID: {Id}", id);

        return Ok(new ApiResponse { Success = true, Message = "Customer deleted successfully" });
    }
}
