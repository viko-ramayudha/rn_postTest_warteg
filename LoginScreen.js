import React, { useState } from 'react';
import { View, TextInput, TouchableOpacity, StyleSheet, Alert, Text, Image, ImageBackground } from 'react-native';

const LoginScreen = ({ navigation, registeredUser }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleLogin = () => {
    if (username === '' || password === '') {
      Alert.alert('Error', 'Column harus terisi!');
    } else if (registeredUser && username === registeredUser.username && password === registeredUser.password) {
      Alert.alert('Succes', 'Login berhasil!')
      navigation.replace('Drawer');
    } else {
      Alert.alert('Error', 'Email dan Password salah');
    }
  };

  return (
    <ImageBackground
      source={{ uri: 'https://i.pinimg.com/564x/6e/e6/52/6ee65213c9a020d9084664323c812cba.jpg' }}
      style={styles.background}
    >
      <View style={styles.overlay}>
        <View style={styles.card}>
          <Text style={styles.title}>Login</Text>
          <TextInput style={styles.input} 
            placeholder="Username" 
            value={username} 
            onChangeText={setUsername} 
            placeholderTextColor="#666"/>
          <TextInput style={styles.input} 
            placeholder="Password" 
            secureTextEntry={true} 
            value={password} 
            onChangeText={setPassword} 
            placeholderTextColor="#666"/>
          <TouchableOpacity style={styles.button} onPress={handleLogin}>
            <Text style={styles.buttonText}>Login</Text>
          </TouchableOpacity>
          <TouchableOpacity style={[styles.buttonn, styles.registerButton]} onPress={() => navigation.navigate('Register')}>
            <Text style={styles.buttonText}>Register</Text>
          </TouchableOpacity>
          <Text style={styles.crg}>Copyright ©2024 WartegBahari</Text>
        </View>
      </View>
    </ImageBackground>
  );
};

const styles = StyleSheet.create({
  background: {
    flex: 1,
    resizeMode: 'cover',
    justifyContent: 'center',
  },
  overlay: {
    flex: 1,
    justifyContent: 'center',
    padding: 20,
  },
  card: {
    backgroundColor: 'rgba(0, 0, 0, 0.5)',
    paddingTop: 30,
    paddingLeft: 20,
    paddingRight: 20,
    paddingBottom: 20,
    borderRadius: 10,
  },
  logo: {
    width: 200,
    height: 100,
    marginBottom: 20,
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    color: '#fff',
    marginBottom: 20,
    textAlign: 'center',
  },
  input: {
    width: '100%',
    height: 45,
    borderColor: '#ccc',
    borderWidth: 1,
    marginBottom: 10,
    padding: 10,
    borderRadius: 5,
    backgroundColor: '#fff',
  },
  button: {
    width: '100%',
    padding: 15,
    backgroundColor: '#2FB634',
    borderRadius: 5,
    alignItems: 'center',
    marginBottom: 10,
    marginTop: 20
  },
  buttonn: {
    width: '100%',
    padding: 15,
    backgroundColor: '#2FB634',
    borderRadius: 5,
    alignItems: 'center',
    marginBottom: 10,
    marginTop: 0
  },
  registerButton: {
    backgroundColor: '#ffc107',
  },
  buttonText: {
    color: '#fff',
    fontWeight: '900',
    fontSize: 16
  },
  crg: {
    color: '#fff',
    marginTop: 20,
    textAlign: 'center', // Tambah properti textAlign untuk posisi teks tengah
  },
});

export default LoginScreen;