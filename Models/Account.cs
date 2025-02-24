using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Account {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountNumber {get;set;}
    public required string Type {get;set;}
    public float Solde {get;set;} = 0f;

    public User User {get;set;}
    public int UserId {get;set;}

    public List<Transaction> FromTransactions {get;set;} = new List<Transaction>();
    public List<Transaction> ToTransactions {get;set;} = new List<Transaction>();

    // Withdraw Money from the Account
    public void Withdraw(float amountToWithdraw) {
        Solde -= amountToWithdraw;
    }

    // Deposit Money
    public void Deposit(float amountToDeposit) {
        Solde += amountToDeposit;
    }
}