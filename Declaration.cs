using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{

    public class ClassDeclaration : Declaration
    {
        private List<Modifier> modifiers;
        private string className;
        private List<Declaration> classBodyDeclarations;
        private SymbolTable parent;

        public ClassDeclaration(List<Modifier> modifiers, string className, List<Declaration> classBodyDeclarations)
        {
            this.modifiers = modifiers;
            this.className = className;
            this.classBodyDeclarations = classBodyDeclarations;
        }
                                                                              
        public override void AddToSymbolTable(SymbolTable parent)
        {
            parent.Add(this.className, this);
            parent.LookUp(this.className);
        }

        public override void ResolveNames(SymbolTable parent)
        {
            this.parent = new SymbolTable(parent);
            foreach (var declaration in classBodyDeclarations)
            {
                declaration.AddToSymbolTable(this.parent);
                declaration.ResolveNames(this.parent);
            }
            
        }

    }

    public class MethodDeclaration : Declaration
    {
        private MethodHeader methodHeader;
        private BlockStatement methodBody;
        private List<Modifier> modifiers;
        private SymbolTable parent;

        public MethodDeclaration(List<Modifier> modifiers, MethodHeader methodHeader, BlockStatement methodBody)
        {
            this.methodHeader = methodHeader;
            this.modifiers = modifiers;
            this.methodBody = methodBody;
        }

        public override void AddToSymbolTable(SymbolTable parent)
        {
        }

        public override void ResolveNames(SymbolTable parent)
        {
            this.methodHeader.AddToSymbolTable(parent);
            this.methodHeader.ResolveNames(parent);
            this.methodBody.AddToSymbolTable(parent);
            this.methodBody.ResolveNames(parent);
        }

    }

    public class MethodHeader : Declaration
    {
        private Type result;
        private MethodDeclarator methodDeclarator;
        private SymbolTable parent;

        public MethodHeader(Type result, MethodDeclarator methodDeclarator)
        {
            this.methodDeclarator = methodDeclarator;
        }

        public override void AddToSymbolTable(SymbolTable parent)
        {
        }

        public override void ResolveNames(SymbolTable parent)
        {
            this.methodDeclarator.AddToSymbolTable(parent);
            this.methodDeclarator.ResolveNames(parent);           
        }

    }

    public class MethodDeclarator : Declaration
    {
        private string methodName;
        private List<FormalParameter> formalParameter;
        private SymbolTable parent;

        public MethodDeclarator(string methodName, List<FormalParameter> formalParameter)
        {
            this.methodName = methodName;
            this.formalParameter = formalParameter;
        }

        public override void AddToSymbolTable(SymbolTable parent)
        {
            this.parent = parent;
            this.parent.Add(this.methodName, this);
            this.parent.LookUp(this.methodName);
        }

        public override void ResolveNames(SymbolTable parent)
        {
            parent = new SymbolTable(parent);
            foreach (var fParams in formalParameter)
            {
                fParams.AddToSymbolTable(parent);
                fParams.ResolveNames(parent);
                this.parent.LookUp(methodName);
            }

        }

    }

    public class FormalParameter : Declaration
    {
        private Type parameterType;
        private string parameterName;

        public FormalParameter(Type parameterType, string parameterName)
        {
            this.parameterType = parameterType;
            this.parameterName = parameterName;
        }

        public override void AddToSymbolTable(SymbolTable parent)
        {
            parent.Add(parameterName, this);
            parent.LookUp(parameterName);
        }

        public override void ResolveNames(SymbolTable parent)
        {
        }
    }

    public class CompoundDeclaration : Declaration
    {
        private List<Declaration> declarations;

        public CompoundDeclaration(List<Declaration> declarations)
        {
            this.declarations = declarations;
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

    public class CompilationUnitDeclarator : Declaration
    {
        private Node compilationUnit;

        public CompilationUnitDeclarator(Node compilationUnit)
        {
            this.compilationUnit = compilationUnit;
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

    public class VariableDeclarator : Declaration
    {
        private string localVariableDaclaratorName;

        public VariableDeclarator(string localVariableDaclaratorName)
        {
            this.localVariableDaclaratorName = localVariableDaclaratorName;
        }

        public override void AddToSymbolTable(SymbolTable parent)
        {
            parent.Add(this.localVariableDaclaratorName, this);
            parent.LookUp(this.localVariableDaclaratorName);
        }

        public override void ResolveNames(SymbolTable parent)
        {
            //parent.LookUp(localVariableDaclaratorName);
        }


    }

}
