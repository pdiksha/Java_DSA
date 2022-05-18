using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MMDTesting
{
    public static class PageObjects
    {

        public static string strCurrentBrowser = null;

        /// <summary>
        /// This class is used to define the page objects so that any changes to the control,
        /// we need to change the ID/Name/XPath only in this place
        /// </summary>
        /// 

        //Login Screen
        public static By loginUserNameInput = By.Id("userName");
        public static By loginPasswordInput = By.Id("password");
        public static By loginLoginButton = By.Id("logon-button");
        public static By loginuserNameDisplay = By.XPath("//*[@id='upperNavLinkArea']/span[1]");
        public static By loginErrorMessage = By.XPath("//div[contains(@class,'alert-danger')]");

        //Home Page
        public static By PageHeaderText = By.XPath("//*[@id='mmd-content']/header/h1");
        public static By homepageSystemAdmin = By.XPath("//a[@data-menu-id='sysadmin']");
        public static By homepageMaintenance = By.XPath("//a[@data-menu-id='maint']");
        public static By homepagePracticeMgmt = By.XPath("//a[@data-menu-id='pract_mgt']");
        public static By homepageFlowSheetAdmin = By.XPath("//a[@data-menu-id='flowsheetAdmin']");
        public static By homepageFlowOrdersAdmin = By.XPath("//a[@data-menu-id='orders_admin']");
        public static By homepageSearch = By.XPath("//a[@data-menu-id='search']");
        public static By homepageReports = By.XPath("//a[@data-menu-id='reports']");
        public static By homepageOrders = By.XPath("//a[@data-menu-id='order']");
        public static By homepageResults = By.XPath("//a[@data-menu-id='results_workflow']");
        public static By homepageDashboard = By.XPath("//*[@id='mmdNavBar']/div[2]/mmd-nav-clinical-menu/ul/li[1]/a");
        public static By homepageMyAccount = By.XPath("//a[@data-menu-id='MyAcct']");
        public static By homepageManageSecurityQestions = By.XPath("//a[@data-menu-id='MngSecQs']");
        public static By homepageLogoff = By.XPath("//a[contains(text(),'Log off')]");//08-27-19

        //Menu Link button
        public static By byMainMenuLinkList = By.XPath("//mmd-nav-clinical-menu//li[@ng-repeat='menuItem in clinicalMenu']/a");

        //System Settings
        public static By MaintSystemSettings = By.XPath("//a[@data-menu-id='sysset']");
        public static By SystemSettingNameInput = By.XPath("//input[@aria-label='Setting Name']");
        public static By SysSettingEditButton = By.XPath("//button[contains(text(),'Edit')]");
        public static By SysSettingEditTextArea = By.XPath("//textarea[@ng-model='viewModel.body']");
        public static By SysSettingSaveButton = By.XPath("//button[contains(text(),'Save')]");

        //To change the role
        public static By ISISystemAdministratorRole = By.XPath("//button[contains(text(),'ISI System Administrator')]");
        public static By ISISystemAdministratorSelectRole = By.XPath("//*[contains(text(),'ISI System Administrator')]");
        public static By DemoPracticeAdministrator = By.XPath("//*[contains(text(),'Demo Practice')]");
        public static By TestNonPracticeRole = By.XPath("//a[text()='Test Non-Practice 2 Insurance']");
        public static By AssociatedCardiologistsRole = By.XPath("//a[text()='associted non practice  Practice Administrator']");
        public static By changeRole = By.XPath("//span[@class='caret']");
        public static By MainLandHospitalInsuranceRole = By.XPath("//a[text()='Mainland Hospital Insurance']");
        public static By ChangeRoleButton = By.XPath("//*[@id='upperNavLinkArea']/div/div/button");
        public static By PracticeAPracticeAdministrator4097 = By.XPath("//a[contains(text(),'4097PracticeA Practice Administrator')]");
        public static By AssociatedCardiologistsV29PPracticeAdministratorRole = By.XPath("//*[contains(text(),'Associated Cardiologists - V29 Practice User')]");

        //Login Security
        public static By securityQuestionSetupWindow = By.XPath("//h3[contains(text(),'Password Recovery Security Question Setup')]");
        public static By securitySelectQuestion = By.Id("questionDropdown");
        public static By securityAnswerInbox = By.XPath("(//input[contains(@class,'ng-valid-parse')])");
        public static By securityConfirmAnswerInbox = By.XPath("(//input[contains(@class,'ng-empty')])");
        public static By securityContinueButton = By.XPath("//button[contains(text(),'Continue')]");
        public static By securityCancelButton = By.XPath("//button[contains(text(),'Cancel')]");
        public static By securitySkipButton = By.XPath("//button[contains(text(),'Skip')]");
        public static By securityFinishButton = By.XPath("//button[contains(text(),'Finish')]");
        public static By securityOKButton = By.XPath("//button[text()='OK']");
        public static By securityInvalidAnswerMessage = By.XPath("//p[text()='Invalid answer.']");

        //Through My Account -> Manage Security Questions
        public static By securityManageSecurityQuestionTextThruMyAccount = By.XPath("//h1[text()=' Manage Security Questions']");
        public static By securityAddNewButtonThruMyAccount = By.XPath("//input[@value='Add New']");
        public static By securitySelectQuestionThruMyAccount = By.XPath("//div[text()='Select a Question...']");
        public static By securitySaveButtonThruMyAccount = By.XPath("//input[@value='Save']");
        public static By securityCancelButtonThruMyAccount = By.XPath("//input[@value='Cancel']");
        public static By securitySelectParticularQuestion = By.XPath("//*[@id='mmd-content']/main/div/div/div/div[4]/div/div/div[1]/form/div/div/div/div/div/ul/li[1]/a");
        public static By securityAnswerThruMyAccount = By.XPath("//input[contains(@class,'ng-empty')]");
        public static By securityConfirmAnswerThruMyAccount = By.XPath("//input[contains(@class,'ng-empty')]");
        public static By securityFinalizeButtonThruMyAccount = By.XPath("//input[@value='Finalize']");
        public static By securityAnsweredTextafterFinalizeThruMyAccount = By.XPath("//div[contains(text(),'You have answered 3 of 3 questions.')]");
        public static By securityQuestionComboboxafterSelect = By.XPath("//button[@class='btn btn-default dropdown-toggle multiselect-button']");

        //System Admin -->> Security Question Lookup
        public static By SecurityQuestionLookup = By.XPath("//a[@data-menu-id='user_sec_lookup']");
        public static By SecurityQuestionUserID = By.Id("txtUserID");
        public static By SecurityQuestionLookupButton = By.Id("btnSearch");
        public static By SecurityQuestionDisplayFrame = By.Id("EAiFrame");
        public static By SecurityQuestionAnswerDisplayTable = By.XPath("//table[@id='grdResults']//tr");

        //Dashboard elements
        public static By byDashboardResultsFilterList = By.XPath("//*[@id='provider-dashboard-container']//mmd-provider-dashboard-filter-list//div[contains(text(),'Results Filters')]/following-sibling::div//a[not(contains(@class,'btn-default'))]");

        //Modal Error Dialog Window
        public static By ModalErrorHandlerDialogOKbutton = By.XPath("//mmd-error-handler//button[text()='OK']");

        //Modal Window controls
        public static By byModalWindowOKbutton = By.XPath("//div[@uib-modal-window]//button[contains(text(),'OK')]");
        public static By byModalWindowCancelbutton = By.XPath("//div[@uib-modal-window]//button[contains(text(),'Cancel')]");
        public static By byModalWindowMessage = By.XPath("//div[@uib-modal-window]//div[@ng-bind-html]");
        public static By byModalWindowTitle = By.XPath("//div[@uib-modal-window]//h3");

        //Inbox Help button
        public static By byInboxHelpIconLink = By.XPath("//*[@id='mmd-content']//mmd-help-button//a");

        //Inbox Filter section controls
        //Filters Applied buttons
        public static By byInboxFilterAppliedButtonDesktop = By.XPath("//button[@id='results-filters-applied-desktop']");
        public static By byInboxNoFilterAppliedButtonDesktop = By.XPath("//button[@id='results-no-filters-applied-desktop']");

        //Inbox Filter main controls
        public static By byInboxFilterTitleButton = By.XPath("//button[@id='inbox-filters-title']");
        public static By byInboxFiltersCollapsedButton = By.XPath("//button[@id='inbox-filters-title' and @aria-expanded='false']");
        public static By byInboxFiltersExpandedButton = By.XPath("//button[@id='inbox-filters-title' and @aria-expanded='true']");

        public static By byInboxFilterManageButton = By.XPath("//button[@title='Manage Saved Filters']");
        public static By byInboxFilterSavedFilterDDL = By.XPath("//*[@id='inbox-filters-list-desktop']");
        public static By byinboxFilterUndoChangesButton = By.XPath("//*[@id='inbox-filters-undo-changes-desktop']");

        //Inbox Filter Footer controls
        public static By byInboxFilterClearButton = By.XPath("//*[@id='inbox-filter-clear-button']");
        public static By byInboxFilterSaveButton = By.XPath("//*[@id='inbox-filter-save-button']");
        public static By byInboxFilterSaveAsButton = By.XPath("//*[@id='inbox-filter-save-as-button']");
        public static By byInboxFilterApplyButton = By.XPath("//*[@id='inbox-filter-apply-button']");
        public static By byInboxFilterSaveButtonDisabled = By.XPath("//*[@id='inbox-filter-save-button' and @disabled='disabled']");
        public static By byInboxFilterSaveAsButtonDisabled = By.XPath("//*[@id='inbox-filter-save-as-button' and @disabled='disabled']");
        public static By byInboxFilterApplyButtonDisabled = By.XPath("//*[@id='inbox-filter-apply-button' and @disabled='disabled']");

        //Footnotes-Legends
        public static By byInboxFilterFootNotesBeginsWith = By.XPath("//span[text()='B']//parent::span[contains(@class,'margin-right-25 ng-binding')]");
        public static By byInboxFilterFootNotesContains = By.XPath("//span[text()='C']//parent::span[contains(@class,'margin-right-25 ng-binding')]");

        //Inbox Table Column Picker elements
        public static By byInboxColumnPickerButton = By.XPath("//mmd-inbox-column-picker//button[contains(.,'Columns')]");
        public static By byInboxColumnPickerButtonExpanded = By.XPath("//mmd-inbox-column-picker//button[contains(.,'Columns') and @aria-expanded='true']");
        public static By byInboxColumnPickerFullList = By.XPath("//mmd-inbox-column-picker//ul");
        public static By byInboxColumnPickerUnselectedInputs = By.XPath("//mmd-inbox-column-picker//input[contains(@class,'ng-empty')]");
        public static By byInboxColumnPickerAllInputs = By.XPath("//mmd-inbox-column-picker//input");

        //Inbox Grid Actions buttons - for View/Print/Archive, Page size
        public static By byInboxGridActionButtons = By.XPath("//*[@id='inbox-grid']//grid-actions//button");
        public static By byInboxPageSizeButton = By.XPath("//mmd-inbox-page-size//button");

        //Inbox refresh icon and inbox results limit text
        public static By byInboxRefreshIcon = By.XPath("//a[@title='Refresh Inbox']");
        public static By byInboxResultsLimitText = By.XPath("//div[@ng-if='viewModel.ExceedsInboxResultsLimit']");

        //Inbox Grid - Manual Sorting by Column Heading
        public static By byInboxColumnSortAscIndicator = By.XPath("//i[contains(@class, 'fa-caret-up')]//ancestor::mmd-inbox-sort");
        public static By byInboxColumnSortDscIndicator = By.XPath("//i[contains(@class, 'fa-caret-down')]//ancestor::mmd-inbox-sort");

        //Inbox Grid - Footer controls
        public static By byInboxPaginationDivTag = By.XPath("//div[contains(@class,'pagination')]");
        public static By byInboxGridNoRowsText = By.XPath("//*[@id='inbox-grid']//h2[contains(text(),'No records found')]");

        //Inbox - Page Footer text
        public static By byInboxPageFooterText = By.XPath("//*[@id='mmd-footer']/mmd-footer-text/div");

        //Manage filter section controls
        public static By byInboxManageFilterGrid = By.XPath("//*[@id='inbox-manage-filters-grid']");
        public static By byInboxManageFilterGridHeaderRow = By.XPath("//*[@id='inbox-manage-filters-grid']//thead//tr");
        public static By byInboxManageFilterGridDataRows = By.XPath("//*[@id='inbox-manage-filters-grid']//tbody//tr");
        public static By byInboxManageFilterNameColHeading = By.XPath("//*[@id='inbox-manage-filters-grid']//a[contains(text(),'Name')]");
        public static By byInboxManageFilterList = By.XPath("//*[@id='inbox-manage-filters-grid']//span[@ng-bind='dataItem.Name']");
        public static By byInboxManageFilterCloseButton = By.XPath("//*[@id='manage-filters-modal']//button[contains(text(),'Close')]");

        //Save Filter section controls
        public static By byInboxFilterModalSaveNameInput = By.XPath("//*[@id='save-filter-name']");
        public static By byInboxFilterModalCancelbutton = By.XPath("//*[@id='inbox-filters-save-as-modal']//button[contains(text(),'Cancel')]");
        public static By byInboxFilterModalSavebutton = By.XPath("//*[@id='inbox-filters-save-as-modal']//button[contains(text(),'Save')]");

        //************************************************* REPORTS - BEGIN ********************************************************//
        //Audit Reports - controls
        public static By byAuditReportsMenu = By.XPath("//a[@data-menu-id='audit_reports']");
        public static By byAuditReportsList = By.Id("reportList");
        public static By byARUserReportUserSelectField = By.XPath("//div[@label='User']/following-sibling::div/select");
        public static By byAuditReportsSearchButton = By.Id("reportSearch");
        public static By byAuditReportsDisplayGridRows = By.XPath("//*[@id='reportGrid']/table//tr");

        //************************************************* REPORTS - END ********************************************************//


        //************************************************* PATIENT SEARCH - BEGIN ********************************************************//
        public static By PatientSearchSearchMenu = By.XPath("//a[@data-menu-id='search']");
        public static By PatientSearchPatientDropdown = By.XPath("//a[@data-menu-id='patient_search']");
        public static By PatientSearchAccessErrorOkButton = By.XPath("//button[text() = 'OK']");
        public static By PatientSearchUnserNotAuthorizedErrorMessage = By.XPath("//h1[contains(text(),'User not authorized')]");

        public static By PatientSearchPatientLastName = By.Id("patient-search-last-name-filter");
        public static By PatientSearchDOB = By.Id("patient-search-dob-filter");
        public static By PatientSearchGender = By.Id("patient-search-gender-filter");
        public static By PatientSearchMRN = By.XPath("//input[@title='Patient MRN']");
        public static By PatientSearchPatientFirstName = By.Id("patient-search-first-name-filter");
        public static By PatientSearchSSN = By.XPath("//input[@title='Patient SSN']");
        public static By PatientSearchZIP = By.XPath("//input[@title='Patient Zip']");
        public static By PatientSearchDeletedDocuments = By.XPath("//div[@label='Search Deleted Documents?']/following-sibling::div");
        public static By PatientSearchDeletedDocComboBox = By.XPath("//*[@label='Search Deleted Documents?']//following-sibling::select");

        public static By PatientSearchHelp = By.XPath("//i[@class='fa fa-question-circle']");
        public static By PatientSearchClearButton = By.XPath("//button[text()='Clear']");
        public static By PatientSearchSearchButton = By.XPath("//span[text()='Search']");
        public static By PatientSearchDataTable = By.XPath("//*[@id='patients-container']/div/table/tbody/tr");
        public static By PatientRecordTestAnuLink = By.LinkText("TEST ,ANU");
        public static By PatientSearchActionButton = By.XPath("//a[@class='btn dropdown-toggle ng-binding']");
        public static By PatientSearchActionPatientSummary = By.XPath("//*[contains(text(), 'Patient Summary')]");
        public static By PatientSearchActionDocuments = By.XPath("//*[contains(text(), ' Documents')]");
        public static By PatientSearchActionCreateOrder = By.XPath("//*[contains(text(), ' Create Consult/Order')]");
        public static By PatientSearchActionNewMessage = By.XPath("//*[contains(text(), ' New Message')]");
        public static By PatientSearchNewSecureMessageScreen = By.XPath("//h1[contains(text(), ' New Secure Message')]");
        public static By PatientSearchPatientSummaryTable = By.XPath("//*[@id='tab-administrative']/mmd-patient-summary-relationship/div/div/mmd-patient-summary-administrative/div/div[1]/div/div[2]/table");
        public static By PatientSearchFaceSheetViewButton = By.XPath("//a[contains(@class, 'icon-button ng-binding ng-scope')]");
        public static By PatientSearchFaceSheetFrame = By.Id("htmlFrame");
        public static By PatientSearchFaceSheetCloseButton = By.XPath("//button[text() = 'Close']");
        public static By PatientSearchCloseButton = By.XPath("//button[contains(text(), 'Close')]");
        public static By PatientSearchCreateConsultButton = By.XPath("//button[contains(text(), 'Create Consult')]");
        public static By PatientSearchCreateConsultHeader = By.XPath("//h1[contains(text(), ' Create Consult')]");
        public static By PatientSearchCreateConsultOrderSelectPhysician = By.XPath("/html/body/div[3]/div/div/div[2]/div/div/main/div/form/div/div[4]/div[1]/span/div/div[2]/select");
        public static By PatientSearchCreateConsultOrderSelectLocation = By.XPath("/html/body/div[3]/div/div/div[2]/div/div/main/div/form/div/div[4]/div[1]/select-field/div/div[2]/select");
        public static By PatientSearchNewMessageButton = By.XPath("//button[contains(text(),'New Message')]");
        public static By PatientSearchSecureMessageType = By.Id("message-types");
        public static By PatientSearchSecureMessageAddButton = By.Id("compose-add-recipient-button");
        public static By PatientSearchSecureMessageAddRecipientButton = By.XPath("//button[contains(text(), 'Add Recipient')]");
        public static By PatientSearchSecureMessageOKButton = By.XPath("//button[contains(text(), 'OK')]");
        public static By PatientSearchSecureMessageOnBehalfofCombobox = By.Id("message-on-behalf-of");
        public static By PatientSearchSecureMessageSendButton = By.XPath("//button[contains(text(), 'Send')]");
        public static By PatientSearchSecureMessageSentTab = By.XPath("//a[text()='Sent']");
        public static By PatientSearchVisitTabRows = By.XPath("//tr[@class='ng-scope']");
		public static By PatientSearchVisitsTab = By.LinkText("Visits");//08-20-19
        public static By PatientSearchDocumentTab = By.LinkText("Documents");
        public static By PatientSearchDocumentTabRows = By.XPath("//tr[contains(@class,'k-master-row')]");
        public static By PatientSearchSecureMessageTab = By.LinkText("Secure Messaging Inbox");
        public static By PatientSearchSecureMessageTabRows = By.XPath("//tr[@class='ng-scope']");
        public static By PatientSearchConsultInboxTab = By.LinkText("Consults/Orders Inbox");//08-21-19
        public static By PatientSearchRequisitionOrderTabRows = By.XPath("//tr[@class='ng-scope']");
        public static By PatientSearchOpenDocument = By.XPath("//i[@class = 'fa fa-file-o']");
        public static By PatientSearchOpenDocumentHTMLPage = By.XPath("//*[@class='htmlPage']");
        public static By PatientSearchDocumentCloseButton = By.XPath("//button[contains(text(),'Close') and @class='btn btn-primary ng-binding']");

        public static By PatientSearchCreatePatientButton = By.XPath("//button[contains(text(), 'Create Patient')]");
        public static By PatientSearchCreatePatientScreen = By.XPath("//h3[@class = 'modal-title ng-binding']");
		public static By PatientSearchCreatePatientCancelButton = By.XPath("//button[contains(text(), 'Cancel')]");//08-20-19

        public static By PatientSearchCreatePatientLastName = By.XPath("//input[@title ='Patient Last Name']");
        public static By PatientSearchCreatePatientFirstName = By.XPath("//input[@title ='Patient First Name']");
        public static By PatientSearchCreatePatientDOB = By.XPath("//input[@class = 'form-control ng-pristine ng-untouched ng-valid ng-isolate-scope ng-empty ng-valid-mask']");
        public static By PatientSearchCreatePatientGender = By.XPath("//span[text()='Patient Gender']/following::select");
        public static By PatientSearchCreatePatientHomePhone = By.XPath("//input[@title='Home Phone']");
        public static By PatientSearchCreatePatientSaveButton = By.XPath("//button[contains(text(), 'Save')]");
        public static By PatientSearchCreatePatientOKButton = By.XPath("//button[contains(text(), 'OK')]");

        //Patient Search - Audit Reports
        public static By PatientSearchAuditReportsMenu = By.XPath("//a[@data-menu-id='audit_reports']");
        public static By PatientSearchAuditReportList = By.Id("reportList");
        public static By PatientSearchAuditReportUserAccessDetailsBeginDate = By.XPath("//span[text()='Begin Date']/following::input");
        public static By PatientSearchAuditReportSearchReportButton = By.Id("reportSearch");
        public static By PatientSearchAuditReportDisplayGrid = By.XPath("//*[@id='reportGrid']/table//tr");

        //Error Messages
        public static By PatientSearchLastNameErrorMessage = By.XPath("//p[@id='patient-search-last-name-filter-error']");
        public static By PatientSearchDOBErrorMessage = By.XPath("//p[contains(text(),'Please enter a valid date.')]");
        public static By PatientSearchSSNErrorMessage = By.XPath("//p[contains(text(), 'Please provide a numeric value that is 4 characters in length.')]");
        public static By PatientSearchMRNErrorMessage = By.XPath("//p[contains(text(), 'Please provide at least the first 3 characters of the Patient MRN.')]");
        public static By PatientSearchConditionallyRequiredFieldErrorMessage = By.XPath("//p[contains(text(), 'Enter one conditionally required field')]");//08-21-19

        //Sorting
        public static By PatientSearchSortTable = By.XPath("//*[@id='patients-container']//b");
        public static By PatientSearchSortAscending = By.XPath("//i[contains(@class, 'fa-caret-up')]//ancestor::mmd-sort");
        public static By PatientSearchSortDescending = By.XPath("//i[contains(@class, 'fa-caret-down')]//ancestor::mmd-sort");

        //Global Search
        public static By PatientGlobalSearchButton = By.XPath("//label[@id='patient-search-global-btn']");

        //************************************************* PATIENT SEARCH - END ********************************************************//

        //Orders Inbox
        //************************************************* ORDERS INBOX - BEGIN ********************************************************//
        //Dashboard - Orders Inbox widget
        public static By DashboardOrdersFiltersWidget = By.XPath("//*[@id='providerDashboard-container']/div/div[3]/mmd-provider-dashboard-chiclet/div[1]/div[1]/div[1]");
        public static By DashboardOrdersFilterFavoriteList = By.XPath("//*[@id='providerDashboard-container']/div/div[3]/mmd-provider-dashboard-chiclet/div[1]/div[2]/div[1]");
        public static By DashboardOrdersFiltersViewMoreLink = By.XPath("//*[@id='providerDashboard-container']/div/div[3]/mmd-provider-dashboard-chiclet/div[1]/div[2]/div[2]/button");

        //For Default filter
        public static By byOrdersFilterManageButton = By.XPath("//*[@id='inbox-filters-panel-heading']/div[1]/div[2]/div/div/mmd-inbox-manage-filters/button");
        public static By byOrdersManageFilterGrid = By.XPath("//*[@id='inbox-manage-filters-grid']");

        public static By byOrdersManageFilterCheck1 = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody/tr[1]/td[2]/div/span/span[1]");
        public static By byOrdersManageFilterUnCheck1 = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody/tr[1]/td[2]/div/span/span[2]");
        public static By byOrdersManageDefaultFilterName1 = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody/tr[1]/td[1]/span");
        public static By byOrdersManageFilterCheck2 = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody/tr[2]/td[2]/div/span/span[1]");
        public static By byOrdersManageFilterUnCheck2 = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody/tr[2]/td[2]/div/span/span[2]");
        public static By byOrdersManageDefaultFilterName2 = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody/tr[2]/td[1]/span");

        public static By byOrdersManageFilterCloseButton = By.XPath("//*[@id='manage-filters-modal']/div/div/div[3]/button");
        public static By byOrdersSavedFiltersList = By.XPath("//*[@id='inbox-filters-list-desktop']");

        //For Delete filter
        public static By OrdersManageFilterGridTable = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody");
        public static By OrdersManageFilterDelete1 = By.XPath("//*[@id='inbox-manage-filters-grid']/table/tbody/tr[1]/td[4]/a[2]");
        public static By OrdersFilterDeleteCancel = By.XPath("//button[contains(text(),'Cancel')]");
        public static By OrdersFilterDeleteOk = By.XPath("//button[contains(text(),'OK')]");

        //For Filter Favorite
        public static By OrderFilterFavoriteModalWarn = By.XPath("/html/body/div[1]/div/div/div[2]/div/div/table/tbody/tr/td[2]/div");
        public static By OrderFilterFavoriteModalOk = By.XPath("/html/body/div[1]/div/div/div[3]/button[3]");


        //For filter sort
        public static By OrdersFilterSort = By.XPath("//*[@id='inbox-manage-filters-grid']/table/thead/tr/th[1]/a");

        //Orders Inbox - Table elements
        public static By byOrdersInboxTable = By.XPath("//*[@id='orders-table']");
        public static By byOrdersInboxTabArchive = By.XPath("//a[@class='ng-binding'][contains(text(), 'Archive')]");
        public static By byOrdersInboxTableHeaderRow = By.XPath("//*[@id='orders-table']/thead/tr");
        public static By byOrdersInboxTblHdrColumnList = By.XPath("//*[@id='orders-table']/thead/tr/th");
        //Orders Inbox - Table Column Picker elements
        public static By byOrdersInboxColumnPickerButton = By.XPath("//mmd-inbox-column-picker//button[contains(.,'Columns')]");
        public static By byOrdersInboxColumnPickerButtonExpanded = By.XPath("//mmd-inbox-column-picker//button[contains(.,'Columns') and @aria-expanded='true']");
        public static By byOrdersInboxColumnPickerFullList = By.XPath("//mmd-inbox-column-picker//ul");
        public static By byOrdersInboxColumnPickerUnselectedInput = By.XPath("//mmd-inbox-column-picker//input[contains(@class,'ng-empty')]");
        public static By byOrdersInboxColumnPickerAllInput = By.XPath("//mmd-inbox-column-picker//input");


        //Orders Inbox other controls
        public static By byOrdersInboxGridActionButtons = By.XPath("//*[@id='inbox-grid']//grid-actions");
        public static By byOrdersInboxPageSizeButton = By.XPath("//mmd-inbox-page-size//button");
        public static By byOrdersInboxPaginationDivTag = By.XPath("//div[@uib-pagination]");
        public static By byOrdersInboxTableActionsLinks = By.XPath("//*[@id='orders-table']//a[contains(text(), 'Actions')]");
        public static By byOrdersInboxRefreshIcon = By.XPath("//a[@title='Refresh Inbox']");

        public static By byOrdersInboxPageSize25Link = By.XPath("//mmd-inbox-page-size//li[2]//a");


        //For Save Filter
        public static By byOrdersInboxTableRows = By.XPath("//*[@id='orders-table']//tr");
        public static By byOrdersInboxTableResult = By.XPath("//*[@id='inbox-grid']/div[1]/div[1]/span");
        public static By byOrdersInboxTableNoRowsText = By.XPath("//*[@id='inbox-grid']/div[2]/div/h2");

        public static By byOrdersInboxFiltersButton = By.XPath("//*[@id='inbox-filters-title']");

        public static By byOrdersFilterAppliedButtonDesktop = By.XPath("//button[@id='results-filters-applied-desktop']");
        public static By byOrdersNoFilterAppliedButtonDesktop = By.XPath("//button[@id='results-no-filters-applied-desktop']");

        public static By byOrdersFilterSelectList = By.XPath("//*[@id='inbox-filters-list-desktop']");

        public static By byOrdersFilterDateFieldsArray = By.XPath("//input[@data-role='datepicker']");

        public static By byOrdersFilterSaveAsButton = By.XPath("//*[@id='inbox-filter-save-as-button']");
        public static By byOrdersFilterUndoChanges = By.XPath("//*[@id='inbox-filters-undo-changes-desktop']");

        public static By byOrdersSaveFilterInput = By.XPath("//*[@id='save-filter-name']");
        public static By byOrdersCancelFilterbtn = By.XPath("//*[@id='inbox-filters-save-as-modal']/div/div/div[3]/button[1]");
        public static By byOrdersSaveFilterbtn = By.XPath("//*[@id='inbox-filters-save-as-modal']/div/div/div[3]/button[2]");
        public static By byOrdersInvalidFilterNameWarning = By.XPath("/html/body/div[1]/div/div/div[2]/div/div/table/tbody/tr/td[2]/div");
        public static By byOrdersSaveFilterOK = By.XPath("/html/body/div[1]/div/div/div[3]/button[3]");

        public static By byOrdersSaveFilterOverwriteText = By.XPath("/html/body/div[1]/div/div/div[1]/h3");
        public static By byOrdersSaveFilterCancel = By.XPath("/html/body/div[1]/div/div/div[3]/button[1]");

        //Orders Inbox - Filter controls
        public static By byOrdersFilterPatientLastName = By.XPath("//*[@id='order-filter-patient-last-name']");
        public static By byOrdersFilterPatientFirstName = By.XPath("//*[@id='order-filter-patient-first-name']");
        public static By byOrdersFilterPatientDOB = By.XPath("//input[@title='Patient DOB']");
        public static By byOrdersFilterPriority = By.XPath("//*[@id='order-priority']");
        public static By byOrdersFilterConsultRangeButton = By.XPath("//button[contains(@ng-click,'DateRange')]");
        public static By byOrdersFilterConsultTimeFrameButton = By.XPath("//button[contains(@ng-click,'TimePeriod')]");
        public static By byOrdersFilterConsultBeginDate = By.XPath("//*[@id='order-date-range-container']//date-field[contains(@label,'Begin Date')]//input");
        public static By byOrdersFilterBeginDateDatePicker = By.XPath("//*[@id='order-date-range-container']//date-field[contains(@label,'Begin Date')]//input/following-sibling::span");
        public static By byOrdersFilterConsultEndDate = By.XPath("//*[@id='order-date-range-container']//date-field[contains(@label,'End Date')]//input");
        public static By byOrdersFilterEndDateDatePicker = By.XPath("//*[@id='order-date-range-container']//date-field[contains(@label,'End Date')]//input/following-sibling::span");
        public static By byOrdersFilterOtherDateDDL = By.XPath("//*[@id='order-date-type']");
        public static By byOrdersFilterOtherBeginDate = By.XPath("//div[@id='order-date-type-container']/following-sibling::div//date-field[contains(@label,'Begin Date')]//input");
        public static By byOrdersFilterOtherEndDate = By.XPath("//div[@id='order-date-type-container']/following-sibling::div//date-field[contains(@label,'End Date')]//input");
        public static By byOrdersFilterFormType = By.XPath("//label[text()='Form Type']/following-sibling::div//ul");
        public static By byOrdersFilterFormTypeLink = By.XPath("//label[text()='Form Type']/following-sibling::div//ul//a");
        public static By byOrdersFilterFacility = By.XPath("//label[text()='Facility']/following-sibling::div//ul");
        public static By byOrdersFilterFacilityLink = By.XPath("//label[text()='Facility']/following-sibling::div//ul//a");
        public static By byOrdersFilterStatus = By.XPath("//label[text()='Status']/following-sibling::div//ul");
        public static By byOrdersFilterStatusLink = By.XPath("//label[text()='Status']/following-sibling::div//ul//a");
        public static By byOrdersFilterSvcRequested = By.XPath("//*[@id='order-filter-service-requested']");

        public static By byOrdersFilterClearButton = By.XPath("//*[@id='inbox-filter-clear-button']");
        public static By byOrdersFilterSaveButton = By.XPath("//*[@id='inbox-filter-save-button']");
        public static By byOrdersFilterApplyButton = By.XPath("//*[@id='inbox-filter-apply-button']");

        public static By byOrdersFilterApplyButtonDisabled = By.XPath("//*[@id='inbox-filter-apply-button' and @disabled='disabled']");
        public static By byOrdersFilterSaveButtonDisabled = By.XPath("//*[@id='inbox-filter-save-button' and @disabled='disabled']");

        //Footnotes-Legends
        public static By byOrdersFilterFootNotesBeginsWith = By.XPath("//span[text()='B']//parent::span[contains(@class,'margin-right-25 ng-binding')]");
        public static By byOrdersFilterFootNotesContains = By.XPath("//span[text()='C']//parent::span[contains(@class,'margin-right-25 ng-binding')]");

        //Footnotes-Fields
        public static By byOrdersFilterPatientLastNameBeginsWithFN = By.XPath("//span[text()='B']//preceding-sibling::label[text()='Patient Last Name']");
        public static By byOrdersFilterPatientFirstNameBeginsWithFN = By.XPath("//span[text()='B']//preceding-sibling::label[text()='Patient First Name']");
        public static By byOrdersFilterServiceRequestedContainsFN = By.XPath("//span[text()='C']//preceding-sibling::label[text()='Service Requested']");

        //DatePicker pop-up control fields
        public static By byDatePickerTable = By.XPath("//*[@id='{{model.uid}}_dateview']//table");
        public static By byDatePickerTableFooterCurrDate = By.XPath("//*[@id='{{model.uid}}_dateview']//a[contains(@class,'k-link k-nav-today')]");
        public static By byDatePickerTableHeaderChangeButton = By.XPath("//*[@id='{{model.uid}}_dateview']//a[contains(@class,'k-link k-nav-fast')]");
        public static By byDatePickerTableNavPrevButton = By.XPath("//*[@id='{{model.uid}}_dateview']//a[contains(@class,'k-link k-nav-prev')]");
        public static By byDatePickerTableNavNextButton = By.XPath("//*[@id='{{model.uid}}_dateview']//a[contains(@class,'k-link k-nav-next')]");
        public static By byDatePickerTableSelectedLink = By.XPath("//*[@id='{{model.uid}}_dateview']//td[@aria-selected='true']//a");

        //Columns Manual Sorting
        public static By byOrdersInboxColumnsLink = By.XPath("//table[@id='orders-table']//b");
        public static By byOrdersInboxColumnSortAscIndicator = By.XPath("//i[contains(@class, 'fa-caret-up')]//ancestor::mmd-inbox-sort");
        public static By byOrdersInboxColumnSortDscIndicator = By.XPath("//i[contains(@class, 'fa-caret-down')]//ancestor::mmd-inbox-sort");

        //Default Sorting Validating elements
        public static By byOrdersInboxDefSortColList15 = By.XPath("//td[@ng-if='viewModel.columns[viewModel.columnKeys.LastUpdated]']");
        public static By byOrdersInboxDefSortColHeading = By.XPath("//table[@id='orders-table']//b[contains(text(),'Last Updated')]");

        //Orders Results
        public static By byOrdersInboxResultsLimitText = By.XPath("//div[@ng-if='viewModel.ExceedsInboxResultsLimit']");

        //************************************************* ORDERS INBOX - END ********************************************************//


        //************************************************* RESULTS INBOX - BEGIN ********************************************************//
        //Inbox - Table elements
        public static By byResultsInboxTable = By.XPath("//*[@id='results-table']");
        public static By byResultsInboxTableHeaderRow = By.XPath("//*[@id='results-table']/thead/tr");
        public static By byResultsInboxTblHdrColumnList = By.XPath("//*[@id='results-table']/thead/tr/th");
        public static By byResultsInboxTableAllRows = By.XPath("//*[@id='results-table']//tr");

        //Results Inbox Filter controls
        public static By byResultsFilterPatientLastName = By.XPath("//*[@id='filter-patient-last-name']");
        public static By byResultsFilterPatientFirstName = By.XPath("//*[@id='filter-patient-first-name']");
        public static By byResultsFilterPatientDOB = By.XPath("//input[@title='Patient DOB']");
        public static By byResultsFilterPatientClass = By.XPath("//*[@id='filters-patient-patientClass']");
        public static By byResultsFilterNotificationType = By.XPath("//*[@id='filters-alert-type']");
        public static By byResultsFilterDocName = By.XPath("//input[@form='filter-document-descriptor']");
        public static By byResultsFilterAssignedTo = By.XPath("//*[@id='filter-assigned-to']");
        public static By byResultsFilterResultStatus = By.XPath("//*[@id='filters-result-status']");
        public static By byResultsFilterABNLInd = By.XPath("//*[@id='filters-abn-ind']");
        public static By byResultsFilterBeginDate = By.XPath("//date-field[@id='filter-start-date']//input");
        public static By byResultsFilterEndDate = By.XPath("//date-field[@id='filter-end-date']//input");
        public static By byResultsFilterDocType = By.XPath("//label[text()='Document Type']/following-sibling::div//ul");
        public static By byResultsFilterDocTypeLink = By.XPath("//label[text()='Document Type']/following-sibling::div//ul//a");
        public static By byResultsFilterFacility = By.XPath("//label[text()='Facility']/following-sibling::div//ul");
        public static By byResultsFilterFacilityLink = By.XPath("//label[text()='Facility']/following-sibling::div//ul//a");
        public static By byResultsFilterCategory = By.XPath("//label[text()='Category']/following-sibling::div//ul");
        public static By byResultsFilterCategoryLink = By.XPath("//label[text()='Category']/following-sibling::div//ul//a");
        public static By byResultsFilterRoutePhysician = By.XPath("//label[text()='Route Physician']/following-sibling::div//ul");
        public static By byResultsFilterRoutePhysicianLink = By.XPath("//label[text()='Route Physician']/following-sibling::div//ul//a");

        //Footnotes-Fields
        public static By byResultsFilterPatLastNameFootNotesB = By.XPath("//span[text()='B']//preceding-sibling::label[text()='Patient Last Name']");
        public static By byResultsFilterPatFirstNameFootNotesB = By.XPath("//span[text()='B']//preceding-sibling::label[text()='Patient First Name']");
        public static By byResultsFilterDocNameFootNotesC = By.XPath("//span[text()='C']//preceding-sibling::label[text()='Document Name']");

        //Results Action link
        public static By byResultsInboxTableActionsLinks = By.XPath("//*[@id='results-table']//a[contains(text(), 'Actions')]");

        //************************************************* RESULTS INBOX - END ********************************************************//



        //Document Search


        //Sys Admin



        //Practice Admin



        //General Admin


        //Secure Messaging (SM)


        //General (Dashboard Test)



        //DocGrid
        //Updated by KH
        //PatientSearch
        public static By patinentSearch = By.XPath("//a[@data-menu-id='patient_search']");
        public static By patientLName = By.Id("patient-search-last-name-filter");
        public static By patientLNameRequired = By.XPath("//*[@id='patient-search-last-name-filter']//ancestor::div[@class='mmd-required']");
        public static By patientFName = By.Id("patient-search-first-name-filter");
        public static By patientFNameRequired = By.XPath("//*[@id='patient-search-first-name-filter']//ancestor::div[@class='mmd-required']");
        public static By psearchbutton = By.Id("searchButton");
        public static By pSearch = By.ClassName("ng-binding");
        public static By pSSNfield = By.XPath(".//div[@class='2 mmd-cond-required']");
        public static By pSSNCReuired = By.XPath("//*[@title='Patient SSN']//ancestor::div[@class='2 mmd-cond-required']");
        public static By pSSNvalue = By.XPath(".//input[@class='form-control ng-empty ng-touched']");
        public static By patientDobRequired = By.XPath("//*[@id='patient-search-dob-filter']//ancestor::div[@class='mmd-required']");
        public static By patientDobCRequired = By.XPath("//*[@id='patient-search-dob-filter']//ancestor::div[@class='mmd-cond-required']");
        public static By patinetGenderRequired = By.XPath("//*[@id='patient-search-gender-filter']//ancestor::div[@class='mmd-required']");
        public static By patientMRNCRequired = By.XPath("//*[@title='Patient MRN']//ancestor::div[@class='mmd-cond-required']");
        

        //Global search 
        //*[@id="patient-search-global-btn"]
        public static By globalsearchbutton = By.XPath(".//*[@id='patient-search-global-btn']");
        public static By globalSearch = By.XPath(".//*[@id='searchMode']/label[2]");
        public static By patientArchive = By.XPath(".//*[@id='searchMode']/label[1]");
        public static By otheroption = By.XPath("//input[@type='radio' and @value='OTHER']");
        public static By comments = By.XPath("//textarea[@ng-model='model.bindable']");
        public static By commenttext = By.XPath("//textarea[@class='form-control ng-empty ng-touched']");
        public static By okButton = By.XPath("./html/body/div[1]/div/div/form/div[2]/submit-button/button/span");
        public static By closeButton = By.XPath("./html/body/div[1]/div/div/form/div[2]/button");
        public static By ConditionalRequiredError = By.XPath("//p[@id='patient-search-dob-filter-error']");

        //Action Element selection on patient summary 

        public static By pAction = By.XPath("//a[@class='btn dropdown-toggle ng-binding']");
        public static By docSelection = By.XPath(".//a[text()=' Documents']");
        public static By ClickonActionbutton = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/button/span");
        public static By viewDoc = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/ul/li[4]/a/i");
        public static By viewwithoutBreak = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/ul/li[5]/a/i");
        public static By docSavedocumentList = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/ul/li[6]/a/i");
        public static By deleteDoc = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/ul/li[8]/a/i");
        public static By sendtoMyEMR = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/ul/li[6]/a");
        public static By demographicsection = By.XPath(".//div[@class='row patient-demographics']");
        public static By closepatientsummary = By.XPath(".//button[@class='btn btn-primary ng-binding']");
        public static By patientsummaryflowsheetstab = By.LinkText("Flowsheets");
        public static By patientsummaryConsultsOrderstab = By.LinkText("Consults/Orders Inbox");
        public static By patientsummaryHospitalDowntimetab = By.LinkText("Hospital Downtime");
        public static By patientsummaryClinicalSummarytab = By.LinkText("Clinical Summary");
        public static By patientsummaryclinicalmedications = By.XPath("//*[contains(text(),'Medications')]");
        public static By patientsummaryclinicalallergies = By.XPath("//*[contains(text(),'Allergies')]");
        public static By patientsummaryclinicalproblems = By.XPath("//*[contains(text(),'Problems')]");
        public static By patientsummaryclinicalimmunizations = By.XPath("//*[contains(text(),'Immunizations')]");
        public static By patientsummaryvisitrecordtable = By.XPath("//div[@class='col-sm-12 col-md-6'][2]//following-sibling::tr");
        public static By patientsummarydocrecords = By.ClassName("Doc_100495078");
        public static By patientsummaryselectdoc = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[3]/td[10]/div");
        public static By patientsummarydocpdfprint = By.XPath("//*[@id='print']");
        public static By patientsummarydocpdfclose = By.XPath("//*[@id='pdfViewerFooter']/button[2]");

        //Testcase Close All button
        public static By closeAllbuttonselection = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[2]/button[2]/i");

        public static By checkAllselection = By.XPath("//i[@class='fa fa-check-square-o']");
        public static By clearFiltersselection = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[3]/ul/li[15]/a");

        public static By selectfilterCategory = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[3]/ul/li[3]/label/span");

        public static By selctcontainsCategory = By.XPath("/html/body/div[1]/div/div/form/div[2]/select/option[4]");

        public static By categoryinput = By.XPath(".//i[@class='margin-top-5 ng-scope']");
        // public static By categoryinputs = By.XPath(".//i[@class='form-control ng-touched ng-empty ng-dirty ng-valid-parse']");
        public static By categoryinputs = By.XPath("/html/body/div[1]/div/div/form/div[2]/div/text-field/div");
        public static By categorysubmiteButton = By.XPath("/html/body/div[1]/div/div/form/submit-button/button/span");
        public static By unheckAllselection = By.XPath("//i[@class='fa fa-square-o']");
        public static By openAllbuttonselection = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[2]/button[1]/i");
        public static By filterButtonselection = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[3]/button/span");
        public static By columnsButton = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[4]/button/span");


        //Quick Filters on Doc

        public static By quickFiltersButton = By.XPath("//i[@class='fa fa-caret-right']");
        public static By documentNametext = By.XPath(".//div[@id='accordiongroup-1775-5268-panel']/div/form/div[1]/div[1]/text-field/div/div[2]");
        public static By documentNametextfield = By.XPath(".//input[@class='form-control ng-empty ng-touched ng-dirty ng-valid-parse']");
        public static By documentCategoryfield = By.ClassName("form-control ng-pristine ng-valid ng-scope ng-empty ng-touched");
        public static By documentCategoryfieldselection = By.XPath(".//option[text()='Lab Orders']");
        public static By documentTypefield = By.XPath(".//*[@id='accordiongroup-1926-5725-panel']/div/form/div[1]/div[3]/select-field/div/div[2]");
        public static By documentTypefieldselection = By.XPath(".//option[text()='Lab Order']");
        public static By documentDateRangefrom = By.XPath(".//span[@class='k-icon k-i-calendar']");
        public static By documentDateRangeto = By.XPath(".//span[@class='k-icon k-i-calendar']");
        public static By clearButton = By.XPath(".//button[text()='Clear']");
        public static By applyButton = By.XPath(".//span[text()='Apply']");
        public static By documentCategoryfieldselectioncontains = By.XPath(".//span[text()='Doc ID']");
        public static By documentCategorytext = By.ClassName("form-control ng-touched ng-dirty ng-valid-parse ng-empty");
        public static By documentCategoryfieldselectioniseqalu = By.XPath(".//option[text()='Is equal to']");
        public static By documentCategoryfieldselectioniseqaluvalue = By.XPath(".//input[@class='k-formatted-value k-input']");
        public static By documentCategoryfieldselectioniseqaluvalue1 = By.XPath("./html/body/div[1]/div/div/form/div[2]/div/span/span/input[1]");
        public static By documentCategoryfieldsubmit = By.XPath(".//span[text()='Submit']");
        public static By documentCategoryfilterDocID = By.XPath(".//a[text()='Doc ID']");
        public static By documentCategoryfilterDocIDfunnel = By.XPath(".//span[@class='k-grid-filter k-state-active']");
        public static By documentCategoryfieldselectionisnoteqalu = By.XPath(".//option[text()='Is not equal to']");
        public static By documentCategoryfilterDocIDfunnel1 = By.XPath(".//i[@class='fa fa-filter']");

        public static By Firstfilteroptionsvalidation = By.XPath("./html/body/div[1]/div/div/form/div[2]/select");
        public static By Firstfilteroptionsvalidationother = By.XPath("./html/body/div[1]/div/div/form/div[2]/div/span/span/input[1]");

        public static By AdditionalCriterionbutton = By.ClassName("accordion-toggle");

        public static By AdditionalCriterionfull = By.XPath(".//div[@class='panel-collapse in collapse']");

        public static By AdditionalCriterionFirstANDOR = By.XPath(".//select[@class='form-group margin-right-50 ng-scope']");

        public static By AdditionalCriterionsecond = By.XPath(".//div[@class='form-control ng-pristine ng-valid ng-not-empty ng-touched']");
        public static By AdditionalCriterionThird = By.XPath(".//span[@class='k-formatted-value k-input']");

        public static By AdditionalCriterionThirdnew = By.XPath(".//*[@id='accordiongroup-1907-5335-panel']/div/div[2]/div/span/span");


        //Doc grid :delete document

        public static By selectDocument = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[15]/td[4]/div/input");
        public static By selectDocument2nd = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[3]/td[4]/div/input");
        public static By selectDocument1st = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[3]/td[4]/div/input");
        public static By docdelYesbutton = By.XPath(".//button[text()='Yes']");
        public static By selectDocumentconfirm = By.XPath(".//button[@class='btn btn-primary ng-binding']");

        // Doc Grid Access:
        public static By groupSelection = By.XPath(".//*[@id='upperNavLinkArea']/div/div");
        public static By isiSystemAdmin = By.XPath(".//a[text()='ISI System Administrator']");
        public static By userAdminLastNameselction = By.XPath(".//*[@id='mmd-content']/main/div/div/div/div[1]/div[1]/div[1]/div[2]/form/div[2]/input");
        public static By userAdminapplybutton = By.Id("userAdmin-lg-filterButton");
        public static By userAdminprofileselection = By.XPath(".//*[@id='KavithaKH']");
        public static By userAdminProfiletab = By.XPath(".//*[@id='userAdmin-userInfoForm']/div/ul/li[3]/a");
        public static By userAdminProfiletypedropdown = By.XPath(".//*[@id='userAdmin-profileType']");
        public static By userAdminProfiletypeAuthorization = By.XPath(".//*[@id='userAdmin-profileType']/option[2]");
        public static By associatedCarddoPracticeAdmin = By.XPath(".//a[text()='Associated Cardiologist Practi Practice Administrator']");
        public static By docTreeAccessFilterBox = By.XPath("//input[@class='ui-grid-filter-input ng-pristine ng-valid ng-empty ng-touched']");
        public static By docTreeAccessFilterBoxEdit = By.XPath("//input[@class='ui-grid-filter-input ng-valid ng-touched ng-dirty ng-empty']");
        public static By docTreeAccess = By.XPath("//div[@class='ui-grid-filter-container ng-scope']");
        public static By docTreeAcessrowselection = By.XPath(".//span[@class='fa-stack custom-checkbox ng-isolate-scope']");
        public static By docTreeAccessusercheckboxEnabled = By.XPath("(.//span[@class='fa fa-stack-1x fa-check enabled-allow'])[3]");
        public static By docTreeAccessusercheckboxDisabled = By.XPath("(.//span[@class='fa fa-stack-1x fa-times enabled-allow enabled-deny'])[2]");
        public static By allCheckbox = By.XPath(".//span[@class='fa fa-square-o fa-stack-2x checkbox-box']");
        public static By emptyCheckbox = By.XPath("(.//span[@class='fa fa-stack-1x'])[3]");
        public static By emptyuserCheckBox = By.XPath(("(.//span[@class='fa fa-square-o fa-stack-2x checkbox-box'])[5]"));
        public static By actiontabDocumentOption = By.XPath(".//i[text()='Documents']");
        public static By patientCloseButton = By.XPath("//*[@id='patient-summary']/div[1]/div[3]/div[2]/div[1]/button[3]");

        // Sending Doc to EMR

        public static By selectaDocument = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[15]/td[4]/div/input");
        public static By selectaDoctoSendEMR = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[3]/td[4]/div/input");
        public static By selectaDoctoSendEMR1 = By.XPath(".//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[14]/td[4]/div/input");
        public static By selectRoutingPhysiciangrid = By.XPath("./html/body/div[1]/div/div/form/div[2]/div/div[2]/select-field/div/div[2]");
        public static By selectRoutingPhysician = By.XPath(".//option[contains(text(),'Stuart, Test (123456)')]");
        public static By sendButton = By.XPath(".//button[text()='Send']");
        public static By clickOnOKButton = By.XPath(".//button[@class='btn btn-primary ng-binding']");
        public static By cleartheFilterBox = By.XPath(".//i[@class='ui-grid-icon-cancel right']");


        //Docgrid sorting
        public static By systemSettingSelection = By.XPath(".//i[@class='fa fa-cog fa-fw']");
        public static By systemSettingName = By.XPath("(.//input[@class='k-input'])[1]");
        public static By systemsettingEditButton = By.XPath(".//button[@class='btn btn-default']");
        public static By systemsettingEditButton1 = By.XPath(".//*[@id='system-settings-grid']/table/tbody/tr/td[4]/div/button");
        public static By editystemSettingTextArea = By.XPath("./html/body/div[1]/div/div/div[2]/textarea");
        public static By editsettingSaveButton = By.XPath(".//button[text()='Save']");
        public static By documentOrder = By.XPath(".//span[text()='Category: Non-Categorized Documents']");

        public static By columnselectionDocumenName = By.XPath(".//a[text()='Document Name']");
        public static By SortingOrder = By.XPath(".//tr[@class='k-grouping-row']");
        public static By firstDocumentinTableTop = By.XPath(".//span[contains(text(),'Category: Non-Categor')]");
        public static By lastDocumentinTableBottom = By.XPath(".//span[contains(text(),'Category: Non-Categor')]");
        public static By systemsettingValue = By.XPath(".//div[@class='ng-binding ng-scope']");
        public static By documentDateFilter = By.XPath(".//a[@class='k-grid-filter k-state-active']");
        public static By dropdownvalue1 = By.XPath(".//option[text()='Is after or equal to']");
        public static By documentDateFilterNotEnabled = By.XPath("(.//a[@class='k-grid-filter'])[3]");
        // max num of doc view
        public static By PatientArchivePatientSearchsusercheckboxDisabled = By.XPath("(.//span[@class='fa fa-square-o fa-stack-2x checkbox-box'])[5]");
        public static By PatientArchivePatientSearchsusercheckboxEnabled = By.XPath("(.//span[@class='fa fa-stack-1x fa-check enabled-allow'])[3]");
        // Patient Test,Anu
        public static By selectDocforView3 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[3]/td[4]/div/input");
        public static By selectDocforView4 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[4]/td[4]/div/input");
        public static By selectDocforView5 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[5]/td[4]/div/input");
        public static By selectDocforView6 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[6]/td[4]/div/input");
        public static By selectDocforView7 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[7]/td[4]/div/input");
        public static By selectDocforView8 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[8]/td[4]/div/input");
        public static By selectDocforView9 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[9]/td[4]/div/input");
        public static By selectDocforView10 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[10]/td[4]/div/input");
        public static By selectDocforView11 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[11]/td[4]/div/input");
        public static By selectDocforView12 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[12]/td[4]/div/input");
        public static By selectDocforView13 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[13]/td[4]/div/input");
        public static By selectDocforView14 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[14]/td[4]/div/input");
        public static By selectDocforView15 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[15]/td[4]/div/input");
        public static By selectDocforView16 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[16]/td[4]/div/input");
        public static By selectDocforView17 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[17]/td[4]/div/input");
        public static By selectDocforView18 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[18]/td[4]/div/input");
        public static By selectDocforView19 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[19]/td[4]/div/input");
        public static By selectDocforView20 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[20]/td[4]/div/input");
        public static By selectDocforView21 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[21]/td[4]/div/input");
        public static By selectDocforView22 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[22]/td[4]/div/input");
        public static By selectDocforView23 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[23]/td[4]/div/input");
        public static By selectDocforView24 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[24]/td[4]/div/input");
        public static By selectDocforView25 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[25]/td[4]/div/input");
        public static By selectDocforView26 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[26]/td[4]/div/input");
        public static By selectDocforView27 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[27]/td[4]/div/input");
        public static By selectDocforView28 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[28]/td[4]/div/input");
        public static By selectDocforView29 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[29]/td[4]/div/input");
        public static By selectDocforView30 = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[30]/td[4]/div/input");

        //Patient Smith Anna
        public static By viewDocumentWithBreak = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/ul/li[4]/a");
        public static By viewDocumentWithoutBreak = By.XPath("//*[@id='documentTree-treeContainer']/div[1]/div[2]/div[2]/div[5]/ul/li[5]/a");
        public static By clickonOKbutton = By.XPath("/html/body/div[1]/div/div/div[3]/button[3]");
        //Sorting
        public static By firstDocumentInTable = By.XPath(" //*[@id='documentTree-treeContainer']/div[1]/div[7]/div/div[3]/table/tbody/tr[1]/td/p/span");


        //FlowSheet: Accession
        //Result Home page and patient search
        public static By PatientSearchResultDataTable = By.XPath("//*[@id='results-table']");
        public static By flowsheetResultablevalidation = By.XPath("//*[@id='tab-flowsheets']");

        //filters on result inbox
        public static By resultHomePage = By.XPath("//a[@data-menu-id='results_workflow']");
        public static By resultInboxFiltersLink = By.Id("inbox-filters-title");
        public static By resultInboxFiltersLink1 = By.XPath(".//*[@id='inbox-filters-title']");
        public static By resultInbox_PatientLaseName = By.Id("filter-patient-last-name");
        public static By resultInbox_PatientFirstName = By.Id("filter-patient-first-name");
        public static By resultInbox_PatientDOB = By.XPath("//input[@title='Patient DOB']");
        public static By resultInbox_DocumentName = By.XPath("//*[@id='inbox-filters-body']/div/form/div/mmd-results-filters/div/div[2]/div[1]/input");


        public static By resultInboxFilterApplyButton = By.Id("inbox-filter-apply-button");

        public static By flowSheetsonActionDD = By.XPath("//*[@id='results-table']/tbody/tr[1]/td[10]/div/div/ul/li[6]/a");
        public static By flowSheeetPage = By.XPath("/html/body/div[1]/div/div/div[1]/h3");
        public static By flowSheeetFiltersIcon = By.XPath(".//a[text()=' Filters']");

        public static By flowsheetSelection = By.XPath(".//a[text()=' Flowsheets                                    ']");
        public static By flowsheettab = By.XPath("(.//a[text()='Flowsheets'])[2]");

        public static By flowsheetGraphICON = By.XPath("//*[@id='flowsheetsGrid']/div[3]/table/tbody/tr[1]/td[1]/mmd-flowsheets-graph/div/button");
        public static By flowsheetGraph = By.XPath(".//span[text()='Flowsheet Graph']");
        //public static By flowsheetGraphValidation = By.Id("{{ model.uid}}_dateview");

        public static By flowsheetGraphValidation = By.XPath(".//input[@class=' k-calendar-container k-popup k-group k-reset']");




        //Flowsheet Category view

        public static By flowSheetCategoryView = By.XPath(".//label[text()='										Category                                    ']");
        public static By flowsheetCategoryoption1 = By.XPath(".//option[text()='Diabetes']");
        public static By flowsheetCategoryoptionechocardiogram = By.XPath(".//option[text()='echocardiogram']");
        public static By flowsheetCategoryoptionLipids = By.XPath(".//option[text()='Lipids']");
        public static By flowsheetCategoryoptionTest2 = By.XPath(".//option[text()='Add New Flowsheet Test 2']");

        public static By flowsheetAggregateSource = By.XPath(".//th[text()='Source']");

        //Flowsheet Panel view

        public static By flowSheetPanelView1 = By.XPath(".//label[text()='										Panel                                    ']");
        public static By flowSheetPanelView = By.Name("1795");
        public static By flowsheetPanelDropDownALL = By.XPath("//option[text()='All']");

        public static By flowsheetPanelDropDownHA1C = By.XPath("//option[text()='HA1C WITH ESTIMATED AVERAGE GLUCOSE']");
        public static By flowsheetPanelDDLIPIDPANEL = By.XPath(".//option[text()='LIPID PANEL']");


        //Date Filter-TimePeriod
        public static By flowsheetDateFilterTimePeriod = By.Id("flowsheet-filter-time-period");
        public static By flowsheetDateFilterTimePeriodDropDown = By.XPath(".//option[text()='6 Months']");
        public static By flowsheetDateFilterTimePeriodDD3months = By.XPath(".//option[text()='3 Months']");
        // public static By flowsheetDateFilterTimePeriodDDALL = By.XPath(".//option[text()='All']");
        public static By flowsheetDateFilterTimeDropDown = By.XPath("(.//select[@class='form-control ng-valid ng-scope ng-not-empty ng-dirty ng-valid-parse ng-touched'])[2]");
        public static By flowsheetDateFilterTimePeriodDDALL = By.XPath("(//option[text()='All'])[3]");
        //public static By flowsheetDateFilterTimePeriodDDALL = By.XPath(".//option[contains(label(),'All')]");




        //Date Filter-Date Range
        public static By flowsheetDateFilterDateRange = By.Id("flowsheet-filter-date-range");

        // public static By flowsheetDateFilterDateRange = By.XPath(".//input[text()='										Date Range                                    ']");
        // public static By flowsheetDateFilterDateRange = By.XPath("(.//input[@class='ng-pristine ng-valid ng-not-empty ng-touched'])[2]");

        public static By flowsheetBeginDate = By.XPath("(.//span[@class='k-icon k-i-calendar'])[3]");
        public static By flowsheetBeginDateNew = By.XPath("(.//span[@class='k-icon k-i-calendar'])[1]");
        // public static By flowsheetBeginDatepicker1 = By.XPath("//input[contains(@class,'form-for-date ng-valid ng-isolate-scope k-input ng-empty ng-valid-mask ng-touched ng-dirty ng-valid-parse')]");
        //public static By flowsheetBeginDatepicker = By.XPath("//input[contains(@class,'form-for-date ng-pristine ng-valid ng-isolate-scope k-input ng-valid-mask ng-not-empty ng-touched')]");


        public static By flowsheetBD = By.XPath("//*[@id='accordiongroup-1791-3888-panel']/div/form/div[1]/div[2]/div[2]/div/div[1]/date-field/div/div[2]/div/span");
        public static By flowsheetBeginDate1 = By.XPath("(.//span[@class='k-picker-wrap k-state-default'])[3]");
        public static By flowsheetBeginDate1New = By.XPath("//span[@class='k-picker-wrap k-state-default']");
        public static By flowsheetBeginDatepicker1 = By.XPath(".//input[@class='form-for-date ng-valid ng-isolate-scope k-input ng-empty ng-valid-mask ng-touched ng-dirty ng-valid-parse']");
        public static By flowsheetBeginDatepicker = By.XPath(".//input[@class='form-for-date ng-pristine ng-valid ng-isolate-scope k-input ng-valid-mask ng-not-empty ng-touched']");
        public static By flowsheetEndDate = By.XPath("(.//span[@class='k-icon k-i-calendar'])[4]");
        public static By flowsheetEndDate1 = By.XPath("(.//span[@class='k-picker-wrap k-state-default'])[4]");
        public static By flowsheetEndDatePicker1 = By.XPath(".//input[@class='form-for-date ng-valid ng-isolate-scope k-input ng-empty ng-valid-mask ng-touched ng-dirty ng-valid-parse']");
        public static By flowsheetEndDatePicker = By.XPath(".//input[@class='form-for-date ng-pristine ng-valid ng-isolate-scope k-input ng-valid-mask ng-not-empty ng-touched']");
        public static By flowsheetwithdatedisplay = By.XPath(".//th[text()='11/20/2011']");


        //Aggregate option
        public static By flowsheetAggregate = By.XPath(".//label[text()='Aggregate']");
        public static By flowsheetAggregateYesButton = By.XPath("//*[@id='flowsheet-filter-aggregate-yes']");
        public static By flowsheetAggregateNoButton = By.Id("flowsheet-filter-aggregate-no");

        public static By flowsheetPatChartselection = By.XPath(".//*[@id='patients-container']/div/table/tbody/tr/td[1]/a");
        public static By patChartFlowsheetTab = By.XPath(".//*[@id='summaryTabContainer']/div/ul/li[5]/a");

        //different buttons on Flowsheet window
        public static By flowsheetApplyButton = By.XPath(".//button[text()='Apply']");
        public static By flowsheetSaveButton = By.XPath(".//button[text()='Save']");
        //public static By flowsheetClearButton = By.XPath(".//button[text()='Clear']");
        public static By flowsheetClearButton = By.XPath("(.//button[text()='Clear'])[2]");
        public static By flowsheetClearButton1 = By.XPath(".//*[@id='accordiongroup-1787-23-panel']/div/form/div[2]/div/div[1]/button[1]");
        public static By flowsheetExportToExcel = By.XPath(".//span[text()='Export to Excel']");
        public static By flowsheetExportToExcelbutton = By.XPath(".//*[@id='flowsheetsGrid']/div[1]/a");
        public static By flowsheetCloseButton = By.XPath("./ html/body/div[1]/div/div/div[3]/button");
        public static By PatientSummaryCloseButton = By.XPath("//*[@id='patient-summary']/div[1]/div[3]/div[2]/div[1]/button[3]");

        //Flowsheet Access authori:

        public static By flowsheetAccessUsercheckboxEnabled = By.XPath("(.//span[@class='fa fa-stack-1x fa-check enabled-allow'])[3]");
        public static By flowsheetAccessUsercheckboxDisabled = By.XPath("(.//span[@class='fa fa-stack-1x fa-times enabled-allow enabled-deny'])[2]");
        public static By flowsheetEffectiveCheckboxEnabled = By.XPath("(.//span[@class='fa fa-stack-1x fa-check enabled-allow'])[1]");
        public static By flowsheetAccessEffectivecheckboxDisabled = By.XPath("(.//span[@class='fa fa-stack-1x fa-times enabled-allow enabled-deny'])[1]");
        public static By flowsheetemptyUserCheckbox = By.XPath("(.//span[@class='fa fa-square-o fa-stack-2x checkbox-box'])[5]");
        public static By flowsheetCategoriesDropdown = By.XPath(".//select[@class='form-control ng-valid ng-scope ng-not-empty ng-dirty ng-valid-parse ng-touched']");

        // Sort

        public static By flowsheetLabelSort = By.XPath(".//label[text()='Sort']");
        public static By flowsheetSortNewToOld = By.Id("flowsheet-filter-sort-new-to-old");
        public static By flowsheetSortOldToNew = By.Id("flowsheet-filter-sort-old-to-new");


    }
}
