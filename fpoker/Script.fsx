// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Deck.fs"
open fpoker.Deck

let deck = getFullDeck()

shuffleList deck 50

