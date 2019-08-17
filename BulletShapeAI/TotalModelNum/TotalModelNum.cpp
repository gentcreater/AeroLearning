// TotalModelNum.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include <cmath>
#include <fstream>  
#include <stdlib.h> 
#include <ostream>
using namespace std;
int main()
{
	std::cout << "Hello World!\n";
	int fuzeflat, headflat, fuzelength, headlength, bodylength, r, rearlength, rearheigth;//r是弹径,当弹长为60时，5<r<15
	long sum = 0;
	int LIDU=1;
	//int fuzeLengthInit, headLengthInit;
	/*ifstream in("test.txt");*/
	ofstream outfile("out.txt", ios::trunc);

	//for (r = 15; r <= 15; r++)
	//{
	//	for (fuzeflat = 0; fuzeflat <= floor(0.5*r); fuzeflat+= 2*LIDU)
	//	{
	//		for (headflat = fuzeflat; headflat <= floor(0.7*r); headflat+= 2*LIDU)
	//		{
	//			for (fuzelength = 0; fuzelength < r; fuzelength+=2*LIDU)
	//			{ 					
	//				for (headlength = 0; headlength <= 30; headlength+= 3*LIDU)
	//				{						
	//					if (fuzelength + headlength > 30) continue;
	//					for (bodylength = 60; bodylength >= 12; bodylength-= 2*LIDU)
	//					{
	//						if (bodylength + fuzelength + headlength > 60) continue;
	//						for (rearlength = 0; rearlength < 10; rearlength+= 2*LIDU)
	//						{
	//							if (bodylength + fuzelength + headlength + rearlength > 60)continue;
	//							for (rearheigth = floor(0.5*r); rearheigth <= r; rearheigth+= LIDU)
	//							{
	//								if (rearlength == 0 && rearheigth < r || fuzelength + headlength + bodylength + rearlength!=60||fuzelength==0||headlength==0||(fuzeflat==0&&headflat==0)) continue;
	//								//std::cout << "bodyHeight（r）=" << r << ",fuzeflat=" << fuzeflat << ",headflat=" << headflat << ",fuzelength=" << fuzelength << ", headlength=" << headlength << ", bodylength=" << bodylength << ", rearlength=" << rearlength << ", rearheigth=" << rearheigth<<"\n";
	//								if (fuzelength + headlength >= 20)
	//								{
	//									//if(fuzelength + headlength+bodylength+rearlength>=60)
	//									outfile << sum << ":  " << "bodyHeight（r）=" << r << ",fuzeflat=" << fuzeflat << ",headflat=" << headflat << ",fuzelength=" << fuzelength << ", headlength=" << headlength << ", bodylength=" << bodylength << ", rearlength=" << rearlength << ", rearheigth=" << rearheigth << "----(计算Radius和line)\n";
	//								}
	//								else 
	//								{
	//									//if (fuzelength + headlength + bodylength + rearlength >= 60)
	//									outfile << sum << ":  " << "bodyHeight（r）=" << r << ",fuzeflat=" << fuzeflat << ",headflat=" << headflat << ",fuzelength=" << fuzelength << ", headlength=" << headlength << ", bodylength=" << bodylength << ", rearlength=" << rearlength << ", rearheigth=" << rearheigth << "----(计算line)\n";
	//								}
	//								sum++;
	//							}
	//						}
	//					}
	//				}
	//			}
	//		}
	//	}
	//}
	//std::cout << "sum=" << sum;

	//算圆头弹外形组合
	for (r = 5; r <= 5; r++)
	{
		for (fuzelength = 1; fuzelength <= floor(1*r); fuzelength +=2* LIDU)
		{

			for (headlength = 1; headlength <= 60; headlength += 4 * LIDU)
			{
				//if (fuzelength + headlength > 60) continue;
				for (bodylength = 60; bodylength >= 1; bodylength -= 5 * LIDU)
				{
					//if (bodylength + fuzelength + headlength > 60) continue;
					for (rearlength = 1; rearlength < 10; rearlength +=  3*LIDU)
					{
						//if (bodylength + fuzelength + headlength + rearlength > 60)continue;
						for (rearheigth = floor(0.4*r); rearheigth <= r; rearheigth += 2*LIDU)
						{
							if (rearlength == 0 || rearheigth > r || fuzelength + headlength + bodylength + rearlength != 60 || fuzelength == 0 || headlength == 0) continue;

							sum++;
							outfile << sum << ":  " << "bodyHeight（r）=" << r << ",fuzelength=" << fuzelength << ", headlength=" << headlength << ", bodylength=" << bodylength << ", rearlength=" << rearlength << ", rearheigth=" << rearheigth << "\n";

							
						}
					}
				}
			}
		}
	}
	std::cout << "sum=" << sum;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
