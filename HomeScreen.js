import React from "react";
import { Text, View, Image, StyleSheet, ScrollView, TouchableOpacity } from "react-native";
import { useNavigation } from '@react-navigation/native';

const HomeScreen = () => {
  const navigation = useNavigation(); 

  return (
    <ScrollView style={styles.container}>

      <Image
        source={require('./assets/bann.jpg')}
        style={styles.banner}
        resizeMode="cover" 
      />
      <Text style={styles.welc}>Selamat Datang di</Text>
      <Text style={styles.title}>Warteg Bahari</Text>

      <View style={styles.cont}>
        <View style={styles.section}>
          <Text style={styles.sectionTitle}>Tentang Warteg Bahari</Text>
          <Text style={styles.sectionContent}>Warteg Bahari adalah warung tegal yang
            menyediakan makanan khas Indonesia
            dengan harga terjangkau dan rasa yang lezat. Kami bangga memberikan pilihan layanan 
          </Text>
        </View>

        {/* Bagian Layanan Warteg Bahari */}
        <View style={styles.section}>
          <Text style={styles.sectionTitle}>Layanan Warteg Bahari</Text>
          <Text style={styles.sectionContent}>
            - Penjualan makanan khas Indonesia seperti nasi goreng dan pecel{'\n'}
            - Pelayanan makan di tempat dan layanan take-away{'\n'}
            - Paket catering untuk acara kantor dan pribadi{'\n'}
            - Menu spesial untuk anak-anak dan keluarga{'\n'}
            - Pilihan minuman tradisional seperti es kelapa muda dan teh manis{'\n'}
            - Ruang santai dan area bermain untuk keluarga{'\n'}
            - Pelayanan ramah dari staff yang berpengalaman
          </Text>
        </View>

        {/* Bagian Mengapa Memilih Warteg Bahari */}
        <View style={styles.section}>
          <Text style={styles.sectionTitle}>Mengapa Warteg Bahari?</Text>
          <Text style={styles.sectionContent}>
            - Rasa dan kualitas makanan yang terjamin{'\n'}
            - Harga yang kompetitif{'\n'}
            - Pengalaman bersantap yang nyaman dan ramah keluarga{'\n'}
            - Lokasi strategis di berbagai kota besar{'\n'}
            - Kebijakan kebersihan dan keamanan yang ketat
          </Text>
        </View>
        {/* Tombol Menu */}
        {/* <TouchableOpacity
        style={styles.btn}
        onPress={() => navigation.navigate("ListMenu")} // Ensure navigation works correctly
        >
        <Text style={{ color: "#000", alignSelf: "center", fontWeight: "bold" }}>
          Menu
        </Text>
      </TouchableOpacity> */}
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  cont: {
    flex: 1,
    padding: 20,
  },
  banner: {
    width: '110%',
    height: 270,
    marginLeft: 0,
    opacity: 0.9,
  },
  welc: {
    paddingTop: 25,
    fontSize: 31.5,
    fontWeight: '900',
    textAlign: 'center',
    color: '#fff',
    // marginLeft: -90,
    marginTop: -200
  },
  title: {
    fontSize: 30,
    fontWeight: '900',
    paddingBottom: -10, 
    textAlign: 'center',
    color: '#2FB634',
    // marginRight: -130,
    marginTop: 5,
    marginBottom: 90
  },
  section: {
    marginTop: 5,
    paddingHorizontal: 3,
    paddingVertical: 15,
    marginBottom: 20,
    backgroundColor: '#fff',
    borderRadius: 14,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.8,
    shadowRadius: 2,
    elevation: 5,
  },
  sectionTitle: {
    fontSize: 18,
    fontWeight: '900',
    color: '#2FB634',
    textAlign: 'center',
    marginTop: 5,
    marginBottom: 5,
  },
  sectionContent: {
    fontSize: 16,
    color: '#666',
    lineHeight: 24,
    alignSelf: 'justify',
    padding: 13,
  },
  btn: {
    borderRadius: 10,
    padding: 13,
    backgroundColor: '#2FB634',
  },
});

export default HomeScreen;
