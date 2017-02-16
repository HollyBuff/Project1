#include <iostream>
#include <fstream>
using namespace std;


int bruteForce(int Cost[], int Value[], int Name[], int n)
{

}

int main()
{
	ifstream file("file.csv");
	string filename;

	cout << "Enter filename: ";
	cin >> filename;

	file.open(filename.c_str());

	int totalcost;
	file >> totalcost;
	cout << totalcost << endl;

	string name, c, v;
	string names[100];
	int costs[100], values[100], cost, value, i = 0;
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
		i++;
	}

	bruteForce(costs, values, names, i);

	for(int j = 0; j < i-1; j++)
	{
		cout << names[j] << " " << costs[j] << " " << values[j] << endl;
	} 
}