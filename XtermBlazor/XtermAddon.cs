using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace XtermBlazor
{
    /// <summary>
    /// The XtermAddon class represents an addon for the Xterm terminal.
    /// An addon is a module that extends the functionality of the Xterm terminal.
    /// Each addon is associated with an Xterm instance and has a unique identifier.
    /// </summary>
    ///
    /// <remarks>
    /// Constructs a new instance of the XtermAddon class, associating it with a specific Xterm instance and assigning it a unique addon ID.
    /// </remarks>
    /// <param name="xterm">The Xterm instance that this addon will be associated with.</param>
    /// <param name="addonId">The unique identifier to be assigned to this addon.</param>
    public class XtermAddon(Xterm xterm, string addonId)
    {
        private const string NAMESPACE_PREFIX = nameof(XtermBlazor);

        /// <summary>
        /// Gets the Xterm instance that this addon is associated with. This property is null if the addon is not yet activated on an Xterm instance.
        /// </summary>
        public Xterm Xterm { get; private set; } = xterm;

        /// <summary>
        /// Gets the unique identifier of this addon. This ID is set when the addon is created and cannot be changed afterwards.
        /// </summary>
        public string AddonId { get; private set; } = addonId;

        /// <summary>
        /// Invokes the specified addon function asynchronously.
        /// </summary>
        /// <param name="functionName">The name of the function to invoke.</param>
        /// <param name="args">The arguments to pass to the function.</param>
        /// <returns>A ValueTask representing the asynchronous operation.</returns>
        public ValueTask<T> InvokeAsync<T>(string functionName, params object[] args)
        {
            return Xterm.JSRuntime.InvokeAsync<T>($"{NAMESPACE_PREFIX}.invokeAddonFunction", Xterm.Id, AddonId, functionName, args);
        }

        /// <summary>
        /// Invokes the specified addon function asynchronously.
        /// </summary>
        /// <param name="functionName">The name of the function to invoke.</param>
        /// <param name="args">The arguments to pass to the function.</param>
        /// <returns>A ValueTask representing the asynchronous operation.</returns>
        public ValueTask InvokeVoidAsync(string functionName, params object[] args)
        {
            return Xterm.JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.invokeAddonFunction", Xterm.Id, AddonId, functionName, args);
        }
    }
}