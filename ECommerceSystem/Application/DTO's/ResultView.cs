﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO_s
{
    public class ResultView<T>
    {
        public T Entity { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
