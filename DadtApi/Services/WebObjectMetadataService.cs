using DadtApi.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DadtApi.IServices;
using Microsoft.EntityFrameworkCore;
using DadtApi.DomainModels;
using System;
using System.Reflection;
using DadtApi.CommonUtility;

namespace DadtApi.Services
{
    public class WebObjectMetadataService : IWebObjectMetadataService
    {
        private readonly dbContext _context;
        private readonly ILog _log;

        public WebObjectMetadataService(dbContext context, ILog log)
        {
            _context = context;
            _log = log;
        }

        /// <summary>
        /// Returns distinct page names from WebObjectMetadata table
        /// to populate web objects admin page dropdown
        /// </summary>
        /// <returns>List of string page names</returns>
        public async Task<List<string>> GetPageNames()
        {
            var pageNames = new List<string>();
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

            try
            {
                pageNames.Add("All");
                var pagesNms = await _context.WebObjectMetadata.Select(w => w.PageNm).Distinct().ToListAsync();
                
                if (pagesNms != null) pageNames.AddRange(pagesNms);
                
                return pageNames;
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            }

            return pageNames;
        }

        /// <summary>
        /// Returns web object metadata on page selected passed as parameter
        /// to populate web objects admin page table
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns>Records of web objects</returns>
        public async Task<List<WebObjectView>> GetWebObjectMetadata(string pageName)
        {
            var webObjects = new List<WebObjectView>();
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;

            try
            {
                webObjects = await _context.WebObjectMetadata.Where(s => s.PageNm == pageName || pageName == "All")
                .Select(w => new WebObjectView
                {
                    WebObjectMetadataId = w.WebObjectMetadataId,
                    LabelTxt = w.LabelTxt,
                    PlaceholderTxt = w.PlaceholderTxt,
                    ToolTipMandatoryInd = w.ToolTipMandatoryInd,
                    ToolTipMessageTxt = w.ToolTipMessageTxt,
                    PageNm = w.PageNm,
                    WebObjectType = w.WebObjectType,
                    MandatoryInd = w.MandatoryInd,
                    MandatoryValidationMessageTxt = w.MandatoryValidationMessageTxt,
                    DataLoadApiUrl = w.DataLoadApiUrl,
                    InitialValueTxt = w.InitialValueTxt,
                    DisplayOrderNbr = w.DisplayOrderNbr,
                    ClassNm = w.ClassNm,
                    WebObjectNm = w.WebObjectNm,
                    DisableInd = w.DisableInd,
                    GroupNm = w.GroupNm,
                    OnDemandDataLoadInd = w.OnDemandDataLoadInd,
                    VisibilityInd = w.VisibilityInd,
                    CertifyInd = w.CertifyInd,
                    WizardInd = w.WizardInd,
                    WizardSectionId = w.WizardSectionId,
                    LabelExtensionTxt = w.LabelExtensionTxt,
                    LabelExtensionTxtClassNm = w.LabelExtensionTxtClassNm,
                    MinimumLengthMandatoryInd = w.MinimumLengthMandatoryInd,
                    MinimumLengthNbr = w.MinimumLengthNbr,
                    MinimumLengthValidationMessageTxt = w.MinimumLengthValidationMessageTxt,
                    ValueSingleSelectInd = w.ValueSingleSelectInd,
                    WebObjectId = w.WebObjectId,
                    MaximumLengthNbr = w.MaximumLengthNbr,
                    ValuePresentIndValidationMessageTxt = w.ValuePresentIndValidationMessageTxt
                }).ToListAsync();

                return webObjects;
            }
            catch (Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            }

            return webObjects;
        }

        /// <summary>
        /// Update existing web object metadata
        /// </summary>
        /// <param name="webObject"></param>
        /// <returns>success/fail</returns>
        public async Task<string> UpdateWebObject(WebObjectView webObject)
        {
            string startTime = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ");
            string stepName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
        
            try
            {
                var webObjectData = await _context.WebObjectMetadata.Where(w => w.WebObjectMetadataId == webObject.WebObjectMetadataId).FirstOrDefaultAsync();
                if (webObjectData != null) 
                {
                    webObjectData.LabelTxt = webObject.LabelTxt;
                    webObjectData.PlaceholderTxt = webObject.PlaceholderTxt;
                    webObjectData.ToolTipMandatoryInd = webObject.ToolTipMandatoryInd;
                    webObjectData.ToolTipMessageTxt = webObject.ToolTipMessageTxt;
                    webObjectData.MandatoryInd = webObject.MandatoryInd;
                    webObjectData.MandatoryValidationMessageTxt = webObject.MandatoryValidationMessageTxt;
                    webObjectData.DataLoadApiUrl = webObject.DataLoadApiUrl;
                    webObjectData.InitialValueTxt = webObject.InitialValueTxt;
                    webObjectData.DisplayOrderNbr = webObject.DisplayOrderNbr;
                    webObjectData.ClassNm = webObject.ClassNm;
                    webObjectData.DisableInd = webObject.DisableInd;
                    webObjectData.OnDemandDataLoadInd = webObject.OnDemandDataLoadInd;
                    webObjectData.VisibilityInd = webObject.VisibilityInd;
                    webObjectData.CertifyInd = webObject.CertifyInd;
                    webObjectData.WizardInd = webObject.WizardInd;
                    webObjectData.WizardSectionId = webObject.WizardSectionId;
                    webObjectData.LabelExtensionTxt = webObject.LabelExtensionTxt;
                    webObjectData.LabelExtensionTxtClassNm = webObject.LabelExtensionTxtClassNm;
                    webObjectData.MinimumLengthMandatoryInd = webObject.MinimumLengthMandatoryInd;
                    webObjectData.MinimumLengthNbr = webObject.MinimumLengthNbr;
                    webObjectData.MinimumLengthValidationMessageTxt = webObject.MinimumLengthValidationMessageTxt;
                    webObjectData.ValueSingleSelectInd = webObject.ValueSingleSelectInd;
                    webObjectData.MaximumLengthNbr = webObject.MaximumLengthNbr;
                    webObjectData.ValuePresentIndValidationMessageTxt = webObject.ValuePresentIndValidationMessageTxt;
                    webObjectData.ChangeAgentId = webObject.ChangeAgentId;
                    webObjectData.ChangeDtm = webObject.ChangeDtm;
                    _context.WebObjectMetadata.Update((Models.WebObjectMetadatum)webObjectData);
                    await _context.SaveChangesAsync();

                    return "success";
                }
            }
            catch(Exception ex)
            {
                _log.LogEntry(stepName, "Error : " + ex, CommonUtility.Constants.STR_LOG_TYPE_ERROR, startTime, DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fffZ"));
            }

            return "fail";
        }
    }
}
