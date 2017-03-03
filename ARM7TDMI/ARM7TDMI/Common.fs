﻿namespace ARM7TDMI 

(* 
    High Level Programming @ Imperial College London # Spring 2017
    Project: A user-friendly ARM7TDMI assembler and simulator in F# and Web Technologies ( Github Electron & Fable Compliler )

    Contributors: Angelos Filos, Baron Khan, Youssef Rizk, Pranav Prabhu

    Module: Common
    Description: 
*)

[<AutoOpen>]
module Common =

    // enumerate all values of a D.U. 
    let enumerator<'T> =
        FSharp.Reflection.FSharpType.GetUnionCases(typeof<'T>)
        |> Array.map (fun c ->  Reflection.FSharpValue.MakeUnion(c,[||]) :?> 'T)

    // Raw data Type
    type Data = int
    // Cast Function
    let Data = int

    type ShiftDirection = 
        |Left of int
        |Right of int
        |NoShift

    // Register ID D.U
    type RegisterID =
        | R0 | R1 | R2 | R3 | R4
        | R5 | R6 | R7 | R8 | R9
        | R10 | R11 | R12 | R13 | R14 | R15

    // Registers Type Abbreviation
    type Registers = Map<RegisterID, Data>

    // Status Flags ID D.U
    type FlagID =
        | N // Negative Flag
        | Z // Zero Flag
        | C // Carry Flag
        | V // Stack Overflow Flag

    // Flags Type Abbreviation
    type Flags = Map<FlagID, bool>

    // Operand D.U Type
    type Operand =
        | ID of RegisterID // Pass Register ID for data access
        | Literal of Data // Pass literal

    // Token Type
    type Token =
        | TokIdentifier of string   //includes MOV, ADD, etc. and labels
        //| TokReg of int
        | TokReg of RegisterID
        | TokConst of int
        | TokComma
        | TokExclam
        | TokSquareLeft
        | TokSquareRight
        | TokCurlyLeft
        | TokCurlyRight
        | TokNewLine
        | TokError of string

    type Operation = 
        | SevenOp of Token*Token*Token*Operand*bool*bool*Operand
        | SixOp of Token*Token*Token*Operand*bool*bool
        | FourOp of Token*Token*Token*bool
        | FourOp2 of Token*Token*bool*Operand
        | FourOp3 of Token*Operand*bool*Operand