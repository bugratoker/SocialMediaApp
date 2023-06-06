import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image, Pressable } from 'react-native';
import { styles } from './style.js';


const searchresult = ({ route, navigation }) => {
  const [search, setSearch] = useState('');
  const handleSearch = () => {
    navigation.navigate('SearchPage', {searchText: search });
  }

  return (
    <View style={styles.container}>
      <View style= {styles.header}>
      <View style={{ flexDirection: 'row' }}>
      <TouchableOpacity  onPress={() => navigation.navigate('Main')}>
        <Image
          source={require('../images/sspacelogo.png')}
          style={{ width: 290, height: 70 }}
        />
      </TouchableOpacity> 
      <TouchableOpacity  onPress={() => navigation.navigate('SearchPage')}>
        <Image
          source={require('../images/search.png')}
          style={{ width: 60, height: 70 }}
        />
      </TouchableOpacity> 
      <TouchableOpacity  onPress={() => navigation.navigate('Profile')}>
        <Image
          source={require('../images/profile.png')}
          style={{ width: 60, height: 70 }}
        />
      </TouchableOpacity>  
    </View>
    </View>
     
    <View style={styles.main}>
        <Text>{route.params.searchText}</Text>
    
    </View>
       
    <View style={styles.footer}>
          
    </View>  
    
    </View>
  );
};



export default searchresult;