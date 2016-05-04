type ProgrammingLanguage = 
    { Id : int
      Name : string
      PublishYear : int }
    override x.ToString() = sprintf "%s (%i)" x.Name x.PublishYear

type Developer = 
    { Id : int
      Name : string }
    override x.ToString() = sprintf "%s" x.Name

type DeveloperPL = 
    { DeveloperId : int
      PlId : int }

let ProgrammingLanguages = 
    [ { Id = 1
        Name = "C"
        PublishYear = 1972 }
      { Id = 2
        Name = "C++"
        PublishYear = 1985 }
      { Id = 3
        Name = "C#"
        PublishYear = 2000 }
      { Id = 4
        Name = "F#"
        PublishYear = 2005 }
      { Id = 5
        Name = "Java"
        PublishYear = 1991 }
      { Id = 6
        Name = "Pascal"
        PublishYear = 1970 }
      { Id = 7
        Name = "Python"
        PublishYear = 1997 }
      { Id = 8
        Name = "Basic"
        PublishYear = 1964 }
      { Id = 9
        Name = "COBOL"
        PublishYear = 1959 }
      { Id = 10
        Name = "FORTRAN"
        PublishYear = 1957 }
      { Id = 11
        Name = "LISP"
        PublishYear = 1956 }
      { Id = 12
        Name = "Perl"
        PublishYear = 1987 }
      { Id = 13
        Name = "JavaScript"
        PublishYear = 1995 }
      { Id = 14
        Name = "Scheme"
        PublishYear = 1975 }
      { Id = 15
        Name = "Clojure"
        PublishYear = 2007 }
      { Id = 16
        Name = "Haskell"
        PublishYear = 1990 }
      { Id = 17
        Name = "Ruby"
        PublishYear = 1995 }
      { Id = 18
        Name = "OCaml"
        PublishYear = 1996 }
      { Id = 19
        Name = "Scala"
        PublishYear = 2003 } ]

let Developers = 
    [ { Id = 1
        Name = "Dennis Ritchie" }
      { Id = 2
        Name = "Bjarne Stroustrup" }
      { Id = 3
        Name = "Anders Hejlsberg" }
      { Id = 4
        Name = "Don Syme" }
      { Id = 5
        Name = "James A. Gosling" }
      { Id = 6
        Name = "Nicklaus Wirth" }
      { Id = 7
        Name = "Guido van Rossum" }
      { Id = 8
        Name = "Kemeny and Kurtz" }
      { Id = 9
        Name = "Grace Hopper" }
      { Id = 10
        Name = "John Backus" }
      { Id = 11
        Name = "John McCarthy" }
      { Id = 12
        Name = "Larry Wall" }
      { Id = 13
        Name = "Brendan Eich" }
      { Id = 14
        Name = "Steele and Sussman" }
      { Id = 15
        Name = "Rich Hickey" }
      { Id = 16
        Name = "Jones, Augustsson, et al" }
      { Id = 17
        Name = "Yukihiro Matsumoto, et al" }
      { Id = 18
        Name = "Xavier Leroy et al." }
      { Id = 19
        Name = "Martin Odersky" } ]

let DevelopersPLs = 
    [ for i in 1..19 -> 
          { DeveloperId = i
            PlId = i } ]

query { 
    for pl in ProgrammingLanguages do
        where (pl.PublishYear = 2005)
        select (pl.ToString())
}

let getPLPageBySize pageSize pageNumber = 
    query { 
        for pl in ProgrammingLanguages do
            skip (pageSize * (pageNumber - 1))
            take pageSize
            select (pl.ToString())
    }

let getPLPageByYear year = 
    query { 
        for pl in ProgrammingLanguages do
            sortBy pl.PublishYear
            skipWhile (pl.PublishYear < year)
            takeWhile (pl.PublishYear = year)
            select (pl.ToString())
    }

query { 
    for f in ProgrammingLanguages do
        count
}
query { 
    for pl in ProgrammingLanguages do
        select pl.PublishYear
}
query { 
    for dev in Developers do
        nth 2
}

query {
    for pl in ProgrammingLanguages do
        groupBy pl.PublishYear into pl
        sortBy pl.Key
        select (pl.Key, pl)
}