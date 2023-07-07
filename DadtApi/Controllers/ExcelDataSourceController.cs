using Microsoft.AspNetCore.Mvc;
using System;

namespace DadtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelDataSourceController : ControllerBase
    {

        public ExcelDataSourceController()
        {

        }

        /// Get the excel data source.
        /// <param name="id"> ODATA string for excel download </param>
        /// <param name="report_type"> If report is for All Solutions download in excel or My Solutions download in excel </param>
        /// /// <param name="commandText"> ODATA connection name </param>
        /// <returns>
        /// data source for excel download. 
        /// </returns>      

        // GET api/exceldatasource
        [HttpGet]
        public IActionResult Get(string id, string report_type, string commandText)
        {
            string fileContent = "";
            try
            {
                if (report_type == "AllSolutions")
                {
                    fileContent = @"<html xmlns:o=""urn:schemas-microsoft-com:office:office""
                    xmlns=""http://www.w3.org/TR/REC-html40"">

                    <head>
                    <meta http-equiv=Content-Type content=""text/x-ms-odc; charset=utf-8"">
                    <meta name=ProgId content=ODC.Database>
                    <meta name=SourceType content=OLEDB>
                    <title>ApplicationReport</title>
                    <xml id=docprops><o:DocumentProperties
                    xmlns:o=""urn:schemas-microsoft-com:office:office""
                    xmlns=""http://www.w3.org/TR/REC-html40"">
                    <o:Name>ApplicationReport</o:Name>
                    </o:DocumentProperties>
                    </xml><xml id=msodc><odc:OfficeDataConnection
                    xmlns:odc=""urn:schemas-microsoft-com:office:odc""
                    xmlns=""http://www.w3.org/TR/REC-html40"">
                    <odc:PowerQueryConnection odc:Type=""OLEDB"">
                    <odc:ConnectionString>Provider=Microsoft.Mashup.OleDb.1;Data Source=$Workbook$;Location=ApplicationReport;Extended Properties=&quot;&quot;</odc:ConnectionString>
                    <odc:CommandType>SQL</odc:CommandType>
                    <odc:CommandText>" + commandText + @"</odc:CommandText>
                    </odc:PowerQueryConnection>
                    <odc:PowerQueryMashupData>&lt;Mashup xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns=&quot;http://schemas.microsoft.com/DataMashup&quot;&gt;&lt;Client&gt;EXCEL&lt;/Client&gt;&lt;Version&gt;2.90.582.0&lt;/Version&gt;&lt;MinVersion&gt;2.21.0.0&lt;/MinVersion&gt;&lt;Culture&gt;en-US&lt;/Culture&gt;&lt;SafeCombine&gt;true&lt;/SafeCombine&gt;&lt;Items&gt;&lt;Query Name=&quot;ApplicationReport&quot;&gt;&lt;Formula&gt;&lt;![CDATA[let&#13;&#10;    Source = Xml.Tables(Web.Contents(&quot;" + id + @"&quot;, [Timeout=#duration(0, 0, 30, 0)])),&#13;&#10;    Table0 = Source{0}[Table],&#13;&#10;    #&quot;Changed Type&quot; = Table.TransformColumnTypes(Table0,{{&quot;ApplicationId&quot;, Int64.Type}, {&quot;ApplicationNm&quot;, type text}, {&quot;ApplicationAcronymNm&quot;, type text}, {&quot;ApplicationDsc&quot;, type text}, {&quot;ApplicationDetailsUrlTxt&quot;, type text}, {&quot;ApplicationClassificationNm&quot;, type text}, {&quot;ProductTypeNm&quot;, type text}, {&quot;InformationDataClassificationNm&quot;, type text}, {&quot;InformationTechnologySupportTierNm&quot;, type text}, {&quot;ApplicationLifecycleStatusNm&quot;, type text}, {&quot;TmModelNm&quot;, type text}, {&quot;ApplicationDevelopedByIntelInd&quot;, type text}, {&quot;SupplierNm&quot;, type text}, {&quot;SaasSolutionInd&quot;, type text}, {&quot;ApplicationAccessibleOutsideIntelNetworkWithoutVpnInd&quot;, type text}, {&quot;ApplicationHostingTypeNm&quot;, type text}, {&quot;ApplicationUserBaseNm&quot;, type text}, {&quot;SuperGroupLongNm&quot;, type text}, {&quot;GroupLongNm&quot;, type text}, {&quot;DivisionLongNm&quot;, type text}, {&quot;ApplicationOwningDepartmentNm&quot;, type text}, {&quot;ProductOwnerNm&quot;, type text}, {&quot;InformationTechnologyManagedApplicationInd&quot;, type text}, {&quot;InformationTechnologySegmentNm&quot;, type text}, {&quot;InformationTechnologyServiceNm&quot;, type text}})&#13;&#10;in&#13;&#10;    #&quot;Changed Type&quot;]]&gt;&lt;/Formula&gt;&lt;IsParameterQuery xsi:nil=&quot;true&quot; /&gt;&lt;IsDirectQuery xsi:nil=&quot;true&quot; /&gt;&lt;/Query&gt;&lt;/Items&gt;&lt;/Mashup&gt;</odc:PowerQueryMashupData>
                    </odc:OfficeDataConnection>
                    </xml>
                    <style>
 

                    </style>
 

                    </head>
 

                    </html>";
                }

                byte[] bytes = new byte[fileContent.Length * sizeof(char)];
                System.Buffer.BlockCopy(fileContent.ToCharArray(), 0, bytes, 0, bytes.Length);

                return File(System.Text.Encoding.ASCII.GetBytes(fileContent), "application/octet-stream", "DADT_oDataConnection.odc");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}