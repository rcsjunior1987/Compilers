%namespace GPLexTutorial

%{
int lines = 0;
%}

letter [a-zA-Z]`
digits [0-9]
nonZeroDigit [1-9]
underscores ['_']
hexDigit [0-9|a-f|A-F]
octalDigit [0-7]
binaryDigit [0|1]
binarySignal ['b'|'B']

multiplicationSignal ['x'|'X']
sign ['+'|'-']
binaryExponentIndicator ['p'|'P']
floatTypeSuffix ['f'|'F'|'d'|'D']
integerTypeSuffix ['l'|'L']

/* Decimal_Numeral */
DecimalNumeral (0|{nonZeroDigit}+{digits}?|{nonZeroDigit}+{underscores}{digits})

/* Hex_Significand */
HexDigits ({hexDigit}|{hexDigit}{underscores}{hexDigit})
HexNumeral (0{multiplicationSignal}{HexDigits})
HexSignificand ({HexNumeral}.?|{HexNumeral})

SignedInteger ({sign}?{digits})
BinaryExponent ({binaryExponentIndicator}{SignedInteger})

/* Identifier */
IdentifierChars {letter}({letter}|{digits})*
Identifier {IdentifierChars}

/* Decimal_Integer_Literal */
DecimalIntegerLiteral {DecimalNumeral}

/* Integer_Literal_Long */
DecimalIntegerLiteralLong {DecimalNumeral}+{integerTypeSuffix}

/* Hex_Integer_Literal */
HexIntegerLiteral {HexNumeral}{integerTypeSuffix}?{hexDigit}*

/* Octal_Integer_Literal */
OctalNumeral (0{octalDigit}|0{underscores}{octalDigit})
OctalIntegerLiteral {OctalNumeral}{integerTypeSuffix}?{octalDigit}*

/* Binary_Integer_Literal */
BinaryNumeral (0{binarySignal}{binaryDigit}*|0{binarySignal}{underscores}{binaryDigit}*)
BinaryIntegerLiteral {BinaryNumeral}{integerTypeSuffix}?{binaryDigit}*

/* Decimal_Floating_Point_Literal  */

/* Hexadecimal_Floating_Point_Literal */
HexadecimalFloatingPointLiteral ({HexSignificand}{BinaryExponent}{floatTypeSuffix}?)


thisExpression this.{Identifier}



%%


abstract     { return (int)Tokens.ABSTRACT; }    
continue 	 { return (int)Tokens.CONTINUE; }   
for	         { return (int)Tokens.FOR; }          
new 	     { return (int)Tokens.NEW; }         
switch 	     { return (int)Tokens.SWITCH; }
assert 	     { return (int)Tokens.ASSERT; }
default 	 { return (int)Tokens.DEFAULT; }
if 	         { return (int)Tokens.IF; }
package 	 { return (int)Tokens.PACKAGE; }
synchronized { return (int)Tokens.SYNCHRONIZED; }
boolean      { return (int)Tokens.BOOLEAN; }
do 	         { return (int)Tokens.DO; }
goto 	     { return (int)Tokens.GOTO; }
private      { return (int)Tokens.PRIVATE; }
this 	     { return (int)Tokens.THIS; }
break 	     { return (int)Tokens.BREAK; }
double 	     { return (int)Tokens.DOUBLE; }
implements   { return (int)Tokens.IMPLEMENTS; }
protected    { return (int)Tokens.PROTECTED; }
throw 	     { return (int)Tokens.THROW; }
byte 	     { return (int)Tokens.BYTE; }
else 	     { return (int)Tokens.ELSE; }
import 	     { return (int)Tokens.IMPORT; }
public 	     { return (int)Tokens.PUBLIC; }
throws 	     { return (int)Tokens.THROWS; }
case 	     { return (int)Tokens.CASE; }
enum 	     { return (int)Tokens.ENUM; }
instanceof   { return (int)Tokens.INSTANCEOF; }
return 	     { return (int)Tokens.RETURN; }
transient    { return (int)Tokens.TRANSIENT; }
catch 	     { return (int)Tokens.CATCH; }
extends      { return (int)Tokens.EXTENDS; }
int 	     { return (int)Tokens.INT; }
short 	     { return (int)Tokens.SHORT; }
try 	     { return (int)Tokens.TRY; }
char 	     { return (int)Tokens.CHAR; }
final 	     { return (int)Tokens.FINAL; }
interface    { return (int)Tokens.INTERFACE; }
static 	     { return (int)Tokens.STATIC; }
void 	     { return (int)Tokens.VOID; }
class 	     { return (int)Tokens.CLASS; }
finally      { return (int)Tokens.FINALLY; }
long 	     { return (int)Tokens.LONG; }
strictfp     { return (int)Tokens.STRICTFP; }
volatile     { return (int)Tokens.VOLATILE; }
const 	     { return (int)Tokens.CONST; }
float 	     { return (int)Tokens.FLOAT; }
native 	     { return (int)Tokens.NATIVE; }
super 	     { return (int)Tokens.SUPER; }
while 	     { return (int)Tokens.WHILE; }

"=" { return '='; }
"+" { return '+'; }
"<" { return '<'; }
">" { return '<'; }
"(" { return '('; }
")" { return ')'; }
"[" { return '['; }
"]" { return ']'; }
"{" { return '{'; }
"}" { return '}'; }
";" { return ';'; }

{DecimalIntegerLiteral} { yylval.name = yytext; return (int)Tokens.INT; }

{DecimalIntegerLiteralLong} { yylval.name = yytext; return (int)Tokens.LONG; }

{HexIntegerLiteral} { yylval.name = yytext; return (int)Tokens.INT; }

{OctalIntegerLiteral} { yylval.name = yytext; return (int)Tokens.INT; }

{BinaryIntegerLiteral} { yylval.name = yytext; return (int)Tokens.INT; }

{Identifier} { yylval.name = yytext; return (int)Tokens.IDENT; }

{thisExpression} { yylval.name = yytext; return (int)Tokens.THIS; }

[\n] { lines++; }
[  \t\r] /* ignore other whitespace */ 
 
. {
	 throw new Exception(                                      
	String.Format(                                          
	"unexpected character '{0}'", yytext));  
  } 

%%

public override void yyerror(string format, params object[] args )
{
    System.Console.Error.WriteLine("Error: line {0}, {1}", lines,
        String.Format(format, args));
}