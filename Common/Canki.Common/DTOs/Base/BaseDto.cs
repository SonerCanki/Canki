using Canki.Common.Enums;
using System;

namespace Canki.Common.DTOs.Base
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
