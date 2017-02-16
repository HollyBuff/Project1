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

	int cost;
	file >> cost;

	cout << cost;
	int a[]
	string number;
	while(getline(file, number, ','))
	{
		cout << number << endl;
	}
}