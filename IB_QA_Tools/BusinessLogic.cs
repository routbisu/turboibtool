using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB_QA_Tools
{
    public class BusinessLogic
    {
        string connectionString = "";
        SqlConnection connection = null;

        public BusinessLogic()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TurboIB"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        #region Enums & Others
        public enum PolicyProductType : int
        {
            HOME = 1,
            LANDLORD = 2,
            MOTOR = 3,
            INVALID = 4,
            NULL = 5
        }
        #endregion

        #region Private Methods
        private DataSet RunSQLQuery(string sqlQuery)
        {
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sqlQuery, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        private Object RunSQLQuerySingleResult(string sqlQuery)
        {
            try
            {
                DataSet dataset = RunSQLQuery(sqlQuery);
                return dataset.Tables[0].Rows[0].ItemArray[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Validates a PolicyNumber to find out Product Type 
        /// </summary>
        /// <param name="policyNumber"></param>
        /// <returns>PolicyProductType Enum - Home, Motor, Landlord or Invalid or Null</returns>
        private PolicyProductType ValidatePolicyNumber(string policyNumber)
        {
            if (string.IsNullOrWhiteSpace(policyNumber))
            {
                return PolicyProductType.NULL;
            }
            else
            {
                // First two characters of Policy number denotes policy type
                // PO - Home, PM - Motor, PL - Landlord
                policyNumber = policyNumber.Trim();
                if (policyNumber.Length > 2)
                {
                    string policyType = policyNumber.Substring(0, 2).ToLower();
                    switch (policyType)
                    {
                        case "po":
                            return PolicyProductType.HOME;
                        case "pl":
                            return PolicyProductType.LANDLORD;
                        case "pm":
                            return PolicyProductType.MOTOR;
                        default:
                            return PolicyProductType.INVALID;
                    }
                }
                else
                {
                    return PolicyProductType.INVALID;
                }
            }
        }

        public long GetPolicyInstalmentIdFromPolicyNumber(string policyNumber, PolicyProductType productType)
        {
            try
            {
                string sql = "JUNK", sqlQueryFormat = "Select TOP 1 {0}PolicyInstalmentID From {0}PolicyInstalmentSetup Where PolicyNumber = '{1}' And IsActive = 1";
                
                switch (productType)
                {
                    case PolicyProductType.HOME:
                        sql = String.Format(sqlQueryFormat, "HomeContent", policyNumber);
                        break;
                    case PolicyProductType.LANDLORD:
                        sql = String.Format(sqlQueryFormat, "Landlord", policyNumber);
                        break;
                    case PolicyProductType.MOTOR:
                        sql = String.Format(sqlQueryFormat, "Motor", policyNumber);
                        break;
                }

                return Convert.ToInt64(RunSQLQuerySingleResult(sql));
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }
        #endregion


        #region Public Methods
        public DataSet GetInstalmentSchedule(string policyNumber)
        {
            PolicyProductType productType = ValidatePolicyNumber(policyNumber);
            long policyInstalmentID = GetPolicyInstalmentIdFromPolicyNumber(policyNumber, productType);

            if(policyInstalmentID > 0)
            {
                string sql, sqlFormat = "Select InstalmentNumber, InstalmentDate, InstalmentAmount, PaymentStatusCode, ReasonForFailure, RetryCount, RetryDate From {0} Where {1} = {2} Order By InstalmentNumber, RetryCount Asc";

                switch (productType)
                {
                    case PolicyProductType.HOME:
                        sql = String.Format(sqlFormat, "HomeContentPolicyPaymentScheduleDetails", "HomeContentPolicyInstalmentId", policyInstalmentID.ToString());
                        var resultH = RunSQLQuery(sql);
                        return resultH;

                    case PolicyProductType.LANDLORD:
                        sql = String.Format(sqlFormat, "LandlordPolicyPaymentScheduleDetails", "LandlordPolicyInstalmentId", policyInstalmentID.ToString());
                        var resultL = RunSQLQuery(sql);
                        return resultL;

                    case PolicyProductType.MOTOR:
                        sql = String.Format(sqlFormat, "MotorPolicyPaymentScheduleDetails", "MotorPolicyInstalmentId", policyInstalmentID.ToString());
                        var resultM = RunSQLQuery(sql);
                        return resultM;
                }

                return null;
            }
            else
            {
                return null;
            }
        }

        public int UpdatePaymentStatus(string policyNumber, int instalmentNumber, int retryCount, string paymentStatus, string failureReason)
        {
            try
            {
                PolicyProductType productType = ValidatePolicyNumber(policyNumber);
                long policyInstalmentID = GetPolicyInstalmentIdFromPolicyNumber(policyNumber, productType);

                string sql = "JUNK", sqlFormat = "Update {0}PolicyPaymentScheduleDetails Set PaymentStatusCode = '{1}', ReasonForFailure = '{5}' Where InstalmentNumber = {2} And RetryCount = {3} And {0}PolicyInstalmentID = {4}";

                switch (productType)
                {
                    case PolicyProductType.HOME:
                        sql = string.Format(sqlFormat, "HomeContent", paymentStatus, instalmentNumber, retryCount, policyInstalmentID, failureReason);
                        break;
                    case PolicyProductType.LANDLORD:
                        sql = string.Format(sqlFormat, "Landlord", paymentStatus, instalmentNumber, retryCount, policyInstalmentID, failureReason);
                        break;
                    case PolicyProductType.MOTOR:
                        sql = string.Format(sqlFormat, "Motor", paymentStatus, instalmentNumber, retryCount, policyInstalmentID, failureReason);
                        break;
                }

                connection.Open();

                SqlCommand updateCommand = new SqlCommand(sql, connection);
                return updateCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
