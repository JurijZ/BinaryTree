using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the data set
            var dl = new DataLoader();
            var tree = dl.Load();
            Helper.Log("Tree depth: " + tree.Length);

            // Initialize variables
            var stack = new Stack<Node>();
            Node rootNode = new Node(tree[0][0], 0, true, null);            
            stack.Push(rootNode);
            int depth = 1;
            int sum = 0;

            // Traverse
            while (stack.Count < tree.Length)
            {
                // loop completion
                if (stack.Count == 0)
                {
                    Helper.Log("Traverse completed!!!");
                    break;
                }

                var node = stack.Pop();               

                // Step to the left
                if (Helper.CheckOddEven(tree[depth][node.distance], depth) && node.LeftNotYetVisited())
                {
                    node.left = false;
                    stack.Push(node);

                    stack.Push(new Node( v : tree[depth][node.distance], d : node.distance, left : true, right : null));
                    depth++;
                }
                // Step to the right
                else if (Helper.CheckOddEven(tree[depth][node.distance + 1], depth) && node.RightNotYetVisited())
                {
                    node.left = false;
                    node.right = false;
                    stack.Push(node);

                    stack.Push(new Node(v: tree[depth][node.distance + 1], d: node.distance + 1, left: true, right: true));
                    depth++;
                }
                // Stuck
                else
                {
                    Helper.Log("--Stuck, doing one step back");
                    depth--;
                }

                // When the path reaches the bottom
                if (depth == tree.Length)
                {
                    Helper.Log("Riched the bottom of the Tree!!!");                    

                    // Prniit the path
                    foreach (var s in stack.Reverse())
                    {
                        Helper.Log(s.value);
                    }

                    // Accumulated value
                    if (stack.Select(n => n.value).Aggregate((a, b) => a + b) > sum)
                    {
                        sum = stack.Select(n => n.value).Aggregate((a, b) => a + b);
                    }
                    Helper.Log("Current max Sum: " + sum);
                    
                    Helper.Log("Continue, taking out last node: " + stack.Pop().value);
                    depth--;
                }
            }

            Console.WriteLine("Final max Sum: " + sum);
            Helper.Log("Final max Sum: " + sum);
            Console.ReadLine();
        }        
    }
}
