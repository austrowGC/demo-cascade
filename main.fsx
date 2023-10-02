#r "nuget: Argu, 6.1.1"
#load "stupid-math.fsx"
open StupidMath
open Argu

type Arguments =
    | [<MainCommand; ExactlyOnce; Last>] Whole_Number of number:int

    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Whole_Number _ -> "whole number on which to operate"

let parser = ArgumentParser.Create<Arguments>(programName = "main.fsx")
let print = printfn "%s"

// [<EntryPoint>]
let main argv =
    try
        let results = parser.ParseCommandLine ()
        let number = results.GetResult Whole_Number
        add41 number |> printfn "%i"

    with e ->
        print e.Message
    0

main fsi.CommandLineArgs
