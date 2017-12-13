# B1CPU

## Design

### Buses

* Data Bus - 8 bit
* Address Bus - 16 bit
* Control Bus - TBD

### Addressing Modes

* Absolute
* Absolute Indexed
* Absolute Indirect
* Absolute Indirect Indexed
* Absolute Indexed Indirect
* Zero-Page
* Zero-Page Indexed
* Zero-Page Indirect
* Zero-Page Indirect Indexed
* Zero-Page Indexed Indirect
* Immediate
* Implied

### User Registers

* A	- 8 bit accumulator
* B	- 8 bit general purpose register
* C	- 8 bit general purpose register
* X	- 8 bit index register

### System Registers

* F	 - 8 bit flag register
* PC - 16 bit program counter
* SP - 16 bit stack pointer
* DI - 16 bit destination index
* SI - 16 bit source index

### Hidden Registers

* IR - 8 bit instruction register
* DB - 8 bit data buffer register
* AB - 16 bit address buffer register

### Flags IH--CVSZ

* I	- interrupt
* H	- halt
* C	- carry
* V	- overflow
* S	- sign (negative)
* Z	- zero

### Register Selector

* A - 00
* B - 01
* C - 10
* X - 11

### Flag Selector

* C - 00
* V - 01
* S - 10
* Z - 11

### Interrupts

* NMI
  - single input line that cannot be disabled
  - CPU pushes flags and pc to stack and jumps to NMI location in memory

* IRQ
  - hardware interrupt
  - IRQ number is taken from data bus and pushed to stack along with flags
  - CPU  jumps to IRQ location in memory

* BRK
  - software interrupt
  - pc and flags are pushed to stack
  - CPU jumps to BRK location in memory

## Prerequisites

```
Microsoft Windows 7 or higher

Microsoft .NET Framework 4.6.1 or higher
```

## Built With

* [Visual Studio 2015](https://www.visualstudio.com/) - IDE and compiler
* [.NET Framework 4.6.1](https://www.microsoft.com/en-us/download/details.aspx?id=49981) - Application Framework
* [Castle Windsor](http://www.castleproject.org/projects/windsor/) - Dependency Injection

## Authors

* **Jamie** - *Initial work* - [coffeeunderrun](https://github.com/coffeeunderrun)

## License

This project is licensed under the GNU General Public License - see the [LICENSE](LICENSE) file for details
