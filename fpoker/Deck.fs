namespace fpoker

module Deck = 
    
    open System

    type Color = Hearts | Diamonds | Spades | Clubs

    type Rank = Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jack | Queen | King | Ace

    type Card = Color * Rank

    type Deck = Card list

    let getCard (color:Color) (rank:Rank) =
        (color, rank)

    let checkIndex index length indexName=
        if index >= 0 && index < length
        then ()
        else 
            let message = sprintf "Index out of range (%d)" index
            invalidArg indexName message

    let swapElements (toSwap:'r list) firstIndex secondIndex =
        
        checkIndex firstIndex toSwap.Length "firstIndex"
        checkIndex secondIndex toSwap.Length "secondIndex"

        printf "%d %d \n" firstIndex secondIndex
        
        let arr = List.toArray toSwap
        let first = arr.[firstIndex]
        arr.[firstIndex] <- arr.[secondIndex]
        arr.[secondIndex] <- first
        Array.toList arr    

    let shuffleList (toShuffle:'r list) nrOfShuffles = 
        let rand = new System.Random();

        let randIndex = 
            rand.Next(1, toShuffle.Length);

        let rec loop x i =
            match i with 
            | 0 -> x
            | i -> loop (swapElements x (rand.Next(1, toShuffle.Length)) (rand.Next(1, toShuffle.Length))) (i-1)

        printf "%A" toShuffle
        let x = loop toShuffle nrOfShuffles   
        printf "%A" x
        x

    let getFullDeck () =
    //use List.zip instead
        [
            getCard Hearts Two;
            getCard Hearts Three;
            getCard Hearts Four;
            getCard Hearts Five;
            getCard Hearts Six;
            getCard Hearts Seven;
            getCard Hearts Eight;
            getCard Hearts Nine;
            getCard Hearts Ten;
            getCard Hearts Jack;
            getCard Hearts Queen;
            getCard Hearts King;
            getCard Hearts Ace;
            getCard Diamonds Two;
            getCard Diamonds Three;
            getCard Diamonds Four;
            getCard Diamonds Five;
            getCard Diamonds Six;
            getCard Diamonds Seven;
            getCard Diamonds Eight;
            getCard Diamonds Nine;
            getCard Diamonds Ten;
            getCard Diamonds Jack;
            getCard Diamonds Queen;
            getCard Diamonds King;
            getCard Diamonds Ace;
            getCard Spades Two;
            getCard Spades Three;
            getCard Spades Four;
            getCard Spades Five;
            getCard Spades Six;
            getCard Spades Seven;
            getCard Spades Eight;
            getCard Spades Nine;
            getCard Spades Ten;
            getCard Spades Jack;
            getCard Spades Queen;
            getCard Spades King;
            getCard Spades Ace;
            getCard Clubs Two;
            getCard Clubs Three;
            getCard Clubs Four;
            getCard Clubs Five;
            getCard Clubs Six;
            getCard Clubs Seven;
            getCard Clubs Eight;
            getCard Clubs Nine;
            getCard Clubs Ten;
            getCard Clubs Jack;
            getCard Clubs Queen;
            getCard Clubs King;
            getCard Clubs Ace;
        ]

