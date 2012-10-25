// ======================================
// Auto-generated. Do not edit -- to add functionality, create a corresponding partial class. 
// ======================================
using System;
namespace Miscellaneous.SemanticStrings.Example
{

    /// <summary>
    /// Struct to wrap strings for DDD, to avoid mixing up string types, and to avoid null strings.
    /// </summary>
    /// <remarks>
    /// structs cannot inherit, so the code is duplicated for each. 
    /// </remarks>
    [Serializable]
	[System.Diagnostics.DebuggerDisplay(@"WrappedStringTrim\{{Value}\}")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:StringWrapper.ttinclude","1.0.0")] 
    public partial struct WrappedStringTrim : IEquatable<WrappedStringTrim>, IComparable<WrappedStringTrim>
    {

        public string Value { get; private set; }

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
        /// <param name="str">The string to wrap. It must not be null.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should throw an exception or return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
        static public WrappedStringTrim New(string str, Func<string, string> transform)
        {
		    if (transform != null) { str = transform(str); }
            if (str == null) { throw new ArgumentException("Input to WrappedStringTrim is not valid","str"); }
            
            return new WrappedStringTrim { Value = str };
        }

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
        /// <param name="str">The string to wrap. It must not be null.</param>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
        static public WrappedStringTrim New(string str)
        {
			Func<string, string> defaultTransform = s => { var trimmed = (s ?? "").Trim(); return trimmed.Length == 0 ? null : trimmed; };
			return New(str, defaultTransform);
        }

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null or invalid.
		/// </summary>
        /// <param name="str">The string to wrap. If is is null or invalid, null is returned.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should throw an exception or return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
        static public WrappedStringTrim? NewOption(string str, Func<string,string> transform)
        {
		    if (transform != null) { str = transform(str); }
            if (str == null) { return null; }
            return new WrappedStringTrim { Value = str };
        }

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null.
		/// </summary>
        /// <param name="str">The string to wrap. If is is null, null is returned.</param>
        static public WrappedStringTrim? NewOption(string str)
        {
			Func<string, string> defaultTransform = s => { var trimmed = (s ?? "").Trim(); return trimmed.Length == 0 ? null : trimmed; };
            return NewOption(str, defaultTransform);
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object other)
        {
            return other is WrappedStringTrim && Equals((WrappedStringTrim)other);
        }

        public bool Equals(WrappedStringTrim other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(WrappedStringTrim lhs, WrappedStringTrim rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(WrappedStringTrim lhs, WrappedStringTrim rhs)
        {
            return !lhs.Equals(rhs);
        }

        public int CompareTo(WrappedStringTrim other)
        {
            return String.CompareOrdinal(Value, other.Value);
        }
    }

    /// <summary>
    /// Extensions to convert strings into WrappedStringTrims.
    /// </summary>
 	public static class WrappedStringTrimStringExtensions
	{
		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
        /// <param name="str">The string to wrap. It must not be null.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should throw an exception or return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
		public static WrappedStringTrim ToWrappedStringTrim(this string str, Func<string, string> transform)
		{
			return WrappedStringTrim.New(str, transform);
		}

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
		public static WrappedStringTrim ToWrappedStringTrim(this string str)
		{
			return WrappedStringTrim.New(str);
		}

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null or invalid.
		/// </summary>
        /// <param name="str">The string to wrap. If is is null or invalid, null is returned.</param>
        /// <param name="transform">A function to transform and/or validate the string. 
		/// The unwrapped string is passed into the transform function,  
		/// and the transform should throw an exception or return null if the string is not valid, 
		//  otherwise the transform should convert the string as needed (eg remove spaces, convert to uppercase, etc).
		/// A null transform is ignored.
		/// </param>
		public static WrappedStringTrim? ToWrappedStringTrimOption(this string str, Func<string, string> transform)
		{
			return WrappedStringTrim.NewOption(str, transform);
		}

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null.
		/// </summary>
		public static WrappedStringTrim? ToWrappedStringTrimOption(this string str)
		{
			return WrappedStringTrim.NewOption(str);
		}

	}
}