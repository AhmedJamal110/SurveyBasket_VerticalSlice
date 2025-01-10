﻿namespace SurveyBasket_VerticalSlice.Features.Authentication.Shared
{
    public static class EmailBodyBuillder
    {
        public static string GenerateEmailBody(string template, Dictionary<string, string> templateModel)
        {
            //var templatePath = $"{Directory.GetCurrentDirectory()}/Templates/{template}.html";
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", $"{template}.html");

            var streamReader = new StreamReader(templatePath);
            var body = streamReader.ReadToEnd();

            foreach (var item in templateModel)
            {
                body = body.Replace(item.Key, item.Value);
            }

            return body;
        }
    }
}