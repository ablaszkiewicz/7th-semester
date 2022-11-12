module Transaction

open Money

type public Transaction (ClientId, Money, IsPaid) =
    member val ClientId: int = ClientId with get, set
    member val Money: Money = Money with get, set
    member val IsPaid: bool = IsPaid with get, set
    
    // override ToString
    override this.ToString() =
        $"{this.ClientId} {this.Money} {this.IsPaid}"
    