let XSVEnumerator fileName = 
    seq { 
        use stream = System.IO.File.OpenText fileName
        while not stream.EndOfStream do
            let line = stream.ReadLine()
            let tokens = line.Split [| '\t' |]
            yield tokens
    }

let filename = @"path\to\somefile.txt"
let xsv = filename |> XSVEnumerator