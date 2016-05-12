type Msg(msgIdentifier, msgContents : string) =
  static let mutable count = 0
  member this.Id = msgIdentifier
  member this.Contents = msgContents
  static member CreateMsg(contents) =
    count <- count + 1
    Msg(count, contents)

let mailbox = new MailboxProcessor<Msg>(fun inbox ->
  let rec loop count =
    async {
      printfn "Message count = %d. Awaiting next message." count
      let! message = inbox.Receive()
      printfn "Message received. ID: %d Contents: %s" message.Id message.Contents
      return! count + 1 |> loop
    }
  0 |> loop)

mailbox.Start()
mailbox.Post(Msg.CreateMsg("Foobar"))
mailbox.Post(Msg.CreateMsg("Fizzbuzz"))
mailbox.Post(Msg.CreateMsg("Foo"))
mailbox.Post(Msg.CreateMsg("Bar"))
mailbox.Post(Msg.CreateMsg("Bazz"))
