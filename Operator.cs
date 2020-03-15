using System;

namespace GPLexTutorial.AST
{

    public class AssignmentOperator : Operator
    {
        private string assignmentOperator;

        public AssignmentOperator(string assignmentOperator)
        {
            this.assignmentOperator = assignmentOperator;
        }

        public override void ResolveNames(SymbolTable parent)
        {
            throw new NotImplementedException();
        }
    }

}
