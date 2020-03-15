using System.Collections.Generic;
using System;
namespace GPLexTutorial.AST
{
    
    public class BlockStatement : Statement
    {
        private List<Statement> blockStatement;
        private SymbolTable parent;

        public BlockStatement(List<Statement> blockStatement)
        {
            this.blockStatement = blockStatement;
        }

        public override void AddToSymbolTable(SymbolTable parent)
        {            
        }

        public override void ResolveNames(SymbolTable parent)
        {
            this.parent = new SymbolTable(parent);
            foreach (var statement in blockStatement)
            {
                statement.AddToSymbolTable(this.parent);
                statement.ResolveNames(this.parent);
            }

        }
    }

    class LocalVariableDeclaration : Statement
    {
        private Type localVariableType;
        private List<VariableDeclarator> localVariables;

        public LocalVariableDeclaration(Type localVariableType, List<VariableDeclarator> localVariables)
        {
            this.localVariableType = localVariableType;
            this.localVariables = localVariables;
        }

        public override void AddToSymbolTable(SymbolTable parent)
        {
        }

        public override void ResolveNames(SymbolTable parent)
        {
            foreach (var variable in localVariables)
            {
                variable.AddToSymbolTable(parent);
                variable.ResolveNames(parent);
            }  

        }
  
    }

    public class StatementFromExpression : Statement
    {
        private Expression expression;

        public StatementFromExpression(Expression expression)
        {
            this.expression = expression;
        }

        public override void AddToSymbolTable(SymbolTable symbolTable)
        {
            //
        }

        public override void ResolveNames(SymbolTable parent)
        {
            //
        }


    }

}
