import { StyleSheet } from 'react-native';  
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
      width: '80%',
      height: 40,
      borderColor: 'gray',
      borderWidth: 1,
      marginBottom: 10,
      paddingHorizontal: 10,
    },
    button: {
      
      backgroundColor: '#dd5b5e',
      paddingVertical: 8,
      paddingHorizontal: 40,
      width: '45%',
      height: 50,
      borderRadius: 40,
    },
    buttonText: {
      color: 'white',
      fontSize: 20,
      textAlign : 'center',
      fontWeight: 'bold',
    },
    logo: {
      width: 300 ,
      height: 40,
      position: 'absolute',
      top: 80,
      
    },
  });
