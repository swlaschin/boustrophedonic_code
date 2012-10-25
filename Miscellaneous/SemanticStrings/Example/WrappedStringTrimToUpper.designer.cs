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
	[System.Diagnostics.DebuggerDisplay(@"WrappedStringTrimToUpper\{{Value}\}")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("T4Template:StringWrapper.ttinclude","1.0.0")] 
    public partial struct WrappedStringTrimToUpper : IEquatable<WrappedStringTrimToUpper>, IComparable<WrappedStringTrimToUpper>
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
        static public WrappedStringTrimToUpper New(string str, Func<string, string> transform)
        {
		    if (transform != null) { str = transform(str); }
            if (str == null) { throw new ArgumentException("Input to WrappedStringTrimToUpper is not valid","str"); }
            
            return new WrappedStringTrimToUpper { Value = str };
        }

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
        /// <param name="str">The string to wrap. It must not be null.</param>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
        static public WrappedStringTrimToUpper New(string str)
        {
			Func<string, string> defaultTransform = s => { var trimmed = (s ?? "").Trim(); return trimmed.Length == 0 ? null : trimmed.ToUpper(); };
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
        static public WrappedStringTrimToUpper? NewOption(string str, Func<string,string> transform)
        {
		    if (transform != null) { str = transform(str); }
            if (str == null) { return null; }
            return new WrappedStringTrimToUpper { Value = str };
        }

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null.
		/// </summary>
        /// <param name="str">The string to wrap. If is is null, null is returned.</param>
        static public WrappedStringTrimToUpper? NewOption(string str)
        {
			Func<string, string> defaultTransform = s => { var trimmed = (s ?? "").Trim(); return trimmed.Length == 0 ? null : trimmed.ToUpper(); };
            return NewOption(str, defaultTransform);
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object other)
        {
            return other is WrappedStringTrimToUpper && Equals((WrappedStringTrimToUpper)other);
        }

        public bool Equals(WrappedStringTrimToUpper other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(WrappedStringTrimToUpper lhs, WrappedStringTrimToUpper rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(WrappedStringTrimToUpper lhs, WrappedStringTrimToUpper rhs)
        {
            return !lhs.Equals(rhs);
        }

        public int CompareTo(WrappedStringTrimToUpper other)
        {
            return String.CompareOrdinal(Value, other.Value);
        }
    }

    /// <summary>
    /// Extensions to convert strings into WrappedStringTrimToUppers.
    /// </summary>
 	public static class WrappedStringTrimToUpperStringExtensions
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
		public static WrappedStringTrimToUpper ToWrappedStringTrimToUpper(this string str, Func<string, string> transform)
		{
			return WrappedStringTrimToUpper.New(str, transform);
		}

		/// <summary>
		/// Create a new struct wrapping a string.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown if the str is null.</exception>
		public static WrappedStringTrimToUpper ToWrappedStringTrimToUpper(this string str)
		{
			return WrappedStringTrimToUpper.New(str);
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
		public static WrappedStringTrimToUpper? ToWrappedStringTrimToUpperOption(this string str, Func<string, string> transform)
		{
			return WrappedStringTrimToUpper.NewOption(str, transform);
		}

		/// <summary>
		/// Create a new nullable struct wrapping a string, or null if the string is null.
		/// </summary>
		public static WrappedStringTrimToUpper? ToWrappedStringTrimToUpperOption(this string str)
		{
			return WrappedStringTrimToUpper.NewOption(str);
		}

	}
}