namespace DeckTests
    open Xunit
    open FsUnit.Xunit
    open fpoker
    open fpoker.Deck

    
    module ``swapElements`` = 
            
        [<Fact>]
        let ``should swap elements in two element list`` ()=
            let l = [1;2]
            let swapped = [2;1]

            swapElements l 0 1 |> should equal swapped

        [<Fact>]
        let ``should swap first and last elements in long list`` ()=
            let l = [1;2;3;4;5;6]
            let expected = [6;2;3;4;5;1]

            swapElements l 0 5 |> should equal expected

        [<Fact>]
        let ``should swap elements in the middle of the list`` ()=
            let l = [1;2;3;4;5;6]
            let expected = [1;2;5;4;3;6]

            swapElements l 2 4 |> should equal expected

        [<Fact>]
        let ``should swap elements when second index is smaller then first`` ()=
            let l = [1;2;3;4;5;6]
            let expected = [1;2;5;4;3;6]

            swapElements l 4 2 |> should equal expected

        [<Fact>]
        let ``should throw an exception when index is out of range`` ()=
            let l = [1;2]
                
            shouldFail (fun () -> swapElements l 0 5 |> ignore) 

    module ``checkIndex`` =
            
        [<Fact>]
        let ``should not fail if index is in range`` ()=
            checkIndex 2 5 "index" |> should be Null

        [<Fact>]
        let ``should fail if index is less then 0`` ()=
            shouldFail (fun () -> checkIndex -1 5 "index" |> ignore)

        [<Fact>]
        let ``should fail if index equals length`` ()=
            shouldFail (fun () -> checkIndex 2 2 "index" |> ignore)

        [<Fact>]
        let ``should fail if index larger than length`` ()=
            shouldFail (fun () -> checkIndex 3 2 "index" |> ignore)

    module ``shuffleList`` =
        
        [<Fact>]
        let ``should be shuffled`` ()=
            let deck = getFullDeck()

            let shuffled = shuffleList deck 50

            shuffled |> should haveLength deck.Length
            shuffled |> should not' (equal deck)
            //deck |> List.iter (shuffled |> should contain)
    
    module ``getFullDeck`` =

        [<Fact>]
        let ``should have 52 cards in deck`` ()=
            getFullDeck() |> should haveLength 52
        
        [<Fact>]
        let ``should generate ordered deck of cards`` ()=
            let expected = 
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
        
            let deck = getFullDeck()

            deck |> should equal expected

