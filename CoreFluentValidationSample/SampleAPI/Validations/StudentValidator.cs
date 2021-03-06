﻿using Data.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public string NotEmptyMessage { get; set; } = "bu alan boş gecilemez.";
        public StudentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).EmailAddress().WithMessage("NotEmptyMessage");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı 1 ya da 2 olabilir");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(control).WithMessage("Okulumuz 18 yaşından büyükler için uygun değildir.");
            RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }

        private bool control(DateTime? arg)
        {
            var control = DateTime.Now.Year - Convert.ToDateTime(arg).Year;
            if(control >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
