import React, { useState } from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import { createDrawerNavigator } from '@react-navigation/drawer';
import RegisterScreen from './RegisterScreen';
import LoginScreen from './LoginScreen';
import HomeScreen from './HomeScreen';
import ListMenu from './ListMenu';
import AddMenu from './AddMenu';

const Stack = createStackNavigator();
const Drawer = createDrawerNavigator();

const DrawerNavigator = () => (
  <Drawer.Navigator initialRouteName="Home" screenOptions={{headerTintColor: '#2FB634', headerStyle: { backgroundColor: '#fff', },
          headerTitleStyle: { color: '#2FB634', fontWeight: '900' },}}>
    <Drawer.Screen name="Home" component={HomeScreen} />
    <Drawer.Screen name="Menu" component={ListMenu} />
    <Drawer.Screen  name='Add Menu' component={AddMenu}/>
    <Drawer.Screen name="LogOut" component={LoginScreen} options={{ headerShown: false }} />
  </Drawer.Navigator>
);

const App = () => {
  const [registeredUser, setRegisteredUser] = useState(null);

  return (
    <NavigationContainer>
      <Stack.Navigator initialRouteName="Login" screenOptions={{ headerShown: false }}>
        <Stack.Screen name="Register">
          {props => <RegisterScreen {...props} setRegisteredUser={setRegisteredUser} />}
        </Stack.Screen>
        <Stack.Screen name="Login">
          {props => <LoginScreen {...props} registeredUser={registeredUser} />}
        </Stack.Screen>
        <Stack.Screen name="Drawer" component={DrawerNavigator} />
      </Stack.Navigator>
    </NavigationContainer>
  );
};

export default App;