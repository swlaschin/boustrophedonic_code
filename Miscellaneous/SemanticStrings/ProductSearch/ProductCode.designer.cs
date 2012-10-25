// ============================================================================
// Auto-generated. Do not edit!
//
// To add functionality, create and edit the partial class in a separate file. 
// ============================================================================
using System;
namespace Miscellaneous.SemanticStrings.ProductSearch
{

    /// <summary>
    /// Struct to wrap strings for DDD, to avoid mixing up string types, and to avoid null strings.
    /// </summary>
    /// <remarks>
    /// structs cannot inherit, so the code is duplicated for each. 
    /// </remarks>
    [Serializable]
	[System.Diagnostics.DebuggerDisplay(@"ProductCode\{{Value}\}")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:StringWrapper.ttinclude","1.0.0")] 
    public partial struct ProductCode : IEquatable<ProductCode>, IComparable<ProductCode>
    {

        public string Value { get; private set; }

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
        /// <param name="str">The string to wrap. It must not be null.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
        static public ProductCode New(string str, Func<string, string> transform)
        {
		    if (transform != null) { str = transform(str); }
            if (str == null) { throw new ArgumentException("Input to ProductCode is not valid","str"); }
            
            return new ProductCode { Value = str };
        }

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
        /// <param name="str">The string to wrap. It must not be null.</param>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
        static public ProductCode New(string str)
        {
			Func<string, string> defaultTransform = s => ReferenceData.TransformProductCode(s);
			return New(str, defaultTransform);
        }

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null or invalid.
		/// </summary>
        /// <param name="str">The string to wrap. If is is null or invalid, null is returned.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
        static public ProductCode? NewOption(string str, Func<string,string> transform)
        {
		    if (transform != null) { str = transform(str); }
            if (str == null) { return null; }
            return new ProductCode { Value = str };
        }

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null.
		/// </summary>
        /// <param name="str">The string to wrap. If is is null, null is returned.</param>
        static public ProductCode? NewOption(string str)
        {
			Func<string, string> defaultTransform = s => ReferenceData.TransformProductCode(s);
            return NewOption(str, defaultTransform);
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object other)
        {
            return other is ProductCode && Equals((ProductCode)other);
        }

        public bool Equals(ProductCode other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(ProductCode lhs, ProductCode rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ProductCode lhs, ProductCode rhs)
        {
            return !lhs.Equals(rhs);
        }

        public int CompareTo(ProductCode other)
        {
            return String.CompareOrdinal(Value, other.Value);
        }
    }

    /// <summary>
    /// Extensions to convert strings into ProductCodes.
    /// </summary>
 	public static class ProductCodeStringExtensions
	{
		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
        /// <param name="str">The string to wrap. It must not be null.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
		public static ProductCode ToProductCode(this string str, Func<string, string> transform)
		{
			return ProductCode.New(str, transform);
		}

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
		public static ProductCode ToProductCode(this string str)
		{
			return ProductCode.New(str);
		}

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null or invalid.
		/// </summary>
        /// <param name="str">The string to wrap. If is is null or invalid, null is returned.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
		public static ProductCode? ToProductCodeOption(this string str, Func<string, string> transform)
		{
			return ProductCode.NewOption(str, transform);
		}

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null.
		/// </summary>
		public static ProductCode? ToProductCodeOption(this string str)
		{
			return ProductCode.NewOption(str);
		}

	}
}