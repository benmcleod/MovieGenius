using System;
using System.Collections.Generic;
using System.Linq;

public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);

public class MovieSearchResults : ICollection<Movie>
{
    public event SelectedIndexChangedEventHandler SelectedIndexChanged;
    public virtual void OnSelectedIndexChanged(EventArgs e)
    {
        if (SelectedIndexChanged != null)
            SelectedIndexChanged(this, e);
    }

    public int ResultCount { get; set; }

    private List<Movie> Movies { get; set; }

    public MovieSearchResults()
    {
        ResultCount = 0;
        Movies = new List<Movie>();
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

    public Movie SelectedValue 
    {
        get { return Movies.ElementAt(SelectedIndex); } 
    }

    public Movie this[int index]
    {
        get { return Movies[index]; }
        set { Movies[index] = value; }
    }

    public void Sort()
    {
        Movies.Sort();
    }

    public void Sort(IComparer<Movie> comparer)
    {
        Movies.Sort(comparer);
    }

    public void Add(Movie item)
    {
        Movies.Add(item);
    }

    public void Clear()
    {
        Movies.Clear();
    }

    public bool Contains(Movie item)
    {
        return Movies.Contains(item);
    }

    public void CopyTo(Movie[] array, int arrayIndex)
    {
        Movies.CopyTo(array, arrayIndex);
    }

    public int Count
    {
        get { return Movies.Count; }
    }

    public bool IsReadOnly
    {
        get { return false; }
    }

    public bool Remove(Movie item)
    {
        return Movies.Remove(item);
    }

    public IEnumerator<Movie> GetEnumerator()
    {
        return Movies.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}
