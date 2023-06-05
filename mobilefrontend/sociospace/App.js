import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image } from 'react-native';
import { styles } from './style.js';
import Icon from 'react-native-vector-icons/FontAwesome';
import { createStackNavigator } from '@react-navigation/stack';

const Stack = createStackNavigator();
const AnaSayfa = ({ navigation }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  return (
    <View style={styles.container}>
      <View style= {styles.header}>
      <View style={{ flexDirection: 'row' }}>
      <Image
        source={require('./images/sspacelogo.png')}
        style={{ width: 290, height: 50 }}
        onPress={() => navigation.navigate('main')}
      />
      <Image
        source={require('./images/search.png')}
        style={{ width: 60, height: 50 }}
      />
      <Image
        source={require('./images/profile.png')}
        style={{ width: 60, height: 50 }}
        onPress={() => navigation.navigate('signin')}
      />
    </View>
      </View>
      <View style={styles.main}>
        
      </View>  
      <View style={styles.footer}>
      </View>  
    
    </View>
  );
};



export default AnaSayfa;