type Tree =
  | Leaf of string
  | Node of Tree * Tree

type Tree<'a> =
  | Leaf of 'a
  | Node of Tree<'a> * Tree<'a>

type TreeL = Node of TreeL list

let rec balanceTree = function
  | 0 -> Node []
  | n -> Node [balanceTree (n - 1); balanceTree (n - 1)]

let rec countLeafNodes = function
  | Node [] -> 1
  | Node list ->
    list |> Seq.fold (fun s t -> s + countLeafNodes t) 0

type TreeT<'a> =
  | LeafT of 'a
  | TreeT of 'a * TreeT<'a> * TreeT<'a>

let rec inorderTraversal tree =
  seq {
    match tree with
    | TreeT(x, left, right) ->
      yield! inorderTraversal left
      yield x
      yield! inorderTraversal right
    | LeafT x -> yield x
  }

let myTreeT = TreeT("D", TreeT("B", LeafT("A"), LeafT("C")), LeafT("E"))
let myseq = myTreeT |> inorderTraversal
printfn "%A" myseq

let rec preorderTraversal tree =
  seq {
    match tree with
    | TreeT(x, left, right) ->
      yield x
      yield! preorderTraversal left
      yield! preorderTraversal right
    | LeafT x -> yield x
  }

let myTreeA = TreeT("D", TreeT("B", LeafT("A"), LeafT("C")), LeafT("E"))
let myseqA = myTreeA |> preorderTraversal
printfn "%A" myseqA

let rec postorderTraversal tree =
  seq {
    match tree with
    | TreeT(x, left, right) ->
      yield! postorderTraversal left
      yield! postorderTraversal right
      yield x
    | LeafT x -> yield x
  }
