import { View, Text, TextInput, TouchableOpacity, StyleSheet, Image } from 'react-native';
export const styles = StyleSheet.create({
    container: {
      flex: 1,
      justifyContent: 'center',
      alignItems: 'center',
    },
    title: {
      fontSize: 24,
      fontWeight: 'bold',
      marginBottom: 20,
    },
    input: {
      width:  300,
      height: 40,
      borderColor: 'gray',
      borderWidth: 1,
      marginBottom: 10,
      paddingHorizontal: 10,
    },
    button: {
      backgroundColor: '#dd5b5e',
      paddingVertical: 7,
      paddingHorizontal: 14,
      borderRadius: 15,
    },
    buttonText: {
      color: 'white',
      fontSize: 15,
      fontWeight: 'bold',
      
    },
    logo: {
      width: 300 ,
      height: 60,
     
      
    },

    header: {
        flex: 2,
        alignContent: 'center',
        justifyContent: 'center',
        backgroundColor: '#fff',
    },
    main: {
        flex: 2,
        alignContent: 'center',
        justifyContent: 'center',
        
    },
    footer: {
        flex: 2,
        alignContent: 'center',
        justifyContent: 'center',
        
    },
    
  });