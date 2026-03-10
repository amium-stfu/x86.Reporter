using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportExplorer
{
    public partial class frmTreeView : DevExpress.XtraEditors.XtraForm
    {
        public frmTreeView()
        {
            InitializeComponent();
        }

        public void AddTopicToTree(string topic)
        {
     
            if (treeList1.InvokeRequired)
            {
                treeList1.Invoke(new Action(() => AddTopicToTree(topic)));
                return;
            }

            Console.WriteLine("Add to treeView " + topic);
            var parts = topic.Split('/');
            TreeListNode currentNode = null;

            foreach (var part in parts)
            {
                if (currentNode == null)
                {
                    currentNode = treeList1.AppendNode(new object[] { part }, null);
                }
                else
                {
                    currentNode = treeList1.AppendNode(new object[] { part }, currentNode);
                }
            }

        }

        private TreeListNode FindNodeByTopic(string topic)
        {
            // Traverse the TreeList to find the node with the specified topic
            foreach (TreeListNode node in treeList1.Nodes)
            {
                if (node.GetValue(0).ToString() == topic)
                {
                    return node;
                }
                // You can implement a recursive search if you have deeper levels
            }
            return null;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AddTopicToTree("stfu/test/abx");
        }

        private string GetAllValuesAsString(TreeListNode node)
        {
            if (node == null)
                return string.Empty;

            // Create a list to hold the values
            List<string> values = new List<string>();

            // Iterate through the node's values
            for (int i = 0; i < node.TreeList.Columns.Count; i++)
            {
                values.Add(node.GetValue(i)?.ToString() ?? string.Empty);
            }

            // Join the values into a single string
            return string.Join(", ", values);
        }
    }
}