using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RoslynSyntaxTree
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntaxTree Tree = CSharpSyntaxTree.ParseText(
                            @"class OrnekClass
                                {
                                    public int OrnekProperty { get; set; }
                                    public void OrnekMetod()
                                    {
 
                                    }
                                    public void OrnekMetod(int x)
                                    {
 
                                    }
 
                                    public void OrnekMetod2()
                                    {
 
                                    }
                                }");
            SyntaxNode Root = Tree.GetRoot();
            var Methods = Root.DescendantNodes().OfType<MethodDeclarationSyntax>().Where(m=> !m.ParameterList.Parameters.Any());
            var Propertys = Root.DescendantNodes().OfType<PropertyDeclarationSyntax>();
            Console.WriteLine("Methods...");
            foreach (var Method in Methods)
            {
                Console.WriteLine(Method.ToString());
            }
            Console.WriteLine("*********\nPropertys...");
            foreach (var Property in Propertys)
            {
                Console.WriteLine(Property.ToString());
            }


            Console.Read();
        }
    }
}
