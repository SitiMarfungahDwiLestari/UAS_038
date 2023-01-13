using System;

namespace UAS_038
{
    class Node
    {
        public int idbarang;
        public string namabarang;
        public string jenisbarang;
        public int hargabarang;
        public Node next;
    }

    class List
    {
        Node Last;
        public List()
        {
            Last = null;
        }
        public void addNode()
        {
            int Kode;
            string nama;
            string jenis;
            int harga;
            Console.Write("\nMasukkan ID Barang: ");
            Kode = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Barang: ");
            nama = Console.ReadLine();
            Console.Write("\nMasukkan Jenis Barang: ");
            jenis = Console.ReadLine();
            Console.Write("\nMasukkan Harga Barang: ");
            harga = Convert.ToInt32(Console.ReadLine());
            Node newNode = new Node();
            newNode.idbarang = Kode;
            newNode.namabarang = nama;
            newNode.jenisbarang = jenis;
            newNode.hargabarang = harga;

            if (Last == null || Kode <= Last.idbarang)
            {
                if ((Last != null) && (Kode == Last.idbarang))
                {
                    Console.WriteLine("\nDuplicate number code not allowed");
                    return;
                }
                newNode.next = Last;
                Last = newNode;
                return;
            }
            Node previous, current;
            previous = Last;
            current = Last;

            while ((current != null) && (Kode >= current.idbarang))
            {
                if (Kode == current.idbarang)
                {
                    Console.WriteLine("\nDuplicate number code not allowed");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newNode.next = current;
            previous.next = newNode;
        }
        public bool Search (string jns, ref Node previous, ref Node current)
        {
            previous = Last;
            current = Last;
            while ((current != null) && (jns != current.jenisbarang))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nDAFTAR KOSONG");
            else
            {
                Console.WriteLine("\nData Barang: \n");
                Console.WriteLine("\nID Barang \t Nama Barang \t Jenis Barang \t Harga Barang");
                Node currentNode;
                currentNode = Last.next;
                for (currentNode = Last; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.idbarang + " \t\t" + currentNode.namabarang + " \t\t" + currentNode.jenisbarang + " \t\t" + currentNode.hargabarang + " \n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (Last == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n==================MENU==================");
                    Console.WriteLine("\n1. Masukkan Data");
                    Console.WriteLine("\n2. Mencari Data (berdasarkan jenis barang)");
                    Console.WriteLine("\n3. Tampilkan Semua Data");
                    Console.WriteLine("\n4. Exit");
                    Console.WriteLine("\nMasukkan Nomor (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nDATA TIDAK TERSEDIA");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan Jenis Barang yang ingin Anda cari: ");
                                string jnsbrg = Console.ReadLine();
                                if (obj.Search(jnsbrg, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData Tidak Ditemukan");
                                else
                                {
                                    Console.WriteLine("\nDATA DITEMUKAN");
                                    Console.WriteLine("\nID Barang: " + curr.idbarang);
                                    Console.WriteLine("\nNama Barang: " + curr.namabarang);
                                    Console.WriteLine("\nJenis Barang: " + curr.jenisbarang);
                                    Console.WriteLine("\nHarga Barang: " + curr.hargabarang);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                Console.WriteLine("\nInvalid Option");
                            }
                            break;
                    }    
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck for the values entered.");
                }
            }
        }
    }
}








//2. Saya menggunakan algoritma Singly Linked List karena algroritma ini dapat digunakan untuk mengurutkan data yang belum 
//   berurutan sama sekali (acak-acakan) dan dapat digunakan untuk melakukan proses pengurutan data dengan algoritma sorting.


//3. Array adalah sebuah struktur data yang memiliki sejulah elemen yang ditempatkan secara berurutan dalam memori komputer.
//   Dimana elemen-elemen array tersebut dapat diakses dengan menggunakan index yang ditentukan.
//   Sedangkan Linked List adalah suatu struktur data yang terdiri dari node-node yang saling terhubung,
//   Dimana setiap node memiliki data dan referensi ke node berikutnya


//4. ditambahkan diakhir disebut ENQUEUE dan data yang dihapus paling terakhir disebut DEQUEUE  


//5. a) - Node 41 and 74 are siblings of each other
//      - Node 16 and 53 are siblings of each other
//      - Node 46 and 55 are siblings of each other 
//      - Node 63 and 70 are siblings of each other
//      - Node 62 and 64 are siblings of each other
//   b) Inorder = 16, 25, 41, 42, 46, 53, 56, 60, 62, 63, 64, 65, 70, 74 
//      Langkah-langkah membacanya adalah dengan membaca subtree dari pohon tersebut mulai dari sebelah kiri.
//      Lalu ke root dan yang terakhir ke kanan. Sehingga didapatkan data seperti diatas.