#include <iostream>
#include <fstream>
using namespace std;


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
	string number;
	while(getline(file, number, ','))
	{
		cout << number << endl;
	}
}