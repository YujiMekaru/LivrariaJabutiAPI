﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaJabutiAPI.Domain.Models.Exceptions
{
    public class ExceptionResponse 
    {
        public int ErrorCode { get; private set; }
        public string? Source { get; private set; } = String.Empty;
        public string? Message { get; private set; } = String.Empty;

        public ExceptionResponse(Exception exception)
        {
            Source = exception.Source;
            Message = exception.Message;
        }
    }
}