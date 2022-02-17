// See https://aka.ms/new-console-template for more information
using LeadScoringDecision_Console;

Console.WriteLine("Hello ML.NET from Console App!");

//Load sample data
var sampleData = new LeadGenerationML.ModelInput()
{
    Do_Not_Email = 0F,
    TotalVisits = -1.151F,
    Total_Time_Spent_on_Website = -0.89F,
    Page_Views_Per_Visit = -1.267F,
    Lead_Origin_Landing_Page_Submission = 0F,
    Lead_Origin_Lead_Add_Form = 0F,
    Lead_Origin_Lead_Import = 0F,
    Lead_Origin_Quick_Add_Form = 0F,
    Lead_Source_Facebook = 0F,
    Lead_Source_Google = 0F,
    Lead_Source_Olark_Chat = 1F,
    Lead_Source_Organic_Search = 0F,
    Lead_Source_Other_Sources = 0F,
    Lead_Source_Reference = 0F,
    Lead_Source_Referral_Sites = 0F,
    Lead_Source_Welingak_Website = 0F,
    Last_Activity_Email_Bounced = 0F,
    Last_Activity_Email_Link_Clicked = 0F,
    Last_Activity_Email_Opened = 0F,
    Last_Activity_Form_Submitted_on_Website = 0F,
    Last_Activity_Olark_Chat_Conversation = 0F,
    Last_Activity_Other_Activity = 0F,
    Last_Activity_Page_Visited_on_Website = 1F,
    Last_Activity_SMS_Sent = 0F,
    Last_Activity_Unreachable = 0F,
    Last_Activity_Unsubscribed = 0F,
    Specialization_Business_Administration = 0F,
    Specialization_E_Business = 0F,
    Specialization_E_COMMERCE = 0F,
    Specialization_Finance_Management = 0F,
    Specialization_Healthcare_Management = 0F,
    Specialization_Hospitality_Management = 0F,
    Specialization_Human_Resource_Management = 0F,
    Specialization_IT_Projects_Management = 0F,
    Specialization_International_Business = 0F,
    Specialization_Marketing_Management = 0F,
    Specialization_Media_and_Advertising = 0F,
    Specialization_Operations_Management = 0F,
    Specialization_Others = 1F,
    Specialization_Retail_Management = 0F,
    Specialization_Rural_and_Agribusiness = 0F,
    Specialization_Services_Excellence = 0F,
    Specialization_Supply_Chain_Management = 0F,
    Specialization_Travel_and_Tourism = 0F,
    What_is_your_current_occupation_Housewife = 0F,
    What_is_your_current_occupation_Other = 0F,
    What_is_your_current_occupation_Student = 0F,
    What_is_your_current_occupation_Unemployed = 1F,
    What_is_your_current_occupation_Working_Professional = 0F,
};

//Load model and predict output
LeadGenerationML.ModelOutput predictionResult = LeadGenerationML.Predict(sampleData);

Console.WriteLine($"The specific proscpet currently observed has the potential of being " +
    $"{(predictionResult.Prediction == 0f ? "'Not Converted'" : "'Converted'")}");

Console.WriteLine($"The specific prospect has the score of {predictionResult.Score[0]} not being converted, " +
    $"while the score of {predictionResult.Score[1]} of being converted.");