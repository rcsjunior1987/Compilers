using System.Collections.Generic;
using System.Collections;

namespace GPLexTutorial
{
    public enum Tokens
    {
        ABSTRACT = 256,
        CONTINUE = 257,
        FOR = 258,
        NEW = 259,
        SWITCH = 260,
        ASSERT = 261,
        DEFAULT = 262,
        IF = 263,
        PACKAGE = 264,
        SYNCHRONIZED = 265,
        BOOLEAN = 266,
        DO = 267,
        GOTO = 268,
        PRIVATE = 269,
        THIS = 270,
        BREAK = 271,
        DOUBLE = 272,
        IMPLEMENTS = 273,
        PROTECTED = 274,
        THROW = 275,
        BYTE = 276,
        ELSE = 277,
        IMPORT = 278,
        PUBLIC = 279,
        THROWS = 280,
        CASE = 281,
        ENUM = 282,
        INSTANCEOF = 283,
        RETURN = 284,
        TRANSIENT = 285,
        CATCH = 286,
        EXTENDS = 287,
        INT = 288,
        SHORT = 289,
        TRY = 290,
        CHAR = 291,
        FINAL = 292,
        INTERFACE = 293,
        STATIC = 294,
        VOID = 295,
        CLASS = 296,
        FINALLY = 297,
        LONG = 298,
        STRICTFP = 299,
        VOLATILE = 300,
        CONST = 301,
        FLOAT = 302,
        NATIVE = 303,
        SUPER = 304,
        WHILE = 305,        NUMBER = 306,        IDENT = 307,        BOOL = 308,        EOF = 309
    };

    public struct MyValueType
    {
        public string num;
        public string name;
    };

    public abstract class ScanBase
    {
        public MyValueType yylval;
        public abstract int yylex();
        protected virtual bool yywrap() { return true; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void TestAst()
        {
            /*
            CompilationUnit root = new CompilationUnit(new List<Declaration>()
            {
                new ClassDeclaration(new List<Modifier>(){ Modifier.Public},"HelloWorld",new List<Declaration>()
                {
                    new MethodDeclaration(new List<Modifier>(){ Modifier.Public,Modifier.Static},new NamedType("void"),"Main",new List<FormalParameter>()
                    {
                        new FormalParameter(new ArrayType(new NamedType("String")),"args")
                    }, new BlockStatement(new List<Statement>()
                    {
                        new Statements(new LocalVariableDeclaration(new LocalVariableType("int"),new List<VariableDeclarator>(){new VariableDeclarator("x")})),
                        new Statements(new LocalVariableDeclaration(new LocalVariableType("int"),new List<VariableDeclarator>(){new VariableDeclarator("y")})),
                        new ExpressionStatement(new AssignmentExpression(new ExpressionName("x"), Operator.assignmentOP, new IntegerLiteral(42))
                        ), new ExpressionStatement(new AssignmentExpression (new ExpressionName("y"), Operator.assignmentOP, new BinaryExpression(new ExpressionName("x"), Operator.additionOP, new IntegerLiteral(1))))

                        //new LocalVariableDeclaration(new LocalVariableType("bool"), new List<VariableDeclarator>(){new VariableDeclarator("flag")}) ,
                        //new ExpressionStatement(new AssignmentExpression(new ExpressionName("flag"), AssignmentOperator.assignmentOp, new BoolLiteral(false)))
                    }

                    ))
                })
            });

    }


}