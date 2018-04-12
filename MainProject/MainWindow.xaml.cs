using System.Windows.Controls;
using System.Windows.Input;


namespace MainProject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Child_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeItem = sender as TreeViewItem;
            if (treeItem == null) return;
            var tree = treeItem.Parent as TreeView;
            if (tree != null)
            {
                var view = tree.SelectedItem as TreeViewItem;
                if (view != null && view.HasItems)
                {
                    view.IsExpanded = !view.IsExpanded;
                }
            }
        }
    }
}
