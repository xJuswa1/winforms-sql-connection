using TestWins.Controller;

namespace TestWins;

public partial class Form1 : Form
{
    private readonly StudentController controller = new StudentController();

    public Form1()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            dataGridView1.DataSource = controller.getAll();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading data: " + ex.Message);
        }
    }

    private Students GetStudentFromForm(bool includeId = false)
    {
        Students s = new Students()
        {
            Name = txtName.Text,
            Course = txtCourse.Text
        };

        if (int.TryParse(txtAge.Text, out int age))
            s.Age = age;
        else
            throw new Exception("Invalid Age");

        if (includeId)
        {
            if (int.TryParse(txtId.Text, out int id))
                s.Id = id;
            else
                throw new Exception("Invalid ID");
        }

        return s;
    }

    private void ClearFields()
    {
        txtId.Clear();
        txtName.Clear();
        txtAge.Clear();
        txtCourse.Clear();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            var student = GetStudentFromForm();
            controller.insert(student);

            LoadData();
            ClearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Add failed: " + ex.Message);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            var student = GetStudentFromForm(true);
            controller.update(student);

            LoadData();
            ClearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Update failed: " + ex.Message);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
                throw new Exception("Invalid ID");

            controller.delete(id);

            LoadData();
            ClearFields();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Delete failed: " + ex.Message);
        }
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var row = dataGridView1.Rows[e.RowIndex];

        txtId.Text = row.Cells["Id"].Value?.ToString();
        txtName.Text = row.Cells["Name"].Value?.ToString();
        txtAge.Text = row.Cells["Age"].Value?.ToString();
        txtCourse.Text = row.Cells["Course"].Value?.ToString();
    }
}
