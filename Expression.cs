using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    
    public class AssignmentExpression : Expression
    {
        private Expression lhs;
        private Operator oper;
        private Expression rhs;

        public AssignmentExpression(Expression lhs, Operator oper, Expression rhs)
        {
            this.lhs = lhs;
            this.oper = oper;
            this.rhs = rhs;
        }

        public override void ResolveNames(SymbolTable parent)
        {
            lhs.ResolveNames(parent);
            rhs.ResolveNames(parent);
        }

    }

    class ExpressionName : Expression
    {
        private string expressionName;

        public ExpressionName(string expressionName)
        {
            this.expressionName = expressionName;
        }

        public override void ResolveNames(SymbolTable parent)
        {
            throw new NotImplementedException();
        }
    }

    public class IntegerLiteral : Expression
    {
        private int value;

        public IntegerLiteral(int value)
        {
            this.value = value;
        }

        public override void ResolveNames(SymbolTable parent)
        {
            throw new NotImplementedException();
        }
    }

}
