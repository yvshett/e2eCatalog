using DadtApi.CommonUtility;
using DadtApi.Context;
using DadtApi.DomainModels;
using Microsoft.EntityFrameworkCore;
using Novell.Directory.Ldap;
using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;

namespace IAPServices.CommonUtility
{
    public class AdGroup
    {
        public string GroupNm { get; set; }
    }
    public class ADGroupSearch
    {
        public string Id { get; set; }
        public string DisplayNm { get; set; }
    }
    public class ActiveDirectory
    {

        #region "Properties"
        public string UserID { get; set; }
        public string WWID { get; set; }
        public string EmailAddress { get; set; }
        public string IDSID { get; set; }
        public string BuildingCode { get; set; }
        public string PhoneBookName { get; set; }
        public string PhoneNumber { get; set; }
        public string RegionCode { get; set; }
        public string SiteCode { get; set; }
        public string BadgeType { get; set; }
        public string MailStop { get; set; }
        public string AdsPath { get; set; }
        public Dictionary<string, string> ADGroups { get; set; }
        public string CostCenter { get; set; }
        public Dictionary<string, string> ExtProperties { get; set; }

        public string this[string index]
        {
            get
            {
                if (ExtProperties == null || !ExtProperties.ContainsKey(index.ToLower()))
                {
                    return "";
                }

                return ExtProperties[index.ToLower()];

            }
        }

        #endregion
    }
    /// <summary>
    /// Enum to provide the type of search needed
    /// </summary>
    /// <remarks></remarks>
    public enum SearchInput
    {
        SI_WWID = 1,
        SI_IDSID = 2,
        SI_NAME = 3,
        SI_EMAIL = 4
    }
    public interface IActiveDirectoryService
    {
        public bool Memberof(string GroupName);
        public ActiveDirectory FindEmployee(string SearchText, SearchInput Type, bool EmployeesOnly, String[] ExtPropertyNames = null);
        public ActiveDirectory[] SearchforEmployee(string SearchName, bool EmployeesOnly, int SizeLimit, String[] ExtPropertyNames = null);
        public ActiveDirectory[] SearchEmployees(string SearchText, bool EmployeesOnly, int SizeLimit, String[] ExtPropertyNames = null);
        public ActiveDirectory getUser(string UserKey, SearchInput Type, String[] ExtPropertyNames = null);
        public ActiveDirectory CurrentUser();
        public ADGroupSearch[] SearchADGroups(string SearchText, int? SizeLimit);
        Task<IEnumerable<WorkerSearch>> GetLdapWorkerSearch(string search, int? resultSize);
        Task<List<ADGroupSearch>> GetPAMSafeAccounts(int applicationId);

    }
    public class ActiveDirectoryService : IActiveDirectoryService
    {
        private readonly dbContext _context;
        public ActiveDirectoryService(dbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Function to check whether the current employee is a member of the specified group.
        /// </summary>
        /// <param name="GroupName">Name of ther group to check</param>
        /// <returns>Boolean. True if this employee is a member of the provided group Name</returns>
        /// <remarks></remarks>
        public bool Memberof(string GroupName)
        {
            try
            {
                //if (ADGroups == null) return false;
                //else return ADGroups.ContainsKey(GroupName.ToLower());
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Function to Find an Active directory account using either WWID, IDSID, Name or Email Address.
        /// </summary>
        /// <param name="SearchText">Text to search for</param>
        /// <param name="Type">SearchInput options: SI_WWID, SI_IDSID, SI_NAME, SI_EMAIL</param>
        /// <param name="EmployeesOnly">True - Only return Individual accounts, False - Return all accounts: Generic or Individual</param>
        /// <param name="ExtPropertyNames">String Array of Active Directory property names to include when searching for employee</param>
        /// <returns>Worker</returns>
        /// <remarks></remarks>
        public ActiveDirectory FindEmployee(string SearchText, SearchInput Type, bool EmployeesOnly, String[] ExtPropertyNames = null)
        {
            ActiveDirectory ReturnValue = null;
            try
            {
                DirectoryEntry oGCDirectoryEntry = null;
                oGCDirectoryEntry = new DirectoryEntry("GC:");
                IEnumerator ie = oGCDirectoryEntry.Children.GetEnumerator();
                ie.MoveNext();
                oGCDirectoryEntry = (DirectoryEntry)ie.Current;

                string sQueryStr = "(&(objectCategory=user)(objectclass=user)";
                if (Type == SearchInput.SI_WWID)
                {
                    if (EmployeesOnly == true)
                    {
                        sQueryStr += "(intelflags=1)";
                    }
                    sQueryStr += "(mail=*)(EmployeeID=" + SearchText + ")";
                }
                else if (Type == SearchInput.SI_IDSID)
                {
                    if (SearchText.IndexOf("\\") != -1) SearchText = SearchText.Substring(SearchText.IndexOf("\\") + 1);

                    sQueryStr += "(mail=*)(samaccountname=" + SearchText + ")";
                }
                else if (Type == SearchInput.SI_NAME)
                {
                    sQueryStr += "(cn=" + SearchText + ")";
                }
                else if (Type == SearchInput.SI_EMAIL)
                {
                    sQueryStr += "(mail=" + SearchText + ")";
                }
                sQueryStr += ")";

                List<String> ADColumns = new List<string>(new string[] { "Name", "Mail", "EmployeeID", "telephonenumber", "streetaddress", "mailNickname", "intelsitecode", "intelBldgCode", "intelregioncode", "employeeBadgeType", "department", "memberof" });
                if (ExtPropertyNames != null)
                {
                    ADColumns.AddRange(ExtPropertyNames);
                }

                DirectorySearcher DS = new DirectorySearcher(oGCDirectoryEntry, sQueryStr, ADColumns.ToArray(), SearchScope.Subtree);

                DS.Sort = new System.DirectoryServices.SortOption("Name", SortDirection.Ascending);
                DS.CacheResults = false;
                DS.ReferralChasing = ReferralChasingOption.None;
                DS.PropertyNamesOnly = false;
                SearchResult oSearchResult = DS.FindOne();

                if (oSearchResult != null)
                {
                    ActiveDirectory Employee = new ActiveDirectory();
                    if (oSearchResult.Properties["EmployeeID"].Count == 1) { Employee.WWID = oSearchResult.Properties["EmployeeID"][0].ToString(); }
                    if (oSearchResult.Properties["intelsitecode"].Count == 1) { Employee.SiteCode = oSearchResult.Properties["intelsitecode"][0].ToString(); }

                    if (oSearchResult.Properties["intelBldgCode"].Count == 1) { Employee.BuildingCode = oSearchResult.Properties["intelBldgCode"][0].ToString(); }
                    if (oSearchResult.Properties["intelregioncode"].Count == 1) { Employee.RegionCode = oSearchResult.Properties["intelregioncode"][0].ToString(); }
                    if (oSearchResult.Properties["telephonenumber"].Count == 1) { Employee.PhoneNumber = oSearchResult.Properties["telephonenumber"][0].ToString(); }
                    if (oSearchResult.Properties["Name"].Count == 1) { Employee.PhoneBookName = oSearchResult.Properties["Name"][0].ToString(); }
                    if (oSearchResult.Properties["mailNickname"].Count == 1) { Employee.IDSID = oSearchResult.Properties["mailNickname"][0].ToString(); }
                    if (oSearchResult.Properties["Mail"].Count == 1) { Employee.EmailAddress = oSearchResult.Properties["Mail"][0].ToString(); }
                    if (oSearchResult.Properties["employeeBadgeType"].Count == 1) { Employee.BadgeType = oSearchResult.Properties["employeeBadgeType"][0].ToString(); }
                    if (oSearchResult.Properties["streetaddress"].Count == 1) { Employee.MailStop = oSearchResult.Properties["streetaddress"][0].ToString(); }
                    if (oSearchResult.Properties["department"].Count == 1) { Employee.CostCenter = oSearchResult.Properties["department"][0].ToString(); }
                    if (oSearchResult.Properties["adspath"].Count == 1) { Employee.AdsPath = oSearchResult.Properties["adspath"][0].ToString().Replace("GC://", "LDAP://"); }

                    //Dictionary<string, string> ADGroups = new Dictionary<string, string>();
                    //foreach (string ADGroup in oSearchResult.Properties["Memberof"])
                    //{
                    //    string groupName = ADGroup.Substring(3, ADGroup.IndexOf(",") - 3);
                    //    if (ADGroups.ContainsKey(groupName.ToLower()) == false) { ADGroups.Add(groupName.ToLower(), groupName); }
                    //}
                    //Employee.ADGroups = ADGroups;

                    if (ExtPropertyNames != null)
                    {
                        Employee.ExtProperties = new Dictionary<String, String>();
                        foreach (string Ext in ExtPropertyNames)
                        {
                            if (!Employee.ExtProperties.ContainsKey(Ext.ToLower()) && oSearchResult.Properties[Ext].Count == 1)
                            {
                                Employee.ExtProperties.Add(Ext.ToLower(), oSearchResult.Properties[Ext][0].ToString());
                            }
                        }
                    }

                    ReturnValue = Employee;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return ReturnValue;
        }
        /// <summary>
        /// Function to search for a list of active directory accounts that meet the part of the name provided
        /// </summary>
        /// <param name="SearchName">Name of employee to search for. Partial names can be used.</param>
        /// <param name="EmployeesOnly">True - Only return Individual accounts, False - Return all accounts: Generic or Individual</param>
        /// <param name="SizeLimit">Limit the return array. Default is 50</param>
        /// <returns>An array of Worker objects</returns>
        /// <remarks></remarks>
        public ActiveDirectory[] SearchforEmployee(string SearchName, bool EmployeesOnly, int SizeLimit, String[] ExtPropertyNames = null)
        {
            ActiveDirectory[] ReturnValue = null;
            try
            {
                DirectoryEntry oGCDirectoryEntry = null;
                oGCDirectoryEntry = new DirectoryEntry("GC:");
                IEnumerator ie = oGCDirectoryEntry.Children.GetEnumerator();
                ie.MoveNext();
                oGCDirectoryEntry = (DirectoryEntry)ie.Current;
                string sQueryStr = "(&(objectCategory=user)(objectclass=user)";
                if (EmployeesOnly == true) { sQueryStr += "(intelflags=1)"; }
                sQueryStr += "(Name=" + SearchName + "*))";

                List<String> ADColumns = new List<string>(new string[] { "Name", "intelBldgCode", "Mail", "EmployeeID", "telephonenumber", "streetaddress", "mailNickname" });
                if (ExtPropertyNames != null)
                {
                    ADColumns.AddRange(ExtPropertyNames);
                }

                DirectorySearcher DS = new DirectorySearcher(oGCDirectoryEntry, sQueryStr, ADColumns.ToArray(), SearchScope.Subtree);

                DS.Sort = new System.DirectoryServices.SortOption("Name", SortDirection.Ascending);
                DS.CacheResults = false;
                DS.ReferralChasing = ReferralChasingOption.None;
                DS.SizeLimit = SizeLimit;
                DS.PropertyNamesOnly = false;
                SearchResultCollection oSearchResultColl = DS.FindAll();

                if (oSearchResultColl != null)
                {
                    ArrayList Employees = new ArrayList();
                    foreach (SearchResult oSearchResult in oSearchResultColl)
                    {
                        ActiveDirectory Employee = new ActiveDirectory();
                        if (oSearchResult.Properties["EmployeeID"].Count == 1) { Employee.WWID = oSearchResult.Properties["EmployeeID"][0].ToString(); }
                        if (oSearchResult.Properties["telephonenumber"].Count == 1) { Employee.PhoneNumber = oSearchResult.Properties["telephonenumber"][0].ToString(); }
                        if (oSearchResult.Properties["intelBldgCode"].Count == 1) { Employee.BuildingCode = oSearchResult.Properties["intelBldgCode"][0].ToString(); }

                        if (oSearchResult.Properties["Name"].Count == 1) { Employee.PhoneBookName = oSearchResult.Properties["Name"][0].ToString(); }
                        if (oSearchResult.Properties["mailNickname"].Count == 1) { Employee.IDSID = oSearchResult.Properties["mailNickname"][0].ToString(); }
                        if (oSearchResult.Properties["Mail"].Count == 1) { Employee.EmailAddress = oSearchResult.Properties["Mail"][0].ToString(); }
                        if (oSearchResult.Properties["streetaddress"].Count == 1) { Employee.MailStop = oSearchResult.Properties["streetaddress"][0].ToString(); }
                        if (oSearchResult.Properties["department"].Count == 1) { Employee.CostCenter = oSearchResult.Properties["department"][0].ToString(); }

                        if (ExtPropertyNames != null)
                        {
                            Employee.ExtProperties = new Dictionary<String, String>();
                            foreach (string Ext in ExtPropertyNames)
                            {
                                if (!Employee.ExtProperties.ContainsKey(Ext.ToLower()) && oSearchResult.Properties[Ext].Count == 1)
                                {
                                    Employee.ExtProperties.Add(Ext.ToLower(), oSearchResult.Properties[Ext][0].ToString());
                                }
                            }
                        }

                        Employees.Add(Employee);
                    }
                    ReturnValue = (ActiveDirectory[])(Employees.ToArray(typeof(ActiveDirectory)));
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return ReturnValue;
        }

        /// <summary>
        /// Function to search for a list of active directory accounts that meet the part of the name provided
        /// </summary>
        /// <param name="SearchText">Name of employee to search for. Partial names can be used.</param>
        /// <param name="EmployeesOnly">True - Only return Individual accounts, False - Return all accounts: Generic or Individual</param>
        /// <param name="SizeLimit">Limit the return array. Default is 50</param>
        /// <returns>An array of Worker objects</returns>
        /// <remarks></remarks>
        public ActiveDirectory[] SearchEmployees(string SearchText, bool EmployeesOnly, int SizeLimit, String[] ExtPropertyNames = null)
        {
            ActiveDirectory[] ReturnValue = null;
            try
            {
                DirectoryEntry oGCDirectoryEntry = null;
                oGCDirectoryEntry = new DirectoryEntry("GC:");
                IEnumerator ie = oGCDirectoryEntry.Children.GetEnumerator();
                ie.MoveNext();
                oGCDirectoryEntry = (DirectoryEntry)ie.Current;
                string sQueryStr = "(&(objectCategory=user)(objectclass=user)";
                if (EmployeesOnly == true) { sQueryStr += "(intelflags=1)"; }

                int wwid;
                if (int.TryParse(SearchText, out wwid))
                {
                    sQueryStr += "(mail=*)(EmployeeID=" + SearchText + "*))";
                }
                else
                {
                    if (SearchText.IndexOf("\\") != -1) SearchText = SearchText.Substring(SearchText.IndexOf("\\") + 1);
                    sQueryStr += "(mail=*)(|(samaccountname=" + SearchText + "*)(Name=" + SearchText + "*)))";
                }

                List<String> ADColumns = new List<string>(new string[] { "Name", "intelBldgCode", "Mail", "EmployeeID", "telephonenumber", "streetaddress", "mailNickname" });
                if (ExtPropertyNames != null)
                {
                    ADColumns.AddRange(ExtPropertyNames);
                }

                DirectorySearcher DS = new DirectorySearcher(oGCDirectoryEntry, sQueryStr, ADColumns.ToArray(), SearchScope.Subtree);

                DS.Sort = new System.DirectoryServices.SortOption("Name", SortDirection.Ascending);
                DS.CacheResults = false;
                DS.ReferralChasing = ReferralChasingOption.None;
                DS.SizeLimit = SizeLimit;
                DS.PropertyNamesOnly = false;
                SearchResultCollection oSearchResultColl = DS.FindAll();

                if (oSearchResultColl != null)
                {
                    ArrayList Employees = new ArrayList();
                    foreach (SearchResult oSearchResult in oSearchResultColl)
                    {
                        ActiveDirectory Employee = new ActiveDirectory();
                        if (oSearchResult.Properties["EmployeeID"].Count == 1) { Employee.WWID = oSearchResult.Properties["EmployeeID"][0].ToString(); }
                        if (oSearchResult.Properties["telephonenumber"].Count == 1) { Employee.PhoneNumber = oSearchResult.Properties["telephonenumber"][0].ToString(); }
                        if (oSearchResult.Properties["intelBldgCode"].Count == 1) { Employee.BuildingCode = oSearchResult.Properties["intelBldgCode"][0].ToString(); }

                        if (oSearchResult.Properties["Name"].Count == 1) { Employee.PhoneBookName = oSearchResult.Properties["Name"][0].ToString(); }
                        if (oSearchResult.Properties["mailNickname"].Count == 1) { Employee.IDSID = oSearchResult.Properties["mailNickname"][0].ToString(); }
                        if (oSearchResult.Properties["Mail"].Count == 1) { Employee.EmailAddress = oSearchResult.Properties["Mail"][0].ToString(); }
                        if (oSearchResult.Properties["streetaddress"].Count == 1) { Employee.MailStop = oSearchResult.Properties["streetaddress"][0].ToString(); }
                        if (oSearchResult.Properties["department"].Count == 1) { Employee.CostCenter = oSearchResult.Properties["department"][0].ToString(); }

                        if (ExtPropertyNames != null)
                        {
                            Employee.ExtProperties = new Dictionary<String, String>();
                            foreach (string Ext in ExtPropertyNames)
                            {
                                if (!Employee.ExtProperties.ContainsKey(Ext.ToLower()) && oSearchResult.Properties[Ext].Count == 1)
                                {
                                    Employee.ExtProperties.Add(Ext.ToLower(), oSearchResult.Properties[Ext][0].ToString());
                                }
                            }
                        }

                        Employees.Add(Employee);
                    }
                    ReturnValue = (ActiveDirectory[])(Employees.ToArray(typeof(ActiveDirectory)));
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return ReturnValue;
        }

        /// <summary>
        /// Function to get user information using the user key for the type specified.
        /// </summary>
        /// <param name="UserKey">Text of the key. Can be WWID, IDSID, Name or Email Address</param>
        /// <param name="Type">SearchInput options: SI_WWID, SI_IDSID, SI_NAME, SI_EMAIL</param>
        /// <returns>Worker</returns>
        /// <remarks></remarks>
        public ActiveDirectory getUser(string UserKey, SearchInput Type, String[] ExtPropertyNames = null)
        {
            try
            {
                bool EmployeesOnly = false;
                if (Type == SearchInput.SI_WWID) { EmployeesOnly = true; }

                ActiveDirectory Employee = FindEmployee(UserKey, Type, EmployeesOnly, ExtPropertyNames);

                if (Employee == null)
                {
                    Employee = new ActiveDirectory();

                    if (Type == SearchInput.SI_WWID) { Employee.WWID = UserKey; }
                    Employee.PhoneBookName = "*Not Found* " + UserKey;
                }
                return Employee;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public ActiveDirectory CurrentUser()
        {
            try
            {
                string Username = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                if (string.IsNullOrEmpty(Username)) { Username = System.Security.Principal.WindowsIdentity.GetCurrent().Name; }

                ActiveDirectory Employee = new ActiveDirectory() { WWID = "00000000" };
                if (!string.IsNullOrEmpty(Username))
                {
                    ActiveDirectory TempEmployee = FindEmployee(Username, SearchInput.SI_IDSID, true);
                    if (TempEmployee != null)
                    {
                        TempEmployee.UserID = Username;
                        return TempEmployee;
                    }
                }

                //Now we can add any User Specific Properties
                return Employee;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public ADGroupSearch[] SearchADGroups(string SearchText, int? SizeLimit)
        {
            ADGroupSearch[] ReturnValue = null;
            try
            {
                using (var connection = new LdapConnection())
                {
                    connection.SecureSocketLayer = true;
                    connection.Connect("corpldap.intel.com", 3269);
                    string UserID = _context.SystemConfigurations.Where(s => s.ConfigurationKey.ToLower() == "send_mail_auth_generator").Select(j => j.ConfigurationValue).FirstOrDefault();
                    string SecretId = _context.SystemConfigurations.Where(s => s.ConfigurationKey.ToLower() == "send_mail_auth_key").Select(j => j.ConfigurationValue).FirstOrDefault();
                    connection.Bind(UserID, EncryptionHelper.Decrypt(SecretId));

                    string searchFilter = "(&(objectCategory=group)(objectclass=group)";

                    if (SearchText.IndexOf("\\") != -1) SearchText = SearchText.Substring(SearchText.IndexOf("\\") + 1);
                    searchFilter += "(|(samaccountname=*" + SearchText + "*)(Name=*" + SearchText + "*)))";

                    var attributeList = new string[] { "displayName", "objectGUID" };
                    var searchQueue = connection.Search("dc=corp,DC=intel,dc=com", LdapConnection.ScopeSub, searchFilter, attributeList, false, null as LdapSearchQueue);

                    LdapMessage message;
                    ArrayList adGroups = new ArrayList();

                    int i = 1;
                    while ((message = searchQueue.GetResponse()) != null)
                    {
                        if (message is LdapSearchResult searchResult)
                        {
                            ADGroupSearch adGroup = new ADGroupSearch();
                            LdapEntry entry = searchResult.Entry;

                            // Get the attribute set of the entry
                            LdapAttributeSet attributeSet = entry.GetAttributeSet();
                            System.Collections.IEnumerator ienum = attributeSet.GetEnumerator();
                            if (i <= SizeLimit)
                            {
                                // Parse through the attribute set to get the attributes and the corresponding values 
                                while (ienum.MoveNext())
                                {
                                    LdapAttribute attribute = (LdapAttribute)ienum.Current;
                                    if (attribute.Name == "displayName")
                                    {
                                        adGroup.DisplayNm = attribute.StringValue;
                                    }
                                    if (attribute.Name == "objectGUID")
                                    {
                                        adGroup.Id = new Guid((byte[])(attribute.ByteValue as object)).ToString("D");
                                    }
                                }
                                i++;
                                adGroups.Add(adGroup);
                            }
                        }
                    }
                    connection.Disconnect();
                    ReturnValue = (ADGroupSearch[])(adGroups.ToArray(typeof(ADGroupSearch)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return ReturnValue;
        }
        public async Task<IEnumerable<WorkerSearch>> GetLdapWorkerSearch(string search, int? resultSize)
        {
            List<WorkerSearch> result = new List<WorkerSearch>();
            using (var connection = new LdapConnection())
            {
                connection.SecureSocketLayer = true;
                connection.Connect("corpldap.intel.com", 3269);
                string UserID = _context.SystemConfigurations.Where(s => s.ConfigurationKey.ToLower() == "send_mail_auth_generator").Select(j => j.ConfigurationValue).FirstOrDefault();
                string SecretId = _context.SystemConfigurations.Where(s => s.ConfigurationKey.ToLower() == "send_mail_auth_key").Select(j => j.ConfigurationValue).FirstOrDefault();
                connection.Bind(UserID, EncryptionHelper.Decrypt(SecretId));
                string searchFilter = "(&(objectCategory=user)(objectclass=user)(intelflags=1)";
                int wwid;
                if (int.TryParse(search, out wwid))
                {
                    searchFilter += "(mail=*)(EmployeeID=" + search + "*))";
                }
                else
                {
                    if (search.IndexOf("\\") != -1) search = search.Substring(search.IndexOf("\\") + 1);
                    searchFilter += "(mail=*)(|(samaccountname=" + search + "*)(Name=" + search + "*)))";
                }
                var attributeList = new string[] { "employeeid", "intelorgunitcode", "samaccountname", "cn", "department", "employeestatuscode", "name", "imageurl" };
                var searchQueue = connection.Search("dc=corp,DC=intel,dc=com", LdapConnection.ScopeSub, searchFilter, null, false, null as LdapSearchQueue);

                LdapMessage message;
                int i = 1;
                while ((message = searchQueue.GetResponse()) != null)
                {
                    if (message is LdapSearchResult searchResult)
                    {
                        var worker = new WorkerSearch();
                        LdapEntry entry = searchResult.Entry;

                        // Get the attribute set of the entry
                        LdapAttributeSet attributeSet = entry.GetAttributeSet();
                        System.Collections.IEnumerator ienum = attributeSet.GetEnumerator();
                        if (i <= resultSize)
                        {
                            // Parse through the attribute set to get the attributes and the corresponding values 
                            while (ienum.MoveNext())
                            {
                                LdapAttribute attribute = (LdapAttribute)ienum.Current;
                                Console.WriteLine(attribute.Name + ":" + attribute.StringValue);
                                if (attribute.Name == "employeeID")
                                {
                                    worker.Wwid = attribute.StringValue;
                                }
                                else if (attribute.Name == "intelOrgUnitCode")
                                {
                                    worker.DepartmentCd = attribute.StringValue;
                                }
                                else if (attribute.Name == "sAMAccountName")
                                {
                                    worker.Idsid = attribute.StringValue;
                                }
                                else if (attribute.Name == "cn")
                                {
                                    worker.CcmailNm = attribute.StringValue;
                                }
                                else if (attribute.Name == "department")
                                {
                                    worker.DepartmentLevel5Cd = attribute.StringValue;
                                }
                                else if (attribute.Name == "employeeStatusCode")
                                {
                                    worker.Status = attribute.StringValue;
                                }
                                else
                                {
                                    worker.FullNm = attribute.StringValue;
                                }
                            }
                            worker.imageURL = "https://photos.intel.com/images/" + worker.Wwid + ".jpg";
                            i++;
                            result.Add(worker);
                        }
                    }
                }
                connection.Disconnect();
            }
            return result;
        }
        public async Task<List<ADGroupSearch>> GetPAMSafeAccounts(int applicationId)
        {
            List<ADGroupSearch> ReturnValue = new List<ADGroupSearch>();
            try
            {
                using (var connection = new LdapConnection())
                {
                    connection.SecureSocketLayer = true;
                    connection.Connect("corpldap.intel.com", 3269);
                    string UserID = _context.SystemConfigurations.Where(s => s.ConfigurationKey.ToLower() == "send_mail_auth_generator").Select(j => j.ConfigurationValue).FirstOrDefault();
                    string SecretId = _context.SystemConfigurations.Where(s => s.ConfigurationKey.ToLower() == "send_mail_auth_key").Select(j => j.ConfigurationValue).FirstOrDefault();
                    connection.Bind(UserID, EncryptionHelper.Decrypt(SecretId));

                    string searchFilter = "(&(objectCategory=group)(objectclass=group)";
                    string SearchText = "PAM SAFE *-" + applicationId.ToString();

                    if (SearchText.IndexOf("\\") != -1) SearchText = SearchText.Substring(SearchText.IndexOf("\\") + 1);
                    searchFilter += "(|(samaccountname=" + SearchText + ")(Name=" + SearchText + ")))";

                    var attributeList = new string[] { "displayName", "objectGUID" };
                    var searchQueue = connection.Search("dc=corp,DC=intel,dc=com", LdapConnection.ScopeSub, searchFilter, attributeList, false, null as LdapSearchQueue);

                    LdapMessage message;
                    ArrayList adGroups = new ArrayList();

                    while ((message = searchQueue.GetResponse()) != null)
                    {
                        if (message is LdapSearchResult searchResult)
                        {
                            ADGroupSearch adGroup = new ADGroupSearch();
                            LdapEntry entry = searchResult.Entry;

                            // Get the attribute set of the entry
                            LdapAttributeSet attributeSet = entry.GetAttributeSet();
                            System.Collections.IEnumerator ienum = attributeSet.GetEnumerator();
                            // Parse through the attribute set to get the attributes and the corresponding values 
                            while (ienum.MoveNext())
                            {
                                LdapAttribute attribute = (LdapAttribute)ienum.Current;
                                if (attribute.Name == "displayName")
                                {
                                    adGroup.DisplayNm = attribute.StringValue;
                                }
                                if (attribute.Name == "objectGUID")
                                {
                                    adGroup.Id = new Guid((byte[])(attribute.ByteValue as object)).ToString("D");
                                }
                            }
                            ReturnValue.Add(adGroup);
                        }
                    }
                    connection.Disconnect();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            return ReturnValue;
        }
    }
}