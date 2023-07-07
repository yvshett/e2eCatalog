using System.Collections.Generic;
using System.Threading.Tasks;
using DadtApi.CommonUtility;
using DadtApi.DomainModels;
using DadtApi.IServices;
using DadtApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageController : ControllerBase
    {
        IAttributeMetaDataService _IAttributeMetaDataService = null;

        public HomePageController(IAttributeMetaDataService objAttributeMetaDataService)
        {
            _IAttributeMetaDataService = objAttributeMetaDataService;
        }

        [HttpGet("app/GetLandingAttributes")]
        public async Task<ActionResult<dynamic>> GetLandingAttributes()
        {
            try
            {

            int iapId = 0;
            List<WebObjectMetadatum> listMetaData = await _IAttributeMetaDataService.Get("LandingPage");
            HomePage homePage = new HomePage();

            homePage.Registration = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionRegistrationHeader", "HEADER", string.Empty, iapId),
                content = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionRegistrationContent", "CONTENT", string.Empty, iapId)
            };

            homePage.allSolutions = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionAllSolutionsHeader", "HEADER", string.Empty, iapId),
                content = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionAllSolutionsContent", "CONTENT", string.Empty, iapId)
            };

            homePage.mySolutions = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionMySolutionsHeader", "HEADER", string.Empty, iapId),
                content = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionMySolutionsContent", "CONTENT", string.Empty, iapId)
            };

            homePage.Analytics = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionAnalyticsHeader", "HEADER", string.Empty, iapId),
                content = MetadataHandlers.MetaDataBuilderString(listMetaData, "sectionAnalyticsContent", "CONTENT", string.Empty, iapId)
            };


            homePage.whatisDADT = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "whatisDADTHeader", "HEADER", string.Empty, iapId),
                content = MetadataHandlers.MetaDataBuilderString(listMetaData, "whatisDADTContent", "CONTENT", string.Empty, iapId)
            };
            homePage.whyRegisterDADT = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "whyRegisterDADTHeader", "HEADER", string.Empty, iapId),
                content = MetadataHandlers.MetaDataBuilderString(listMetaData, "whyRegisterDADTContent", "CONTENT", string.Empty, iapId)
            };
            homePage.whatRegisterDADT = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "whatRegisterDADTHeader", "HEADER", string.Empty, iapId),
                content = MetadataHandlers.MetaDataBuilderString(listMetaData, "whatRegisterDADTContent", "CONTENT", string.Empty, iapId),
                list = MetadataHandlers.MetaDataBuilderString(listMetaData, "whatRegisterDADTContentList", "CONTENT", string.Empty, iapId),
            };
            homePage.dadtRegistrationExamples = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "dadtRegistrationExamplesHeader", "HEADER", string.Empty, iapId),
               // content = MetadataHandlers.MetaDataBuilderString(listMetaData, "", "CONTENT", string.Empty, iapId)
            };
            homePage.whatsNewInDADT = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "whatsNewInDADTHeader", "HEADER", string.Empty, iapId),
            };

            homePage.announcementBanner = new HomePageAttributes()
            {
                Header = MetadataHandlers.MetaDataBuilderString(listMetaData, "announcementBanner", "HEADER", string.Empty, iapId),
            };

            return homePage;
            }
            catch (System.Exception)
            {

                throw;
            }

        }
    }
}

public class HomePage
{
    public HomePageAttributes Registration { get; set; }

    public HomePageAttributes allSolutions { get; set; }

    public HomePageAttributes mySolutions { get; set; }

    public HomePageAttributes Analytics { get; set; }

    public HomePageAttributes whatisDADT { get; set; }

    public HomePageAttributes whyRegisterDADT { get; set; }

    public HomePageAttributes whatRegisterDADT { get; set; }

    public HomePageAttributes dadtRegistrationExamples { get; set; }
    
    public HomePageAttributes whatsNewInDADT { get; set; }

    public HomePageAttributes announcementBanner { get; set; }
}

public class HomePageAttributes
{
    public ElmtMetadataString Header { get; set; }

    public ElmtMetadataString content { get; set; }

    public ElmtMetadataString list { get; set; }
}
