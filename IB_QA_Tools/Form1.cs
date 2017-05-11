using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IB_QA_Tools
{
    public partial class frmMainWindow : Form
    {
        BusinessLogic businessLogic = null;
        string selectedPolicyNumber = "";

        public frmMainWindow()
        {
            InitializeComponent();
            businessLogic = new BusinessLogic();

            // Load all combobox items in payment status combobox
            cbPaymentStatus.Items.Add(new ComboboxItem { Text = "Waiting", Value = "W" });
            cbPaymentStatus.Items.Add(new ComboboxItem { Text = "Pending", Value = "P" });
            cbPaymentStatus.Items.Add(new ComboboxItem { Text = "Successful", Value = "S" });
            cbPaymentStatus.Items.Add(new ComboboxItem { Text = "Dishonoured", Value = "D" });
            cbPaymentStatus.Items.Add(new ComboboxItem { Text = "Fatal Dishonoured", Value = "F" });
            cbPaymentStatus.Items.Add(new ComboboxItem { Text = "Other", Value = "O" });
            cbPaymentStatus.Items.Add(new ComboboxItem { Text = "Scheduled", Value = "PG" });

        }

        private void RefreshPolicyInfoGrid()
        {
            try
            {
                selectedPolicyNumber = txtPolicyNumber.Text.Trim();
                var result = businessLogic.GetInstalmentSchedule(selectedPolicyNumber);
                if (result == null)
                {
                    MessageBox.Show("No payment schedule found", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    gvPaymentSchedule.DataSource = result.Tables[0];
                    gvPaymentSchedule.AutoResizeColumns();
                    gvPaymentSchedule.AutoResizeRows();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshPolicyInfoGrid();
        }

        private void txtPolicyNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtPolicyNumber.Text) == false)
            {
                btnGetSchedule.Visible = true;
            }
            else
            {
                btnGetSchedule.Visible = false;
            }

            if(e.KeyCode == Keys.Enter)
            {
                selectedPolicyNumber = txtPolicyNumber.Text.Trim();
                RefreshPolicyInfoGrid();
            }
        }
        
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                var allSelectedRows = gvPaymentSchedule.SelectedRows;

                for (int i = 0; i < allSelectedRows.Count; i++)
                {
                    int instalmentNumber = Convert.ToInt32(allSelectedRows[i].Cells[0].Value);
                    int retryCount = 0;
                    if (allSelectedRows[i].Cells[5].Value is DBNull)
                    {
                        retryCount = 0;
                    }
                    else
                    {
                        retryCount = Convert.ToInt32(allSelectedRows[i].Cells[5].Value);
                    }

                    string paymentStatus = (cbPaymentStatus.SelectedItem as ComboboxItem).Value.ToString();
                    string failureReason = txtReasonFailure.Text;

                    businessLogic.UpdatePaymentStatus(selectedPolicyNumber, instalmentNumber, retryCount, paymentStatus, failureReason);
                }

                RefreshPolicyInfoGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvPaymentSchedule_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var allSelectedRows = gvPaymentSchedule.SelectedRows;
                if (allSelectedRows.Count > 0)
                {
                    if (allSelectedRows.Count == 1)
                    {
                        var failureReason = allSelectedRows[0].Cells[4].Value;
                        txtReasonFailure.Text = failureReason.ToString();

                        var paymentStat = allSelectedRows[0].Cells[3].Value.ToString();

                        switch (paymentStat)
                        {
                            case "W":
                                cbPaymentStatus.SelectedIndex = 0;
                                break;
                            case "P":
                                cbPaymentStatus.SelectedIndex = 1;
                                break;
                            case "S":
                                cbPaymentStatus.SelectedIndex = 2;
                                break;
                            case "D":
                                cbPaymentStatus.SelectedIndex = 3;
                                break;
                            case "F":
                                cbPaymentStatus.SelectedIndex = 4;
                                break;
                            case "O":
                                cbPaymentStatus.SelectedIndex = 5;
                                break;
                            case "PG":
                                cbPaymentStatus.SelectedIndex = 6;
                                break;
                            default:
                                cbPaymentStatus.SelectedIndex = 5;
                                break;
                        }

                        // Show Delete Retry Button
                        int retryCount = 0;

                        if (allSelectedRows[0].Cells[5].Value is DBNull)
                        {
                            retryCount = 0;
                        }
                        else
                        {
                            retryCount = Convert.ToInt32(allSelectedRows[0].Cells[5].Value);
                        }

                        if (retryCount > 0)
                        {
                            btnDeleteRetry.Visible = true;
                        }
                        else
                        {
                            btnDeleteRetry.Visible = false;
                        }


                        if (retryCount < 2)
                        {
                            btnAddRetry.Visible = true;
                        }
                        else
                        {
                            btnAddRetry.Visible = false;
                        }

                    }
                    else
                    {
                        cbPaymentStatus.SelectedIndex = 2;
                        txtReasonFailure.Text = "";
                        btnDeleteRetry.Visible = false;
                        btnAddRetry.Visible = false;
                    }

                    panelPaymentStatus.Enabled = true;
                }
                else
                {
                    panelPaymentStatus.Enabled = false;
                    btnDeleteRetry.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItemValue = (cbPaymentStatus.SelectedItem as ComboboxItem).Value.ToString();
            if(selectedItemValue == "D")
            {
                txtReasonFailure.Text = "Insufficient Balance";
            }
            else if(selectedItemValue == "F")
            {
                txtReasonFailure.Text = "Fatal Dishonor";
            }
        }
    }
}
