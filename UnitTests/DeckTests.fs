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
                

