public class Transaction() {
    public int Id {get;set;}
    public float amount {get;set;}
    public DateTime Timestamp {get;set;}
    public required int FromAccountId {get;set;}
    public required Account FromAccount {get;set;}
    public required int ToAccountId {get;set;}
    public required Account ToAccount {get;set;}


    // Validate the Transaction
    public bool Validate(){
        return (FromAccount.Solde - amount >= 0); 
    } 
}