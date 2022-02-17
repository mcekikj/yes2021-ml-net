using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LeadScoringDecision_Console;

namespace LeadScoringDecision_Function
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Hello ML.NET from Azure Function!");

            var requestBody = await req.ReadAsStringAsync();

            var requestBodyContent = JsonConvert.DeserializeObject<LeadGenerationML.ModelInput>(requestBody);

            //Load sample data
            var observation = new LeadGenerationML.ModelInput()
            {
                Do_Not_Email = requestBodyContent.Do_Not_Email,
                TotalVisits = requestBodyContent.TotalVisits,
                Total_Time_Spent_on_Website = requestBodyContent.Total_Time_Spent_on_Website,
                Page_Views_Per_Visit = requestBodyContent.Page_Views_Per_Visit,
                Lead_Origin_Landing_Page_Submission = requestBodyContent.Lead_Origin_Landing_Page_Submission,
                Lead_Origin_Lead_Add_Form = requestBodyContent.Lead_Origin_Lead_Add_Form,
                Lead_Origin_Lead_Import = requestBodyContent.Lead_Origin_Lead_Import,
                Lead_Origin_Quick_Add_Form = requestBodyContent.Lead_Origin_Quick_Add_Form,
                Lead_Source_Facebook = requestBodyContent.Lead_Source_Facebook,
                Lead_Source_Google = requestBodyContent.Lead_Source_Google,
                Lead_Source_Olark_Chat = requestBodyContent.Lead_Source_Olark_Chat,
                Lead_Source_Organic_Search = requestBodyContent.Lead_Source_Organic_Search,
                Lead_Source_Other_Sources = requestBodyContent.Lead_Source_Other_Sources,
                Lead_Source_Reference = requestBodyContent.Lead_Source_Reference,
                Lead_Source_Referral_Sites = requestBodyContent.Lead_Source_Referral_Sites,
                Lead_Source_Welingak_Website = requestBodyContent.Lead_Source_Welingak_Website,
                Last_Activity_Email_Bounced = requestBodyContent.Last_Activity_Email_Bounced,
                Last_Activity_Email_Link_Clicked = requestBodyContent.Last_Activity_Email_Link_Clicked,
                Last_Activity_Email_Opened = requestBodyContent.Last_Activity_Email_Opened,
                Last_Activity_Form_Submitted_on_Website = requestBodyContent.Last_Activity_Form_Submitted_on_Website,
                Last_Activity_Olark_Chat_Conversation = requestBodyContent.Last_Activity_Olark_Chat_Conversation,
                Last_Activity_Other_Activity = requestBodyContent.Last_Activity_Other_Activity,
                Last_Activity_Page_Visited_on_Website = requestBodyContent.Last_Activity_Page_Visited_on_Website,
                Last_Activity_SMS_Sent = requestBodyContent.Last_Activity_SMS_Sent,
                Last_Activity_Unreachable = requestBodyContent.Last_Activity_Unreachable,
                Last_Activity_Unsubscribed = requestBodyContent.Last_Activity_Unsubscribed,
                Specialization_Business_Administration = requestBodyContent.Specialization_Business_Administration,
                Specialization_E_Business = requestBodyContent.Specialization_E_Business,
                Specialization_E_COMMERCE = requestBodyContent.Specialization_E_COMMERCE,
                Specialization_Finance_Management = requestBodyContent.Specialization_Finance_Management,
                Specialization_Healthcare_Management = requestBodyContent.Specialization_Healthcare_Management,
                Specialization_Hospitality_Management = requestBodyContent.Specialization_Hospitality_Management,
                Specialization_Human_Resource_Management = requestBodyContent.Specialization_Human_Resource_Management,
                Specialization_IT_Projects_Management = requestBodyContent.Specialization_IT_Projects_Management,
                Specialization_International_Business = requestBodyContent.Specialization_International_Business,
                Specialization_Marketing_Management = requestBodyContent.Specialization_Marketing_Management,
                Specialization_Media_and_Advertising = requestBodyContent.Specialization_Media_and_Advertising,
                Specialization_Operations_Management = requestBodyContent.Specialization_Operations_Management,
                Specialization_Others = requestBodyContent.Specialization_Others,
                Specialization_Retail_Management = requestBodyContent.Specialization_Retail_Management,
                Specialization_Rural_and_Agribusiness = requestBodyContent.Specialization_Rural_and_Agribusiness,
                Specialization_Services_Excellence = requestBodyContent.Specialization_Services_Excellence,
                Specialization_Supply_Chain_Management = requestBodyContent.Specialization_Supply_Chain_Management,
                Specialization_Travel_and_Tourism = requestBodyContent.Specialization_Travel_and_Tourism,
                What_is_your_current_occupation_Housewife = requestBodyContent.What_is_your_current_occupation_Housewife,
                What_is_your_current_occupation_Other = requestBodyContent.What_is_your_current_occupation_Other,
                What_is_your_current_occupation_Student = requestBodyContent.What_is_your_current_occupation_Student,
                What_is_your_current_occupation_Unemployed = requestBodyContent.What_is_your_current_occupation_Unemployed,
                What_is_your_current_occupation_Working_Professional = requestBodyContent.What_is_your_current_occupation_Working_Professional,
            };

            //Load model and predict output
            var result = LeadGenerationML.Predict(observation);

            //return new OkObjectResult($"The currently observed sample has the potential of being " +
            //    $"{(result.Prediction == 0 ? "Not Converted" : "Converted")}");

            return new OkObjectResult(result);
            //test
        }
    }
}
