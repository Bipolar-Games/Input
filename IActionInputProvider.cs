using System;

namespace Bipolar.Input
{
    public interface IActionInputProvider
    {
        event Action OnPerformed;
    }

	[Serializable]
	public class ActionInputProvider : Serialized<IActionInputProvider>, IActionInputProvider
	{
        protected Action onPerformed;
        protected bool isInitialized;

        public event Action OnPerformed
        {
            add
            {
                if (isInitialized == false && base.Value != null)
                {
                    isInitialized = true;
                    base.Value.OnPerformed -= InvokeAction;
                    base.Value.OnPerformed += InvokeAction;
                }
                onPerformed += value;
            }

            remove
            {
                onPerformed -= value;
            }
        }

        public override IActionInputProvider Value
        {
            get => base.Value;
            set
            {
                if (base.Value != null)
                    base.Value.OnPerformed -= InvokeAction;

                base.Value = value;
                if (base.Value != null)
                    base.Value.OnPerformed += InvokeAction;
            }
        }

        protected void InvokeAction() => onPerformed?.Invoke();
    }
}
