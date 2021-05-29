using System;
using System.Runtime.InteropServices;


namespace PointerPlus
{
    /// <summary>
    /// A <see cref="Ptr"/> but allows you to go <seealso cref="Back"/> without having to remember the Type the Ptr was converted to
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct ExactPtr<T> : IDisposable
    {
        /// <summary>
        /// Create a pointer with a GcHandle
        /// </summary>
        /// <param name="handle">The Handle to convert to a <see cref="IntPtr"/></param>
        public ExactPtr(GCHandle handle)
        {
            Handle = handle;
            mem = -1;
        }

        /// <summary>
        /// A direct ref to the Handle converted to a <see cref="IntPtr"/>
        /// </summary>
        public IntPtr Pointer => (IntPtr)Handle;

        /// <summary>
        /// The handle used
        /// </summary>
        public GCHandle Handle { get; }

        private int mem;
        /// <summary>
        /// A direct reference to the memory to make an IntPtr
        /// <para>Will return -1 if <see cref="Handle"/> or <seealso cref="Pointer"/> is default</para>
        /// </summary>
        public int Memory
        {
            get
            {
                if (Pointer == default || Handle == default)
                    return -1;

                if (Handle.Target == null)
                    return -1;

                if (mem <= -1)
                    mem = Pointer.ToInt32();

                return mem;
            }
        }

        /// <summary>
        /// <see cref="GCHandle.Free"/>
        /// </summary>
        public void Free() => Handle.Free();

        /// <summary>
        /// <see cref="Free"/>
        /// </summary>
        public void Dispose()
        {
            Free();
        }

        /// <summary>
        /// Convert back to <typeparamref name="T"/>
        /// <para>Will throw if <see cref="Free"/></para>
        /// </summary>
        /// <returns></returns>
        public T Back() => Pointer.To<T>();

        /// <summary>
        /// Frees and then sets the value.
        /// </summary>
        /// <param name="val"></param>
        public void Set(T val)
        {
            this.Free();
            this = val;
        }

        /// <summary>
        /// Implicit, used for methods with T args.
        /// </summary>
        /// <param name="o"></param>
        public static implicit operator ExactPtr<T>(T o)
        {
            return new ExactPtr<T>(GCHandle.Alloc(o));
        }
    }

}
