using EF_EX_QLFOOD.Entities;
using EF_EX_QLFOOD.IServices;
using EF_EX_QLFOOD.Services;
using EF_EX_QLFOOD.Helper;

void Main()
{
    IMonAnServices monAnServices = new MonAnServices();
    Console.WriteLine("Nhap mon an can them cong thuc:");
    int monID = int .Parse(Console.ReadLine());
    monAnServices.ThemCongThuc(monID);
}
Main();