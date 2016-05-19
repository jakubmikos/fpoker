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

        loop toShuffle nrOfShuffles   

    let getFullDeck () =
        let colors = [ Hearts; Diamonds; Spades; Clubs]
        let ranks = [ Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King; Ace]

        let applyRank color =
            let colorCard = getCard color
            ranks |> List.map colorCard
        
        colors |> List.map applyRank |> List.concat
        