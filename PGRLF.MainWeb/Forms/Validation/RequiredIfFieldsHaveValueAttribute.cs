using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime;


namespace PGRLF.MainWeb.Forms.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredIfFieldsHaveValueAttribute : ValidationAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:PGRLF.MainWeb.Forms.Validation.RequiredIfFieldHasValueAttribute" />
        ///     class.
        /// </summary>
        /// <param name="otherProperty">The property to compare with the current property.</param>
        public RequiredIfFieldsHaveValueAttribute(
            string[] otherProperty,
            object[] otherPropertyValue)
            : base()
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException("otherProperty");
            }
            this.OtherProperty = otherProperty;
            this.OtherPropertyValue = otherPropertyValue;
        }

        /// <summary>
        ///     Gets the property to compare with the current property.
        /// </summary>
        /// <returns>
        ///     The other property.
        /// </returns>
        public string[] OtherProperty { get; private set; }

        /// <summary>
        ///     Gets the value of the other property.
        /// </summary>
        /// <returns>
        ///     The value of the other property.
        /// </returns>
        public object[] OtherPropertyValue
        {
            get;
            internal set;
        }

        /// <summary>
        ///     Gets a value that indicates whether the attribute requires validation context.
        /// </summary>
        /// <returns>
        ///     true if the attribute requires validation context; otherwise, false.
        /// </returns>
        public override bool RequiresValidationContext
        {
            get { return true; }
        }

        /// <summary>
        ///     Gets or sets a value that indicates whether an empty string is allowed.
        /// </summary>
        /// <returns>
        ///     true if an empty string is allowed; otherwise, false. The default value is false.
        /// </returns>
        public bool AllowEmptyStrings
        {
            get;
            set;
        }


        /// <summary>
        ///     Determines whether a specified object is valid.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> is valid; otherwise, false.
        /// </returns>
        /// <param name="value">The object to validate.</param>
        /// <param name="validationContext">An object that contains information about the validation request.</param>
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            //ValidationResult finalResult = null;
            bool[] isValid = new[] { false, false };
            for (int i = 0; i < OtherProperty.Length; i++)
            {
                var otherPropertyName = OtherProperty[i];
                var otherPropertyValue = OtherPropertyValue[i];
                PropertyInfo property = validationContext.ObjectType.GetProperty(otherPropertyName);

                if (property == (PropertyInfo)null)
                {
                    return new ValidationResult(this.ErrorMessage);
                }
                else
                {
                    object objB = property.GetValue(validationContext.ObjectInstance, (object[])null);
                    if (Equals(otherPropertyValue, objB))
                    {
                        string str = value as string;
                        if (str != null && !this.AllowEmptyStrings)
                        {
                            if (str.Trim().Length != 0)
                            {
                                isValid[i] = true;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            ValidationResult finalResult = null;
            if (isValid[0] && isValid[1])
            {
                finalResult = null;
            }
            else
            {
                finalResult = new ValidationResult("");
            }
            return finalResult;
        }

        private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return
                ((TypeDescriptionProvider)new AssociatedMetadataTypeTypeDescriptionProvider(type)).GetTypeDescriptor(
                    type);
        }
    }
}