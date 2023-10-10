using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NavicatClone
{
	public partial class AlterTableCompaireForm : Form
	{
		private Dictionary<string, string> selectedSourceTables;
		private Dictionary<string, string> selectedTargetTables;

		public AlterTableCompaireForm()
		{
			InitializeComponent();
		}

		public void SetSelectedSourceTables(Dictionary<string, string> sourceTables)
		{
			selectedSourceTables = sourceTables;
			PopulateSourceTreeView();
		}

		public void SetSelectedTargetTables(Dictionary<string, string> targetTables)
		{
			selectedTargetTables = targetTables;
			PopulateTargetTreeView();
		}

		private void PopulateSourceTreeView()
		{
			treeView1.Nodes.Clear();
			TreeNode sourceRootNode = new TreeNode("Selected Source Tables");

			foreach (var table in selectedSourceTables)
			{
				TreeNode tableNode = new TreeNode(table.Key);
				tableNode.Tag = table.Value; // Store the SQL query in the tag
				sourceRootNode.Nodes.Add(tableNode);
			}

			treeView1.Nodes.Add(sourceRootNode);
			sourceRootNode.Expand();
		}

		private void PopulateTargetTreeView()
		{
			treeView2.Nodes.Clear();
			TreeNode targetRootNode = new TreeNode("Selected Target Tables");

			foreach (var table in selectedTargetTables)
			{
				TreeNode tableNode = new TreeNode(table.Key);
				tableNode.Tag = table.Value; // Store the SQL query in the tag
				targetRootNode.Nodes.Add(tableNode);
			}

			treeView2.Nodes.Add(targetRootNode);
			targetRootNode.Expand();
		}
	}
}
