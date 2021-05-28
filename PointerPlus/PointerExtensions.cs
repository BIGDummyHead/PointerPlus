using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace PointerPlus
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class PointerExtensions
    {
        /// <summary>
        /// Converts the object directly to an <see cref="Ptr"/>
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static unsafe Ptr ToPointer(this object target)
        {
            if (target is null)
                throw new Exception("Target may not be null");

            GCHandle handle = GCHandle.Alloc(target);

            return new Ptr(handle);
        }

        /// <summary>
        /// Parse a Hexadecimal string and convert to a Int
        /// </summary>
        /// <param name="toParse"></param>
        /// <returns></returns>
        public static int ParseHex(this string toParse)
        {
            if (string.IsNullOrEmpty(toParse))
                throw new Exception("String cannot be null or empty");

            return int.Parse(toParse, NumberStyles.HexNumber);
        }

        /// <summary>
        /// Try to parse a Hexadecimal string and convert to a Int
        /// </summary>
        /// <param name="toParse"></param>
        /// <param name="parse"></param>
        /// <returns></returns>
        public static bool TryParseHex(this string toParse, out int parse)
        {
            if (string.IsNullOrEmpty(toParse))
                throw new Exception("String cannot be null or empty");

            return int.TryParse(toParse, NumberStyles.HexNumber, null, out parse);
        }

        /// <summary>
        /// Convert and int to a readable Memory address (Hexadecimal)
        /// </summary>
        /// <param name="o"></param>
        /// <param name="add0x">Add the 0x to the first portion of the hexadecimal</param>
        /// <returns></returns>
        public static string ToMemAddr(this int o, bool add0x = false)
        {
            string ret = o.ToString("X");

            if (add0x)
                ret = "0x" + ret;

            return ret;
        }

        /// <summary>
        /// Convert any object to an 'unsafe' <see cref="Ptr"/>
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static unsafe Ptr* ToUnsafePointer(this object target)
        {
            if (target is null)
                throw new Exception("Target is null");

            Ptr handle = new Ptr(GCHandle.Alloc(target));

            return &handle;
        }

        /// <summary>
        /// Direct to a Handle can be converted to an <see cref="IntPtr"/>
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static GCHandle ToHandle(this object target)
        {
            if (target is null)
                throw new Exception("Target is null");

            return GCHandle.Alloc(target);
        }

        /// <summary>
        /// Convert the Ptr to an <see cref="object"/>
        /// </summary>
        /// <param name="ptr">The pointer</param>
        /// <returns></returns>
        public static object ToObject(this IntPtr ptr)
        {
            return To<object>(ptr);
        }

        /// <summary>
        /// Convert any <see cref="IntPtr"/> to <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static T To<T>(this IntPtr ptr)
        {
            GCHandle handle = (GCHandle)ptr;

            if (handle.Target is null)
                throw new Exception("Pointer cannot be switched back to object");

            return (T)handle.Target;
        }

        /// <summary>
        /// Take the pointer from a <see cref="Ptr"/> and make it into a <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static T To<T>(this Ptr ptr)
        {
            return ptr.Pointer.To<T>();
        }

        /// <summary>
        /// Take the pointer from a <see cref="Ptr"/> and make it into an object
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static object ToObject(this Ptr ptr)
        {
            return ptr.To<object>();
        }


    }

}
