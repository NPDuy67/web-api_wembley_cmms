﻿using System.Runtime.Serialization;

namespace WembleyCMMS.Api.Application.Commands.UpdateInputs
{
    [DataContract]
    public class AddUpdateInputCommand : IRequest<string>
    {
        public bool? Confirm { get; set; }

        public AddUpdateInputCommand(bool? confirm)
        {
            Confirm = confirm;
        }
    }
}
