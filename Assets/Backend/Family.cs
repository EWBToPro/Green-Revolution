using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Author: Hoa Nguyen
 * This class represents a family in the game.
 */

public class Family
{
    public string FamilyName;
    List<FamilyMember> FamilyMembers = new List<FamilyMember> ();
    int numFarmPlots;
    private int _numChildren;
    private int _numAdults;
    
    //Constructor of the class
    public Family(string FamilyName, int NumChildren, int numAdults, int numFarmPlots)
    {
        this.FamilyName = FamilyName;
        for(int i = 0; i < NumChildren; i++)
        {
            //Temporary name
            int Age = Random.Range(0, 12);
            Child child = new Child("A", FamilyName, Age);
            FamilyMembers.Add(child);
        }
        for (int i = 0; i < numAdults; i++)
        {
            //Temporary name
            int Age = Random.Range(18, 81);
            Adult adult = new Adult("B", FamilyName, Age);
            FamilyMembers.Add(adult);
        }
        this._numAdults = numAdults;
        this._numChildren = NumChildren;
        this.numFarmPlots = numFarmPlots;
    }

    //Add a new child to the family
    public void CreateChild()
    {
        //Temporary name
        Child child = new Child("A", FamilyName, 0);
        FamilyMembers.Add(child);
        this._numChildren++;
    }

    //Calculate family's total consumption after each year
    public int GetTotalConsumption()
    {
        return this._numChildren * 5 + this._numAdults * 10;
    }

    //Grow a child up 
    public void ChildGrowUp()
    {
        List<Child> Children = this.FamilyMembers.OfType<Child>().ToList();

        Child GrowingUpKid = Children[0];
        Adult NewAdult = GrowingUpKid.ToAdult();
        FamilyMembers.Remove(GrowingUpKid);
        FamilyMembers.Add(NewAdult);
        this._numAdults++;
        this._numChildren--;
    }

    public void AddAge()
    {
        for (int i = 0; i < this.FamilyMembers.Count; i++)
        {
            this.FamilyMembers[i].IncrementAge();
        };
    }

    // Count the amount of adults
    public int GetAdultAmount()
    {
        List<Adult> Adult = this.FamilyMembers.OfType<Adult>().ToList();
        return Adult.Count();
    }

    // Count the amount of children
    public int GetChildrenAmount()
    {
        List<Child> children = this.FamilyMembers.OfType<Child>().ToList();
        return children.Count();
    }

}
