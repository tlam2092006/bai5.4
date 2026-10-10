namespace WinFormsApp5._4
{
    public partial class Form1 : Form
    {
        private readonly List<Employee> employees =
        [
            new("NV001", "Nguyễn Minh An", "Trưởng phòng", "Kinh doanh", "Miền Bắc", new DateTime(2019, 3, 12)),
            new("NV002", "Trần Thu Hà", "Chuyên viên kinh doanh", "Kinh doanh", "Miền Bắc", new DateTime(2021, 6, 1)),
            new("NV003", "Lê Quốc Bảo", "Chuyên viên kinh doanh", "Kinh doanh", "Miền Nam", new DateTime(2022, 2, 14)),
            new("NV004", "Phạm Ngọc Linh", "Trưởng phòng", "Nhân sự", "Tuyển dụng", new DateTime(2018, 9, 10)),
            new("NV005", "Võ Thanh Tùng", "Chuyên viên nhân sự", "Nhân sự", "Tuyển dụng", new DateTime(2023, 4, 3)),
            new("NV006", "Đặng Mỹ Duyên", "Chuyên viên nhân sự", "Nhân sự", "Đào tạo", new DateTime(2020, 11, 23)),
            new("NV007", "Hoàng Gia Huy", "Trưởng phòng", "Công nghệ thông tin", "Phát triển phần mềm", new DateTime(2017, 5, 8)),
            new("NV008", "Bùi Hải Yến", "Lập trình viên", "Công nghệ thông tin", "Phát triển phần mềm", new DateTime(2022, 8, 15)),
            new("NV009", "Ngô Đức Long", "Quản trị hệ thống", "Công nghệ thông tin", "Hạ tầng", new DateTime(2021, 1, 4))
        ];

        public Form1()
        {
            InitializeComponent();
            InitializeImages();
            tvDepartments.AfterSelect += (_, e) => ShowEmployees(e.Node);
            cboView.SelectedIndexChanged += (_, _) =>
            {
                lsvEmployees.View = cboView.SelectedItem?.ToString() switch
                {
                    "SmallIcon" => View.SmallIcon,
                    "LargeIcon" => View.LargeIcon,
                    "Tile" => View.Tile,
                    _ => View.Details
                };
            };
            BuildDepartmentTree();
        }

        private void InitializeImages()
        {
            treeImages.Images.Add("company", SystemIcons.Application.ToBitmap());
            treeImages.Images.Add("department", SystemIcons.Shield.ToBitmap());
            treeImages.Images.Add("team", SystemIcons.Information.ToBitmap());
            tvDepartments.ImageList = treeImages;
            var companyNode = tvDepartments.Nodes[0];
            companyNode.ImageKey = companyNode.SelectedImageKey = "company";
            foreach (TreeNode departmentNode in companyNode.Nodes)
            {
                departmentNode.ImageKey = departmentNode.SelectedImageKey = "department";
                foreach (TreeNode teamNode in departmentNode.Nodes)
                    teamNode.ImageKey = teamNode.SelectedImageKey = "team";
            }

            employeeImages.Images.Add("employee", SystemIcons.Information.ToBitmap());
            lsvEmployees.SmallImageList = employeeImages;
            lsvEmployees.LargeImageList = employeeImages;
        }

        private void BuildDepartmentTree()
        {
            tvDepartments.ExpandAll();
            tvDepartments.SelectedNode = tvDepartments.Nodes[0];
        }

        private void ShowEmployees(TreeNode selectedNode)
        {
            IEnumerable<Employee> matches = selectedNode.Level switch
            {
                1 => employees.Where(employee => employee.Department == selectedNode.Text),
                2 => employees.Where(employee => employee.Department == selectedNode.Parent!.Text && employee.Team == selectedNode.Text),
                _ => employees
            };

            lsvEmployees.BeginUpdate();
            lsvEmployees.Items.Clear();
            foreach (var employee in matches)
            {
                var item = new ListViewItem(employee.Id, "employee");
                item.SubItems.Add(employee.FullName);
                item.SubItems.Add(employee.Position);
                item.SubItems.Add(employee.StartDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(employee.Department);
                item.Tag = employee;
                lsvEmployees.Items.Add(item);
            }
            lsvEmployees.EndUpdate();
        }

        private sealed record Employee(string Id, string FullName, string Position, string Department, string Team, DateTime StartDate);
    }
}
