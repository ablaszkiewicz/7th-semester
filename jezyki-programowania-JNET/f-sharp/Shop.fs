﻿module Shop

open System
open Client
open Money
open Transaction

type public Shop(Clients, Transactions) =
    member val Clients: List<Client> = Clients with get, set
    member val Transactions: List<Transaction> = Transactions with get, set
    
    new() = Shop([], [])

    member this.AddClient(client) =
        this.Clients <- client :: this.Clients
        
    member this.AddTransaction(transaction) =
        this.Transactions <- transaction :: this.Transactions
        
    member this.GetClient(clientId: int) =
        this.Clients |> List.find(fun client -> client.Id = clientId)
        
    member this.GetSumOfTransactions(clientId: int) =
        let transactions = this.Transactions |> List.filter (fun x -> x.ClientId = clientId)
        transactions |> List.sumBy (fun x -> x.Money)
    
    member this.GetSumOfUnpaidTransactions(clientId: int) =
        let transactions = this.Transactions |> List.filter (fun x -> x.ClientId = clientId && x.IsPaid = false)
        transactions |> List.sumBy (fun x -> x.Money)
        
    member this.PromoteClient(clientId: int) =
        let client = this.Clients |> List.find (fun x -> x.Id = clientId)
        let sum = this.GetSumOfTransactions(clientId)
        if client.IsClientForLongerThan(365) && sum > Money(1000.0m, "PLN") then
            client.LoyaltyStatus <- LoyaltyStatus.LoyaltyStatus.VIP
        else
            failwith "Client is not eligible for promotion"
    