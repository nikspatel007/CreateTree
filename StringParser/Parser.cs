using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringParser
{
   /// <summary>
   /// Parse class creates a list of nodes and root at each depth to create ultimate tree structure
   /// It also allows to put all of them in order.
   /// </summary>
    public class Parser
    {
        private readonly List<Node> _nodes;
        private readonly Dictionary<int, string> _connections;
        private readonly string _originalValue;

        public Parser(string record)
        {
            _connections = new Dictionary<int, string>();
            _nodes = new List<Node>();
            _originalValue = CleanString(record);
        }

        /// <summary>
        /// Parses string and create List of nodes to create tree structure using ToString() function.
        /// Returns the same object after modifying it.
        /// </summary>
        /// <returns></returns>
        public Parser Parse()
        {
            string currentString = string.Empty;
            int depth = -1;
            _connections.Add(-1,"");
            char[] chars = _originalValue.ToCharArray();

            foreach (var c in chars)
            {
                switch (c)
                {
                    case '(':
                        AddToNode(depth, currentString);
                        depth += 1;
                        _connections.Add(depth,currentString);
                        currentString = string.Empty;
                        break;
                    case ',':
                        if (!string.IsNullOrEmpty(currentString))
                        {
                            AddToNode(depth, currentString);
                            currentString = string.Empty;
                        }
                        break;
                    case ')':
                        AddToNode(depth, currentString);
                        depth -= 1;
                        currentString = string.Empty;
                        break;
                    default:
                        currentString += c;
                        break;
                }
            }

            //In case pure string without brackets was passed.
            if (!_nodes.Any())
            {
                AddToNode(depth, currentString);
            }
            return this;
        }

        /// <summary>
        /// Writes All nodes in an Ordered tree structure to the console using recursion.
        /// </summary>
        /// <param name="depth">depth of the tree</param>
        /// <param name="value">value to be examined.</param>
        public void WriteInOrder(int depth = -1, string value = "")
        {
            var nodes = _nodes.Where(x => x.Depth == depth).OrderBy(x => x.Value);
            foreach (var node in nodes)
            {
                Console.WriteLine($"{CreateDashes(depth)} {node.Value}");
                if (_connections.ContainsKey(depth) && _connections.ContainsValue(node.Value))
                {
                    WriteInOrder(depth + 1, node.Value);
                }
            }
        }

        #region Private functions and classes.

        /// <summary>
        /// Add to the list. Seperated out to make sure we can have easily add optional parameter without changing other calls.
        /// </summary>
        /// <param name="depth">Depth at which value exists.</param>
        /// <param name="value">Value to be stored.</param>
        private void AddToNode(int depth, string value)
        {
            _nodes.Add(new Node(depth, value));
        }

        /// <summary>
        /// Removes unnecessary characters from the original string.
        /// </summary>
        /// <param name="record">String to be cleaned.</param>
        /// <returns>modified string.</returns>
        private string CleanString(string record)
        {            
            return record
                .Replace(" ", "")
                .Replace(@"\", "");
        }

        /// <summary>
        /// Creates dashes based on the depth.
        /// There is a scope to improve this function as everytime ToString or InOrder function is called,
        /// It will be required to create dashes.
        /// </summary>
        /// <param name="dash">dahses based on the depth</param>
        /// <returns></returns>
        private string CreateDashes(int dash)
        {
            string record = string.Empty;
            for (int i = 0; i < dash; i++)
            {
                record += "-";
            }
            return record;
        }

        /// <summary>
        /// Node is a list that includes key (depth) and value (record) attached to it.
        /// This class allows to create multiple keys with same mechanism.
        /// </summary>
        private class Node
        {
            public Node(int depth, string value)
            {
                Depth = depth;
                Value = value;
            }

            public int Depth { get; }

            public string Value { get; }
        }

        #endregion

        /// <summary>
        /// Returns String in a tree format.
        /// Easy to test in future as well , this string can written to multiple persistence mechanisms easily.
        /// </summary>
        /// <returns>String in a tree format.</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var node in _nodes)
            {
                stringBuilder.Append($"{CreateDashes(node.Depth)} {node.Value} {Environment.NewLine}");
            }

            return stringBuilder.ToString();
        }

    }
}