using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using ShadyNagy.Swagger.SharedKernel;

namespace ShadyNagy.Swagger.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;

        private string _userName = string.Empty;
        public string Username
        {
            get => _userName;
            set => _userName = value.Replace("@", "");
        }

        public string UserId { get; set; } = string.Empty;


        public Employee()
        {
        }

        public override string ToString() => FullName;
    }
}
