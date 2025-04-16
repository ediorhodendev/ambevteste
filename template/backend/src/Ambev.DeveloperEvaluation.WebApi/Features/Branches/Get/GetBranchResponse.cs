namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.Get
{
    public class GetBranchResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
