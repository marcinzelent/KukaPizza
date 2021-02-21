using System;
using KukaPizza.Controllers;

namespace KukaPizza.Views
{
    public abstract class View
    {
        private Controller _controller;
        public void Init(Controller controller)
        {
            _controller = controller;
            Draw();
            Interact();
        }

        protected abstract void Draw();
        protected abstract void Interact();

        public void NavigateTo(Type view)
        {
            Activator.CreateInstance(view, _controller);
        }
    }
}