using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{

    public abstract class Node
    {
        public abstract void ResolveNames(SymbolTable parent);

        void Indent(int n)
        {
            //for (int i = 0; i < n; i++)
                //Console.Write("    ");
        }       

        public void DumpValue(int indent = 0)
        {
            Indent(indent);
            //Console.WriteLine("{0}", GetType().ToString());

            Indent(indent);
            //Console.WriteLine("{");

            foreach (var field in GetType().GetFields(System.Reflection.BindingFlags.NonPublic |
                                                      System.Reflection.BindingFlags.Instance))
            {
                object value = field.GetValue(this);
                Indent(indent + 1);

                // Is this value something we can iterate through?
                // We test that it is a generic type, this way we don't treat strings as IEnumerables.
                if (value is System.Collections.IEnumerable && value.GetType().IsGenericType)
                {
                    //Console.WriteLine("{0}:", field.Name);
                    Indent(indent + 1);
                    //Console.WriteLine("{");

                    foreach (object item in (System.Collections.IEnumerable)value)
                    {
                        if (item is Node)
                        {
                            ((Node)item).DumpValue(indent + 2);
                        }
                        else
                        {
                            Indent(indent + 2);
                            //Console.WriteLine("{0}", item);
                        }
                    }

                    Indent(indent + 1);
                    //Console.WriteLine("}");
                }
                else if (value is Node)
                {
                    //Console.WriteLine("{0}:", field.Name);
                    ((Node)value).DumpValue(indent + 2);
                }
                else
                {
                    //Console.WriteLine("{0}: {1}", field.Name, value);
                }
            }

            Indent(indent);
            //Console.WriteLine("}");

        }
    }

    public class CompilationUnit : Node
    {
        private List<Declaration> declarations;
        private SymbolTable parent;

        public CompilationUnit(List<Declaration> declarations)
        {
            this.declarations = declarations;          
        }

        public override void ResolveNames(SymbolTable parent)
        {
            this.parent = new SymbolTable(parent);
            foreach (var declaration in declarations)
            {
                declaration.AddToSymbolTable(this.parent);
                declaration.ResolveNames(this.parent);
            }
        }

    }

    public abstract class Declaration : Node
    {
        public abstract void AddToSymbolTable(SymbolTable symbolTable);
    }

    public abstract class Statement : Node
    {
        public abstract void AddToSymbolTable(SymbolTable symbolTable);
    }

    public abstract class Expression : Node
    {
    }

    public abstract class Operator : Node
    {
    }

    public abstract class Type : Node
    {
    }

}