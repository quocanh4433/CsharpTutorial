
// VuKhi sungLuc;
// sungLuc = new VuKhi();

VuKhi sungLuc = new VuKhi("M11", 2);
VuKhi sungMay = new VuKhi("B51", 5);

sungLuc.SatThuong = 40;

sungLuc.TanCong();
sungMay.TanCong();

Console.WriteLine(sungLuc.SatThuong);

for (int i = 0; i < 1000; i++)
{
  VuKhi a;
  a = new VuKhi("VU KHI" + i, i + 12);
  a = null;
}

using (VuKhi s = new VuKhi("Ak41", 12))
{

}