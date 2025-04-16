namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.Create
{
    public class CreateBranchResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}
