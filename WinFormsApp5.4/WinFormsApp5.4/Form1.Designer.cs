namespace WinFormsApp5._4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Panel toolbarPanel;
        private Label viewLabel;
        private SplitContainer splitContainer;
        private Panel treePanel;
        private Panel listPanel;
        private TreeView tvDepartments;
        private ListView lsvEmployees;
        private ComboBox cboView;
        private ImageList treeImages;
        private ImageList employeeImages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolbarPanel = new Panel();
            viewLabel = new Label();
            cboView = new ComboBox();
            splitContainer = new SplitContainer();
            treePanel = new Panel();
            tvDepartments = new TreeView();
            listPanel = new Panel();
            lsvEmployees = new ListView();
            treeImages = new ImageList(components);
            employeeImages = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            toolbarPanel.SuspendLayout();
            treePanel.SuspendLayout();
            listPanel.SuspendLayout();
            SuspendLayout();

            toolbarPanel.Controls.Add(cboView);
            toolbarPanel.Controls.Add(viewLabel);
            toolbarPanel.Dock = DockStyle.Top;
            toolbarPanel.Height = 40;

            viewLabel.Location = new Point(10, 10);
            viewLabel.Size = new Size(80, 23);
            viewLabel.Text = "Chế độ xem:";
            viewLabel.TextAlign = ContentAlignment.MiddleLeft;

            cboView.DropDownStyle = ComboBoxStyle.DropDownList;
            cboView.Items.AddRange(new object[] { "Details", "SmallIcon", "LargeIcon", "Tile" });
            cboView.Location = new Point(95, 8);
            cboView.Size = new Size(150, 23);
            cboView.SelectedIndex = 0;

            splitContainer.Dock = DockStyle.Fill;
            splitContainer.FixedPanel = FixedPanel.Panel1;
            splitContainer.Location = new Point(0, 40);
            splitContainer.Name = "splitContainer";
            splitContainer.Panel1.Controls.Add(treePanel);
            splitContainer.Panel1MinSize = 220;
            splitContainer.Panel2.Controls.Add(listPanel);
            splitContainer.Size = new Size(900, 510);
            splitContainer.SplitterDistance = 250;

            treePanel.Controls.Add(tvDepartments);
            treePanel.Dock = DockStyle.Fill;

            tvDepartments.Dock = DockStyle.Fill;
            tvDepartments.Nodes.AddRange(new TreeNode[]
            {
                new TreeNode("Công ty ABC", new TreeNode[]
                {
                    new TreeNode("Kinh doanh", new TreeNode[]
                    {
                        new TreeNode("Miền Bắc"),
                        new TreeNode("Miền Nam")
                    }),
                    new TreeNode("Nhân sự", new TreeNode[]
                    {
                        new TreeNode("Tuyển dụng"),
                        new TreeNode("Đào tạo")
                    }),
                    new TreeNode("Công nghệ thông tin", new TreeNode[]
                    {
                        new TreeNode("Phát triển phần mềm"),
                        new TreeNode("Hạ tầng")
                    })
                })
            });
            tvDepartments.ExpandAll();

            listPanel.Controls.Add(lsvEmployees);
            listPanel.Dock = DockStyle.Fill;

            lsvEmployees.Columns.Add("Mã NV", 80);
            lsvEmployees.Columns.Add("Họ Tên", 150);
            lsvEmployees.Columns.Add("Chức vụ", 150);
            lsvEmployees.Columns.Add("Ngày vào làm", 110);
            lsvEmployees.Columns.Add("Phòng ban", 140);
            lsvEmployees.Dock = DockStyle.Fill;
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
            lsvEmployees.Items.AddRange(new ListViewItem[]
            {
                new ListViewItem(new[] { "NV001", "Nguyễn Minh An", "Trưởng phòng", "12/03/2019", "Kinh doanh" }),
                new ListViewItem(new[] { "NV002", "Trần Thu Hà", "Chuyên viên kinh doanh", "01/06/2021", "Kinh doanh" }),
                new ListViewItem(new[] { "NV003", "Lê Quốc Bảo", "Chuyên viên kinh doanh", "14/02/2022", "Kinh doanh" })
            });
            lsvEmployees.MultiSelect = false;
            lsvEmployees.View = View.Details;

            treeImages.ColorDepth = ColorDepth.Depth32Bit;
            treeImages.ImageSize = new Size(16, 16);
            employeeImages.ColorDepth = ColorDepth.Depth32Bit;
            employeeImages.ImageSize = new Size(32, 32);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            Controls.Add(splitContainer);
            Controls.Add(toolbarPanel);
            MinimumSize = new Size(750, 450);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhân viên";

            listPanel.ResumeLayout(false);
            treePanel.ResumeLayout(false);
            toolbarPanel.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
