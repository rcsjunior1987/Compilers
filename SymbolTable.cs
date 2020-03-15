using System;
using System.Collections.Generic;
using System.Linq;

namespace GPLexTutorial.AST
{
    public class SymbolTable
    {
        private SymbolTable parent;
        private Dictionary<string, Declaration> table;

        public SymbolTable(SymbolTable parent)
        {
            this.parent = parent;
            this.table = new Dictionary<string, Declaration>();
        }

        public void Add(string name, Declaration decl)
        {

            //Console.Clear();

            table.Add(name, decl);
            foreach (var table in this.table)
            {
                Console.WriteLine("declared {0}", table);
            }
            
        }

        public Declaration LookUp(string name)
        {
            if (table.ContainsKey(name))
            {
                return table[name];
            }
            else if (parent != null)
            {
                return parent.LookUp(name);
            }
            else
            {
                throw new Exception();
            }
        }

    }
}