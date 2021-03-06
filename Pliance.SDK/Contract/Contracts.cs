using System;
using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    // @inject: contracts
	public class Address 
	{
		public string City { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string StreetNo { get; set; }
	}

	public class ArchiveCompanyCommand 
	{
		public string CompanyReferenceId { get; set; }
	}

	public class ArchiveCompanyResponse : Response 
	{
	}

	public class ArchivePersonCommand 
	{
		public string PersonReferenceId { get; set; }
	}

	public class ArchivePersonResponse : Response 
	{
	}

	public class Birthdate 
	{
		public int? Day { get; set; }
		public int? Month { get; set; }
		public int? Year { get; set; }
	}

	public enum BirthMatchType
	{
		Date = 0,
		Range = 1,
	}

	public enum ClassificationType
	{
		Unknown = 0,
		FalsePositive = 1,
		Match = 2,
	}

	public class ClassifyCompanyHitCommand 
	{
		public string AliasId { get; set; }
		public ClassificationType Classification { get; set; }
		public string CompanyReferenceId { get; set; }
		public string MatchId { get; set; }
	}

	public class ClassifyCompanyHitResponse : Response 
	{
	}

	public class ClassifyPersonHitCommand 
	{
		public string AliasId { get; set; }
		public ClassificationType Classification { get; set; }
		public string MatchId { get; set; }
		public string PersonReferenceId { get; set; }
	}

	public class ClassifyPersonHitResponse : Response 
	{
	}

	public class CompanyGraphBeneficiariesQuery 
	{
		public string CompanyReferenceId { get; set; }
	}

	public class CompanyGraphBeneficiariesResult : ResponseGeneric<Graph> 
	{
	}

	public class CompanyHit 
	{
		public string AliasId { get; set; }
		public ClassificationType Classification { get; set; }
		public bool IsSanction { get; set; }
		public List<TextMatch> MatchedName { get; set; }
		public string MatchId { get; set; }
		public string Name { get; set; }
	}

	public class CompanyIdentity 
	{
		public string Country { get; set; }
		public string Identity { get; set; }
	}

	public class CompanySearchQuery 
	{
		public Filter Filter { get; set; }
		public Page Page { get; set; }
		public string Query { get; set; }
	}

	public class CompanySearchQueryResult : ResponseGeneric<CompanySearchResponseData> 
	{
	}

	public class CompanySearchResponseData 
	{
		public List<CompanySearchResult> Result { get; set; }
	}

	public class CompanySearchResult 
	{
		public bool Archived { get; set; }
		public string CompanyReferenceId { get; set; }
		public CompanyIdentity Identity { get; set; }
		public bool IsPep { get; set; }
		public bool IsRca { get; set; }
		public bool IsSanction { get; set; }
		public List<TextMatch> Name { get; set; }
	}

	public class DeleteCompanyCommand 
	{
		public string CompanyReferenceId { get; set; }
	}

	public class DeleteCompanyResponse : Response 
	{
	}

	public class DeletePersonCommand 
	{
		public string PersonReferenceId { get; set; }
	}

	public class DeletePersonResponse : Response 
	{
	}

	public class EngagementModel 
	{
		public string Name { get; set; }
		public string RegistrationNumber { get; set; }
	}

	public class FeedQuery 
	{
		public string From { get; set; }
	}

	public class FeedQueryItem 
	{
		public object Body { get; set; }
		public string Checkpoint { get; set; }
		public object Metadata { get; set; }
		public string Type { get; set; }
	}

	public class FeedQueryResult : ResponseGeneric<FeedQueryResultData> 
	{
	}

	public class FeedQueryResultData 
	{
		public List<FeedQueryItem> Items { get; set; }
	}

	public class Filter 
	{
		public bool? IsPep { get; set; }
		public bool? IsRca { get; set; }
		public bool? IsSanction { get; set; }
	}

	public enum Fuzziness
	{
		Metaphone = 0,
		Simple = 1,
		Diacritics = 2,
	}

	public enum Gender
	{
		Unknown = 0,
		Male = 1,
		Female = 2,
	}

	public class Graph 
	{
		public List<Link> Links { get; set; }
		public List<Node> Nodes { get; set; }
	}

	public class LastChanged 
	{
		public string Checkpoint { get; set; }
		public DateTime TimestampUtc { get; set; }
	}

	public class LegalPerson 
	{
		public object Hits { get; set; }
		public string Name { get; set; }
	}

	public class Link 
	{
		public int Source { get; set; }
		public int Target { get; set; }
		public string Type { get; set; }
	}

	public class ListAddress 
	{
		public string City { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string StreetNo { get; set; }
	}

	public class ListBirthdate 
	{
		public bool Circa { get; set; }
		public int? Day { get; set; }
		public int? FromYear { get; set; }
		public int? Month { get; set; }
		public int? ToYear { get; set; }
		public BirthMatchType Type { get; set; }
		public int? Year { get; set; }
	}

	public class ListCompanyNameViewModel 
	{
		public string Name { get; set; }
		public List<TextMatch> SelectedName { get; set; }
		public string Type { get; set; }
	}

	public class ListCompanyViewModel 
	{
		public string CompanyReferenceId { get; set; }
		public bool IsSanction { get; set; }
		public List<ListCompanyNameViewModel> Names { get; set; }
		public List<string> SanctionLists { get; set; }
	}

	public class ListPersonNameViewModel 
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<TextMatch> SelectedFirstName { get; set; }
		public List<TextMatch> SelectedLastName { get; set; }
		public string Type { get; set; }
	}

	public class ListPersonViewModel 
	{
		public List<ListAddress> Addresses { get; set; }
		public List<ListBirthdate> Birthdates { get; set; }
		public List<string> Countries { get; set; }
		public Gender Gender { get; set; }
		public List<string> Images { get; set; }
		public bool IsPep { get; set; }
		public bool IsRca { get; set; }
		public bool IsSanction { get; set; }
		public string ListId { get; set; }
		public List<string> Lists { get; set; }
		public List<ListPersonNameViewModel> Names { get; set; }
		public string NationalIdentificationNumber { get; set; }
		public List<string> Nationalities { get; set; }
		public List<ListRelationViewModel> Relations { get; set; }
		public List<ListRole> Roles { get; set; }
	}

	public class ListRelationViewModel 
	{
		public string FirstName { get; set; }
		public bool IsPep { get; set; }
		public bool IsRca { get; set; }
		public bool IsSanction { get; set; }
		public string LastName { get; set; }
		public string RelationPersonId { get; set; }
		public string RelationType { get; set; }
	}

	public class ListRole 
	{
		public string Description { get; set; }
		public bool IsActive { get; set; }
		public string SinceDay { get; set; }
		public string SinceMonth { get; set; }
		public string SinceYear { get; set; }
		public string ToDay { get; set; }
		public string ToMonth { get; set; }
		public string ToYear { get; set; }
	}

	public class Node 
	{
		public int Id { get; set; }
		public bool IsPep { get; set; }
		public string Name { get; set; }
		public string Reference { get; set; }
		public string Type { get; set; }
	}

	public enum Order
	{
		Any = 0,
		Strict = 1,
		Exact = 2,
	}

	public class Page 
	{
		public int? No { get; set; }
		public int? Size { get; set; }
	}

	public class PersonHit 
	{
		public string AliasId { get; set; }
		public ClassificationType Classification { get; set; }
		public string FirstName { get; set; }
		public bool IsPep { get; set; }
		public bool IsRca { get; set; }
		public bool IsSanction { get; set; }
		public string LastName { get; set; }
		public List<TextMatch> MatchedFirstName { get; set; }
		public List<TextMatch> MatchedLastName { get; set; }
		public string MatchId { get; set; }
	}

	public class PersonIdentity 
	{
		public string Country { get; set; }
		public string Identity { get; set; }
	}

	public class PersonReport 
	{
		public string Country { get; set; }
		public List<LegalPerson> LegalPersons { get; set; }
		public object Persons { get; set; }
	}

	public class PersonSearchQuery 
	{
		public Filter Filter { get; set; }
		public Page Page { get; set; }
		public string Query { get; set; }
	}

	public class PersonSearchQueryResult : ResponseGeneric<PersonSearchResponseData> 
	{
	}

	public class PersonSearchResponseData 
	{
		public List<PersonSearchResult> Result { get; set; }
	}

	public class PersonSearchResult 
	{
		public bool Archived { get; set; }
		public List<TextMatch> FirstName { get; set; }
		public PersonIdentity Identity { get; set; }
		public bool IsPep { get; set; }
		public bool IsRca { get; set; }
		public bool IsSanction { get; set; }
		public List<TextMatch> LastName { get; set; }
		public string PersonReferenceId { get; set; }
	}

	public class PingQuery 
	{
	}

	public class PingResponse : Response 
	{
	}

	public class RegisterCompanyCommand 
	{
		public string CompanyReferenceId { get; set; }
		public CompanyIdentity Identity { get; set; }
		public string Name { get; set; }
		public RegisterCompanyOptions Options { get; set; }
	}

	public class RegisterCompanyOptions 
	{
		public Fuzziness Fuzziness { get; set; }
		public bool OmitResult { get; set; }
		public Order Order { get; set; }
	}

	public class RegisterCompanyResponse : ResponseGeneric<ViewCompanyResponseData> 
	{
	}

	public class RegisterPersonCommand 
	{
		public List<Address> Addresses { get; set; }
		public Birthdate Birthdate { get; set; }
		public string FirstName { get; set; }
		public string Gender { get; set; }
		public PersonIdentity Identity { get; set; }
		public string LastName { get; set; }
		public RegisterPersonOptions Options { get; set; }
		public string PersonReferenceId { get; set; }
	}

	public class RegisterPersonOptions 
	{
		public Fuzziness Fuzziness { get; set; }
		public bool OmitResult { get; set; }
		public Order Order { get; set; }
	}

	public class RegisterPersonResponse : ResponseGeneric<ViewPersonResponseData> 
	{
		public List<List<PersonHit>> Hits { get; set; }
	}

	public class ReportQuery 
	{
	}

	public class ReportQueryResult : Response 
	{
		public List<string> HighRiskCountries { get; set; }
		public List<PersonReport> PersonReports { get; set; }
	}

	public enum ResponseStatus
	{
		Success = 0,
		Error = -1,
	}

	public class TextMatch 
	{
		public bool IsMatch { get; set; }
		public string Text { get; set; }
	}

	public class UnarchiveCompanyCommand 
	{
		public string CompanyReferenceId { get; set; }
	}

	public class UnarchiveCompanyResponse : Response 
	{
	}

	public class UnarchivePersonCommand 
	{
		public string PersonReferenceId { get; set; }
	}

	public class UnarchivePersonResponse : Response 
	{
	}

	public class ViewCompanyQuery 
	{
		public string CompanyReferenceId { get; set; }
	}

	public class ViewCompanyQueryResult : ResponseGeneric<ViewCompanyResponseData> 
	{
	}

	public class ViewCompanyResponseData 
	{
		public bool Archived { get; set; }
		public List<ViewPersonResponseData> Beneficiaries { get; set; }
		public string CompanyReferenceId { get; set; }
		public bool HighRiskCountry { get; set; }
		public List<List<CompanyHit>> Hits { get; set; }
		public CompanyIdentity Identity { get; set; }
		public bool IsSanction { get; set; }
		public LastChanged LastChanged { get; set; }
		public string Name { get; set; }
	}

	public class ViewPersonQuery 
	{
		public string PersonReferenceId { get; set; }
	}

	public class ViewPersonQueryResult : ResponseGeneric<ViewPersonResponseData> 
	{
	}

	public class ViewPersonResponseData 
	{
		public List<Address> Addresses { get; set; }
		public bool Archived { get; set; }
		public Birthdate Birth { get; set; }
		public string Birthdate { get; set; }
		public List<EngagementModel> Engagements { get; set; }
		public string FirstName { get; set; }
		public Gender Gender { get; set; }
		public bool HighRiskCountry { get; set; }
		public List<List<PersonHit>> Hits { get; set; }
		public PersonIdentity Identity { get; set; }
		public bool IsPep { get; set; }
		public bool IsRca { get; set; }
		public bool IsSanction { get; set; }
		public LastChanged LastChanged { get; set; }
		public string LastName { get; set; }
		public string PersonReferenceId { get; set; }
	}

	public class WatchlistCompanyQuery 
	{
		public string CompanyReferenceId { get; set; }
		public string MatchId { get; set; }
	}

	public class WatchlistCompanyQueryResult : ResponseGeneric<ListCompanyViewModel> 
	{
	}

	public class WatchlistQuery 
	{
		public string FirstName { get; set; }
		public string Id { get; set; }
		public string LastName { get; set; }
	}

	public class WatchlistQuery_v2 
	{
		public string MatchId { get; set; }
		public string PersonReferenceId { get; set; }
	}

	public class WatchlistQueryResult : ResponseGeneric<ListPersonViewModel> 
	{
	}

	public class WatchlistQueryResult_v2 : ResponseGeneric<ListPersonViewModel> 
	{
	}

	public class WebhookQuery 
	{
	}

	public class WebhookQueryResult : ResponseGeneric<WebhookQueryResultData> 
	{
	}

	public class WebhookQueryResultData 
	{
		public bool Enabled { get; set; }
		public string Secret { get; set; }
		public string Url { get; set; }
	}

	public class WebhookUpdateCommand 
	{
		public bool Enabled { get; set; }
		public string Secret { get; set; }
		public string Url { get; set; }
	}

	public class WebhookUpdateResponse : Response 
	{
	}

    // @inject: !contracts
}
