namespace Pliance.SDK.Contract
{
    public class RegisterCompanyCommand
	{
		public string CompanyReferenceId { get; set; }
		public CompanyIdentity Identity { get; set; }
		public string Name { get; set; }
	}
}
