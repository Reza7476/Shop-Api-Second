﻿using Common.Application.FileUtil;
using Common.Application.SecurityUtil;
using Common.Domain;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Common.Application.Validation.FluentValidations
{
    public static class FluentValidations
    {
        public static IRuleBuilderOptionsConditions<T, TProperty> JustImageFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "شما فقط قادر به وارد کردن عکس میباشید") where TProperty : IFormFile?
        {
            return ruleBuilder.Custom((file, context) =>
            {
                if (file == null)
                    return;

                if (!ImageValidator.IsImage(file))
                {
                    context.AddFailure(errorMessage);
                }
            });
        }
        public static IRuleBuilderOptionsConditions<T, string> ValidNationalId<T>(this IRuleBuilder<T,string> ruleBuilder, string errorMessage = "کد ملی نا معتبر میباشید") 
        {
            return ruleBuilder.Custom((nationalCode, context) =>
            {
               if(IranianNationaCodeChecker.IsValid(nationalCode)==false)
                    context.AddFailure(errorMessage);   
            });
        }



        public static IRuleBuilderOptionsConditions<T, TProperty> JustValidFile<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string errorMessage = "فایل نامعتبر است") where TProperty : IFormFile
        {
            return ruleBuilder.Custom((file, context) =>
            {
                if (file == null)
                    return;

                if (!FileValidation.IsValidFile(file))
                {
                    context.AddFailure(errorMessage);
                }
            });
        }
    }
}