using System;
using System.Windows.Forms;

namespace EmployeeSalaryCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get user inputs
            string employeeName = textBox1.Text;
            string selectedGrade = comboBox1.SelectedItem.ToString();
            int basicSalary = 0;
            int housingAllowance = 0;
            int conveyanceAllowance = 0;
            int otherBenefit1 = 0;
            int otherBenefit2 = 0;

            if (selectedGrade == "Director")
            {
                basicSalary = 100000;
            }
            else if (selectedGrade == "Manager")
            {
                basicSalary = 50000;
            }
            else if (selectedGrade == "Project Manager")
            {
                basicSalary = 40000;
            }
            else if (selectedGrade == "Programmer")
            {
                basicSalary = 30000;
            }

            if (checkBox1.Checked)
            {
                housingAllowance = 20000;
            }
            if (checkBox2.Checked)
            {
                conveyanceAllowance = 15000;
            }
            if (checkBox3.Checked)
            {
                otherBenefit1 = 10000;
            }
            if (checkBox4.Checked)
            {
                otherBenefit2 = 10000;
            }

            int projectCompletionBonus = 0;
            int yearEndBonus = 0;
            int performanceBonus = 0;
            int customerAppreciationBonus = 0;

            foreach (var item in BonusesCheckedListBox.CheckedItems)
            {
                string bonusItem = item.ToString();
                if (bonusItem == "Project Completion Bonus")
                {
                    projectCompletionBonus = 20000;
                }
                else if (bonusItem == "Year End Bonus")
                {
                    yearEndBonus = 30000;
                }
                else if (bonusItem == "Performance Bonus")
                {
                    performanceBonus = 25000;
                }
                else if (bonusItem == "Customer Appreciation Bonus")
                {
                    customerAppreciationBonus = 15000;
                }
            }

            // Calculate total salary
            int totalSalary = basicSalary + housingAllowance + conveyanceAllowance +
                otherBenefit1 + otherBenefit2 + projectCompletionBonus +
                yearEndBonus + performanceBonus + customerAppreciationBonus;

            // Deductions
            if (!string.IsNullOrEmpty(groupBox4.Text))
            {
                int deductions = int.Parse(groupBox4.Text);
                totalSalary -= deductions;
            }

            // Display the result
            string result = $"Employee Name: {employeeName}\n" +
                $"Employee Grade: {selectedGrade}\n" +
                $"Total Salary: {totalSalary:C}";

            MessageBox.Show(result, "Salary Calculation Result");
        }
    }
}

