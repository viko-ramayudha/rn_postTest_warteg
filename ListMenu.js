import React, { useState, useEffect } from "react";
import { Text, View, Image, StyleSheet, TextInput, Alert, TouchableOpacity, ScrollView, Modal } from "react-native";
import * as Notifications from 'expo-notifications';
import axios from 'axios';
import { RefreshControl } from "react-native-gesture-handler";

const Profile = (props) => {
  return (
    <View>
      <View style={styles.wrapperprofile}>
        <TouchableOpacity onPress={props.onPress}>
          <Image source={require('./assets/ic-makan.jpg')} style={styles.img} />
        </TouchableOpacity>

        <View style={styles.txtwrapper}>
          <TouchableOpacity onPress={props.onPress}>
            <Text style={styles.text}>Menu  : {props.nama}</Text>
            <Text style={styles.text}>Price   : {props.harga}</Text>
            <Text style={styles.text}>Stock  : {props.stok}</Text>
          </TouchableOpacity>
        </View>

        <TouchableOpacity onPress={props.onDelete}>
          <View style={styles.iconWrapper}>
            <Image source={require('./assets/add.png')} style={styles.icon} />
          </View>
        </TouchableOpacity>
      </View>
    </View>
  );
}

const ListMenu = () => {
  const [nama, setNama] = useState("");
  const [harga, setHarga] = useState("");
  const [stok, setStok] = useState("");
  const [utss, setUtss] = useState([]);
  const [btn, setBtn] = useState("Simpan");
  const [selectedUser, setSelectedUser] = useState({});
  const [searchTerm, setSearchTerm] = useState("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [refreshing, setRefreshing] = useState(false);

  useEffect(() => {
    read();
    registerForPushNotifications(); 
  }, []);

  const read = async () => {
    setLoading(true);
    try {
      const response = await axios.get('http://192.168.190.166:7023/api/Menu');
      console.log(response.data);
      setUtss(response.data.data);
      setNama("");
      setHarga("");
      setStok("");
      setBtn("Simpan");
    } catch (err) {
      console.error('Error fetching data:', err);
      setError('Terjadi kesalahan saat mengambil data');
    } finally {
      setLoading(false);
      setRefreshing(false);
    }
  }

  const registerForPushNotifications = async () => {
    try {
      const { status } = await Notifications.requestPermissionsAsync();
      if (status !== 'granted') {
        alert('Permission to receive notifications was denied');
        return;
      }
      console.log('Notification permissions granted!');
    } catch (error) {
      console.error('Error getting notification permission:', error);
    }
  };

  const handleSearch = (text) => {
    setSearchTerm(text); 
    if (text.trim() !== "") {
      const filteredUts = utss.filter(uts =>
        uts.nama.toLowerCase().includes(text.toLowerCase())
      );
      setUtss(filteredUts); 
    } else {
      read(); 
    }
  };

  const submit = () => {
    const data = {
      nama: nama,
      harga: harga,
      stok: stok
    }
    if (btn === "Simpan") {
      axios.post('http://192.168.190.166:7023/api/Menu/insertMenu', data)
        .then(response => {
          console.log(response);
          read();
          sendNotification('Item Ditambahkan', 'Berhasil menambahkan item baru.');
        })
        .catch(err => console.log(err));
    } else {
      axios.put(`http://192.168.190.166:7023/api/Menu/updateMenu/${selectedUser.id}`, data)
        .then(response => {
          console.log(response);
          read();
          sendNotification('Item Diperbarui', 'Berhasil memperbarui item.');
          setIsModalVisible(false);
        })
        .catch(err => console.log(err));
    }
  }

  const selectItem = (item) => {
    console.log(item);
    setSelectedUser(item);
    setNama(item.nama);
    setHarga(item.harga);
    setStok(item.stok);
    setBtn("Update");
    setIsModalVisible(true);
  }

  const deleteItem = (item) => {
    console.log(item);
    axios.delete(`http://192.168.190.166:7023/api/Menu/deleteMenu/${item.id}`)
      .then(response => {
        console.log(response);
        read();
        sendNotification('Item Dihapus', 'Berhasil menghapus item.');
      })
      .catch(err => console.log(err));
  }

  const sendNotification = async (title, body) => {
    try {
      await Notifications.presentNotificationAsync({
        title: title,
        body: body,
      });
    } catch (error) {
      console.error('Error sending notification:', error);
    }
  };

  const handleRefresh = () => {
    setRefreshing(true);
    read();
  }

  return (
    <ScrollView refreshControl={
      <RefreshControl
      refreshing={refreshing}
      onRefresh={handleRefresh}/>
    }>
      <View>
        <TouchableOpacity style={styles.ads}>
          <Image source={{ uri: 'https://blog.javamifi.com/wp-content/uploads/2023/09/Cuplikan-layar-2023-09-27-223916.png' }} style={styles.ads} />
        </TouchableOpacity>
      </View>

      <View style={styles.container}>
        {/* <Text style={{ fontWeight: '900', fontSize: 17, color: '#000', marginBottom: 18, alignSelf: 'center' }}>List Menu Warteg Bahari</Text>
        <TextInput style={styles.input} placeholder="Menu" value={nama} onChangeText={(value) => setNama(value)} />
        <TextInput style={styles.input} placeholder="Harga" value={harga} onChangeText={(value) => setHarga(value)} />
        <TextInput style={styles.input} placeholder="Stok" value={stok} onChangeText={(value) => setStok(value)} />
        <TouchableOpacity onPress={submit} style={styles.btn}>
          <Text style={{ color: '#000', alignSelf: 'center', fontWeight: 'bold' }}>{btn}</Text>
        </TouchableOpacity> */}
  
        <View style={styles.searchContainer}>
          <TextInput
            style={styles.searchInput}
            placeholder="Search by Name"
            value={searchTerm}
            onChangeText={handleSearch} 
            keyboardType="default"
            returnKeyType="search"
            refreshing={loading}
          />
        </View>
        <View style={styles.line} />
        <View style={{ paddingVertical: 10 }}>
          {utss.map(uts => (
            <Profile
              key={uts.id}
              nama={uts.nama}
              harga={uts.harga}
              stok={uts.stok}
              onPress={() => selectItem(uts)}
              onDelete={() => Alert.alert('Perhatian!', 'Apakah anda ingin memesan menu ini?', [{ text: 'tidak' }, { text: 'Ya', }])}
            />
          ))}
        </View>
      </View>

      {/* Modal */}
      <Modal
        animationType="slide"
        transparent={true}
        visible={isModalVisible}
        onRequestClose={() => setIsModalVisible(false)}
      >
        <View style={styles.modalBackground}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Detail Menu</Text>
            <Text style={styles.modalText}>Menu   : {selectedUser.nama}</Text>
            <Text style={styles.modalText}>Price    : {selectedUser.harga}</Text>
            <Text style={styles.modalText}>Stock   : {selectedUser.stok}</Text>
            <TouchableOpacity onPress={() => setIsModalVisible(false)} style={styles.modalButton}>
              <Text style={styles.modalButtonText}>Close</Text>
            </TouchableOpacity>
          </View>
        </View>
      </Modal>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  wrapperprofile: {
    marginVertical: 10,
    flexDirection: 'row',
    alignItems: 'center',
    borderRadius: 9,
    borderWidth: 1,
    backgroundColor: '#f0f0f0',
    padding: 10,
  },
  img: {
    alignItems: 'center',
    alignSelf: 'stretch',
    width: 60,
    height: 60,
    borderRadius: 60 / 2
  },
  icon: {
    alignItems: 'right',
    width: 38,
    height: 38,
    marginLeft: -90,
  },
  txtwrapper: {
    marginLeft: 10,
    width: 300,
  },
  container: {
    padding: 20,
    backgroundColor: '#fff'
  },
  ads: {
    height: 250,
    width: 435,
    marginLeft: -15
  },
  searchContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    backgroundColor: '#fff',
    paddingTop: 0,
    paddingBottom: 10,
  },
  searchInput: {
    flex: 1,
    height: 40,
    width: 200,
    borderColor: '#ccc',
    borderWidth: 1,
    borderRadius: 20,
    paddingHorizontal: 10,
    backgroundColor: '#f0f0f0',
    marginRight: 10,
    marginLeft: 1,
    borderWidth: 1,
  },
  input: {
    padding: 7,
    marginBottom: 20,
    borderRadius: 8,
    borderWidth: 1,
    backgroundColor: '#f0f0f0',
  },
  line: {
    height: 2,
    backgroundColor: 'black',
    marginVertical: 10,
  },
  btn: {
    borderRadius: 10,
    padding: 13,
    backgroundColor: '#2FB634',
  },
  text: {
    fontSize: 13,
    fontWeight: 'bold',
  },
  modalBackground: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
  },
  modalContent: {
    backgroundColor: '#fff',
    padding: 20,
    borderRadius: 10,
    width: '80%',
  },
  modalTitle: {
    fontSize: 18,
    fontWeight: 'bold',
    marginBottom: 20,
    alignSelf: 'center',
  },
  modalText: {
    fontSize: 16,
    marginBottom: 5,
  },
  modalButton: {
    marginTop: 50,
    backgroundColor: '#2FB634',
    padding: 10,
    paddingBottom: 13,
    borderRadius: 8,
    width: '50%',
    alignSelf: 'center',
  },
  modalButtonText: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#fff',
    alignSelf: 'center',
  },
});

export default ListMenu;
