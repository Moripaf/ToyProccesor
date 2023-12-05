# Toy Processor

Toy Processor is a simulator/assembler for the Toy/2 ISA 

## Installation

this app is made using .net framework 6 so
you need at least that version of the .net framework to run this app

## the Toy/2 Insttuction Set Architecture
| Mnemonic    |            Description          |         Function          |
| ----------- | --------------------------------|---------------------------|
| JMP vec     | Indirect jump                   | PC:=vec                   |
| ADC src     | Addition                        | A:=A+[src]*; update C      |
| XOR src     | Exclusive or                    | 	A:=A xor [src]          |
| SBC src     | Subtract                        |A:=A - [src] - C; update C |
| 	ROR       | Rotate right through carry      | A,C:=A,C ror 1            |
|   TAT       | Transfer to T                   | 	T:=A                    |
| 	OR src    | Logical or                      | 	A:=A or [src]           |
| 	AND src   | Logical and                     | 	A:=A and [src]          |
| 	LDC src   | Load A, clear carry             | 	A:=[src]; C:=0          |
| 	BCC vec   | Indirect jump if carry clear    | 	IF C=1 THEN PC:=[vec]   |
| 	BNE vec   | Indirect jump if not zero       | 	IF Z=0 THEN PC:=[vec]   |
|     LDI     | Load A indirect                 | 	A:=[A]                  |
| 	  STT     | Store T indirect                | 	[A]:=T                  |
| 	LDA src   | Load A, don't clear carry       | 	A:=[src]                |
| 	STA dest  | Store A                         | 	[dest]:=A               |

*[src] = the value of the memory cell at the 'src' address
## Directives
``` 
.ORG [number]
```
``` 
.DATA [char] [OptionalNumber]
```
you can use .ORG and .DATA directives to declare variables and manipulate memory 
.ORG has the org pointer point to a specific address in memory 
than .data declares a variable in that point in memory
(org is incremented with every use of .data)
example : 
```
.ORG 25 // org -> 25  
.DATA A 20 // A -> 25 org -> 26 cell #25 in memory is set to 20
.DATA B // B->26 org->27 but no change in memory  
```

## Labels

Every Line that is not part of the ISA or a directive is treated as a label
you can use labels as jumping points via the JMP command :
```
loop
//...some instructions ..
JMP loop // pc = pc at loop
```
## Assembler
the assembler reads a text file with toy assembly code in it and creates a new file
with the [readFileName].out.txt format and which contains the assembled (turned to binary) form of the program
keep in mind that you can use directives with the assebmler it leave lines with directive as blank lines but otherwise it is compatibale with them 
as per assembly syntax there should only be 1 instruction per line no semicolon (;) needed :
```
SBC 17
ROR 
```
each instruction needs to be written in all upper case or all lower case for it to be recognized by the assembler
```
ADC 5 // a + [5]
adc 5 // a + [5]
aDc 5 // treated as label
```
## Simulator
the simulator is a tool to run a Toy assembly code.
you can import your code from a txt file or type it manually in the text box on the right.

the panel on the left shows the 3 registers in the processor A and T and PC
you can change the registers value manually and at runtime
if you want to jump to a specific line in code change the value of PC and press the Jump button

the panel at the bottom of the page displays the memory which is divided into 16 blocks
 select how the data is displayed using 'the show memory type' to view the memory
if you wish to change the block of memory your monitoring use the 'monitor' button
and the associated text box.
## Break Points
to insert a break point add a '*' as the start of a line to insert a breakpoint there
the run all button will keep running the code line by line until it reaches a breakpoint 
example :
```
adc 5
*JMP 15 // code execution stops here
```
press run all again to continue the code execution

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[MIT](https://choosealicense.com/licenses/mit/)
