using System;

namespace GPLexTutorial.AST
{

    public class IntType : Type
    {
        public IntType()
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            throw new NotImplementedException();
        }
    }

    public class VoidType : Type
    {
        public VoidType()
        {
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            throw new NotImplementedException();
        }
    }

    public class NamedType : Type
    {
        private string typeName;

        public NamedType(string typeName)
        {
            this.typeName = typeName;
        }

        public override void ResolveNames(SymbolTable symbolTable)
        {
            throw new NotImplementedException();
        }
    }

    public class ArrayType : Type
    {
        private string arrayType;

        public ArrayType(string arrayType)
        {
            this.arrayType = arrayType;
        }

        public override void ResolveNames(SymbolTable parent)
        {
            throw new NotImplementedException();
        }
    }


}
