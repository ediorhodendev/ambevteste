using Ambev.DeveloperEvaluation.Application.Branches.Create;
using Ambev.DeveloperEvaluation.Application.Branches.Delete;
using Ambev.DeveloperEvaluation.Application.Branches.Get;
using Ambev.DeveloperEvaluation.Application.Branches.Update;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.Create;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.Get;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.Update;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<BranchesController> _logger;

    public BranchesController(IMediator mediator, IMapper mapper, ILogger<BranchesController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Cria uma nova filial
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de filial: {@Request}", request);

        var command = _mapper.Map<CreateBranchCommand>(request);
        var result = await _mediator.Send(command, cancellationToken);
        var response = _mapper.Map<CreateBranchResponse>(result);

        _logger.LogInformation("Filial criada com sucesso. ID: {Id}", response.Id);

        return CreatedAtAction(nameof(GetBranch), new { id = response.Id }, new ApiResponseWithData<CreateBranchResponse>
        {
            Success = true,
            Message = "Branch created successfully",
            Data = response
        });
    }

    /// <summary>
    /// Recupera os dados de uma filial pelo ID
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetBranchResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBranch(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Consultando filial ID: {Id}", id);

        var result = await _mediator.Send(new GetBranchCommand { Id = id }, cancellationToken);
        if (result == null)
        {
            _logger.LogWarning("Filial não encontrada. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Branch not found" });
        }

        var response = _mapper.Map<GetBranchResponse>(result);

        _logger.LogInformation("Filial recuperada com sucesso: {@Response}", response);

        return Ok(new ApiResponseWithData<GetBranchResponse>
        {
            Success = true,
            Message = "Branch retrieved successfully",
            Data = response
        });
    }

    /// <summary>
    /// Atualiza os dados de uma filial existente
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBranch(Guid id, [FromBody] UpdateBranchRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Atualizando filial ID: {Id} com dados: {@Request}", id, request);

        var command = _mapper.Map<UpdateBranchCommand>(request);
        command.Id = id;

        var success = await _mediator.Send(command, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Filial não encontrada para atualização. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Branch not found" });
        }

        _logger.LogInformation("Filial atualizada com sucesso. ID: {Id}", id);

        return Ok(new ApiResponse { Success = true, Message = "Branch updated successfully" });
    }

    /// <summary>
    /// Remove uma filial pelo ID
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBranch(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Solicitada exclusão da filial ID: {Id}", id);

        var success = await _mediator.Send(new DeleteBranchCommand { Id = id }, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Filial não encontrada para exclusão. ID: {Id}", id);
            return NotFound(new ApiResponse { Success = false, Message = "Branch not found" });
        }

        _logger.LogInformation("Filial excluída com sucesso. ID: {Id}", id);

        return Ok(new ApiResponse { Success = true, Message = "Branch deleted successfully" });
    }
}
