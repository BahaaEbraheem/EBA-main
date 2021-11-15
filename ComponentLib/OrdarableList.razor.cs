using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    public partial class OrdarableList<T> : ComponentBase
    {

        [Parameter]
        public List<T> Items { get; set; }

        [Parameter]
        public RenderFragment<T> ItemTemplate { get; set; }

        [Parameter]
        public string KeyName { get; set; }

        public void StartDrag(T item)
        {
            currentIndex = GetIndex(item);
        }

        public void Drop(T item)
        {
            var index = GetIndex(item);
            var current = Items[currentIndex];

            Items.RemoveAt(currentIndex);
            Items.Insert(index, current);

            // update current selection
            currentIndex = index;

            StateHasChanged();
        }

        int currentIndex;
        int GetIndex(T item)
        {
            return Items.FindIndex(i => i.GetType().GetProperty(KeyName).GetValue(i) == item.GetType().GetProperty(KeyName).GetValue(item));
        }

    }
}
