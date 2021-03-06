// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDocumentationProvider.cs" company="">
//   
// </copyright>
// <summary>
//   A custom <see cref="IDocumentationProvider" /> that reads the API documentation from an XML documentation file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MeetingRoomReservation.Web.Areas.HelpPage
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Http.Description;
    using System.Xml.XPath;

    using MeetingRoomReservation.Web.Areas.HelpPage.ModelDescriptions;

    /// <summary>
    ///     A custom <see cref="IDocumentationProvider" /> that reads the API documentation from an XML documentation file.
    /// </summary>
    public class XmlDocumentationProvider : IDocumentationProvider, IModelDocumentationProvider
    {
        /// <summary>
        /// The type expression.
        /// </summary>
        private const string TypeExpression = "/doc/members/member[@name='T:{0}']";

        /// <summary>
        /// The method expression.
        /// </summary>
        private const string MethodExpression = "/doc/members/member[@name='M:{0}']";

        /// <summary>
        /// The property expression.
        /// </summary>
        private const string PropertyExpression = "/doc/members/member[@name='P:{0}']";

        /// <summary>
        /// The field expression.
        /// </summary>
        private const string FieldExpression = "/doc/members/member[@name='F:{0}']";

        /// <summary>
        /// The parameter expression.
        /// </summary>
        private const string ParameterExpression = "param[@name='{0}']";

        /// <summary>
        /// The _document navigator.
        /// </summary>
        private readonly XPathNavigator _documentNavigator;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDocumentationProvider"/> class.
        /// </summary>
        /// <param name="documentPath">
        /// The physical path to XML document.
        /// </param>
        public XmlDocumentationProvider(string documentPath)
        {
            if (documentPath == null)
            {
                throw new ArgumentNullException("documentPath");
            }

            var xpath = new XPathDocument(documentPath);
            this._documentNavigator = xpath.CreateNavigator();
        }

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="controllerDescriptor">
        /// The controller descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDocumentation(HttpControllerDescriptor controllerDescriptor)
        {
            var typeNode = this.GetTypeNode(controllerDescriptor.ControllerType);
            return GetTagValue(typeNode, "summary");
        }

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="actionDescriptor">
        /// The action descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public virtual string GetDocumentation(HttpActionDescriptor actionDescriptor)
        {
            var methodNode = this.GetMethodNode(actionDescriptor);
            return GetTagValue(methodNode, "summary");
        }

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="parameterDescriptor">
        /// The parameter descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public virtual string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
        {
            var reflectedParameterDescriptor = parameterDescriptor as ReflectedHttpParameterDescriptor;
            if (reflectedParameterDescriptor != null)
            {
                var methodNode = this.GetMethodNode(reflectedParameterDescriptor.ActionDescriptor);
                if (methodNode != null)
                {
                    var parameterName = reflectedParameterDescriptor.ParameterInfo.Name;
                    var parameterNode =
                        methodNode.SelectSingleNode(
                            string.Format(CultureInfo.InvariantCulture, ParameterExpression, parameterName));
                    if (parameterNode != null)
                    {
                        return parameterNode.Value.Trim();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The get response documentation.
        /// </summary>
        /// <param name="actionDescriptor">
        /// The action descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
        {
            var methodNode = this.GetMethodNode(actionDescriptor);
            return GetTagValue(methodNode, "returns");
        }

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDocumentation(MemberInfo member)
        {
            var memberName = string.Format(
                CultureInfo.InvariantCulture, 
                "{0}.{1}", 
                GetTypeName(member.DeclaringType), 
                member.Name);
            var expression = member.MemberType == MemberTypes.Field ? FieldExpression : PropertyExpression;
            var selectExpression = string.Format(CultureInfo.InvariantCulture, expression, memberName);
            var propertyNode = this._documentNavigator.SelectSingleNode(selectExpression);
            return GetTagValue(propertyNode, "summary");
        }

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDocumentation(Type type)
        {
            var typeNode = this.GetTypeNode(type);
            return GetTagValue(typeNode, "summary");
        }

        /// <summary>
        /// The get method node.
        /// </summary>
        /// <param name="actionDescriptor">
        /// The action descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="XPathNavigator"/>.
        /// </returns>
        private XPathNavigator GetMethodNode(HttpActionDescriptor actionDescriptor)
        {
            var reflectedActionDescriptor = actionDescriptor as ReflectedHttpActionDescriptor;
            if (reflectedActionDescriptor != null)
            {
                var selectExpression = string.Format(
                    CultureInfo.InvariantCulture, 
                    MethodExpression, 
                    GetMemberName(reflectedActionDescriptor.MethodInfo));
                return this._documentNavigator.SelectSingleNode(selectExpression);
            }

            return null;
        }

        /// <summary>
        /// The get member name.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetMemberName(MethodInfo method)
        {
            var name = string.Format(
                CultureInfo.InvariantCulture, 
                "{0}.{1}", 
                GetTypeName(method.DeclaringType), 
                method.Name);
            var parameters = method.GetParameters();
            if (parameters.Length != 0)
            {
                var parameterTypeNames = parameters.Select(param => GetTypeName(param.ParameterType)).ToArray();
                name += string.Format(CultureInfo.InvariantCulture, "({0})", string.Join(",", parameterTypeNames));
            }

            return name;
        }

        /// <summary>
        /// The get tag value.
        /// </summary>
        /// <param name="parentNode">
        /// The parent node.
        /// </param>
        /// <param name="tagName">
        /// The tag name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetTagValue(XPathNavigator parentNode, string tagName)
        {
            if (parentNode != null)
            {
                var node = parentNode.SelectSingleNode(tagName);
                if (node != null)
                {
                    return node.Value.Trim();
                }
            }

            return null;
        }

        /// <summary>
        /// The get type node.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="XPathNavigator"/>.
        /// </returns>
        private XPathNavigator GetTypeNode(Type type)
        {
            var controllerTypeName = GetTypeName(type);
            var selectExpression = string.Format(CultureInfo.InvariantCulture, TypeExpression, controllerTypeName);
            return this._documentNavigator.SelectSingleNode(selectExpression);
        }

        /// <summary>
        /// The get type name.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetTypeName(Type type)
        {
            var name = type.FullName;
            if (type.IsGenericType)
            {
                // Format the generic type name to something like: Generic{System.Int32,System.String}
                var genericType = type.GetGenericTypeDefinition();
                var genericArguments = type.GetGenericArguments();
                var genericTypeName = genericType.FullName;

                // Trim the generic parameter counts from the name
                genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
                var argumentTypeNames = genericArguments.Select(t => GetTypeName(t)).ToArray();
                name = string.Format(
                    CultureInfo.InvariantCulture, 
                    "{0}{{{1}}}", 
                    genericTypeName, 
                    string.Join(",", argumentTypeNames));
            }

            if (type.IsNested)
            {
                // Changing the nested type name from OuterType+InnerType to OuterType.InnerType to match the XML documentation syntax.
                name = name.Replace("+", ".");
            }

            return name;
        }
    }
}