using OrderProcessing.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessing.Core
{
    /// <summary>
    /// Common class for command result
    /// </summary>
    public class CommandResult
    {
        private readonly List<Error> _errors = new List<Error>();

        /// <summary>
        /// Shows command success status
        /// </summary>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// Error list
        /// </summary>
        public IEnumerable<Error> Errors => _errors;

        /// <summary>
        /// Creates a command result indicating success status
        /// </summary>
        public static CommandResult Success { get; } = new CommandResult { Succeeded = true };

        /// <summary>
        /// Creates failed command result
        /// </summary>
        public static T Failed<T>(List<Error> errors) where T : CommandResult, new()
        {
            T result = (T)Activator.CreateInstance(typeof(T));

            if (result == null)
            {
                return new T();
            }

            result.Succeeded = false;
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }

            return result;
        }
    }
}
