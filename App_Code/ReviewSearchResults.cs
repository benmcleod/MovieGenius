using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ReviewSearchResults : ICollection<Review>
{
    public event SelectedIndexChangedEventHandler SelectedIndexChanged;
    public virtual void OnSelectedIndexChanged(EventArgs e)
    {
        if (SelectedIndexChanged != null)
            SelectedIndexChanged(this, e);
    }

    public int TotalCount { get; set; }

    private List<Review> Reviews { get; set; }

    public ReviewSearchResults()
    {
        TotalCount = 0;
        Reviews = new List<Review>();
        selectedIndex = 0;
    }

    private int selectedIndex;
    public int SelectedIndex
    {
        get { return selectedIndex; }
        set
        {
            selectedIndex = value;
            OnSelectedIndexChanged(EventArgs.Empty);
        }
    }

    public Review SelectedValue
    {
        get { return Reviews.ElementAt(SelectedIndex); }
    }

    public Review this[int index]
    {
        get { return Reviews[index]; }
        set { Reviews[index] = value; }
    }

    public void Sort()
    {
        Reviews.Sort();
    }

    public void Sort(IComparer<Review> comparer)
    {
        Reviews.Sort(comparer);
    }

    public void Add(Review item)
    {
        Reviews.Add(item);
    }

    public void Clear()
    {
        Reviews.Clear();
    }

    public bool Contains(Review item)
    {
        return Reviews.Contains(item);
    }

    public void CopyTo(Review[] array, int arrayIndex)
    {
        Reviews.CopyTo(array, arrayIndex);
    }

    public int Count
    {
        get { return Reviews.Count; }
    }

    public bool IsReadOnly
    {
        get { return false; }
    }

    public bool Remove(Review item)
    {
        return Reviews.Remove(item);
    }


    public IEnumerator<Review> GetEnumerator()
    {
        return Reviews.GetEnumerator();
    }


    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}
