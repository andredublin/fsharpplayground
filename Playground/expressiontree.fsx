type Expression =
  | Integer of int
  | Addition of Expression * Expression
  | Multiply of Expression * Expression

let expr = Addition (Multiply (Integer 2, Integer 3), Integer 1)

let rec evalExpr expr =
  match expr with
  | Integer i -> i
  | Addition (x, y) -> evalExpr x + evalExpr y
  | Multiply (x, y) -> evalExpr x * evalExpr y

let result = evalExpr expr
