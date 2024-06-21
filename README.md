# Parking System

Program ini mensimulasikan sistem manajemen parkir menggunakan .NET 5. Program memungkinkan pengguna untuk mengelola slot parkir untuk mobil dan motor, mencatat masuk dan keluar kendaraan, serta menghasilkan berbagai laporan berdasarkan kendaraan yang terparkir.

## Fitur
- Buat Parking Lot
```bash
Commands : create_parking_lot 6
Created a parking lot with 6 slots

```
- Parkir kendaraan
```bash
Commands : park B-1234-XYZ Putih Mobil
Allocated slot number: 1

```
- Kendaraan keluar
```bash
Commands : leave 4
Slot number 4 is free
```
- Lihat status parkir
```bash
Commands : status
Slot No.    Registration No    Type  Color
1           B-1234-XYZ      Mobil Putih
```

- Lihat laporan berdasarkan warna kendaraan
```bash
Commands : registration_numbers_for_cars_with_colour Putih
B-1234-XYZ 
```

- Lihat laporan berdasarkan jenis kendaraan
```bash
Commands : slot_numbers_for_cars_with_colour Putih
1
```

- Lihat laporan berdasarkan nomor registrasi kendaraan
```bash
Commands : slot_number_for_registration_number B-1234-XYZ 
1
```

- Lihat Kendaraan berdasarkan nomer plat genap
```bash
Commands : registration_numbers_for_cars_with_even_number
B-1234-XYZ 
```

- Lihat Kendaraan berdasarkan nomer plat ganjil
```bash
Commands : registration_numbers_for_cars_with_odd_number
B-1235-SST 
```


