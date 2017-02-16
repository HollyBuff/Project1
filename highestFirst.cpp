//
//  highestFirst.cpp
//  
//
//  Created by Collin Blanchard on 2/14/17.
//
//

#include <iostream>
#include <string>
#include <fstream>

using namespace std;

void sort(string name[], int cost[], int value[], int count)
{
    for(int i = 0; i < count; i++)
    {
        int j = i;
        if(cost[i] < cost[j])
            j = k;
        string n = name[j];
        int c = cost[j];
        int v = value[j];
        
    }
}


int main()
{
    ifstream file("file.csv");
    string filename;
    string name, v, c, blank;
    int value, cost, totalcost, i=0;
    string names[100];
    int costs[100];
    int values[100];
    
    cout << "Enter filename: ";
    cin >> filename;
    
    file.open(filename.c_str());
    
    file >> totalcost;
    
    while(file.good())
    {
        getline(file, name, ',');
        names[i] = name;
        getline(file, c, ',');
        cost = stoi(c);
        costs[i] = cost;
        getline(file, v, '\n');
        value = stoi(v);
        values[i] = value;
        
        //sort(names,costs,values, i);
        i++;
    }
    
    
    cout << totalcost << endl;
    for(int j = 0; j < i-1; j++)
    {
        cout << names[j] << "," << costs[j] << "," << values[j] << endl;
    }
}
