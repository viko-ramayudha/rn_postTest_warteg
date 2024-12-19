using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

public class DbManager
{
    private readonly string _connectionString;
    public DbManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

    // Warteg
    public List<Warteg> GetAllWartegs()
        {
            List<Warteg> wartegList = new List<Warteg>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Warteg";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Warteg warteg = new Warteg
                            {
                                id = Convert.ToInt32(reader["Id"]),
                                nama = reader["Nama"].ToString(),
                                harga = Convert.ToInt32(reader["Harga"]),
                                stok = Convert.ToInt32(reader["Stok"]),
                            };
                            wartegList.Add(warteg);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return wartegList;
        }

    // Warteg GetById
    public Warteg GetWartegById(int id)
        {
        Warteg warteg = null;
        try
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM warteg WHERE id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        warteg = new Warteg
                        {
                            id = Convert.ToInt32(reader["Id"]),
                            nama = reader["Nama"].ToString(),
                            harga = Convert.ToInt32(reader["Harga"]),
                            stok = Convert.ToInt32(reader["Stok"]),
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return warteg;
        }

        // Create Warteg
        public int CreateWarteg(Warteg warteg)
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    string query = "INSERT INTO warteg (nama, harga, stok, id) VALUES (@Nama, @Harga, @Stok, @Id)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", warteg.id);
                        command.Parameters.AddWithValue("@Nama", warteg.nama);
                        command.Parameters.AddWithValue("@Harga", warteg.harga);
                        command.Parameters.AddWithValue("@Stok", warteg.stok);

                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }

        // Update Warteg
        public int UpdateWarteg(int id, Warteg warteg)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE warteg SET nama = @Nama, harga = @Harga, stok = @Stok WHERE id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@Nama", warteg.nama);
                    command.Parameters.AddWithValue("@Harga", warteg.harga);
                    command.Parameters.AddWithValue("@Stok", warteg.stok);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Delete Warteg
        public int DeleteWarteg(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM warteg WHERE id = @Id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // User
//     public List<User> GetAllUsers()
//         {
//             List<User> userList = new List<User>();
//             try
//             {
//                 using (MySqlConnection connection = new MySqlConnection(_connectionString))
//                 {
//                     string query = "SELECT * FROM User";
//                     MySqlCommand command = new MySqlCommand(query, connection);
//                     connection.Open();
//                     using (MySqlDataReader reader = command.ExecuteReader())
//                     {
//                         while (reader.Read())
//                         {
//                             User user = new User
//                             {
//                                 id = Convert.ToInt32(reader["id"]),
//                                 nama = reader["nama"].ToString(),
//                                 email = reader["email"].ToString(),
//                             };
//                             userList.Add(user);
//                         }
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//             return userList;
//         }

//         // Create User
//         public int CreateUser(User user)
//             {
//                 using (MySqlConnection connection = new MySqlConnection(_connectionString))
//                 {
//                     string query = "INSERT INTO user (nama, email) VALUES (@Nama, @Email)";
//                     using (MySqlCommand command = new MySqlCommand(query, connection))
//                     {
//                         command.Parameters.AddWithValue("@Nama", user.nama);
//                         command.Parameters.AddWithValue("@Email", user.email);

//                         connection.Open();
//                         return command.ExecuteNonQuery();
//                     }
//                 }
//             }
        
//         // Update User
//         public int UpdateUser(int id, User user)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "UPDATE user SET nama = @Nama, email = @Email WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Nama", user.nama);
//                     command.Parameters.AddWithValue("@Email", user.email);
//                     command.Parameters.AddWithValue("@Id", id);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

//         // Delete User
//         public int DeleteUser(int id)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "DELETE FROM user WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id", id);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

//     // Buku
//     public List<Buku> GetAllBukus()
//         {
//             List<Buku> bukuList = new List<Buku>();
//             try
//             {
//                 using (MySqlConnection connection = new MySqlConnection(_connectionString))
//                 {
//                     string query = "SELECT * FROM Buku";
//                     MySqlCommand command = new MySqlCommand(query, connection);
//                     connection.Open();
//                     using (MySqlDataReader reader = command.ExecuteReader())
//                     {
//                         while (reader.Read())
//                         {
//                             Buku buku = new Buku
//                             {
//                                 id = Convert.ToInt32(reader["Id"]),
//                                 judul = reader["Judul"].ToString(),
//                                 pengarang = reader["Pengarang"].ToString(),
//                                 penerbit = reader["Penerbit"].ToString(),
//                                 tahun = Convert.ToInt32(reader["Tahun"])
//                             };
//                             bukuList.Add(buku);
//                         }
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//             return bukuList;
//         }

//     // Buku
//     public Buku GetBukuById(int id)
//         {
//         Buku buku = null;
//         try
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "SELECT * FROM buku WHERE id = @Id";
//                 MySqlCommand command = new MySqlCommand(query, connection);
//                 command.Parameters.AddWithValue("@Id", id);
//                 connection.Open();
//                 using (MySqlDataReader reader = command.ExecuteReader())
//                 {
//                     if (reader.Read())
//                     {
//                         buku = new Buku
//                         {
//                             id = Convert.ToInt32(reader["Id"]),
//                             judul = reader["Judul"].ToString(),
//                             pengarang = reader["Pengarang"].ToString(),
//                             penerbit = reader["Penerbit"].ToString(),
//                             tahun = Convert.ToInt32(reader["Tahun"])
//                         };
//                     }
//                 }
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//         return buku;
//         }

//         // Create Buku
//         public int CreateBuku(Buku buku)
//             {
//                 using (MySqlConnection connection = new MySqlConnection(_connectionString))
//                 {
//                     string query = "INSERT INTO buku (judul, pengarang, penerbit, tahun,id) VALUES (@Judul, @Pengarang, @Penerbit, @Tahun, @Id)";
//                     using (MySqlCommand command = new MySqlCommand(query, connection))
//                     {
//                         command.Parameters.AddWithValue("@Id", buku.id);
//                         command.Parameters.AddWithValue("@Judul", buku.judul);
//                         command.Parameters.AddWithValue("@Pengarang", buku.pengarang);
//                         command.Parameters.AddWithValue("@Penerbit", buku.penerbit);
//                         command.Parameters.AddWithValue("@Tahun", buku.tahun);

//                         connection.Open();
//                         return command.ExecuteNonQuery();
//                     }
//                 }
//             }
        
//         // Update Buku
//         public int UpdateBuku(int id, Buku buku)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "UPDATE buku SET judul = @Judul, pengarang = @Pengarang, penerbit = @Penerbit, tahun = @Tahun WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Judul", buku.judul);
//                     command.Parameters.AddWithValue("@Pengarang", buku.pengarang);
//                     command.Parameters.AddWithValue("@Penerbit", buku.penerbit);
//                     command.Parameters.AddWithValue("@Tahun", buku.tahun);
//                     command.Parameters.AddWithValue("@Id", id);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

//         // Delete Buku
//         public int DeleteBuku(int id)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "DELETE FROM buku WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id", id);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

// // Peminjaman
//     public List<Peminjaman> GetAllPeminjamans()
//     {
//         List<Peminjaman> PeminjamanList = new List<Peminjaman>();
//         try
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "SELECT * FROM Peminjaman";
//                 MySqlCommand command = new MySqlCommand(query, connection);
//                 connection.Open();
//                 using (MySqlDataReader reader = command.ExecuteReader())
//                 {
//                     while (reader.Read())
//                     {
//                         Peminjaman peminjaman = new Peminjaman
//                         {
//                             id = Convert.ToInt32(reader["id"]),
//                             id_buku = Convert.ToInt32(reader["id_buku"]),
//                             id_user = Convert.ToInt32(reader["id_user"]),
//                             nama_user = reader["nama_user"].ToString(),
//                             judul_buku = reader["judul_buku"].ToString(),
//                             tanggal_pinjam = reader.GetDateTime(reader.GetOrdinal("tanggal_pinjam")),
//                             tanggal_pengembalian = reader.GetDateTime(reader.GetOrdinal("tanggal_pengembalian")),
//                         };
//                         PeminjamanList.Add(peminjaman);
//                     }
//                 }
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//         return PeminjamanList;
//     }
//     // Get By ID
//     public List<Peminjaman> GetIndeksPeminjamanById(int id)
//         {
//             List<Peminjaman> Peminjaman = new List<Peminjaman>();
//             try
//             {
//                 using (MySqlConnection connection = new MySqlConnection(_connectionString))
//                 {
//                     string query = "SELECT * FROM peminjaman WHERE id = ?";
//                     using (MySqlCommand command = new MySqlCommand(query, connection))
//                     {
//                         command.Parameters.AddWithValue("@Id", id);
//                         connection.Open();
//                         using (MySqlDataReader reader = command.ExecuteReader())
//                         {
//                             while (reader.Read())
//                             {
//                                 Peminjaman info = new Peminjaman
//                                 {
//                                     id = Convert.ToInt32(reader["id"]),
//                                     id_buku = Convert.ToInt32(reader["id_buku"]),
//                                     id_user = Convert.ToInt32(reader["id_user"]),
//                                     nama_user = reader["nama_user"].ToString(),
//                                     judul_buku = reader["judul_buku"].ToString(),
//                                     tanggal_pinjam = reader.GetDateTime(reader.GetOrdinal("tanggal_pinjam")),
//                                     tanggal_pengembalian = reader.GetDateTime(reader.GetOrdinal("tanggal_pengembalian")),
//                                 };
//                                 Peminjaman.Add(info);
//                             }
//                         }
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//             return Peminjaman;
//         }
//     // Create Peminjaman
//     public int CreatePeminjaman(Peminjaman peminjaman)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 // string query = "INSERT INTO peminjaman (id , id_buku , id_user , nama_user , judul_buku , tanggal_pinjam , tanggal_pengembalian) VALUES (@Id , @Id_buku , @Id_user, @Nama_buku , @Judul_buku , @Tanggal_pinjam , @Tanggal_pengembalian)";
//                 string query = "INSERT INTO peminjaman (id, id_buku, id_user, tanggal_pinjam, tanggal_pengembalian) VALUES (@Id , @Id_buku , @Id_user, @Tanggal_pinjam , @Tanggal_pengembalian)";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id", peminjaman.id);
//                     command.Parameters.AddWithValue("@Id_buku", peminjaman.id_buku);
//                     command.Parameters.AddWithValue("@Id_user", peminjaman.id_user);
//                     // command.Parameters.AddWithValue("@Nama_user", peminjaman.nama_user);
//                     // command.Parameters.AddWithValue("@Judul_buku", peminjaman.judul_buku);
//                     command.Parameters.AddWithValue("@Tanggal_pinjam", peminjaman.tanggal_pinjam);
//                     command.Parameters.AddWithValue("@Tanggal_pengembalian", peminjaman.tanggal_pengembalian);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }
    
//     // Update Peminjaman
//     public int UpdatePeminjaman(int id, Peminjaman peminjaman)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "UPDATE peminjaman SET id_buku = @Id_buku, id_user = @Id_user, nama_user = @Nama_user, judul_buku = @Judul_buku, tanggal_pinjam = @Tanggal_pinjam, tanggal_pengembalian = @Tanggal_pengembalian WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id_buku", peminjaman.id_buku);
//                     command.Parameters.AddWithValue("@Id_user", peminjaman.id_user);
//                     command.Parameters.AddWithValue("@Nama_user", peminjaman.nama_user);
//                     command.Parameters.AddWithValue("@Judul_buku", peminjaman.judul_buku);
//                     command.Parameters.AddWithValue("@Tanggal_pinjam", peminjaman.tanggal_pinjam);
//                     command.Parameters.AddWithValue("@Tanggal_pengembalian", peminjaman.tanggal_pengembalian);
//                     command.Parameters.AddWithValue("@Id", id);



//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

//     // Delete Peminjaman
//     public int DeletePeminjaman(int id)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "DELETE FROM peminjaman WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id", id);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

//         // Denda
//         public List<Denda> GetAllDendas()
//         {
//             List<Denda> DendaList = new List<Denda>();
//             try
//             {
//                 using (MySqlConnection connection = new MySqlConnection(_connectionString))
//                 {
//                     string query = "SELECT * FROM Denda";
//                     MySqlCommand command = new MySqlCommand(query, connection);
//                     connection.Open();
//                     using (MySqlDataReader reader = command.ExecuteReader())
//                     {
//                         while (reader.Read())
//                         {
//                             Denda denda = new Denda
//                             {
//                                 id = Convert.ToInt32(reader["id"]),
//                                 id_buku = Convert.ToInt32(reader["id_buku"]),
//                                 id_user = Convert.ToInt32(reader["id_user"]),
//                                 nama_user = reader["nama_user"].ToString(),
//                                 judul_buku = reader["judul_buku"].ToString(),
//                                 jumlah_denda = Convert.ToInt32(reader["jumlah_denda"])
//                             };
//                             DendaList.Add(denda);
//                         }
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }
//             return DendaList;
//         }
    
//     // Create Denda
//     public int CreateDenda(Denda denda)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "INSERT INTO denda (id , id_buku , id_user , nama_user, judul_buku, jumlah_denda) VALUES (@Id , @Id_buku , @Id_user, @Nama_user , @Judul_buku ,  @Jumlah_denda)";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id", denda.id);
//                     command.Parameters.AddWithValue("@Id_buku", denda.id_buku);
//                     command.Parameters.AddWithValue("@Id_user", denda.id_user);
//                     command.Parameters.AddWithValue("@Nama_user", denda.nama_user);
//                     command.Parameters.AddWithValue("@Judul_buku", denda.judul_buku);
//                     command.Parameters.AddWithValue("@Jumlah_denda", denda.jumlah_denda);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

//     // Update Denda
//     public int UpdateDenda(int id, Denda denda)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "UPDATE denda SET id_buku = @Id_buku, id_user = @Id_user, nama_user = @Nama_user, judul_buku = @Judul_buku, jumlah_denda = @Jumlah_denda WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id_buku", denda.id_buku);
//                     command.Parameters.AddWithValue("@Id_user", denda.id_user);
//                     command.Parameters.AddWithValue("@Nama_user", denda.nama_user);
//                     command.Parameters.AddWithValue("@Judul_buku", denda.judul_buku);
//                     command.Parameters.AddWithValue("@Jumlah_denda", denda.jumlah_denda);
//                     command.Parameters.AddWithValue("@Id", id);



//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }

//     // Delete Denda
//     public int DeleteDenda(int id)
//         {
//             using (MySqlConnection connection = new MySqlConnection(_connectionString))
//             {
//                 string query = "DELETE FROM denda WHERE id = @Id";
//                 using (MySqlCommand command = new MySqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@Id", id);

//                     connection.Open();
//                     return command.ExecuteNonQuery();
//                 }
//             }
//         }
    
}