using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace materi_delete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.Write("\nKetik K untuk Terhubung ke Database atau E untuk Keluar Dari Aplikasi : ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data Source = LAPTOP-R77GIF67\\ICHSAN;" +
                                         "initial catalog = suwanting;User ID = sa; Password = rT5*donolayan";
                                conn = new SqlConnection(strKoneksi);
                                conn.Open();

                                /* LOGIN */

                                bool sudah_login = false;
                                while (!sudah_login)
                                {
                                    Console.Write("\nUsername: ");
                                    string username = Console.ReadLine();
                                    Console.Write("Password: ");
                                    string password = Console.ReadLine();

                                    /* CEK USERNAME & PASSWORD */
                                    if (username == "1" && password == "1")
                                    {
                                        sudah_login = true;
                                        Console.Clear();
                                    }

                                    else
                                    {
                                        Console.WriteLine("\nUsername atau Password salah BROOOO!");
                                    }
                                }


                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("\n1. Pendaki");
                                        Console.WriteLine("\n2. Rombongan");
                                        Console.WriteLine("\n3. Booking");
                                        Console.WriteLine("\n4. Barang");
                                        Console.WriteLine("\n5. Barang Bawaan");
                                        Console.WriteLine("\nx. Keluar");
                                        Console.Write("\nEnter your choice : ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            /* lihat pendaki */
                                            case '1':
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nPendaki");
                                                        Console.WriteLine("\na. Melihat Data di Pendaki");
                                                        Console.WriteLine("\nb. Tambah Data Pendaki");
                                                        Console.WriteLine("\nc. Edit / update Pendaki");
                                                        Console.WriteLine("\nd. Hapus Data Tabel Pendaki");
                                                        Console.WriteLine("\nx. Keluar");
                                                        Console.Write("\nEnter your choice : ");
                                                        char ch2 = Convert.ToChar(Console.ReadLine());
                                                        switch (ch2)
                                                        {
                                                            /* lihat pendaki */
                                                            case 'a':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Data PENDAKI");
                                                                    Console.WriteLine();
                                                                    pr.bacaPendaki(conn);
                                                                }
                                                                break;

                                                            /* input pendaki */
                                                            case 'b':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data pendaki\n");
                                                                    Console.Write("Masukkan NIK: ");
                                                                    string nik = Console.ReadLine();
                                                                    Console.Write("Masukkan Nama Lengkap: ");
                                                                    string nmlkp = Console.ReadLine();
                                                                    Console.Write("Masukkan Berat Badan: ");
                                                                    string bb = Console.ReadLine();
                                                                    Console.Write("Masukkan No HP: ");
                                                                    string hp = Console.ReadLine();
                                                                    Console.Write("Masukkan Kota Domisili: ");
                                                                    string kt = Console.ReadLine();
                                                                    Console.Write("Masukkan Kode Rombongan: ");
                                                                    string kr = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.insertPendaki(nik, nmlkp, bb, hp, kt, kr, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /* edit pendaki */
                                                            case 'c':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Edit Pendaki\n");
                                                                    Console.Write("Masukkan NIK: ");
                                                                    string nnik = Console.ReadLine();
                                                                    Console.Write("Masukkan Nama Lengkap: ");
                                                                    string nnmlkp = Console.ReadLine();
                                                                    Console.Write("Masukkan Berat Badan: ");
                                                                    string nbb = Console.ReadLine();
                                                                    Console.Write("Masukkan No HP: ");
                                                                    string nhp = Console.ReadLine();
                                                                    Console.Write("Masukkan Kota Domisili: ");
                                                                    string nkt = Console.ReadLine();
                                                                    Console.Write("Masukkan Kode Rombongan: ");
                                                                    string nkr = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.updatePendaki(nnik, nnmlkp, nbb, nhp, nkt, nkr, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                                /*  hapus pendaki */
                                                            case 'd':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Masukkan Nama Pendaki yang Ingin Dihapus: \n");
                                                                    string Nmap = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.deletePendaki(Nmap, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            case 'x':
                                                                conn.Close();
                                                                Console.Clear();
                                                                Main(new string[0]);
                                                                return;
                                                            default:
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("\nInvalid Option!!");
                                                                }
                                                                break;

                                                        }

                                                    }
                                                    catch
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nCheck for the value entered.");
                                                    }

                                                }


                                            /* lihat rombongan */
                                            case '2':
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nRombongan");
                                                        Console.WriteLine("\na. Melihat Data di Rombongan");
                                                        Console.WriteLine("\nb. Tambah Data Rombongan");
                                                        Console.WriteLine("\nc. Edit / update Rombongan");
                                                        Console.WriteLine("\nd. Hapus Data Tabel Rombongan");
                                                        Console.WriteLine("\nx. Keluar");
                                                        Console.Write("\nEnter your choice : ");
                                                        char ch3 = Convert.ToChar(Console.ReadLine());
                                                        switch (ch3)
                                                        {
                                                            /* lihat rombongan */
                                                            case 'a':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Data ROMBONGAN");
                                                                    Console.WriteLine();
                                                                    pr.bacaRombongan(conn);
                                                                }
                                                                break;


                                                            /* input Rombongan */
                                                            case 'b':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data Rombongan\n");
                                                                    Console.Write("Masukkan Nama Rombongan: ");
                                                                    string nmr = Console.ReadLine();
                                                                    Console.Write("Masukkan Kode Booking: ");
                                                                    string kdb = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.insertRombongan(nmr, kdb, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /* Edit Rombongan */
                                                            case 'c':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data Rombongan\n");
                                                                    Console.Write("Masukkan Kode Rombongan: ");
                                                                    string nkdr = Console.ReadLine();
                                                                    Console.Write("Masukkan Nama Rombongan: ");
                                                                    string nnmr = Console.ReadLine();
                                                                    Console.Write("Masukkan Kode Booking: ");
                                                                    string nkdb = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.updateRombongan(nkdr, nnmr, nkdb, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /* Hapus Rombongan */
                                                            case 'd':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Masukkan Kode Rombongan yang Ingin Dihapus: \n");
                                                                    string kd_r = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.deleteRombongan(kd_r, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            case 'x':
                                                                conn.Close();
                                                                Console.Clear();
                                                                Main(new string[0]);
                                                                return;
                                                            default:
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("\nInvalid Option!!");
                                                                }
                                                                break;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nCheck for the value entered.");
                                                    }
                                                }
                                               

                                            /* lihat booking */
                                            case '3':
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nRombongan");
                                                        Console.WriteLine("\ny. Melihat Data di Booking");
                                                        Console.WriteLine("\nw. Tambah Data Booking");
                                                        Console.WriteLine("\nc. Edit / update Booking");
                                                        Console.WriteLine("\nd. Hapus Data Tabel Booking");
                                                        Console.WriteLine("\nx. Keluar");
                                                        Console.Write("\nEnter your choice : ");
                                                        char ch4 = Convert.ToChar(Console.ReadLine());
                                                        switch (ch4)
                                                        {
                                                            /* lihat booking */
                                                            case 'y':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Data BOOKING");
                                                                    Console.WriteLine();
                                                                    pr.bacaBooking(conn);
                                                                }
                                                                break;

                                                            /* input Booking */
                                                            case 'w':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data Booking\n");
                                                                    Console.Write("Jalur Turun: ");
                                                                    string jlr = Console.ReadLine();
                                                                    Console.Write("Masukkan Jumlah Hari: ");
                                                                    string jmlh = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.insertBooking(jlr, jmlh, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;


                                                            /* Edit Booking */
                                                            case 'c':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Edit Data Booking\n");
                                                                    Console.Write("Kode Booking: ");
                                                                    string nkdb = Console.ReadLine();
                                                                    Console.Write("Jalur Turun: ");
                                                                    string njlr = Console.ReadLine();
                                                                    Console.Write("Masukkan Jumlah Hari: ");
                                                                    string njmlh = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.updateBooking(nkdb, njlr, njmlh, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /* Hapus Booking */
                                                            case 'd':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Masukkan Kode Booking yang Ingin Dihapus: \n");
                                                                    string KdB = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.deleteBooking(KdB, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            case 'x':
                                                                conn.Close();
                                                                Console.Clear();
                                                                Main(new string[0]);
                                                                return;
                                                            default:
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("\nInvalid Option!!");
                                                                }
                                                                break;

                                                        }
                                                    }
                                                    catch
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nCheck for the value entered.");
                                                    }
                                                }
                                               

                                            /* lihat barang */
                                            case '4':
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nBarang");
                                                        Console.WriteLine("\na. Melihat Data di Barang");
                                                        Console.WriteLine("\nb. Tambah Data Barang");
                                                        Console.WriteLine("\nc. Edit / update Barang");
                                                        Console.WriteLine("\nd. Hapus Data Tabel Barang");
                                                        Console.WriteLine("\nx. Keluar");
                                                        Console.Write("\nEnter your choice : ");
                                                        char ch5 = Convert.ToChar(Console.ReadLine());
                                                        switch (ch5)
                                                        {
                                                            /* lihat barang */
                                                            case 'a':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Data BARANG");
                                                                    Console.WriteLine();
                                                                    pr.bacaBarang(conn);
                                                                }
                                                                break;


                                                            /* input Barang */
                                                            case 'b':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data Barang\n");
                                                                    Console.Write("Masukkan Nama Barang: ");
                                                                    string nmb = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.insertBarang(nmb, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /* Edit Barang */
                                                            case 'c':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data Barang\n");
                                                                    Console.Write("Masukkan ID Barang: ");
                                                                    string nid = Console.ReadLine();
                                                                    Console.Write("Masukkan Nama Barang: ");
                                                                    string nnmb = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.updateBarang(nid, nnmb, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /* hapus Barang */
                                                            case 'd':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Masukkan Nama Barang yang Ingin Dihapus: \n");
                                                                    string nmBr = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.deleteBarang(nmBr, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            case 'x':
                                                                conn.Close();
                                                                Console.Clear();
                                                                Main(new string[0]);
                                                                return;
                                                            default:
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("\nInvalid Option!!");
                                                                }
                                                                break;

                                                        }
                                                    }
                                                    catch
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nCheck for the value entered.");
                                                    }
                                                }
                                               

                                            /* lihat barang bawaan */
                                            case '5':
                                                while (true)
                                                {
                                                    try
                                                    {
                                                        Console.WriteLine("\nBarang Bawaan");
                                                        Console.WriteLine("\na. Melihat Data di Barang Bawaan");
                                                        Console.WriteLine("\nb. Tambah Data Barang Bawaan");
                                                        Console.WriteLine("\nc. Edit / update Barang Bawaan");
                                                        Console.WriteLine("\nd. Hapus Data Tabel Barang Bawaan");
                                                        Console.WriteLine("\ne. Testing Hapus Barang Bawaan");
                                                        Console.WriteLine("\nx. Keluar");
                                                        Console.Write("\nEnter your choice : ");
                                                        char ch6 = Convert.ToChar(Console.ReadLine());
                                                        switch (ch6)
                                                        {
                                                            /* lihat barang bawaan */
                                                            case 'a':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Data BARANG BAWAAN");
                                                                    Console.WriteLine();
                                                                    pr.bacaBarangBawaan(conn);
                                                                }
                                                                break;

                                                            /* input Barang Bawaan */
                                                            case 'b':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data Barang Bawaan\n");
                                                                    Console.Write("Masukkan Kode Rombongan: ");
                                                                    string kdbf = Console.ReadLine();
                                                                    Console.Write("Masukkan Id Barang: ");
                                                                    string idbf = Console.ReadLine();
                                                                    Console.Write("Jumlah: ");
                                                                    string jmlhb = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.insertBarangBawaan(kdbf, idbf, jmlhb, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;


                                                            /* Edit Barang Bawaan */
                                                            case 'c':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Input Data Barang Bawaan\n");
                                                                    Console.Write("Masukkan Kode Rombongan: ");
                                                                    string nkdr = Console.ReadLine();
                                                                    Console.Write("Masukkan Id Barang: ");
                                                                    string nidb = Console.ReadLine();
                                                                    Console.Write("Jumlah: ");
                                                                    string njmlhb = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.updateBarangBawaan(nkdr, nidb, njmlhb, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /* hapus Barang Bawaan */
                                                            case 'd':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Masukkan Kode Rombongan: \n");
                                                                    string Kdr = Console.ReadLine();
                                                                    Console.WriteLine("Masukkan Kode Barang yang Ingin Dihapus: \n");
                                                                    string KdBB = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.deleteBarangBawaan(Kdr, KdBB, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;

                                                            /*   Testing Hapus Barang Bawaan */
                                                            case 'e':
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Masukkan Kode Rombongan: \n");
                                                                    string Kdr = Console.ReadLine();
                                                                    try
                                                                    {
                                                                        pr.deleteTestBarangBawaan(Kdr, conn);
                                                                    }
                                                                    catch (Exception e)
                                                                    {
                                                                        Console.WriteLine("\nAnda tidak memiliki " +
                                                                            "akses untuk menambah data atau Data yang anda masukkan salah");
                                                                        Console.WriteLine(e.ToString());
                                                                    }
                                                                }
                                                                break;


                                                            case 'x':
                                                                conn.Close();
                                                                Console.Clear();
                                                                Main(new string[0]);
                                                                return;
                                                            default:
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("\nInvalid Option!!");
                                                                }
                                                                break;

                                                        }
                                                    }
                                                    catch
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("\nCheck for the value entered.");
                                                    }
                                                }
                            
                                            case 'x':
                                                conn.Close();
                                                Console.Clear();
                                                Main(new string[0]);
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid Option!!");
                                                }
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
                            }
                        case 'E':
                            return;
                        default:
                            {
                                Console.WriteLine("\ninvalid option");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak Dapat Mengakses Database Tersebut\n");
                    Console.ResetColor();
                }
            }
        }

        /* ini untuk read Pendaki */
        public void bacaPendaki(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select NIK, nama_lengkap, berat_badan, no_hp, kota_domisili, kode_rombongan From pendaki", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine("\tNIK            : " + r["NIK"]);
                Console.WriteLine("\tNama Lengkap   : " + r["nama_lengkap"]);
                Console.WriteLine("\tBerat Badan    : " + r["berat_badan"]);
                Console.WriteLine("\tNo HP          : " + r["no_hp"]);
                Console.WriteLine("\tKota Domisili  : " + r["kota_domisili"]);
                Console.WriteLine("\tKode Rombongan : " + r["kode_rombongan"]);
                Console.WriteLine();
            }
            r.Close();
        }

        /* ini untuk read Rombongan */
        public void bacaRombongan(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select kode_rombongan, nama_rombongan, kode_booking From rombongan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine("\tKode Rombongan : " + r["kode_rombongan"]);
                Console.WriteLine("\tNama Rombongan : " + r["nama_rombongan"]);
                Console.WriteLine("\tKode Booking   : " + r["kode_booking"]);
                Console.WriteLine();
            }
            r.Close();
        }

        /* ini untuk read Booking */
        public void bacaBooking(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select kode_booking, jalur_turun, jumlah_hari from booking", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine("\tKode Booking : " + r["kode_booking"]);
                Console.WriteLine("\tJalur Turun  : " + r["jalur_turun"]);
                Console.WriteLine("\tJumlah Hari  : " + r["jumlah_hari"]);
                Console.WriteLine();
            }
            r.Close();
        }

        /* ini untuk read Barang */
        public void bacaBarang(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select id_barang, nama_barang From barang", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine("\tID Barang    : " + r["id_barang"]);
                Console.WriteLine("\tNama Barang  : " + r["nama_barang"]);
                Console.WriteLine();
            }
            r.Close();
        }

        /* ini untuk read Barang Bawaan */
        public void bacaBarangBawaan(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select kode_rombongan, id_barang, jumlah From barang_bawaan", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine("\tKode Rombongan   : " + r["kode_rombongan"]);
                Console.WriteLine("\tID barang        : " + r["id_barang"]);
                Console.WriteLine("\tjumlah           : " + r["jumlah"]);
                Console.WriteLine();
            }
            r.Close();
        }

        /* INSERT PENDAKI BRO */
        public void insertPendaki(string nik, string nmlkp, string bb, string hp, string kt, string kr, SqlConnection con)
        {

            if (nik.Length != 16)
            {
                Console.WriteLine("\n\n======== NIK harus berupa 16 angka. ========");
                return;
            }


            string str = "";
            str = "insert into pendaki (NIK,nama_lengkap,berat_badan,no_hp,kota_domisili,kode_rombongan) " +
                "values(@nik,@nm,@bb,@hp,@kt,@kr)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nik", nik));
            cmd.Parameters.Add(new SqlParameter("nm", nmlkp));
            cmd.Parameters.Add(new SqlParameter("bb", bb));
            cmd.Parameters.Add(new SqlParameter("hp", hp));
            cmd.Parameters.Add(new SqlParameter("kt", kt));
            cmd.Parameters.Add(new SqlParameter("kr", kr));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }

        /* INSERT ROMBONGAN BRO */

        public bool IsKodeBookingExists(string kdb, SqlConnection con)
        {
            string query = "SELECT COUNT(*) FROM rombongan WHERE kode_booking = @kdb";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("kdb", kdb));

            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }

        public void insertRombongan(string nmr, string kdb, SqlConnection con)
        {
            if (IsKodeBookingExists(kdb, con))
            {
                Console.WriteLine("Kode booking salah, kode booking sudah dipakai.");
                return;
            }

            string str = "INSERT INTO rombongan (nama_rombongan, kode_booking) " +
                        "VALUES (@nmr, @kdb)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.Add(new SqlParameter("nmr", nmr));
            cmd.Parameters.Add(new SqlParameter("kdb", kdb));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil ditambahkan.");
        }


        /* INSERT BOOKING BRO */
        public void insertBooking(string jlr, string jmlh, SqlConnection con)
        {
            if (string.IsNullOrEmpty(jlr))
            {
                Console.WriteLine("Error: Jalur turun tidak boleh kosong.");
                return;
            }
            if (string.IsNullOrEmpty(jmlh))
            {
                Console.WriteLine("Error: Jumlah hari tidak boleh kosong.");
                return;
            }

            string str = "INSERT INTO booking (jalur_turun, jumlah_hari) " +
                        "VALUES (@jlr, @jmlh)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("jlr", jlr));
            cmd.Parameters.Add(new SqlParameter("jmlh", jmlh));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil ditambahkan.");
        }


        /* INSERT BARANG BANG */
        public void insertBarang(string nmb, SqlConnection con)
        {
            string str = "";
            str = "insert into barang(nama_barang) " +
                "values(@nmb)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nmb", nmb));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }

        /* INSERT BARANG BAWAAN MASS*/
        public void insertBarangBawaan(string kdbf, string idbf, string jmlhb, SqlConnection con)
        {
            string checkRombonganQuery = "SELECT COUNT(*) FROM rombongan WHERE kode_rombongan = @kdbf";
            SqlCommand checkRombonganCmd = new SqlCommand(checkRombonganQuery, con);
            checkRombonganCmd.Parameters.Add(new SqlParameter("kdbf", kdbf));

            int countRombongan = (int)checkRombonganCmd.ExecuteScalar();

            if (countRombongan == 0)
            {
                Console.WriteLine("Kode rombongan salah");
            }
            else
            {
                string checkBarangQuery = "SELECT COUNT(*) FROM barang WHERE id_barang = @idbf";
                SqlCommand checkBarangCmd = new SqlCommand(checkBarangQuery, con);
                checkBarangCmd.Parameters.Add(new SqlParameter("idbf", idbf));

                int countBarang = (int)checkBarangCmd.ExecuteScalar();

                if (countBarang == 0)
                {
                    Console.WriteLine("id barang salah bro");
                }
                else
                {
                    string str = "INSERT INTO barang_bawaan (kode_rombongan, id_barang, jumlah) " +
                                "VALUES (@kdbf, @idbf, @jmlhb)";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.Parameters.Add(new SqlParameter("kdbf", kdbf));
                    cmd.Parameters.Add(new SqlParameter("idbf", idbf));
                    cmd.Parameters.Add(new SqlParameter("jmlhb", jmlhb));

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data berhasil ditambahkan");
                }
            }
        }




        /* UPDATEEEEE */
        public void updatePendaki(string nnik, string nnmlkp, string nbb, string nhp, string nkt, string nkr, SqlConnection con)
        {
            string str = "UPDATE pendaki SET NIK = @nnik, nama_lengkap = @nnmlkp, berat_badan = @nbb, no_hp = @nhp, kota_domisili = @nkt, kode_rombongan = @nkr WHERE NIK = @nnik";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nnik", nnik));
            cmd.Parameters.Add(new SqlParameter("nnmlkp", nnmlkp));
            cmd.Parameters.Add(new SqlParameter("nbb", nbb));
            cmd.Parameters.Add(new SqlParameter("nhp", nhp));
            cmd.Parameters.Add(new SqlParameter("nkt", nkt));
            cmd.Parameters.Add(new SqlParameter("nkr", nkr));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Diedit");
        }

        public void updateRombongan(string nkdr, string nnmr, string nkdb, SqlConnection con)
        {
            string str = "UPDATE rombongan SET nama_rombongan = @nnmr, kode_booking = @nkdb WHERE kode_rombongan = @nkdr";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nkdr", nkdr));
            cmd.Parameters.Add(new SqlParameter("nnmr", nnmr));
            cmd.Parameters.Add(new SqlParameter("nkdb", nkdb));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Diedit");
        }

        public void updateBooking(string nkdb, string njlr, string njmlh, SqlConnection con)
        {
            string str = "UPDATE booking SET jalur_turun = @njlr, jumlah_hari = @njmlh WHERE kode_booking = @nkdb";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("njlr", njlr));
            cmd.Parameters.Add(new SqlParameter("njmlh", njmlh));
            cmd.Parameters.Add(new SqlParameter("nkdb", nkdb));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Diedit");
        }
        public void updateBarang(string nid, string nnmb, SqlConnection con)
        {
            string str = "UPDATE barang SET nama_barang = @nnmb WHERE id_barang = @nid";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nid", nid));
            cmd.Parameters.Add(new SqlParameter("nnmb", nnmb));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Diedit");
        }

        public void updateBarangBawaan(string nkdr, string nidb, string njmlhb, SqlConnection con)
        {
            string str = "UPDATE barang_bawaan SET jumlah = @njmlhb WHERE id_barang = @nidb";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nkdr", nkdr));
            cmd.Parameters.Add(new SqlParameter("nidb", nidb));
            cmd.Parameters.Add(new SqlParameter("njmlhb", njmlhb));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Diedit");
        }

        /* DELETEEEEEE */

        public void deletePendaki(string nmlkp, SqlConnection con)
        {
            string str = "";
            str = "Delete pendaki where nama_lengkap = @nmlkp";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nmlkp", nmlkp));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Dihapus");
        }

        public void deleteRombongan(string kd_r, SqlConnection con)
        {
            string str = "";
            str = "Delete rombongan where kode_rombongan = @kd_r";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("kd_r", kd_r));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Dihapus");
        }

        public void deleteBooking(string kdb, SqlConnection con)
        {
            string str = "";
            str = "Delete booking where kode_booking = @kdb";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("kdb", kdb));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Dihapus");
        }

        public void deleteBarang(string nmbr, SqlConnection con)
        {
            string str = "";
            str = "Delete barang where nama_barang = @nmbr";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("nmbr", nmbr));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Dihapus");
        }

        public void deleteBarangBawaan(string kdr, string kdbb, SqlConnection con)
        {
            string str = "";
            str = "Delete FROM barang_bawaan where id_barang = @kdbb AND kode_rombongan = @kdr";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("kdbb", kdbb));
            cmd.Parameters.Add(new SqlParameter("kdr", kdr));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Dihapus");
        }

        public void deleteTestBarangBawaan(string kdr, SqlConnection con)
        {
            string str = "";
            str = "Delete FROM barang_bawaan WHERE kode_rombongan = @kdr";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("kdr", kdr));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data berhasil Dihapus");
        }

    }
}
