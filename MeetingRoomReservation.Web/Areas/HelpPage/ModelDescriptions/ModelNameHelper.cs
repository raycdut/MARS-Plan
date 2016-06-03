// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelNameHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The model name helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web.Areas.HelpPage.ModelDescriptions
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The model name helper.
    /// </summary>
    internal static class ModelNameHelper
    {
        // Modify this to provide custom model name mapping.
        /// <summary>
        /// The get model name.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetModelName(Type type)
        {
            var modelNameAttribute = type.GetCustomAttribute<ModelNameAttribute>();
            if (modelNameAttribute != null && !string.IsNullOrEmpty(modelNameAttribute.Name))
            {
                return modelNameAttribute.Name;
            }

            var modelName = type.Name;
            if (type.IsGenericType)
            {
                // Format the generic type name to something like: GenericOfAgurment1AndArgument2
                var genericType = type.GetGenericTypeDefinition();
                var genericArguments = type.GetGenericArguments();
                var genericTypeName = genericType.Name;

                // Trim the generic parameter counts from the name
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                var argumentTypeNames = genericArguments.Select(t => GetModelName(t)).ToArray();
                modelName = string.Format(
                    CultureInfo.InvariantCulture, 
                    "{0}Of{1}", 
                    genericTypeName, 
                    string.Join("And", argumentTypeNames));
            }

            return modelName;
        }
    }
}