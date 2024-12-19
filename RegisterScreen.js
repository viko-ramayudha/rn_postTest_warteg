import React, { useState } from 'react';
import { View, TextInput, TouchableOpacity, StyleSheet, Alert, Text, ImageBackground } from 'react-native';

const RegisterScreen = ({ navigation, setRegisteredUser }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

const handleRegister = () => {
    if (username === '' || password === '') {
        Alert.alert('Error', 'Kolom harus terisi!');
    } else {
        setRegisteredUser({ username, password });
        Alert.alert('Success', 'Akun pengguna berhasil dibuat!');
        navigation.navigate('Login');
    }
};

return (
    <ImageBackground
        source={{ uri: 'https://i.pinimg.com/564x/6e/e6/52/6ee65213c9a020d9084664323c812cba.jpg' }}
        style={styles.background}
    >
    <View style={styles.overlay}>
        <View style={styles.card}>
        <Text style={styles.title}>Register</Text>
        <TextInput
            style={styles.input}
            placeholder="Username"
            value={username}
            onChangeText={setUsername}
            autoCapitalize="none"
            placeholderTextColor="#666"
        />
        <TextInput
            style={styles.input}
            placeholder="Password"
            secureTextEntry
            value={password}
            onChangeText={setPassword}
            placeholderTextColor="#666"
        />
        <TouchableOpacity style={styles.button} onPress={handleRegister}>
            <Text style={styles.buttonText}>Register</Text>
        </TouchableOpacity>
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
    backgroundColor: '#ffc107',
    borderRadius: 5,
    alignItems: 'center',
    marginBottom: 10,
    marginTop: 20
},
buttonText: {
    color: '#fff',
    fontWeight: '900',
    fontSize: 16
},
});

export default RegisterScreen;