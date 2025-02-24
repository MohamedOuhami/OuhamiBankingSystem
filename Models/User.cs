public class User {
    public int Id {get;set;}
    public required string  FirstName {get;set;}
    public required string LastName {get;set;}
    public required string Email {get;set;}
    public string? Phone {get;set;}

    public List<Account> Accounts = new List<Account>();
}